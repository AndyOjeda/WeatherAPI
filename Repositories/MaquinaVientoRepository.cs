using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{
    public interface IMaquinaVientoRepository
    {
        Task<IEnumerable<MaquinaViento>> GetMaquinaVientos();
        Task<MaquinaViento?> GetMaquinaViento(int id);
        Task<MaquinaViento> CreateMaquinaViento(MaquinaViento MaquinaViento);
        Task<MaquinaViento> PutMaquinaViento(MaquinaViento MaquinaViento);
        Task<MaquinaViento?> DeleteMaquinaViento(int id);
    }

    public class MaquinaVientoRepository : IMaquinaVientoRepository
    {
        private readonly AppDbContext _db;
        public MaquinaVientoRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<MaquinaViento?> GetMaquinaViento(int id)
        {
            return await _db.MaquinaViento.FindAsync(id);
        }

        public async Task<IEnumerable<MaquinaViento>> GetMaquinaVientos()
        {
            return await _db.MaquinaViento.ToListAsync();
        }

        public async Task<MaquinaViento> CreateMaquinaViento(MaquinaViento MaquinaViento)
        {
            _db.MaquinaViento.Add(MaquinaViento);
            await _db.SaveChangesAsync();
            return MaquinaViento;
        }

        public async Task<MaquinaViento> PutMaquinaViento(MaquinaViento MaquinaViento)
        {
            _db.Entry(MaquinaViento).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return MaquinaViento;
        }

        public async Task<MaquinaViento?> DeleteMaquinaViento(int id)
        {
            MaquinaViento? MaquinaViento = await _db.MaquinaViento.FindAsync(id);
            if (MaquinaViento == null) return MaquinaViento;
            MaquinaViento.IsActive = false;
            _db.Entry(MaquinaViento).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return MaquinaViento;
        }

    }
}
