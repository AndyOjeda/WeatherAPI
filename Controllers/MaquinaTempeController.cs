using System.ComponentModel.DataAnnotations;
using WeatherAPI.Model;
using WeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinaTempeController(IMaquinaTempeService MaquinaTempeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMaquinaTempes()
        {
            IEnumerable<MaquinaTempe> MaquinaTempes = await MaquinaTempeService.GetMaquinaTempes();
            return Ok(MaquinaTempes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaquinaTempe(int id)
        {
            MaquinaTempe? MaquinaTempe = await MaquinaTempeService.GetMaquinaTempe(id);
            if (MaquinaTempe == null)
            {
                return NotFound();
            }
            return Ok(MaquinaTempe);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaquinaTempe(
            [Required] DateTime Fecha,
            [Required] string Resultado
         )
        {
            var newMaquinaTempe = await MaquinaTempeService.CreateMaquinaTempe(Fecha, Resultado);
            return CreatedAtAction(nameof(GetMaquinaTempe), new { id = newMaquinaTempe.MaquinaTId }, newMaquinaTempe);
        }

        [HttpPut]
        public async Task<IActionResult> PutMaquinaTempe(
            [Required] int MaquinaTId,
            [Required] DateTime Fecha,
            [Required] string Resultado

                       )
        {
            var newMaquinaTempe = await MaquinaTempeService.PutMaquinaTempe(MaquinaTId, Fecha, Resultado);
            return Ok(newMaquinaTempe);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMaquinaTempe(int id)
        {
            var MaquinaTempe = await MaquinaTempeService.DeleteMaquinaTempe(id);
            if (MaquinaTempe == null)
            {
                return NotFound();
            }
            return Ok(MaquinaTempe);
        }
    }

}
