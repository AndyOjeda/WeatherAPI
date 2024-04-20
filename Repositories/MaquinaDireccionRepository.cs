using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{
    public interface IMaquinaDireccionRepository
    {
        Task<IEnumerable<MaquinaDireccion>> GetMaquinaDireccions();
        Task<MaquinaDireccion?> GetMaquinaDireccion(int id);
        Task<MaquinaDireccion> CreateMaquinaDireccion(MaquinaDireccion MaquinaDireccion);
        Task<MaquinaDireccion> PutMaquinaDireccion(MaquinaDireccion MaquinaDireccion);
        Task<MaquinaDireccion?> DeleteMaquinaDireccion(int id);
    }

    public class MaquinaDireccionRepository : IMaquinaDireccionRepository
    {
        private readonly AppDbContext _db;
        public MaquinaDireccionRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<MaquinaDireccion?> GetMaquinaDireccion(int id)
        {
            return await _db.MaquinaDireccion.FindAsync(id);
        }

        public async Task<IEnumerable<MaquinaDireccion>> GetMaquinaDireccions()
        {
            return await _db.MaquinaDireccion.ToListAsync();
        }

        public async Task<MaquinaDireccion> CreateMaquinaDireccion(MaquinaDireccion MaquinaDireccion)
        {
            _db.MaquinaDireccion.Add(MaquinaDireccion);
            await _db.SaveChangesAsync();
            return MaquinaDireccion;
        }

        public async Task<MaquinaDireccion> PutMaquinaDireccion(MaquinaDireccion MaquinaDireccion)
        {
            _db.Entry(MaquinaDireccion).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return MaquinaDireccion;
        }

        public async Task<MaquinaDireccion?> DeleteMaquinaDireccion(int id)
        {
            MaquinaDireccion? MaquinaDireccion = await _db.MaquinaDireccion.FindAsync(id);
            if (MaquinaDireccion == null) return MaquinaDireccion;
            MaquinaDireccion.IsActive = false;
            _db.Entry(MaquinaDireccion).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return MaquinaDireccion;
        }

    }
}
