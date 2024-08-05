using DispenarioMedBCK.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebDispensario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasRegController : ControllerBase
    {
        private readonly IRepositorioFacturareg _repositorioFacturasReg;
        public FacturasRegController(IRepositorioFacturareg repositorioFacturasReg)

        {
            _repositorioFacturasReg = repositorioFacturasReg;
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var lista = await _repositorioFacturasReg.Facturasregs(id);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
