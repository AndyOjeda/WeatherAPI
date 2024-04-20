using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{
    public interface IMaquinaRadiaRepository
    {
        Task<IEnumerable<MaquinaRadia>> GetMaquinaRadias();
        Task<MaquinaRadia?> GetMaquinaRadia(int id);
        Task<MaquinaRadia> CreateMaquinaRadia(MaquinaRadia MaquinaRadia);
        Task<MaquinaRadia> PutMaquinaRadia(MaquinaRadia MaquinaRadia);
        Task<MaquinaRadia?> DeleteMaquinaRadia(int id);
    }

    public class MaquinaRadiaRepository : IMaquinaRadiaRepository
    {
        private readonly AppDbContext _db;
        public MaquinaRadiaRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<MaquinaRadia?> GetMaquinaRadia(int id)
        {
            return await _db.MaquinaRadiacionSolar.FindAsync(id);
        }

        public async Task<IEnumerable<MaquinaRadia>> GetMaquinaRadias()
        {
            return await _db.MaquinaRadiacionSolar.ToListAsync();
        }

        public async Task<MaquinaRadia> CreateMaquinaRadia(MaquinaRadia MaquinaRadia)
        {
            _db.MaquinaRadiacionSolar.Add(MaquinaRadia);
            await _db.SaveChangesAsync();
            return MaquinaRadia;
        }

        public async Task<MaquinaRadia> PutMaquinaRadia(MaquinaRadia MaquinaRadia)
        {
            _db.Entry(MaquinaRadia).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return MaquinaRadia;
        }

        public async Task<MaquinaRadia?> DeleteMaquinaRadia(int id)
        {
            MaquinaRadia? MaquinaRadia = await _db.MaquinaRadiacionSolar.FindAsync(id);
            if (MaquinaRadia == null) return MaquinaRadia;
            MaquinaRadia.IsActive = false;
            _db.Entry(MaquinaRadia).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return MaquinaRadia;
        }

    }
}
