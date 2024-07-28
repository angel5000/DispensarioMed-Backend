using DispenarioMedBCK.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebDispensario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialMedController : ControllerBase
    {
        private readonly IRepositorioHistorialMedico _repositorioHistorialMed;
        public HistorialMedController(IRepositorioHistorialMedico repositorioHistorialMed)

        {
            _repositorioHistorialMed = repositorioHistorialMed;
        }
        [HttpGet]

        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var lista = await _repositorioHistorialMed.HistorialMed(id);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
