using System.ComponentModel.DataAnnotations;
using WeatherAPI.Model;
using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Servicios;


namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstacionController(IEstacionService estacionService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Estacion> estaciones = await estacionService.GetAll();
            return Ok(estaciones);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEstacion(int id)
        {
            Estacion? estacion = await estacionService.GetEstacion(id);
            if (estacion == null)
            {
                return NotFound();
            }
            return Ok(estacion);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstacion(
            [Required] string Nombre,
            [Required] string Ubicacion,
            [Required] string marca,
            [Required] int EstadoId  )
        {
            var newEstacion = await estacionService.CreateEstacion(Nombre, Ubicacion, marca, EstadoId);
            return CreatedAtAction(nameof(GetEstacion), new { id = newEstacion.EstacionId }, newEstacion);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEstacion(int id)
        {
            var estacion = await estacionService.DeleteEstacion(id);
            if (estacion == null)
            {
                return NotFound();
            }
            return Ok(estacion);
        }
    }

}
