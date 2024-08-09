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
        public async Task<IActionResult> RegistrardtPaciente([FromBody] Paciente request)
        {
            if (request == null)
            {
                return BadRequest("Usuario es nulo.");
            }

            var result = await _repositorioRegistrar.RegistrarPaciente(request);

            if (result)
            {
                return Ok( request.IdPaciente);
            }
            else
            {
                return StatusCode(500, "Ocurrió un error al registrar el usuario.");
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioPacienteDto userDto)
        {
            var result = await _repositorioRegistrar.RegistrarUsuariocContra(userDto);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
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
