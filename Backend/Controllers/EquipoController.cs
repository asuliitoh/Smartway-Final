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
    [Route("[controller]")]
    [ApiController]
    public class EquipoController(Context context) : ControllerBase
    {
        private readonly Context _context = context;

        // GET: Equipo
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Equipo>>> GetEquiposByUser()
        {
            //Cogemos el ID del token incluido en la cabecera Authorization
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);
            var equipos = await _context.Equipos.AsNoTracking().Where(e => e.OwnerId == userId
            || (_context.AgenteEquipos.Any(agenteEquipo => agenteEquipo.AgenteId == userId
            && (agenteEquipo.EquipoId == e.Id && agenteEquipo.Estado == EstadoSolicitud.ACEPTADA))))
            .ToListAsync();
            return equipos;
        }

        // GET: Equipo/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Equipo>> GetEquipo(int id)
        {
            
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null) return NotFound();

            //Cogemos el ID del token incluido en la cabecera Authorization
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);
            bool permitido = equipo.OwnerId == userId ||
             _context.AgenteEquipos.Any(agenteEquipo => agenteEquipo.AgenteId == userId &&
              agenteEquipo.EquipoId == id && agenteEquipo.Estado == EstadoSolicitud.ACEPTADA);
            if (!permitido) return Forbid();

            return equipo;
        }

        // PUT: Equipo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutEquipo(int id, Equipo equipo)
        {
            if (id != equipo.Id)
            {
                return BadRequest();
            }

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

            return NoContent();
        }

        // POST: api/Equipo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Equipo>> PostEquipo(EquipoDTO equipoDTO)
        {
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);
            var equipo = new Equipo
            {
                Nombre = equipoDTO.Nombre,
                Especialidad = equipoDTO.Especialidad,
                OwnerId = userId
            };

            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();
            return equipo;
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

        private bool EquipoExists(int id)
        {
            return _context.Equipos.Any(e => e.Id == id);
        }
    }
}
