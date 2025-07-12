using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartwayFinal.Models;

namespace SmartwayFinal.Controllers
{
    //Esta interfaz es declarada para la inserción de dependencias de EquipoController a EstadisticasController.
     public interface IEquipoService
    {
        int GetEquiposFormados();
    } 

    [Route("[controller]")]
    [ApiController]
    public class EquipoController(Context context) : ControllerBase, IEquipoService
    {
        private readonly Context _context = context;

        // GET: Equipo
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<EquipoDTO>>> GetEquiposByUser()
        {
            //Cogemos el ID del token incluido en la cabecera Authorization
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);
            var equipos = await _context.Equipos.AsNoTracking().Include(e => e.Miembros).
            Include(e => e.Operaciones).Where(e => e.OwnerId == userId
            || (_context.AgenteEquipos.Any(agenteEquipo => agenteEquipo.AgenteId == userId
            && (agenteEquipo.EquipoId == e.Id && agenteEquipo.Estado == EstadoSolicitud.ACEPTADA)))).Select( e => NewEquipoDTO(e))
            .ToListAsync();
            return equipos;
        }

        // GET: Equipo/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<EquipoDTO>> GetEquipo(int id)
        {

            var equipo = await _context.Equipos.Include(e => e.Miembros).Include(e => e.Operaciones).FirstOrDefaultAsync(e => e.Id == id);
            if (equipo == null) return NotFound();

            //Cogemos el ID del token incluido en la cabecera Authorization
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);
            bool permitido = equipo.OwnerId == userId ||
             _context.AgenteEquipos.Any(agenteEquipo => agenteEquipo.AgenteId == userId &&
              agenteEquipo.EquipoId == id && agenteEquipo.Estado == EstadoSolicitud.ACEPTADA);
            if (!permitido) return Forbid();

            return NewEquipoDTO(equipo);
        }

        // PUT: Equipo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<EquipoDTO>> PutEquipo(int id, UpdateEquipo update)
        {
            
            if (id != update.Id) return BadRequest();
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null) return NotFound();
            equipo.Nombre = update.Nombre;
            equipo.Especialidad = update.Especialidad;
            _context.Entry(equipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NewEquipoDTO(equipo);
        }

        // PUT: Equipo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/Abandonar")]
        [Authorize]
        public async Task<IActionResult> AbandonarEquipo(int id)
        {
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);

            var agenteEquipo = await _context.AgenteEquipos.
            Where(agenteEquipos => agenteEquipos.AgenteId == userId && agenteEquipos.EquipoId == id).FirstOrDefaultAsync();

            if (agenteEquipo == null) return NotFound();

            _context.AgenteEquipos.Remove(agenteEquipo);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        // POST: api/Equipo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<EquipoDTO>> PostEquipo(CrearEquipo crearEquipo)
        {
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);
            var equipo = new Equipo
            {
                Nombre = crearEquipo.Nombre,
                Especialidad = crearEquipo.Especialidad,
                OwnerId = userId
            };

            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();
            return NewEquipoDTO(equipo);
        }

        // DELETE: api/Equipo/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteEquipo(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }

            //Cogemos el ID del token incluido en la cabecera Authorization
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);

            //Si el ID del Agente actual no es igual al ID del dueño del equipo, no puede borrar el equipo y se devuelve 403.
            if (userId != equipo.OwnerId) return Forbid();

            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [NonAction] 
        public int GetEquiposFormados()
        {
            return _context.Equipos.AsNoTracking().Count();
        }

        private bool EquipoExists(int id)
        {
            return _context.Equipos.Any(e => e.Id == id);
        }

        private static EquipoDTO NewEquipoDTO(Equipo equipo)
        {
                return new EquipoDTO
            {
                Id = equipo.Id,
                Nombre = equipo.Nombre,
                Especialidad = equipo.Especialidad,
                OwnerId = equipo.OwnerId,
                Miembros = [.. equipo.Miembros.Select(a => 
                    new MiembroEquipo{
                        Id = a.Id,
                        Nombre = a.Nombre,
                        Apellidos = a.Apellidos
                    })],

                Operaciones = [.. equipo.Operaciones.Select(o => 
                    new OperacionEquipo{
                        Id = o.Id,
                        Nombre = o.Nombre
                    })]
            };
        }
    }
}
