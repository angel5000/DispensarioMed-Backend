using DispenarioMedBCK.Models;
using DispenarioMedBCK.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DispenarioMedBCK.Repositorio.RepositorioRegistrar;

namespace WebDispensario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrarPacienteController : ControllerBase
    {


        private readonly IRepositorioRegistrar _repositorioRegistrar;

        public RegistrarPacienteController(IRepositorioRegistrar Registrar)
        {
            _repositorioRegistrar = Registrar;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrardtPaciente([FromBody] PacienteCreateDto request)
        {
            if (request == null)
            {
                return BadRequest("Usuario es nulo.");
            }

            var result = await _repositorioRegistrar.RegistrarPaciente(request);

            if (result)
            {
                return Ok(new { message = "Paciente registrado correctamente" });
            }
            else
            {
                return StatusCode(500, "Ocurrió un error al registrar el usuario.");
            }
        }
        [HttpPost("registrarUser")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] RegistrarUsuarioctRequest request)
        {
            if (request == null)
            {
                return BadRequest("Usuario es nulo.");
            }

            var result = await _repositorioRegistrar.RegistrarUsuariocContra(request.UserDt);

            if (result)
            {
                return Ok(new { message = "Usuario registrado correctamente" });
            }
            else
            {
                return StatusCode(500, "Ocurrió un error al registrar el usuario.");
            }
        }

        public class RegistrarUsuarioRequest
        {
          //  public DispenarioMedBCK.Repositorio.RepositorioRegistrar.Paciente Usuario { get; set; }
   
        }
        public class RegistrarUsuarioctRequest
        {
         
            public DispenarioMedBCK.Repositorio.RepositorioRegistrar.UsuariosPacientes UserDt { get; set; }
        }
    }
}
