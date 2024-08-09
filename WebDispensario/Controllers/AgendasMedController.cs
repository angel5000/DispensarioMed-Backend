using DispenarioMedBCK.Repositorio;
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

        [HttpGet("{idHorario}")]
        public async Task<IActionResult> GetHorario(int idHorario)
        {
            // Llama al servicio para obtener el horario por IdHorario
            var horario = await _repositorioAgendas.ObtenerHorarioPorIdAsync(idHorario);

            if (horario == null)
            {
                return NotFound(); // Devuelve 404 si el horario no se encuentra
            }

            return Ok(horario); // Devuelve 200 y el objeto HorarioCitaDTO si se encuentra
        }


    }
}
