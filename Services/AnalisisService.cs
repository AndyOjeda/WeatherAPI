using System.ComponentModel.DataAnnotations;
using WeatherAPI.Context;
using WeatherAPI.Model;
using WeatherAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CORNWAY.Services
{
    public interface IAnalisisService
    {
        Task<IEnumerable<Analisis>> GetAnalisiss();
        Task<Analisis?> GetAnalisis(int id);
        Task<Analisis> CreateAnalisis(
            DateTime Fecha,
            string ResultadoAnalisis,
            int MedicionId,
            int UserId     
            );
        Task<Analisis> PutAnalisis(
            DateTime? Fecha,
            string? ResultadoAnalisis,
            int? MedicionId,
            int? UserId);

        Task<Analisis?> DeleteAnalisis(int id);
    }
    public class AnalisisService(IAnalisisRepository AnalisisRepository) : IAnalisisService
    {
        public async Task<Analisis?> GetAnalisis(int id)
        {
            return await AnalisisRepository.GetAnalisis(id);
        }

        public async Task<IEnumerable<Analisis>> GetAnalisiss()
        {
            return await AnalisisRepository.GetAnalisiss();
        }
        public async Task<Analisis> CreateAnalisis(
            DateTime Fecha,
            string ResultadoAnalisis,
            int MedicionId,
            int UserId
            )

        {
            return await AnalisisRepository.CreateAnalisis(new Analisis
            {
                Fecha = Fecha,
                ResultadoAnalisis = ResultadoAnalisis,
                MedicionId = MedicionId,
                UserId = UserId   

            });
        }
        public async Task<Analisis> PutAnalisis(
              int AnalisisId,
              DateTime? Fecha,
              string? ResultadoAnalisis,
              int? MedicionId,
              int? UserId
              )

        {
            Analisis? newAnalisis = await AnalisisRepository.GetAnalisis(AnalisisId);
            if (newAnalisis == null)
            {
                throw new Exception("Analisis no encontrada");
            }
            else
            {
                newAnalisis.Fecha = Fecha ?? newAnalisis.Fecha;
                newAnalisis.ResultadoAnalisis = ResultadoAnalisis ?? newAnalisis.ResultadoAnalisis;
                newAnalisis.MedicionId = MedicionId ?? newAnalisis.MedicionId;
                newAnalisis.UserId = UserId ?? newAnalisis.UserId;
                return await AnalisisRepository.PutAnalisis(newAnalisis);
            }
        }

        public async Task<Analisis?> DeleteAnalisis(int id)
        {
            return await AnalisisRepository.DeleteAnalisis(id);
        }

    }
}

