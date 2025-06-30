using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartwayFinal.Models;
using SmartwayFinal.Services;

namespace SmartwayFinal.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AgentesController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly JWTHandler _jwt;

        public AgentesController(TodoContext context, JWTHandler jwt)
        {
            _context = context;
            _jwt = jwt;
        }


        // GET: api/Agentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agente>>> GetAgentes()
        {
            return await _context.Agentes.ToListAsync();
        }

        // GET: api/Agentes/5
        [HttpGet("{id}")]
        
        public async Task<ActionResult<Agente>> GetAgente(AgenteLoginDTO agenteLoginDTO)
        {
            var agente = await _context.Agentes.FindAsync(agenteLoginDTO.Id);

            if (agente == null) return NotFound();

            else if (!String.Equals(agente.Password, agenteLoginDTO.Password)) return Unauthorized();

            return agente;
        }

        // GET: api/Agentes/login
        [HttpPost("login")]
        public async Task<ActionResult<ResponseAgenteLoginDTO>> Login(AgenteLoginDTO agenteLoginDTO)
        {
            var agente = await _context.Agentes.FindAsync(agenteLoginDTO.Id);

            if (agente == null) return NotFound();

            else if (!String.Equals(agente.Password, agenteLoginDTO.Password)) return Unauthorized();

            string token = _jwt.GenerateToken(agente.Nombre, agente.Apellidos, agente.Id);

            return NewResponseAgenteLoginDTO(agente, token);
        }
        /*
                    // PUT: api/Agentes/5
                    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
                    [HttpPut("{id}")]
                    public async Task<IActionResult> PutAgente(long id, Agente agente)
                    {
                        if (id != agente.Id)
                        {
                            return BadRequest();
                        }

                        _context.Entry(agente).State = EntityState.Modified;

                        try
                        {
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!AgenteExists(id))
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
        // POST: api/Agentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResponseAgenteRegistroDTO>> PostAgente(AgenteRegistroDTO agenteRegistroDTO)
        {

            var agente = new Agente
            {
                Nombre = agenteRegistroDTO.Nombre,
                Apellidos = agenteRegistroDTO.Apellidos,
                Password = agenteRegistroDTO.Password
            };

            _context.Agentes.Add(agente);
            await _context.SaveChangesAsync();

            return NewResponseAgenteRegistroDTO(agente);
        }

        // POST: api/Agentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("registro")]
        public async Task<ActionResult<ResponseAgenteRegistroDTO>> Register(AgenteRegistroDTO agenteRegistroDTO)
        {

            var agente = new Agente
            {
                Nombre = agenteRegistroDTO.Nombre,
                Apellidos = agenteRegistroDTO.Apellidos,
                Password = agenteRegistroDTO.Password
            };

            _context.Agentes.Add(agente);
            await _context.SaveChangesAsync();

            return NewResponseAgenteRegistroDTO(agente);
        }


        // DELETE: api/Agentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgente(long id)
        {
            var agente = await _context.Agentes.FindAsync(id);
            if (agente == null)
            {
                return NotFound();
            }

            _context.Agentes.Remove(agente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    

        private bool AgenteExists(long id)
        {
            return _context.Agentes.Any(e => e.Id == id);
        }

        private ResponseAgenteRegistroDTO NewResponseAgenteRegistroDTO(Agente agente)
        {
            return new ResponseAgenteRegistroDTO
            {
                Id = agente.Id,
                Nombre = agente.Nombre,
                Apellidos = agente.Apellidos
            };
        }

        private ResponseAgenteLoginDTO NewResponseAgenteLoginDTO(Agente agente, string token){
            return new ResponseAgenteLoginDTO
            {
                Id = agente.Id,
                Nombre = agente.Nombre,
                Apellidos = agente.Apellidos,
                Token = token
            };
        }

    }
}
