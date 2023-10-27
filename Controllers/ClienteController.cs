using APIHotel.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIHotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        public IConfiguration configuration;
        private Cliente cliente;
        public ClienteController(IConfiguration configuration)
        {
            this.configuration = configuration;

            cliente = new(this.configuration);
        }
        [Authorize]
        [HttpGet("listar")]
        public IActionResult Listar()
        {

            var respuesta = cliente.Listar();

            return Ok(respuesta);

        }
        [Authorize]
        [HttpGet("listar/{id}")]
        public IActionResult Buscar(int id)
        {

            var respuesta = cliente.Buscar(id);

            return Ok(respuesta);

        }
        [Authorize]
        [HttpGet("buscar/{id}")]
        public IActionResult Buscar(string id)
        {

            var respuesta = cliente.Buscar(id);

            return Ok(respuesta);

        }
        [Authorize]
        [HttpPost("agregar")]
        public IActionResult Agregar([FromBody] JsonElement resultado)
        {
            var respuesta = cliente.Agregar(resultado);

            return Ok(respuesta);

        }
        [Authorize]
        [HttpPut("modificar/{id}")]
        public IActionResult Modificar(int id, [FromBody] JsonElement resultado)
        {
            var respuesta = cliente.Modificar(id, resultado);

            return Ok(respuesta);

        }
    }
}
