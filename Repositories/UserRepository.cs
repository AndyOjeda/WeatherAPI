using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{

    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetUser(int id);
        Task<User> AddUser(
            string UserName,
            int UserAmount
            );
        Task<User> UpdateUser(User User);
        Task<User?> DeleteUser(int id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly FactoryDbContext _context;

        public UserRepository(FactoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.ProductionCapacities.ToListAsync();
        }

        public async Task<User?> GetUser(int id)
        {
            return await _context.ProductionCapacities.FindAsync(id);
        }

        public async Task<User> AddUser(
            string UserName,
            int UserAmount
        )
        {
            User User = new User
            {
                UserName = UserName,
                UserAmount = UserAmount,
                IsDeleted = false
            };
            _context.ProductionCapacities.Add(User);
            await _context.SaveChangesAsync();
            return User;
        }

        public async Task<User> UpdateUser(User User)
        {
            _context.ProductionCapacities.Update(User);
            await _context.SaveChangesAsync();
            return User;
        }

        public async Task<User?> DeleteUser(int id)
        {
            User? User = await _context.ProductionCapacities.FindAsync(id);
            if (User != null)
            {
                User.IsDeleted = true;
                _context.ProductionCapacities.Update(User);
                await _context.SaveChangesAsync();
            }
            return User;
        }
    }
}
