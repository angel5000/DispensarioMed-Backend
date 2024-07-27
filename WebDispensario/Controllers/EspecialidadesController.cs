using DispenarioMedBCK.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebDispensario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly IRepositorioEspecialidad _repositorioEspecialidades;
        public EspecialidadesController(IRepositorioEspecialidad repositorioEspecialidades)

        {
            _repositorioEspecialidades = repositorioEspecialidades;
        }
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {
                var lista = await _repositorioEspecialidades.ObtenerTodos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


    }
}
