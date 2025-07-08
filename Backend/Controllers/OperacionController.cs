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

namespace SmartwayFinal.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OperacionController(Context context) : ControllerBase
    {
        private readonly Context _context = context;

      
        // GET: Operacion/
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Operacion>>> GetOperationsByUser()
        {
            //Cogemos el ID del token incluido en la cabecera Authorization
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);
            
            //Se intenta recuperar el agente asociado a dicha ID. 
            var agente = await _context.Agentes.AsNoTracking().FirstOrDefaultAsync(a => userId == a.Id);
            
            //Si no tiene asociado ninguna entidad Agente, se devuelve código de estado 403
            if (agente == null) return Forbid();
            
            //Se recuperan todos los equipos del agente 
            var equiposId = new HashSet<int>();
            if (agente.OwnerEquiposId != null) equiposId.UnionWith(agente.OwnerEquiposId);
            if (agente.MemberEquiposId != null) equiposId.UnionWith(agente.MemberEquiposId);
            var equipos = await _context.Equipos.AsNoTracking().Where(e => equiposId.Contains(e.Id)).Select(e => e.OperacionesId).ToListAsync();
            
            //Se recuperan todas las operaciones de todos los equipos del agente
            var operacionesIds = equipos.SelectMany(ids => ids).ToList();
            var operaciones = await _context.Operaciones.AsNoTracking().Where(op => operacionesIds.Contains(op.Id)).ToListAsync();
            return operaciones;
        }

           // GET: Operacion/id
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Operacion>> GetOperationByUser(int id)
        {
            //Cogemos el ID del token incluido en la cabecera Authorization
            var userIdToken = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdToken == null) return Forbid();
            int userId = int.Parse(userIdToken!.Value);

            //Se intenta recuperar el agente asociado a dicha ID. 
            var agente = await _context.Agentes.AsNoTracking().FirstOrDefaultAsync(a => userId == a.Id);
            
            //Si no tiene asociado ninguna entidad Agente, se devuelve código de estado 403
            if (agente == null) return Forbid();
            
            //Se recuperan todos los equipos del agente 
            var equiposId = new HashSet<int>();
            if (agente.OwnerEquiposId != null) equiposId.UnionWith(agente.OwnerEquiposId);
            if (agente.MemberEquiposId != null) equiposId.UnionWith(agente.MemberEquiposId);
            bool permitido = await _context.Equipos.AsNoTracking().Where(e => equiposId.Contains(e.Id)).AnyAsync(e => e.OperacionesId.Contains(id));
            if (!permitido) return Forbid();
            return await _context.Operaciones.FindAsync(id);
            
        }

        // POST: api/Operacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Operacion>> PostOperacion(OperacionDTO operacionDTO)
        {
            var operacion = new Operacion
            {
                Nombre = operacionDTO.Nombre,
                Estado = operacionDTO.Estado,
                FechaInicio = operacionDTO.FechaInicio,
                FechaFinal = operacionDTO.FechaFinal
            };

            _context.Operaciones.Add(operacion);
            await _context.SaveChangesAsync();

            return operacion;
        }

        /*
        // PUT: api/Operacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperacion(int id, Operacion operacion)
        {
            if (id != operacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(operacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperacionExists(id))
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
        */


        /*
        // POST: api/Operacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Operacion>> PostOperacion(Operacion operacion)
        {
            _context.Operaciones.Add(operacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperacion", new { id = operacion.Id }, operacion);
        }
        */

        // DELETE: api/Operacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOperacion(long id)
        {
            var operacion = await _context.Operaciones.FindAsync(id);
            if (operacion == null)
            {
                return NotFound();
            }

            _context.Operaciones.Remove(operacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OperacionExists(int id)
        {
            return _context.Operaciones.Any(e => e.Id == id);
        }
    }
}
