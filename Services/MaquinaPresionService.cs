using System.ComponentModel.DataAnnotations;
using WeatherAPI.Context;
using WeatherAPI.Model;
using WeatherAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Services
{
    public interface IMaquinaPresionService
    {
        Task<IEnumerable<MaquinaPresion>> GetMaquinaPresions();
        Task<MaquinaPresion?> GetMaquinaPresion(int id);
        Task<MaquinaPresion> CreateMaquinaPresion(
            DateTime Fecha,
            string Resultado
            );
        Task<MaquinaPresion> PutMaquinaPresion(
            int MaquinaPreId,
            DateTime? Fecha,
            string? Resultado
            );

        Task<MaquinaPresion?> DeleteMaquinaPresion(int id);
    }
    public class MaquinaPresionService(IMaquinaPresionRepository MaquinaPresionRepository) : IMaquinaPresionService
    {
        public async Task<MaquinaPresion?> GetMaquinaPresion(int id)
        {
            return await MaquinaPresionRepository.GetMaquinaPresion(id);
        }

        public async Task<IEnumerable<MaquinaPresion>> GetMaquinaPresions()
        {
            return await MaquinaPresionRepository.GetMaquinaPresions();
        }
        public async Task<MaquinaPresion> CreateMaquinaPresion(
            DateTime Fecha,
            string Resultado
            )

        {
            return await MaquinaPresionRepository.CreateMaquinaPresion(new MaquinaPresion
            {
                Fecha = Fecha,
                Resultado = Resultado

            });
        }
        public async Task<MaquinaPresion> PutMaquinaPresion(
              int MaquinaPreId,
              DateTime? Fecha,
              string? Resultado
                )
        {
            MaquinaPresion? newMaquinaPresion = await MaquinaPresionRepository.GetMaquinaPresion(MaquinaPreId);
            if (newMaquinaPresion == null)
            {
                throw new Exception("MaquinaPresion no encontrada");
            }
            else
            {
                newMaquinaPresion.Fecha = Fecha ?? newMaquinaPresion.Fecha;
                newMaquinaPresion.Resultado = Resultado ?? newMaquinaPresion.Resultado;
                return await MaquinaPresionRepository.PutMaquinaPresion(newMaquinaPresion);
            }
        }

        public async Task<MaquinaPresion?> DeleteMaquinaPresion(int id)
        {
            return await MaquinaPresionRepository.DeleteMaquinaPresion(id);
        }

    }
}

