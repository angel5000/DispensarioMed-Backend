using DispenarioMedBCK.Models;
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
        [HttpPost]
        public async Task<IActionResult> IngresarCitaMedica([FromBody] CitaMedicadto citaDto)
        {
            if (citaDto == null)
            {
                return BadRequest("Los datos de la cita médica no pueden ser nulos.");
            }

            try
            {
                // Mapea el DTO a la entidad CitasMedica
                var citaMedica = MapDtoToCitasMedica(citaDto);

                // Llama al servicio para guardar la cita médica
                var resultado = await _repositorioCitasMedicas.IngresarCitaMedicaAsync(citaMedica);

                if (resultado)
                {
                    return CreatedAtAction(nameof(IngresarCitaMedica), new { id = citaMedica.Idcita }, citaMedica);
                }
                else
                {
                    return StatusCode(500, "Error al ingresar la cita médica.");
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones y logging
                // Logger.LogError(ex, "Error al registrar la cita médica.");
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        private CitasMedica MapDtoToCitasMedica(CitaMedicadto dto)
        {
            return new CitasMedica
            {
                Idpaciente = dto.IdPaciente,
                Idmedico = dto.IdMedico,
                IdhorarioCitas = dto.IdHorarioCitas,
                Motivo = dto.Motivo
            };
        }
    }
}
