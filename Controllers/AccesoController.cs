using APIHotel.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIHotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccesoController : Controller
    {
        private readonly IConfiguration configuration;
        private Acceso Acceso;
        public AccesoController(IConfiguration configuration)
        {
            this.configuration = configuration;

            Acceso = new(this.configuration);
        }

        [HttpPost]
        [Route("acceder")]
        public IActionResult ValidarAcceso([FromBody] JsonElement request)
        {

            (var response, int estatus) = Acceso.ValidarAcceso(request);
            return StatusCode(estatus, response);

        }
    }
}
