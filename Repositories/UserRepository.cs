using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User?> GetUser(int id);
        Task<User> CreateUser(User User);
        Task<User> PutUser(User User);
        Task<User?> DeleteUser(int id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;
        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<User?> GetUser(int id)
        {
            return await _db.User.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _db.User.ToListAsync();
        }

        public async Task<User> CreateUser(User User)
        {
            _db.User.Add(User);
            await _db.SaveChangesAsync();
            return User;
        }

        public async Task<User> PutUser(User User)
        {
            _db.Entry(User).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return User;
        }

        public async Task<User?> DeleteUser(int id)
        {
            User? User = await _db.User.FindAsync(id);
            if (User == null) return User;
            User.IsActive = false;
            _db.Entry(User).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return User;
        }

    }
}
