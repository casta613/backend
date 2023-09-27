using APIHotel.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIHotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgenciaController : Controller
    {
        public IConfiguration configuration;
        private Agencia agencia;
        public AgenciaController(IConfiguration configuration)
        {
            this.configuration = configuration;

            agencia = new(this.configuration);
        }
        [Authorize]
        [HttpGet("listar")]
        public IActionResult Listar()
        {

            var respuesta = agencia.Listar();

            return Ok(respuesta);

        }

        [HttpGet("listar/{id}")]
        public IActionResult Buscar(int id)
        {

            var respuesta = agencia.Buscar(id);

            return Ok(respuesta);

        }

        [HttpPost("agregar")]
        public IActionResult Agregar([FromBody]JsonElement resultado)
        {
            var respuesta = agencia.Agregar(resultado);

            return Ok(respuesta);

        }

        [HttpPut("modificar/{id}")]
        public IActionResult Modificar(int id ,[FromBody] JsonElement resultado)
        {
            var respuesta = agencia.Modificar(id,resultado);

            return Ok(respuesta);

        }
    }
}
