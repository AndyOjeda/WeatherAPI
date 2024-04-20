using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{
    public interface IMedicionRepository
    {
        Task<IEnumerable<Medicion>> GetMedicions();
        Task<Medicion?> GetMedicion(int id);
        Task<Medicion> CreateMedicion(Medicion Medicion);
        Task<Medicion> PutMedicion(Medicion Medicion);
        Task<Medicion?> DeleteMedicion(int id);
    }

    public class MedicionRepository : IMedicionRepository
    {
        private readonly AppDbContext _db;
        public MedicionRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Medicion?> GetMedicion(int id)
        {
            return await _db.Medicion.FindAsync(id);
        }

        public async Task<IEnumerable<Medicion>> GetMedicions()
        {
            return await _db.Medicion.ToListAsync();
        }

        public async Task<Medicion> CreateMedicion(Medicion Medicion)
        {
            _db.Medicion.Add(Medicion);
            await _db.SaveChangesAsync();
            return Medicion;
        }

        public async Task<Medicion> PutMedicion(Medicion Medicion)
        {
            _db.Entry(Medicion).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Medicion;
        }

        public async Task<Medicion?> DeleteMedicion(int id)
        {
            Medicion? Medicion = await _db.Medicion.FindAsync(id);
            if (Medicion == null) return Medicion;
            Medicion.IsActive = false;
            _db.Entry(Medicion).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Medicion;
        }

    }
}
