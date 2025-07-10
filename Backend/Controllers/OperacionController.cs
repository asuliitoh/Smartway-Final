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

            var operaciones = await _context.Operaciones.AsNoTracking()
            .Where(o => o.CreadorId == userId ||
             (o.EquipoId != null &&
             (o.Equipo.OwnerId ==userId || _context.AgenteEquipos.Any(agenteEquipo => agenteEquipo.AgenteId == userId && agenteEquipo.EquipoId == o.EquipoId))))
             .ToListAsync();
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
            var operacion = await _context.Operaciones.FindAsync(id);
            if (operacion == null) return NotFound();
            bool permitido = operacion.CreadorId == userId || operacion.EquipoId != null && (operacion.Equipo.OwnerId == userId || _context.AgenteEquipos.Any(agenteEquipo => agenteEquipo.AgenteId == userId && agenteEquipo.EquipoId == operacion.EquipoId));
            if (!permitido) return Forbid();
            return operacion;
            
            
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
