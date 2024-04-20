using System.ComponentModel.DataAnnotations;
using WeatherAPI.Model;
using WeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinaRadiaController(IMaquinaRadiaService MaquinaRadiaService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMaquinaRadias()
        {
            IEnumerable<MaquinaRadia> MaquinaRadias = await MaquinaRadiaService.GetMaquinaRadias();
            return Ok(MaquinaRadias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaquinaRadia(int id)
        {
            MaquinaRadia? MaquinaRadia = await MaquinaRadiaService.GetMaquinaRadia(id);
            if (MaquinaRadia == null)
            {
                return NotFound();
            }
            return Ok(MaquinaRadia);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaquinaRadia(
            [Required] DateTime Fecha,
            [Required] string Resultado
         )
        {
            var newMaquinaRadia = await MaquinaRadiaService.CreateMaquinaRadia(Fecha, Resultado);
            return CreatedAtAction(nameof(GetMaquinaRadia), new { id = newMaquinaRadia.MaquinaRId }, newMaquinaRadia);
        }

        [HttpPut]
        public async Task<IActionResult> PutMaquinaRadia(
            [Required] int MaquinaRId,
            [Required] DateTime Fecha,
            [Required] string Resultado

                       )
        {
            var newMaquinaRadia = await MaquinaRadiaService.PutMaquinaRadia(MaquinaRId, Fecha, Resultado);
            return Ok(newMaquinaRadia);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMaquinaRadia(int id)
        {
            var MaquinaRadia = await MaquinaRadiaService.DeleteMaquinaRadia(id);
            if (MaquinaRadia == null)
            {
                return NotFound();
            }
            return Ok(MaquinaRadia);
        }
    }

}
