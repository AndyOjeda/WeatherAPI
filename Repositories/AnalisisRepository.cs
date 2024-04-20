using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{

    public interface IAnalisisRepository
    {
        Task<List<Analisis>> GetAll();
        Task<Analisis?> GetAnalisis(int id);

        Task<Analisis> AddAnalisis(

            DateTime Fecha,
            string ResultadoAnalisis,
            int MedicionId,
            int UserId
        );

        Task<Analisis> UpdateAnalisis(Analisis analisis);
        Task<Analisis?> DeleteAnalisis(int id);

        public class AnalisisRepository : IAnalisisRepository
        {
            private readonly AppDbContext _context;

            public AnalisisRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<List<Analisis>> GetAll()
            {
                return await _context.Analisis.ToListAsync();
            }

            public async Task<Analisis?> GetAnalisis(int id)
            {
                return await _context.Analisis.FindAsync(id);
            }

            public async Task<Analisis> AddAnalisis(
                DateTime Fecha,
                string ResultadoAnalisis,
                int MedicionId,
                int UserId
            )
            {
                Analisis analisis = new Analisis
                {
                    Fecha = Fecha,
                    ResultadoAnalisis = ResultadoAnalisis,
                    MedicionId = MedicionId,
                    UserId = UserId,
                };
                _context.Analisis.Add(analisis);
                await _context.SaveChangesAsync();
                return analisis;
            }

            public async Task<Analisis> UpdateAnalisis(Analisis analisis)
            {
                _context.Entry(analisis).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return analisis;
            }

            public async Task<Analisis?> DeleteAnalisis(int id)
            {
                Analisis? analisis = await _context.Analisis.FindAsync(id);
                if (analisis == null)
                {
                    return null;
                }

                _context.Entry(analisis).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return analisis;
            }
        }
    }
}
