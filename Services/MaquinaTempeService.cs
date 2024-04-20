using System.ComponentModel.DataAnnotations;
using WeatherAPI.Context;
using WeatherAPI.Model;
using WeatherAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Services
{
    public interface IMaquinaTempeService
    {
        Task<IEnumerable<MaquinaTempe>> GetMaquinaTempes();
        Task<MaquinaTempe?> GetMaquinaTempe(int id);
        Task<MaquinaTempe> CreateMaquinaTempe(
            DateTime Fecha,
            string Resultado
            );
        Task<MaquinaTempe> PutMaquinaTempe(
            int MaquinaTId,
            DateTime? Fecha,
            string? Resultado
            );

        Task<MaquinaTempe?> DeleteMaquinaTempe(int id);
    }
    public class MaquinaTempeService(IMaquinaTempeRepository MaquinaTempeRepository) : IMaquinaTempeService
    {
        public async Task<MaquinaTempe?> GetMaquinaTempe(int id)
        {
            return await MaquinaTempeRepository.GetMaquinaTempe(id);
        }

        public async Task<IEnumerable<MaquinaTempe>> GetMaquinaTempes()
        {
            return await MaquinaTempeRepository.GetMaquinaTempes();
        }
        public async Task<MaquinaTempe> CreateMaquinaTempe(
            DateTime Fecha,
            string Resultado
            )

        {
            return await MaquinaTempeRepository.CreateMaquinaTempe(new MaquinaTempe
            {
                Fecha = Fecha,
                Resultado = Resultado

            });
        }
        public async Task<MaquinaTempe> PutMaquinaTempe(
              int MaquinaTId,
              DateTime? Fecha,
              string? Resultado
                )
        {
            MaquinaTempe? newMaquinaTempe = await MaquinaTempeRepository.GetMaquinaTempe(MaquinaTId);
            if (newMaquinaTempe == null)
            {
                throw new Exception("MaquinaTempe no encontrada");
            }
            else
            {
                newMaquinaTempe.Fecha = Fecha ?? newMaquinaTempe.Fecha;
                newMaquinaTempe.Resultado = Resultado ?? newMaquinaTempe.Resultado;
                return await MaquinaTempeRepository.PutMaquinaTempe(newMaquinaTempe);
            }
        }

        public async Task<MaquinaTempe?> DeleteMaquinaTempe(int id)
        {
            return await MaquinaTempeRepository.DeleteMaquinaTempe(id);
        }

    }
}

