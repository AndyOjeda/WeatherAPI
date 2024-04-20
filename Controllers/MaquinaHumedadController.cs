using System.ComponentModel.DataAnnotations;
using WeatherAPI.Model;
using WeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinaHumedadController(IMaquinaHumedadService MaquinaHumedadService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMaquinaHumedads()
        {
            IEnumerable<MaquinaHumedad> MaquinaHumedads = await MaquinaHumedadService.GetMaquinaHumedads();
            return Ok(MaquinaHumedads);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaquinaHumedad(int id)
        {
            MaquinaHumedad? MaquinaHumedad = await MaquinaHumedadService.GetMaquinaHumedad(id);
            if (MaquinaHumedad == null)
            {
                return NotFound();
            }
            return Ok(MaquinaHumedad);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaquinaHumedad(
            [Required] DateTime Fecha,
            [Required] string Resultado
         )
        {
            var newMaquinaHumedad = await MaquinaHumedadService.CreateMaquinaHumedad(Fecha, Resultado);
            return CreatedAtAction(nameof(GetMaquinaHumedad), new { id = newMaquinaHumedad.MaquinaHId }, newMaquinaHumedad);
        }

        [HttpPut]
        public async Task<IActionResult> PutMaquinaHumedad(
            [Required] int MaquinaHId,
            [Required] DateTime Fecha,
            [Required] string Resultado

                       )
        {
            var newMaquinaHumedad = await MaquinaHumedadService.PutMaquinaHumedad(MaquinaHId, Fecha, Resultado);
            return Ok(newMaquinaHumedad);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMaquinaHumedad(int id)
        {
            var MaquinaHumedad = await MaquinaHumedadService.DeleteMaquinaHumedad(id);
            if (MaquinaHumedad == null)
            {
                return NotFound();
            }
            return Ok(MaquinaHumedad);
        }
    }

}
