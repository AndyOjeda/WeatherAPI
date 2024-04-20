using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{
    public interface IAnalisisRepository
    {
        Task<IEnumerable<Analisis>> GetAnalisiss();
        Task<Analisis?> GetAnalisis(int id);
        Task<Analisis> CreateAnalisis(Analisis Analisis);
        Task<Analisis> PutAnalisis(Analisis Analisis);
        Task<Analisis?> DeleteAnalisis(int id);
    }

    public class AnalisisRepository : IAnalisisRepository
    {
        private readonly AppDbContext _db;
        public AnalisisRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Analisis?> GetAnalisis(int id)
        {
            return await _db.Analisis.FindAsync(id);
        }

        public async Task<IEnumerable<Analisis>> GetAnalisiss()
        {
            return await _db.Analisis.ToListAsync();
        }

        public async Task<Analisis> CreateAnalisis(Analisis Analisis)
        {
            _db.Analisis.Add(Analisis);
            await _db.SaveChangesAsync();
            return Analisis;
        }

        public async Task<Analisis> PutAnalisis(Analisis Analisis)
        {
            _db.Entry(Analisis).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Analisis;
        }

        public async Task<Analisis?> DeleteAnalisis(int id)
        {
            Analisis? Analisis = await _db.Analisis.FindAsync(id);
            if (Analisis == null) return Analisis;
            Analisis.IsActive = false;
            _db.Entry(Analisis).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Analisis;
        }

    }
}
