using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{

    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetUser(int id);
        Task<User> CreateUser(
            string Nombre,
            string Apellido,
            string Correo,
            string Contrasena
            );
        Task<User> UpdateUser(User user);
        Task<User?> DeleteUser(int id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User?> GetUser(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<User> CreateUser(
            string Nombre,
            string Apellido,
            string Correo,
            string Contrasena
        )
        {
            User User = new User
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Correo = Correo,
                Contrasena = Contrasena
            };
            _context.User.Add(User);
            await _context.SaveChangesAsync();
            return User;
        }

        public async Task<User> UpdateUser(User User)
        {
            _context.User.Update(User);
            await _context.SaveChangesAsync();
            return User;
        }

        public async Task<User?> DeleteUser(int id)
        {
            User? User = await _context.User.FindAsync(id);
            if (User != null)
            {
                _context.User.Update(User);
                await _context.SaveChangesAsync();
            }
            return User;
        }
    }
}
