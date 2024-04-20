using System.ComponentModel.DataAnnotations;
using WeatherAPI.Model;
using WeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinaPrecipiController(IMaquinaPrecipiService MaquinaPrecipiService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMaquinaPrecipis()
        {
            IEnumerable<MaquinaPrecipi> MaquinaPrecipis = await MaquinaPrecipiService.GetMaquinaPrecipis();
            return Ok(MaquinaPrecipis);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaquinaPrecipi(int id)
        {
            MaquinaPrecipi? MaquinaPrecipi = await MaquinaPrecipiService.GetMaquinaPrecipi(id);
            if (MaquinaPrecipi == null)
            {
                return NotFound();
            }
            return Ok(MaquinaPrecipi);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaquinaPrecipi(
            [Required] DateTime Fecha,
            [Required] string Resultado
         )
        {
            var newMaquinaPrecipi = await MaquinaPrecipiService.CreateMaquinaPrecipi(Fecha, Resultado);
            return CreatedAtAction(nameof(GetMaquinaPrecipi), new { id = newMaquinaPrecipi.MaquinaPId }, newMaquinaPrecipi);
        }

        [HttpPut]
        public async Task<IActionResult> PutMaquinaPrecipi(
            [Required] int MaquinaPId,
            [Required] DateTime Fecha,
            [Required] string Resultado

                       )
        {
            var newMaquinaPrecipi = await MaquinaPrecipiService.PutMaquinaPrecipi(MaquinaPId, Fecha, Resultado);
            return Ok(newMaquinaPrecipi);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMaquinaPrecipi(int id)
        {
            var MaquinaPrecipi = await MaquinaPrecipiService.DeleteMaquinaPrecipi(id);
            if (MaquinaPrecipi == null)
            {
                return NotFound();
            }
            return Ok(MaquinaPrecipi);
        }
    }

}
