using DispenarioMedBCK.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DispenarioMedBCK.Repositorio.RepositorioCitasMedicas;

namespace WebDispensario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasMedicasController : ControllerBase
    {

        private readonly IRepositorioCitasMedicas _repositorioCitasMedicas;
        public CitasMedicasController(IRepositorioCitasMedicas repositorioCitasMedicas)

        {
            _repositorioCitasMedicas = repositorioCitasMedicas;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CitasMedicas>>> GetCitasMedicasById(int id)
        {
            var citas = await _repositorioCitasMedicas.ObtenerCitasMedicas(id);

            if (citas == null || !citas.Any())
            {
                return NotFound();
            }

            return Ok(citas);
        }

        [HttpPut("reprogramar")]
        public async Task<IActionResult> ReprogramarCita([FromBody] ReprogramarCitaRequest request)
        {
            var result = await _repositorioCitasMedicas.ReprogramarCitaAsync(request.IdPaciente, request.IdHorario, request.IdHorarioAnterior);

            if (result)
            {
                return Ok(new { message = "Cita reprogramada correctamente" });
            }
            else
            {
                return NotFound(new { message = "Cita no encontrada" });
            }
        }
        [HttpDelete("Eliminar")]
        public async Task<IActionResult> CancelarCita([FromBody] CancelarCitas request)
        {
            var result = await _repositorioCitasMedicas.CancelarCitaMedica (request.IdPaciente, request.IdHorario);

            if (result)
            {
                return Ok(new { message = "Cita Cancelada" });
            }
            else
            {
                return NotFound(new { message = "Cita no encontrada" });
            }
        }


        public class ReprogramarCitaRequest
        {
            public int IdPaciente { get; set; }
            public int IdHorario { get; set; }
            public int IdHorarioAnterior { get; set; }
        }
        public class CancelarCitas
        {
            public int IdPaciente { get; set; }
            public int IdHorario { get; set; }
          
        }

    }
}
