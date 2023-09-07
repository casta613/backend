using APIHotel.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIHotel.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ReservaController : Controller
    {
       
            public IConfiguration configuration;
            private Reserva reserva;
            public ReservaController(IConfiguration configuration)
            {
                this.configuration = configuration;

            reserva = new(this.configuration);
            }

            [HttpGet("listar")]
            public IActionResult Listar()
            {

                var respuesta = reserva.Listar();

                return Ok(respuesta);

            }

            [HttpGet("listar/{id}")]
            public IActionResult Buscar(int id)
            {

                var respuesta = reserva.Buscar(id);

                return Ok(respuesta);

            }

            [HttpPost("agregar")]
            public IActionResult Agregar([FromBody] JsonElement resultado)
            {
                var respuesta = reserva.Agregar(resultado);

                return Ok(respuesta);

            }

            [HttpPut("modificar/{id}")]
            public IActionResult Modificar(int id, [FromBody] JsonElement resultado)
            {
                var respuesta = reserva.Modificar(id, resultado);

                return Ok(respuesta);

            }

            [HttpGet("listar/estatus")]
            public IActionResult ListarEstatus()
            {

                var respuesta = reserva.ListarEstatus();

                return Ok(respuesta);

            }

            [HttpGet("buscar/estatus/{id}")]
            public IActionResult BuscarEstatus(int id)
            {

                var respuesta = reserva.BuscarEstatus(id);

                return Ok(respuesta);

            }

            [HttpPost("agregar/estatus")]
            public IActionResult AgregarEstatus([FromBody] JsonElement resultado)
            {
                var respuesta = reserva.AgregarEstatus(resultado);

                return Ok(respuesta);

            }

            [HttpPut("modificar/estatus/{id}")]
            public IActionResult ModificarEstatus(int id, [FromBody] JsonElement resultado)
            {
                var respuesta = reserva.ModificarEstatus(id, resultado);

                return Ok(respuesta);

            }

           
    }
}
