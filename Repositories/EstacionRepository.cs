using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{

    public interface IEstacionRepository
    {
        Task<List<Estacion>> GetAll();
        Task<Estacion?> GetEstacion(int id);
        Task<Estacion> AddEstacion(
            string EstacionName,
            int EstacionAmount
            );
        Task<Estacion> UpdateEstacion(Estacion Estacion);
        Task<Estacion?> DeleteEstacion(int id);
    }

    public class EstacionRepository : IEstacionRepository
    {
        private readonly AppDbContext _context;

        public EstacionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Estacion>> GetAll()
        {
            return await _context.Estacion.ToListAsync();
        }

        public async Task<Estacion?> GetEstacion(int id)
        {
            return await _context.Estacion.FindAsync(id);
        }

        public async Task<Estacion> AddEstacion(
            string EstacionName,
            int EstacionAmount
        )
        {
            Estacion Estacion = new Estacion
            {
                Nombre = Nombre,
                Ubicacion = Ubicacion,
                marca = marca,
                EstadoId = EstadoId,
                IsDeleted = false
            };
            _context.Estacion.Add(Estacion);
            await _context.SaveChangesAsync();
            return Estacion;
        }

        public async Task<Estacion> UpdateEstacion(Estacion Estacion)
        {
            _context.Estacion.Update(Estacion);
            await _context.SaveChangesAsync();
            return Estacion;
        }

        public async Task<Estacion?> DeleteEstacion(int id)
        {
            Estacion? Estacion = await _context.Estacion.FindAsync(id);
            if (Estacion != null)
            {
                Estacion.IsDeleted = true;
                _context.Estacion.Update(Estacion);
                await _context.SaveChangesAsync();
            }
            return Estacion;
        }
    }
}
