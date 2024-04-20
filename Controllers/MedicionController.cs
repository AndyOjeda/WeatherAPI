using System.ComponentModel.DataAnnotations;
using WeatherAPI.Model;
using WeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicionController(IMedicionService medicionService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMedicions()
        {
            IEnumerable<Medicion> mediciones = await medicionService.GetMediciones();
            return Ok(mediciones);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMedicion(int id)
        {
            Medicion? medicion = await medicionService.GetMedicion(id);
            if (medicion == null)
            {
                return NotFound();
            }
            return Ok(medicion);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicion(
            [Required] DateTime FechaMedicion,
            [Required] float Temperatura,
            [Required] float Humedad,
            [Required] float Presion,
            [Required] float Precipitacion,
            [Required] float RadiacionSolar,
            [Required] float VelocidadViento,
            [Required] float DireccionViento,
            [Required] int EstacionId
            )
        {
            var newMedicion = await medicionService.CreateMedicion(FechaMedicion, Temperatura, Humedad, Presion, Precipitacion, RadiacionSolar, VelocidadViento, DireccionViento, EstacionId);
            return CreatedAtAction(nameof(GetMedicion), new { id = newMedicion.MedicionId }, newMedicion);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMedicion(int id)
        {
            var medicion = await medicionService.DeleteMedicion(id);
            if (medicion == null)
            {
                return NotFound();
            }
            return Ok(medicion);
        }
    }

}
