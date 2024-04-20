using System.ComponentModel.DataAnnotations;
using WeatherAPI.Model;
using WeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinaDireccionController(IMaquinaDireccionService MaquinaDireccionService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMaquinaDireccions()
        {
            IEnumerable<MaquinaDireccion> MaquinaDireccions = await MaquinaDireccionService.GetMaquinaDireccions();
            return Ok(MaquinaDireccions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaquinaDireccion(int id)
        {
            MaquinaDireccion? MaquinaDireccion = await MaquinaDireccionService.GetMaquinaDireccion(id);
            if (MaquinaDireccion == null)
            {
                return NotFound();
            }
            return Ok(MaquinaDireccion);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaquinaDireccion(
            [Required] DateTime Fecha,
            [Required] string Resultado
         )
        {
            var newMaquinaDireccion = await MaquinaDireccionService.CreateMaquinaDireccion(Fecha, Resultado);
            return CreatedAtAction(nameof(GetMaquinaDireccion), new { id = newMaquinaDireccion.MaquinaDId }, newMaquinaDireccion);
        }

        [HttpPut]
        public async Task<IActionResult> PutMaquinaDireccion(
            [Required] int MaquinaDId,
            [Required] DateTime Fecha,
            [Required] string Resultado

                       )
        {
            var newMaquinaDireccion = await MaquinaDireccionService.PutMaquinaDireccion(MaquinaDId, Fecha, Resultado);
            return Ok(newMaquinaDireccion);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMaquinaDireccion(int id)
        {
            var MaquinaDireccion = await MaquinaDireccionService.DeleteMaquinaDireccion(id);
            if (MaquinaDireccion == null)
            {
                return NotFound();
            }
            return Ok(MaquinaDireccion);
        }
    }

}
