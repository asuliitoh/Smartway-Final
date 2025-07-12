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
    //Esta interfaz es declarada para la inserción de dependencias de AgentesController a EstadisticasController.
    public interface IAgenteService
    {
        int GetAgentesRegistrados();
    } 

    [Route("[controller]")]
    [ApiController]
    public class AgentesController(Context context, JWTHandler jwt) : ControllerBase, IAgenteService
    {
        private readonly Context _context = context;
        private readonly JWTHandler _jwt = jwt;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agente>>> GetAgentes()
        {
            return await _context.Agentes.ToListAsync();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<AgenteDTO>> GetAgente(int Id)
        {
            var agente = await _context.Agentes.FindAsync(Id);

            if (agente == null) return NotFound();

            return NewAgenteDTO(agente);
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest login)
        {
            var agente = await _context.Agentes.FindAsync(login.Id);

            if (agente == null) return NotFound();

            else if (!String.Equals(agente.Password, login.Password)) return Unauthorized();

            string token = _jwt.GenerateToken(agente);

            return NewLoginResponse(agente, token);
        }

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


            _context.Entry(agente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();        
                return NewAgenteDTO(agente);
                
            }
            catch (DbUpdateConcurrencyException) { throw; }
            
        }


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

        [NonAction] 
        public int GetAgentesRegistrados()
        {
            return _context.Agentes.AsNoTracking().Count();
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
                //EquipoId = agente.EquipoId
            };
        }
    }
}
