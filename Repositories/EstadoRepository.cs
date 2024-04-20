using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{
    public interface IEstadoRepository
    {
        Task<IEnumerable<Estado>> GetEstados();
        Task<Estado?> GetEstado(int id);
        Task<Estado> CreateEstado(Estado Estado);
        Task<Estado> PutEstado(Estado Estado);
        Task<Estado?> DeleteEstado(int id);
    }

    public class EstadoRepository : IEstadoRepository
    {
        private readonly AppDbContext _db;
        public EstadoRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Estado?> GetEstado(int id)
        {
            return await _db.Estado.FindAsync(id);
        }

        public async Task<IEnumerable<Estado>> GetEstados()
        {
            return await _db.Estado.ToListAsync();
        }

        public async Task<Estado> CreateEstado(Estado Estado)
        {
            _db.Estado.Add(Estado);
            await _db.SaveChangesAsync();
            return Estado;
        }

        public async Task<Estado> PutEstado(Estado Estado)
        {
            _db.Entry(Estado).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Estado;
        }

        public async Task<Estado?> DeleteEstado(int id)
        {
            Estado? Estado = await _db.Estado.FindAsync(id);
            if (Estado == null) return Estado;
            Estado.IsActive = false;
            _db.Entry(Estado).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return Estado;
        }

    }
}
