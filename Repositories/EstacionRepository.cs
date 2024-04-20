using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;

namespace WeatherAPI.Repositories
{

    public interface IEstacionRepository
    {
        Task<List<Estacion>> GetAll();
        Task<Estacion?> GetEstacion(int id);
        Task<Estacion> CreateEstacion(
            string Nombre,
            string Ubicacion,
            string marca,
            int EstadoId
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

        public async Task<Estacion> CreateEstacion(
                string Nombre,
                string Ubicacion,
                string marca,
                int EstadoId
                )
        {
            Estacion Estacion = new Estacion
            {
                Nombre = Nombre,
                Ubicacion = Ubicacion,
                marca = marca,
                EstadoId = EstadoId,
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
                _context.Estacion.Update(Estacion);
                await _context.SaveChangesAsync();
            }
            return Estacion;
        }
    }
}
