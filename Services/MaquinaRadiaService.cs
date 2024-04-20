using System.ComponentModel.DataAnnotations;
using WeatherAPI.Context;
using WeatherAPI.Model;
using WeatherAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Services
{
    public interface IMaquinaRadiaService
    {
        Task<IEnumerable<MaquinaRadia>> GetMaquinaRadias();
        Task<MaquinaRadia?> GetMaquinaRadia(int id);
        Task<MaquinaRadia> CreateMaquinaRadia(
            DateTime Fecha,
            string Resultado
            );
        Task<MaquinaRadia> PutMaquinaRadia(
            int MaquinaRId,
            DateTime? Fecha,
            string? Resultado
            );

        Task<MaquinaRadia?> DeleteMaquinaRadia(int id);
    }
    public class MaquinaRadiaService(IMaquinaRadiaRepository MaquinaRadiaRepository) : IMaquinaRadiaService
    {
        public async Task<MaquinaRadia?> GetMaquinaRadia(int id)
        {
            return await MaquinaRadiaRepository.GetMaquinaRadia(id);
        }

        public async Task<IEnumerable<MaquinaRadia>> GetMaquinaRadias()
        {
            return await MaquinaRadiaRepository.GetMaquinaRadias();
        }
        public async Task<MaquinaRadia> CreateMaquinaRadia(
            DateTime Fecha,
            string Resultado
            )

        {
            return await MaquinaRadiaRepository.CreateMaquinaRadia(new MaquinaRadia
            {
                Fecha = Fecha,
                Resultado = Resultado

            });
        }
        public async Task<MaquinaRadia> PutMaquinaRadia(
              int MaquinaRId,
              DateTime? Fecha,
              string? Resultado
                )
        {
            MaquinaRadia? newMaquinaRadia = await MaquinaRadiaRepository.GetMaquinaRadia(MaquinaRId);
            if (newMaquinaRadia == null)
            {
                throw new Exception("MaquinaRadia no encontrada");
            }
            else
            {
                newMaquinaRadia.Fecha = Fecha ?? newMaquinaRadia.Fecha;
                newMaquinaRadia.Resultado = Resultado ?? newMaquinaRadia.Resultado;
                return await MaquinaRadiaRepository.PutMaquinaRadia(newMaquinaRadia);
            }
        }

        public async Task<MaquinaRadia?> DeleteMaquinaRadia(int id)
        {
            return await MaquinaRadiaRepository.DeleteMaquinaRadia(id);
        }

    }
}

