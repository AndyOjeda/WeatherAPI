using System.ComponentModel.DataAnnotations;
using WeatherAPI.Context;
using WeatherAPI.Model;
using WeatherAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Services
{
    public interface IMaquinaHumedadService
    {
        Task<IEnumerable<MaquinaHumedad>> GetMaquinaHumedads();
        Task<MaquinaHumedad?> GetMaquinaHumedad(int id);
        Task<MaquinaHumedad> CreateMaquinaHumedad(
            DateTime Fecha,
            string Resultado
            );
        Task<MaquinaHumedad> PutMaquinaHumedad(
            int MaquinaHId,
            DateTime? Fecha,
            string? Resultado
            );

        Task<MaquinaHumedad?> DeleteMaquinaHumedad(int id);
    }
    public class MaquinaHumedadService(IMaquinaHumedadRepository MaquinaHumedadRepository) : IMaquinaHumedadService
    {
        public async Task<MaquinaHumedad?> GetMaquinaHumedad(int id)
        {
            return await MaquinaHumedadRepository.GetMaquinaHumedad(id);
        }

        public async Task<IEnumerable<MaquinaHumedad>> GetMaquinaHumedads()
        {
            return await MaquinaHumedadRepository.GetMaquinaHumedads();
        }
        public async Task<MaquinaHumedad> CreateMaquinaHumedad(
            DateTime Fecha,
            string Resultado
            )

        {
            return await MaquinaHumedadRepository.CreateMaquinaHumedad(new MaquinaHumedad
            {
                Fecha = Fecha,
                Resultado = Resultado

            });
        }
        public async Task<MaquinaHumedad> PutMaquinaHumedad(
              int MaquinaHId,
              DateTime? Fecha,
              string? Resultado
                )
        {
            MaquinaHumedad? newMaquinaHumedad = await MaquinaHumedadRepository.GetMaquinaHumedad(MaquinaHId);
            if (newMaquinaHumedad == null)
            {
                throw new Exception("MaquinaHumedad no encontrada");
            }
            else
            {
                newMaquinaHumedad.Fecha = Fecha ?? newMaquinaHumedad.Fecha;
                newMaquinaHumedad.Resultado = Resultado ?? newMaquinaHumedad.Resultado;
                return await MaquinaHumedadRepository.PutMaquinaHumedad(newMaquinaHumedad);
            }
        }

        public async Task<MaquinaHumedad?> DeleteMaquinaHumedad(int id)
        {
            return await MaquinaHumedadRepository.DeleteMaquinaHumedad(id);
        }

    }
}

