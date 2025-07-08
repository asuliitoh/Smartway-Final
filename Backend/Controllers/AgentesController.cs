using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartwayFinal.Models;
using SmartwayFinal.Services;

namespace SmartwayFinal.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AgentesController(Context context, JWTHandler jwt) : ControllerBase
    {
        private readonly Context _context = context;
        private readonly JWTHandler _jwt = jwt;


        // GET: api/Agentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agente>>> GetAgentes()
        {
            return await _context.Agentes.ToListAsync();
        }

        // GET: api/Agentes/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<AgenteDTO>> GetAgente(int Id)
        {
            var agente = await _context.Agentes.FindAsync(Id);

            if (agente == null) return NotFound();

            return NewAgenteDTO(agente);
        }
        

        // GET: api/Agentes/login
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest login)
        {
            var agente = await _context.Agentes.FindAsync(login.Id);

            if (agente == null) return NotFound();

            else if (!String.Equals(agente.Password, login.Password)) return Unauthorized();

            string token = _jwt.GenerateToken(agente.Nombre!, agente.Apellidos!, agente.Id);

            return NewLoginResponse(agente, token);
        }

        // PUT: api/Agentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<AgenteDTO>> UpdateAgente(string id, AgenteDTO update)
        {
            if (! (update.Id.ToString() == id)) return BadRequest();
            var agente = await _context.Agentes.FindAsync(update.Id);
            if (agente == null) return NotFound();

            agente.Nombre = update.Nombre;
            agente.Apellidos = update.Apellidos;
            agente.Rango = update.Rango;
            agente.Activo = update.Activo;
            agente.EquipoId = update.EquipoId;

            _context.Entry(agente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();        
                return NewAgenteDTO(agente);
                
            }
            catch (DbUpdateConcurrencyException) { throw; }
            
        }

        
        // PUT: api/Agentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}/password")]
        [Authorize]
        public async Task<ActionResult<AgenteDTO>> UpdatePasswordAgente(string id, PasswordRequest update)
        {
            if (!string.Equals(id, update.Id)) return BadRequest();
            var agente = await _context.Agentes.FindAsync(update.Id);
            if (agente == null) return NotFound();

            if (!String.Equals(agente.Password, update.Password) || !String.Equals(update.NewPassword, update.ConfirmPassword)) return Unauthorized();

            agente.Password = update.NewPassword;

            _context.Entry(agente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                Console.WriteLine(agente.Password);
                return Ok();
                
            }
            catch (DbUpdateConcurrencyException) { throw; }
            
        }


        /*                
        // POST: api/Agentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegistroResponse>> PostAgente(RegistroResponse agenteRegistroDTO)
        {

            var agente = new Agente
            {
                Nombre = agenteRegistroDTO.Nombre,
                Apellidos = agenteRegistroDTO.Apellidos,
               
            };

            _context.Agentes.Add(agente);
            await _context.SaveChangesAsync();

            return NewRegistroResponse(agente);
        }

        */

        // POST: api/Agentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("registro")]
        public async Task<ActionResult<RegistroResponse>> Register(RegistroRequest registro)
        {

            var agente = new Agente
            {
                Nombre = registro.Nombre,
                Apellidos = registro.Apellidos,
                Password = registro.Password
            };

            _context.Agentes.Add(agente);
            await _context.SaveChangesAsync();

            return NewRegistroResponse(agente);
        }

        /*
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

        */

        private bool AgenteExists(int id)
        {
            return _context.Agentes.Any(e => e.Id == id);
        }

        private static RegistroResponse NewRegistroResponse(Agente agente)
        {
            return new RegistroResponse
            {
                Id = agente.Id!,
                Nombre = agente.Nombre,
                Apellidos = agente.Apellidos
            };
        }

        private static LoginResponse NewLoginResponse(Agente agente, string token)
        {
            return new LoginResponse
            {
                Id = agente.Id,
                Nombre = agente.Nombre,
                Apellidos = agente.Apellidos,
                Token = token
            };
        }

        private static AgenteDTO NewAgenteDTO(Agente agente)
        {
            return new AgenteDTO
            {
                Id = agente.Id!,
                Nombre = agente.Nombre,
                Apellidos = agente.Apellidos,
                Rango = agente.Rango,
                Activo = agente.Activo,
                EquipoId = agente.EquipoId
            };
        }
    }
}
