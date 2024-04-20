using System.ComponentModel.DataAnnotations;
using WeatherAPI.Model;
using WeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalisisController(IAnalisisService analisisService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAnalisis()
        {
            IEnumerable<Analisis> analises = await analisisService.GetAnalisis();
            return Ok(analises);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnalisis(int id)
        {
            Analisis? analisis = await analisisService.GetAnalisis(id);
            if (analisis == null)
            {
                return NotFound();
            }
            return Ok(analisis);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnalisis(
            [Required] DateTime Fecha,
            [Required] string ResultadoAnalisis,
            [Required] int MedicionId,
            [Required] int UserId
         )
        {
            var newAnalisis = await analisisService.CreateAnalisis(Fecha, ResultadoAnalisis, MedicionId, UserId);
            return CreatedAtAction(nameof(GetAnalisis), new { id = newAnalisis.AnalisisId }, newAnalisis);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAnalisis(int id)
        {
            var Analisis = await analisisService.DeleteAnalisis(id);
            if (Analisis == null)
            {
                return NotFound();
            }
            return Ok(Analisis);
        }
    }

}
