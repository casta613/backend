using APIHotel.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIHotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadoController : Controller
    {
        public IConfiguration configuration;
        private Empleado empleado;
        public EmpleadoController(IConfiguration configuration)
        {
            this.configuration = configuration;

            empleado = new(this.configuration);
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {

            var respuesta = empleado.Listar();

            return Ok(respuesta);

        }

        [HttpGet("listar/{id}")]
        public IActionResult Buscar(int id)
        {

            var respuesta = empleado.Buscar(id);

            return Ok(respuesta);

        }

        [HttpPost("agregar")]
        public IActionResult Agregar([FromBody] JsonElement resultado)
        {
            var respuesta = empleado.Agregar(resultado);

            return Ok(respuesta);

        }

        [HttpPut("modificar/{id}")]
        public IActionResult Modificar(int id, [FromBody] JsonElement resultado)
        {
            var respuesta = empleado.Modificar(id, resultado);

            return Ok(respuesta);

        }

        [HttpGet("puesto/listar")]
        public IActionResult ListarPuesto()
        {

            var respuesta = empleado.ListarPuesto();

            return Ok(respuesta);

        }

        [HttpGet("puesto/buscar/{id}")]
        public IActionResult BuscarPuesto(int id)
        {

            var respuesta = empleado.BuscarPuesto(id);

            return Ok(respuesta);

        }

        [HttpPost("puesto/agregar")]
        public IActionResult AgregarPuesto([FromBody] JsonElement resultado)
        {
            var respuesta = empleado.AgregarPuesto(resultado);

            return Ok(respuesta);

        }

        [HttpPut("puesto/modificar/{id}")]
        public IActionResult ModificarPuesto(int id, [FromBody] JsonElement resultado)
        {
            var respuesta = empleado.ModificarPuesto(id, resultado);

            return Ok(respuesta);

        }
    }
}
