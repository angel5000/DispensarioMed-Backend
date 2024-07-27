﻿using DispenarioMedBCK.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebDispensario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendasMedController : ControllerBase
    {

        private readonly IRepositorioAgenda _repositorioAgendas;
        public AgendasMedController(IRepositorioAgenda repositorioAgendas)

        {
            _repositorioAgendas = repositorioAgendas;
        }
        [HttpGet]

        public async Task<IActionResult> Get(string sector, string especialidad)
        {
            try
            {
                var lista = await _repositorioAgendas.ObtenerDisponible( sector,  especialidad);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
