using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{

    public interface IMedicionRepository
    {
        Task<List<Medicion>> GetAll();
        Task<Medicion?> GetMedicion(int id);
        Task<Medicion> AddMedicion(
            DateTime FechaMedicion,
            float Temperatura,
            float Humedad,
            float Presion,
            float Precipitacion,
            float RadiacionSolar,
            float VelocidadViento,
            float DireccionViento,
            int EstacionId
            );
        Task<Medicion> UpdateMedicion(Medicion Medicion);
        Task<Medicion?> DeleteMedicion(int id);
    }

    public class MedicionRepository : IMedicionRepository
    {
        private readonly AppDbContext _context;

        public MedicionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Medicion>> GetAll()
        {
            return await _context.Medicion.ToListAsync();
        }

        public async Task<Medicion?> GetMedicion(int id)
        {
            return await _context.Medicion.FindAsync(id);
        }

        public async Task<Medicion> AddMedicion(
            float Temperatura,
            float Humedad,
            float Presion,
            float Precipitacion,
            float RadiacionSolar,
            float VelocidadViento,
            float DireccionViento,
            int EstacionId
        )
        {
            Medicion Medicion = new Medicion
            {
                Temperatura = Temperatura,
                Humedad = Humedad,
                Presion = Presion,
                Precipitacion = Precipitacion,
                RadiacionSolar = RadiacionSolar,
                VelocidadViento = VelocidadViento,
                DireccionViento = DireccionViento,
                EstacionId = EstacionId

            };
            _context.Medicion.Add(Medicion);
            await _context.SaveChangesAsync();
            return Medicion;
        }

        public async Task<Medicion> UpdateMedicion(Medicion Medicion)
        {
            _context.Medicion.Update(Medicion);
            await _context.SaveChangesAsync();
            return Medicion;
        }

        public async Task<Medicion?> DeleteMedicion(int id)
        {
            Medicion? Medicion = await _context.Medicion.FindAsync(id);
            if (Medicion != null)
            {
                _context.Medicion.Update(Medicion);
                await _context.SaveChangesAsync();
            }
            return Medicion;
        }
    }
}
