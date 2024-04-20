using System.ComponentModel.DataAnnotations;
using WeatherAPI.Model;
using WeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicionController(IMedicionService MedicionService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMedicions()
        {
            IEnumerable<Medicion> Medicions = await MedicionService.GetMedicions();
            return Ok(Medicions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicion(int id)
        {
            Medicion? Medicion = await MedicionService.GetMedicion(id);
            if (Medicion == null)
            {
                return NotFound();
            }
            return Ok(Medicion);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicion(
            [Required] DateTime FechaMedicion,
            [Required] int TemperaturaId,
            [Required] int HumedadId,
            [Required] int PresionId,
            [Required] int PrecipitacionId,
            [Required] int RadiacionSolarId,
            [Required] int VelocidadVientoId,
            [Required] int DireccionVientoId

         )
        {
            var newMedicion = await MedicionService.CreateMedicion(FechaMedicion, TemperaturaId, HumedadId, PresionId, PrecipitacionId, RadiacionSolarId, VelocidadVientoId, DireccionVientoId);
            return CreatedAtAction(nameof(GetMedicion), new { id = newMedicion.MedicionId }, newMedicion);
        }

        [HttpPut]
        public async Task<IActionResult> PutMedicion(
            [Required] int MedicionId,
            [Required] DateTime FechaMedicion,
            [Required] int TemperaturaId,
            [Required] int HumedadId,
            [Required] int PresionId,
            [Required] int PrecipitacionId,
            [Required] int RadiacionSolarId,
            [Required] int VelocidadVientoId,
            [Required] int DireccionVientoId

                       )
        {
            var newMedicion = await MedicionService.PutMedicion(MedicionId, FechaMedicion, TemperaturaId, HumedadId, PresionId, PrecipitacionId, RadiacionSolarId, VelocidadVientoId, DireccionVientoId);
            return Ok(newMedicion);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMedicion(int id)
        {
            var Medicion = await MedicionService.DeleteMedicion(id);
            if (Medicion == null)
            {
                return NotFound();
            }
            return Ok(Medicion);
        }
    }

}
