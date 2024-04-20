using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace factoryApi.Repositories
{

    public interface IMedicionRepository
    {
        Task<List<Medicion>> GetAll();
        Task<Medicion?> GetMedicion(int id);
        Task<Medicion> AddMedicion(
            string MedicionName,
            int MedicionAmount
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
            string MedicionName,
            int MedicionAmount
        )
        {
            Medicion Medicion = new Medicion
            {
                MedicionName = MedicionName,
                MedicionAmount = MedicionAmount,
                IsDeleted = false
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
                Medicion.IsDeleted = true;
                _context.Medicion.Update(Medicion);
                await _context.SaveChangesAsync();
            }
            return Medicion;
        }
    }
}
