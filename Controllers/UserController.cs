using System.ComponentModel.DataAnnotations;
using WeatherAPI.Model;
using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Servicios;

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<User> users = await userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            User? user = await userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(User);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(
            [Required] string Nombre,
            [Required] string Apellido,
            [Required] string Correo,
            [Required] string Contrasena
            )
        {
            var newUser = await userService.CreateUser(Nombre, Apellido, Correo, Contrasena);
            return CreatedAtAction(nameof(GetUser), new { id = newUser.UserId }, newUser);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await userService.DeleteUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }

}
