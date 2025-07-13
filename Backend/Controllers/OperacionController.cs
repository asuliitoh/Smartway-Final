using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartwayFinal.Models;
using System.Security.Claims;
using SmartwayFinal.Controllers;
using NuGet.Protocol.Plugins;

namespace SmartwayFinal.Controllers
{

    //Esta interfaz es declarada para la inserción de dependencias de OperacionController a EstadisticasController.
    public interface IOperacionService
    {
        int GetOperacionesCompletadas();
    }

    [Route("[controller]")]
    [ApiController]
    public class OperacionController(Context context) : ControllerBase, IOperacionService
    {
        private readonly Context _context = context;

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<OperacionDTO>>> GetOperationsByUser()
        {
            //Cogemos el ID del token incluido en la cabecera Authorization
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);

            var operaciones = await _context.Operaciones.AsNoTracking()
            .Where(o => o.CreadorId == userId ||
             (o.EquipoId != null &&
             (o.Equipo.OwnerId == userId || _context.AgenteEquipos.Any(agenteEquipo => agenteEquipo.AgenteId == userId && agenteEquipo.EquipoId == o.EquipoId))))
             .Select(o => NewOperacionDTO(o)).ToListAsync();
            return operaciones;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<OperacionDTO>> GetOperationByUser(int id)
        {
            //Cogemos el ID del token incluido en la cabecera Authorization
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);
            var operacion = await _context.Operaciones.FindAsync(id);
            if (operacion == null) return NotFound();
            bool permitido = operacion.CreadorId == userId || operacion.EquipoId != null && (operacion.Equipo.OwnerId == userId || _context.AgenteEquipos.Any(agenteEquipo => agenteEquipo.AgenteId == userId && agenteEquipo.EquipoId == operacion.EquipoId));
            if (!permitido) return Forbid();
            return NewOperacionDTO(operacion);


        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<OperacionDTO>> PostOperacion(CrearOperacion crear)
        {
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);
            var operacion = new Operacion
            {
                Nombre = crear.Nombre,
                Estado = crear.Estado,
                FechaInicio = crear.FechaInicio,
                FechaFinal = crear.FechaFinal,
                CreadorId = userId

            };

            _context.Operaciones.Add(operacion);
            await _context.SaveChangesAsync();

            return NewOperacionDTO(operacion);
        }

        [HttpPut("{id}/AsignarEquipo/{equipoId}")]
        [Authorize]
        public async Task<ActionResult<OperacionDTO>> AsignarEquipo(int id, int equipoId)
        {
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);

            //Comprobación de que la operación existe y no tiene equipo asignado.
            var operacion = await _context.Operaciones.FindAsync(id);
            if (operacion == null) return NotFound();
            if (operacion.EquipoId != null) return Forbid();

            //Comprobación de que el equipo existe y el agente actual sea el dueño.
            var equipo = await _context.Equipos.FindAsync(equipoId);
            Console.WriteLine("operacion no era null");
            Console.WriteLine(equipoId);
            if (equipo == null) return NotFound();
            Console.WriteLine("equipo no era null");
            if (equipo.OwnerId != userId) return Forbid();

            operacion.EquipoId = equipoId;

            _context.Entry(operacion).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
                return NewOperacionDTO(operacion);
                
            }
            catch (DbUpdateConcurrencyException) { throw; }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteOperacion(int id)
        {
            var operacion = await _context.Operaciones.FindAsync(id);
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);
            if (operacion == null) return NotFound();
            bool permitido = (operacion.EquipoId == null && operacion.CreadorId == userId) || (operacion.EquipoId != null && operacion.Equipo.OwnerId == userId);
            if (!permitido) return Forbid();
            _context.Operaciones.Remove(operacion);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [NonAction]
        public int GetOperacionesCompletadas()
        {
            return _context.Operaciones.AsNoTracking().Where(o => o.Estado == EstadoOperacion.COMPLETADO).Count();
        }


        private static OperacionDTO NewOperacionDTO(Operacion operacion)
        {
            return new OperacionDTO
            {
                Id = operacion.Id,
                Nombre = operacion.Nombre,
                Estado = operacion.Estado,
                FechaInicio = operacion.FechaInicio,
                FechaFinal = operacion.FechaFinal,
                EquipoId = operacion.EquipoId
            };
        }
        
    }
}
