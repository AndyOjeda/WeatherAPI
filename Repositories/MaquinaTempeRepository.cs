using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{
    public interface IMaquinaTempeRepository
    {
        Task<IEnumerable<MaquinaTempe>> GetMaquinaTempes();
        Task<MaquinaTempe?> GetMaquinaTempe(int id);
        Task<MaquinaTempe> CreateMaquinaTempe(MaquinaTempe MaquinaTempe);
        Task<MaquinaTempe> PutMaquinaTempe(MaquinaTempe MaquinaTempe);
        Task<MaquinaTempe?> DeleteMaquinaTempe(int id);
    }

    public class MaquinaTempeRepository : IMaquinaTempeRepository
    {
        private readonly AppDbContext _db;
        public MaquinaTempeRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<MaquinaTempe?> GetMaquinaTempe(int id)
        {
            return await _db.MaquinaTemperatura.FindAsync(id);
        }

        public async Task<IEnumerable<MaquinaTempe>> GetMaquinaTempes()
        {
            return await _db.MaquinaTemperatura.ToListAsync();
        }

        public async Task<MaquinaTempe> CreateMaquinaTempe(MaquinaTempe MaquinaTempe)
        {
            _db.MaquinaTemperatura.Add(MaquinaTempe);
            await _db.SaveChangesAsync();
            return MaquinaTempe;
        }

        public async Task<MaquinaTempe> PutMaquinaTempe(MaquinaTempe MaquinaTempe)
        {
            _db.Entry(MaquinaTempe).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return MaquinaTempe;
        }

        public async Task<MaquinaTempe?> DeleteMaquinaTempe(int id)
        {
            MaquinaTempe? MaquinaTempe = await _db.MaquinaTemperatura.FindAsync(id);
            if (MaquinaTempe == null) return MaquinaTempe;
            MaquinaTempe.IsActive = false;
            _db.Entry(MaquinaTempe).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return MaquinaTempe;
        }

    }
}
