using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{
    public interface IMaquinaPrecipiRepository
    {
        Task<IEnumerable<MaquinaPrecipi>> GetMaquinaPrecipis();
        Task<MaquinaPrecipi?> GetMaquinaPrecipi(int id);
        Task<MaquinaPrecipi> CreateMaquinaPrecipi(MaquinaPrecipi MaquinaPrecipi);
        Task<MaquinaPrecipi> PutMaquinaPrecipi(MaquinaPrecipi MaquinaPrecipi);
        Task<MaquinaPrecipi?> DeleteMaquinaPrecipi(int id);
    }

    public class MaquinaPrecipiRepository : IMaquinaPrecipiRepository
    {
        private readonly AppDbContext _db;
        public MaquinaPrecipiRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<MaquinaPrecipi?> GetMaquinaPrecipi(int id)
        {
            return await _db.MaquinaPrecipitacion.FindAsync(id);
        }

        public async Task<IEnumerable<MaquinaPrecipi>> GetMaquinaPrecipis()
        {
            return await _db.MaquinaPrecipitacion.ToListAsync();
        }

        public async Task<MaquinaPrecipi> CreateMaquinaPrecipi(MaquinaPrecipi MaquinaPrecipi)
        {
            _db.MaquinaPrecipitacion.Add(MaquinaPrecipi);
            await _db.SaveChangesAsync();
            return MaquinaPrecipi;
        }

        public async Task<MaquinaPrecipi> PutMaquinaPrecipi(MaquinaPrecipi MaquinaPrecipi)
        {
            _db.Entry(MaquinaPrecipi).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return MaquinaPrecipi;
        }

        public async Task<MaquinaPrecipi?> DeleteMaquinaPrecipi(int id)
        {
            MaquinaPrecipi? MaquinaPrecipi = await _db.MaquinaPrecipitacion.FindAsync(id);
            if (MaquinaPrecipi == null) return MaquinaPrecipi;
            MaquinaPrecipi.IsActive = false;
            _db.Entry(MaquinaPrecipi).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return MaquinaPrecipi;
        }

    }
}
