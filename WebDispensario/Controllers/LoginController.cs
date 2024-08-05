using DispenarioMedBCK.Repositorio;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebDispensario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly RepositorioLogin _repositorioLogin;

        public LoginController(RepositorioLogin repositorioLogin)
        {
            _repositorioLogin = repositorioLogin;
        }
        [HttpPut("actualizar-contrasena")]
        public IActionResult ActualizarContrasena([FromBody] ActualizarContrasenaRequest request)
        {
            if (request.UserId <= 0 || string.IsNullOrEmpty(request.NuevaContrasena))
            {
                return BadRequest("ID de usuario o nueva contraseña inválidos.");
            }

            bool actualizado = _repositorioLogin.ActualizarContrasena(request.UserId, request.NuevaContrasena);

            if (!actualizado)
            {
                return NotFound("Usuario no encontrado.");
            }

            return Ok("Contraseña actualizada exitosamente.");
        }
        public class ActualizarContrasenaRequest
        {
            public int UserId { get; set; }
            public string NuevaContrasena { get; set; }
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var userId = _repositorioLogin.Login(request.Usuario, request.Contrasena);

            if (userId == null)
            {
                return Unauthorized("Usuario o contraseña incorrecta.");
            }

            return Ok(new { Message = "Login exitoso", IdUsuario = userId });
        }
        public class LoginRequest
        {
            public string Usuario { get; set; }
            public string Contrasena { get; set; }
        }

    }
}
