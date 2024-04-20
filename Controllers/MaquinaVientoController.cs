using System.ComponentModel.DataAnnotations;
using WeatherAPI.Model;
using WeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinaVientoController(IMaquinaVientoService MaquinaVientoService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMaquinaVientos()
        {
            IEnumerable<MaquinaViento> MaquinaVientos = await MaquinaVientoService.GetMaquinaVientos();
            return Ok(MaquinaVientos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaquinaViento(int id)
        {
            MaquinaViento? MaquinaViento = await MaquinaVientoService.GetMaquinaViento(id);
            if (MaquinaViento == null)
            {
                return NotFound();
            }
            return Ok(MaquinaViento);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaquinaViento(
            [Required] DateTime Fecha,
            [Required] string Resultado
         )
        {
            var newMaquinaViento = await MaquinaVientoService.CreateMaquinaViento(Fecha, Resultado);
            return CreatedAtAction(nameof(GetMaquinaViento), new { id = newMaquinaViento.MaquinaVId }, newMaquinaViento);
        }

        [HttpPut]
        public async Task<IActionResult> PutMaquinaViento(
            [Required] int MaquinaVId,
            [Required] DateTime Fecha,
            [Required] string Resultado

                       )
        {
            var newMaquinaViento = await MaquinaVientoService.PutMaquinaViento(MaquinaVId, Fecha, Resultado);
            return Ok(newMaquinaViento);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMaquinaViento(int id)
        {
            var MaquinaViento = await MaquinaVientoService.DeleteMaquinaViento(id);
            if (MaquinaViento == null)
            {
                return NotFound();
            }
            return Ok(MaquinaViento);
        }
    }

}
