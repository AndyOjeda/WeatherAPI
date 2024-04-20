using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{
    public interface IEstacionRepository
    {
        Task<IEnumerable<Estacion>> GetEstacions();
        Task<Estacion?> GetEstacion(int id);
        Task<Estacion> CreateEstacion(Estacion Estacion);
        Task<Estacion> PutEstacion(Estacion Estacion);
        Task<Estacion?> DeleteEstacion(int id);
    }

    public class EstacionRepository : IEstacionRepository
    {
        private readonly AppDbContext _db;
        public EstacionRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Estacion?> GetEstacion(int id)
        {
            return await _db.Estacion.FindAsync(id);
        }

        public async Task<IEnumerable<Estacion>> GetEstacions()
        {
            return await _db.Estacion.ToListAsync();
        }

        public async Task<Estacion> CreateEstacion(Estacion Estacion)
        {
            _db.Estacion.Add(Estacion);
            await _db.SaveChangesAsync();
            return Estacion;
        }

        public async Task<Estacion> PutEstacion(Estacion Estacion)
        {
            _db.Entry(Estacion).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Estacion;
        }

        public async Task<Estacion?> DeleteEstacion(int id)
        {
            Estacion? Estacion = await _db.Estacion.FindAsync(id);
            if (Estacion == null) return Estacion;
            Estacion.IsActive = false;
            _db.Entry(Estacion).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Estacion;
        }

    }
}
