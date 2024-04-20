using System.ComponentModel.DataAnnotations;
using WeatherAPI.Model;
using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Servicios;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController(IEstadoService estadoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Estado> estados = await estadoService.GetAll();
            return Ok(estados);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEstado(int id)
        {
            Estado? estado = await estadoService.GetEstado(id);
            if (estado == null)
            {
                return NotFound();
            }
            return Ok(estado);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstado(
            [Required] string EstadoActual
            )
        {
            var newEstado = await estadoService.CreateEstado(EstadoActual);
            return CreatedAtAction(nameof(GetEstado), new { id = newEstado.EstadoId }, newEstado);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            var estado = await estadoService.DeleteEstado(id);
            if (estado == null)
            {
                return NotFound();
            }
            return Ok(estado);
        }
    }

}
