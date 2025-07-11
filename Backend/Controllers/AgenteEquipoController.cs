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
    [Route("SolicitudEquipo")]
    [ApiController]
    public class AgenteEquipoController(Context context) : ControllerBase
    {
        private readonly Context _context = context;

        // GET: api/AgenteEquipo
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<SolicitudPendiente>>> GetSolicitudesByUser()
        {
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);

            return await _context.AgenteEquipos.Where(agenteEquipo => agenteEquipo.AgenteId == userId
            && agenteEquipo.Estado == EstadoSolicitud.PENDIENTE).Select(agenteEquipo =>
            new SolicitudPendiente
            {
                EquipoId = agenteEquipo.EquipoId,
                Nombre = agenteEquipo.Equipo.Nombre
                
            }).ToListAsync();
        }

        [HttpPut("Aceptar")]
        [Authorize]
        public async Task<IActionResult> AceptarSolicitud(SolicitudPendiente agenteEquipoDTO)
        {
             /*El agente solo puede enviar una solicitud a otro agente si este es el dueño
            del equipo*/
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);
            
            var agenteEquipo = await _context.AgenteEquipos.FindAsync(userId, agenteEquipoDTO.EquipoId);
            if (agenteEquipo == null) return NotFound();

            if (agenteEquipo.AgenteId != userId) return Forbid();

            agenteEquipo.Estado = EstadoSolicitud.ACEPTADA;

            _context.Entry(agenteEquipo).State = EntityState.Modified;


            try {
                await _context.SaveChangesAsync();
                 return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            
        }

        [HttpPut("Rechazar")]
         [Authorize]
        public async Task<IActionResult> RechazarSolicitud(SolicitudPendiente agenteEquipoDTO)
        {

            /*El agente solo puede enviar una solicitud a otro agente si este es el dueño
           del equipo*/
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);

            var agenteEquipo = await _context.AgenteEquipos.FindAsync(userId, agenteEquipoDTO.EquipoId);
            if (agenteEquipo == null) return NotFound();

            if (agenteEquipo.AgenteId != userId) return Forbid();

            _context.AgenteEquipos.Remove(agenteEquipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("Enviar")]
        [Authorize]
        public async Task<ActionResult<AgenteEquipo>> EnviarSolicitud(EnviarSolicitud agenteEquipoDTO)
        {
            /*El agente solo puede enviar una solicitud a otro agente si este es el dueño
            del equipo*/
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);

            var agente = await _context.Agentes.AsNoTracking().Where(a => a.Id == userId && a.OwnerEquipos.Any(e => e.Id == agenteEquipoDTO.EquipoId)).FirstOrDefaultAsync();

            if (agente == null) return Forbid();
            else if (userId == agenteEquipoDTO.AgenteId) return BadRequest();
            var agenteEquipo = new AgenteEquipo
            {
                AgenteId = agenteEquipoDTO.AgenteId,
                EquipoId = agenteEquipoDTO.EquipoId,
                Estado = EstadoSolicitud.PENDIENTE
            };

            _context.AgenteEquipos.Add(agenteEquipo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                if (AgenteEquipoExists(agenteEquipo.AgenteId, agenteEquipo.EquipoId)) return Conflict();
                else { throw; }
                
            }

            return NoContent();
        }

        private bool AgenteEquipoExists(int AgenteId, int EquipoId)
        {
            return _context.AgenteEquipos.Any(e => e.AgenteId == AgenteId && e.EquipoId == EquipoId);
        }
    }
}
