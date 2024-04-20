using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{
    public interface IMaquinaPresionRepository
    {
        Task<IEnumerable<MaquinaPresion>> GetMaquinaPresions();
        Task<MaquinaPresion?> GetMaquinaPresion(int id);
        Task<MaquinaPresion> CreateMaquinaPresion(MaquinaPresion MaquinaPresion);
        Task<MaquinaPresion> PutMaquinaPresion(MaquinaPresion MaquinaPresion);
        Task<MaquinaPresion?> DeleteMaquinaPresion(int id);
    }

    public class MaquinaPresionRepository : IMaquinaPresionRepository
    {
        private readonly AppDbContext _db;
        public MaquinaPresionRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<MaquinaPresion?> GetMaquinaPresion(int id)
        {
            return await _db.MaquinaPresion.FindAsync(id);
        }

        public async Task<IEnumerable<MaquinaPresion>> GetMaquinaPresions()
        {
            return await _db.MaquinaPresion.ToListAsync();
        }

        public async Task<MaquinaPresion> CreateMaquinaPresion(MaquinaPresion MaquinaPresion)
        {
            _db.MaquinaPresion.Add(MaquinaPresion);
            await _db.SaveChangesAsync();
            return MaquinaPresion;
        }

        public async Task<MaquinaPresion> PutMaquinaPresion(MaquinaPresion MaquinaPresion)
        {
            _db.Entry(MaquinaPresion).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return MaquinaPresion;
        }

        public async Task<MaquinaPresion?> DeleteMaquinaPresion(int id)
        {
            MaquinaPresion? MaquinaPresion = await _db.MaquinaPresion.FindAsync(id);
            if (MaquinaPresion == null) return MaquinaPresion;
            MaquinaPresion.IsActive = false;
            _db.Entry(MaquinaPresion).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return MaquinaPresion;
        }

    }
}
