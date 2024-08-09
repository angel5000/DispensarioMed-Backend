using DispenarioMedBCK.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static DispenarioMedBCK.Repositorio.RepositorioUsuarios;

namespace WebDispensario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IRepositorioUsuarios _repositorioUsuarios;
        public UsuariosController(IRepositorioUsuarios repositorioUsuarios)

        {
            _repositorioUsuarios = repositorioUsuarios;
        }

       

        [HttpGet("usuarios-pacientes")]
        public async Task<IActionResult> ObtenerTodosUsuariosPacientes()
        {
            var usuariosPacientes = await _repositorioUsuarios.ObtenerTodosUsuariosPacientesAsync();
            return Ok(usuariosPacientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerUsuarioPacientePorId(int id)
        {
            try
            {
                var usuario = await _repositorioUsuarios.ObtenerUsuarioPacientePorIdAsync(id);
                if (usuario == null)
                {
                    return NotFound(new { message = "Usuario no encontrado." });
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, new { message = "Error al obtener el usuario.", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] ActualizarUsuarioPacienteDto usuarioDto)
        {
            if (usuarioDto == null)
            {
                return BadRequest("Datos del usuario no proporcionados.");
            }

            // Verifica que el id coincida con el id en el DTO si es necesario
           
            
            var resultado = await _repositorioUsuarios.ActualizarEstadoUsuarioPacienteAsync(id, usuarioDto);


            if (resultado)
            {
                return NoContent(); // Devuelve un código de estado 204 (No Content) para indicar éxito
            }
            else
            {
                return NotFound("Usuario no encontrado.");
            }
        }

      

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarUsuarioPaciente(int id)
        {
            try
            {
                // Llama al servicio para cambiar el estado del usuario
                await _repositorioUsuarios.EliminarUsuarioPacienteAsync(id);
                return Ok(new { message = "Usuario cambiado a estado Eliminado." });
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return StatusCode(500, new { message = "Error al cambiar el estado del usuario.", error = ex.Message });
            }
        }


        /// <summary>
        /// /////////
        /// </summary>
        /// <returns></returns>
        /// 

        [HttpGet("med-usuarios")]
        public async Task<IActionResult> ObtenerTodosMedUsuarios()
        {
            var medUsuarios = await _repositorioUsuarios.ObtenerTodosMedUsuariosAsync();
            return Ok(medUsuarios);
        }

    }
}
