using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartwayFinal.Models;

namespace SmartwayFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionController : ControllerBase
    {
        private readonly Context _context;

        public OperacionController(Context context)
        {
            _context = context;
        }

        // GET: api/Operacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operacion>>> GetOperaciones()
        {
            return await _context.Operaciones.ToListAsync();
        }

        // GET: api/Operacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operacion>> GetOperacion(long id)
        {
            var operacion = await _context.Operaciones.FindAsync(id);

            if (operacion == null)
            {
                return NotFound();
            }

            return operacion;
        }

        // PUT: api/Operacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperacion(string id, Operacion operacion)
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

        // POST: api/Operacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Operacion>> PostOperacion(Operacion operacion)
        {
            _context.Operaciones.Add(operacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperacion", new { id = operacion.Id }, operacion);
        }

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

        private bool OperacionExists(string id)
        {
            return _context.Operaciones.Any(e => e.Id == id);
        }
    }
}
