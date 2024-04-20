using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{
    public interface IMaquinaHumedadRepository
    {
        Task<IEnumerable<MaquinaHumedad>> GetMaquinaHumedads();
        Task<MaquinaHumedad?> GetMaquinaHumedad(int id);
        Task<MaquinaHumedad> CreateMaquinaHumedad(MaquinaHumedad MaquinaHumedad);
        Task<MaquinaHumedad> PutMaquinaHumedad(MaquinaHumedad MaquinaHumedad);
        Task<MaquinaHumedad?> DeleteMaquinaHumedad(int id);
    }

    public class MaquinaHumedadRepository : IMaquinaHumedadRepository
    {
        private readonly AppDbContext _db;
        public MaquinaHumedadRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<MaquinaHumedad?> GetMaquinaHumedad(int id)
        {
            return await _db.MaquinaHumedad.FindAsync(id);
        }

        public async Task<IEnumerable<MaquinaHumedad>> GetMaquinaHumedads()
        {
            return await _db.MaquinaHumedad.ToListAsync();
        }

        public async Task<MaquinaHumedad> CreateMaquinaHumedad(MaquinaHumedad MaquinaHumedad)
        {
            _db.MaquinaHumedad.Add(MaquinaHumedad);
            await _db.SaveChangesAsync();
            return MaquinaHumedad;
        }

        public async Task<MaquinaHumedad> PutMaquinaHumedad(MaquinaHumedad MaquinaHumedad)
        {
            _db.Entry(MaquinaHumedad).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return MaquinaHumedad;
        }

        public async Task<MaquinaHumedad?> DeleteMaquinaHumedad(int id)
        {
            MaquinaHumedad? MaquinaHumedad = await _db.MaquinaHumedad.FindAsync(id);
            if (MaquinaHumedad == null) return MaquinaHumedad;
            MaquinaHumedad.IsActive = false;
            _db.Entry(MaquinaHumedad).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return MaquinaHumedad;
        }

    }
}
