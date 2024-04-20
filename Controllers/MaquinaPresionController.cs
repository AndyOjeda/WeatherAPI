using System.ComponentModel.DataAnnotations;
using WeatherAPI.Model;
using WeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinaPresionController(IMaquinaPresionService MaquinaPresionService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMaquinaPresions()
        {
            IEnumerable<MaquinaPresion> MaquinaPresions = await MaquinaPresionService.GetMaquinaPresions();
            return Ok(MaquinaPresions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaquinaPresion(int id)
        {
            MaquinaPresion? MaquinaPresion = await MaquinaPresionService.GetMaquinaPresion(id);
            if (MaquinaPresion == null)
            {
                return NotFound();
            }
            return Ok(MaquinaPresion);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaquinaPresion(
            [Required] DateTime Fecha,
            [Required] string Resultado
         )
        {
            var newMaquinaPresion = await MaquinaPresionService.CreateMaquinaPresion(Fecha, Resultado);
            return CreatedAtAction(nameof(GetMaquinaPresion), new { id = newMaquinaPresion.MaquinaPreId }, newMaquinaPresion);
        }

        [HttpPut]
        public async Task<IActionResult> PutMaquinaPresion(
            [Required] int MaquinaPreId,
            [Required] DateTime Fecha,
            [Required] string Resultado

                       )
        {
            var newMaquinaPresion = await MaquinaPresionService.PutMaquinaPresion(MaquinaPreId, Fecha, Resultado);
            return Ok(newMaquinaPresion);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMaquinaPresion(int id)
        {
            var MaquinaPresion = await MaquinaPresionService.DeleteMaquinaPresion(id);
            if (MaquinaPresion == null)
            {
                return NotFound();
            }
            return Ok(MaquinaPresion);
        }
    }

}
