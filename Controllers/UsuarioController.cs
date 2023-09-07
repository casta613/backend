using APIHotel.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIHotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        public IConfiguration configuration;
        private Usuario usuario;
        public UsuarioController(IConfiguration configuration)
        {
            this.configuration = configuration;

            usuario = new(this.configuration);
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {

            var respuesta = usuario.Listar();

            return Ok(respuesta);

        }

        [HttpGet("listar/{id}")]
        public IActionResult Buscar(int id)
        {

            var respuesta = usuario.Buscar(id);

            return Ok(respuesta);

        }

        [HttpPost("agregar")]
        public IActionResult Agregar([FromBody] JsonElement resultado)
        {
            var respuesta = usuario.Agregar(resultado);

            return Ok(respuesta);

        }

        [HttpPut("modificar/{id}")]
        public IActionResult Modificar(int id, [FromBody] JsonElement resultado)
        {
            var respuesta = usuario.Modificar(id, resultado);

            return Ok(respuesta);

        }

        [HttpGet("rol/listar")]
        public IActionResult ListarRol()
        {

            var respuesta = usuario.ListarRol();

            return Ok(respuesta);

        }

        [HttpGet("rol/buscar/{id}")]
        public IActionResult BuscarRol(int id)
        {

            var respuesta = usuario.BuscarRol(id);

            return Ok(respuesta);

        }

        [HttpPost("rol/agregar")]
        public IActionResult AgregarRol([FromBody] JsonElement resultado)
        {
            var respuesta = usuario.AgregarRol(resultado);

            return Ok(respuesta);

        }

        [HttpPut("rol/modificar/{id}")]
        public IActionResult ModificarRol(int id, [FromBody] JsonElement resultado)
        {
            var respuesta = usuario.ModificarRol(id, resultado);

            return Ok(respuesta);

        }
    }
}
