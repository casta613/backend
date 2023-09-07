using APIHotel.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIHotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HabitacionController : Controller
    {
        public IConfiguration configuration;
        private Habitacion habitacion;
        public HabitacionController(IConfiguration configuration)
        {
            this.configuration = configuration;

            habitacion = new(this.configuration);
        }

        [HttpGet("listar")]
        public IActionResult Listar()
        {

            var respuesta = habitacion.Listar();

            return Ok(respuesta);

        }

        [HttpGet("listar/{id}")]
        public IActionResult Buscar(int id)
        {

            var respuesta = habitacion.Buscar(id);

            return Ok(respuesta);

        }

        [HttpPost("agregar")]
        public IActionResult Agregar([FromBody] JsonElement resultado)
        {
            var respuesta = habitacion.Agregar(resultado);

            return Ok(respuesta);

        }

        [HttpPut("modificar/{id}")]
        public IActionResult Modificar(int id, [FromBody] JsonElement resultado)
        {
            var respuesta = habitacion.Modificar(id, resultado);

            return Ok(respuesta);

        }

        [HttpGet("listar/estatus")]
        public IActionResult ListarEstatus()
        {

            var respuesta = habitacion.ListarEstatus();

            return Ok(respuesta);

        }

        [HttpGet("buscar/estatus/{id}")]
        public IActionResult BuscarEstatus(int id)
        {

            var respuesta = habitacion.BuscarEstatus(id);

            return Ok(respuesta);

        }

        [HttpPost("agregar/estatus")]
        public IActionResult AgregarEstatus([FromBody] JsonElement resultado)
        {
            var respuesta = habitacion.AgregarEstatus(resultado);

            return Ok(respuesta);

        }

        [HttpPut("modificar/estatus/{id}")]
        public IActionResult ModificarEstatus(int id, [FromBody] JsonElement resultado)
        {
            var respuesta = habitacion.ModificarEstatus(id, resultado);

            return Ok(respuesta);

        }

        [HttpGet("listar/tipo")]
        public IActionResult ListarTipo()
        {

            var respuesta = habitacion.ListarTipo();

            return Ok(respuesta);

        }

        [HttpGet("buscar/tipo/{id}")]
        public IActionResult BuscarTipo(int id)
        {

            var respuesta = habitacion.BuscarTipo(id);

            return Ok(respuesta);

        }

        [HttpPost("agregar/tipo")]
        public IActionResult AgregarTipo([FromBody] JsonElement resultado)
        {
            var respuesta = habitacion.AgregarTipo(resultado);

            return Ok(respuesta);

        }

        [HttpPut("modificar/tipo/{id}")]
        public IActionResult ModificarTipo(int id, [FromBody] JsonElement resultado)
        {
            var respuesta = habitacion.ModificarTipo(id, resultado);

            return Ok(respuesta);

        }
    }
}
