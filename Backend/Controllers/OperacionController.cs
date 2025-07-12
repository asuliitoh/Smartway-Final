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
        public async Task<ActionResult<IEnumerable<Operacion>>> GetOperationsByUser()
        {
            //Cogemos el ID del token incluido en la cabecera Authorization
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);

            var operaciones = await _context.Operaciones.AsNoTracking()
            .Where(o => o.CreadorId == userId ||
             (o.EquipoId != null &&
             (o.Equipo.OwnerId == userId || _context.AgenteEquipos.Any(agenteEquipo => agenteEquipo.AgenteId == userId && agenteEquipo.EquipoId == o.EquipoId))))
             .ToListAsync();
            return operaciones;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Operacion>> GetOperationByUser(int id)
        {
            //Cogemos el ID del token incluido en la cabecera Authorization
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);
            var operacion = await _context.Operaciones.FindAsync(id);
            if (operacion == null) return NotFound();
            bool permitido = operacion.CreadorId == userId || operacion.EquipoId != null && (operacion.Equipo.OwnerId == userId || _context.AgenteEquipos.Any(agenteEquipo => agenteEquipo.AgenteId == userId && agenteEquipo.EquipoId == operacion.EquipoId));
            if (!permitido) return Forbid();
            return operacion;


        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Operacion>> PostOperacion(OperacionDTO operacionDTO)
        {
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);
            var operacion = new Operacion
            {
                Nombre = operacionDTO.Nombre,
                Estado = operacionDTO.Estado,
                FechaInicio = operacionDTO.FechaInicio,
                FechaFinal = operacionDTO.FechaFinal,
                CreadorId = userId

            };

            _context.Operaciones.Add(operacion);
            await _context.SaveChangesAsync();

            return operacion;
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

    }
}
