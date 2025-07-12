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
    [Route("Estadisticas")]
    [ApiController]
    public class EstadisticasController(IAgenteService agentesController, IEquipoService equipoController, IOperacionService operacionController) : ControllerBase

    {
        
        private readonly IAgenteService _agentesController = agentesController;
        private readonly IEquipoService _equipoController = equipoController;
        private readonly IOperacionService _operacionController = operacionController;

        [HttpGet]
        public ActionResult<EstadisticasGenerales> GetEstadisticas()
        {
            var estadisticas = new EstadisticasGenerales
            {
                AgentesRegistrados = _agentesController.GetAgentesRegistrados(),
                EquiposFormados = _equipoController.GetEquiposFormados(),
                OperacionesCompletadas = _operacionController.GetOperacionesCompletadas()
            };

            return estadisticas;
        }


    }
}