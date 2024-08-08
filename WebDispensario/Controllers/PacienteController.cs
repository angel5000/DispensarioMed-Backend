using DispenarioMedBCK.Models;
using DispenarioMedBCK.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebDispensario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IRepositorioPaciente _repositorioPaciente;
        public PacienteController(IRepositorioPaciente repositorioPaciente)

        {
            _repositorioPaciente = repositorioPaciente;
        }
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                var lista = await _repositorioPaciente.ObtenerTodos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetID(int id)
        {
            try
            {
                var lista = await _repositorioPaciente.PacienteID(id);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Paciente pacienteActualizado)
        {
            try
            {
                var pacienteModificado = await _repositorioPaciente.ModificarPaciente(id, pacienteActualizado);
                return Ok(pacienteModificado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        /*  [HttpPut("{id}")]
          public async Task<IActionResult> Update(int id, [FromBody] Paciente pacienteActualizado)
          {
              try
              {
                  var pacienteModificado = await _repositorioPaciente.ModificarPaciente(id, pacienteActualizado);
                  return Ok(pacienteModificado);
              }
              catch (Exception ex)
              {
                  return BadRequest(ex.ToString());
              }
          }*/
    }
}
