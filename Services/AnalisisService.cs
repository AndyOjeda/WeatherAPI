using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI.Model;
using WeatherAPI.Repositories;

namespace WeatherAPI.Servicios
{
    public interface IAnalisisServicio
    {
        Task<List<Analisis>> GetAll();
        Task<Analisis?> GetAnalisis(int id);
        Task<Analisis> AddAnalisis(
                        DateTime Fecha, 
                        string ResultadoAnalisis, 
                        int MedicionId, 
                        int UserId);
        Task<Analisis> UpdateAnalisis(
                        DateTime Fecha, 
                        string ResultadoAnalisis, 
                        int MedicionId, 
                        int UserId);
        Task<Analisis?> DeleteAnalisis(int id);
    }

    public class AnalisisService : IAnalisisServicio
    {
        private readonly IAnalisisRepository _analisisRepository;

        public AnalisisService(IAnalisisRepository analisisRepository)
        {
            _analisisRepository = analisisRepository;
        }

        public async Task<List<Analisis>> GetAll()
        {
            return await _analisisRepository.GetAll();
        }

        public async Task<Analisis?> GetAnalisis(int id)
        {
            return await _analisisRepository.GetAnalisis(id);
        }

        public async Task<Analisis> AddAnalisis(
                                    DateTime Fecha,
                                    string ResultadoAnalisis,
                                    int MedicionId,
                                    int UserId)
        {
            return await _analisisRepository.AddAnalisis(
                                               Fecha,
                                               ResultadoAnalisis,
                                               MedicionId,
                                               UserId);
        }

        public async Task<Analisis> UpdateAnalisis(
                                    DateTime Fecha, 
                                    string ResultadoAnalisis, 
                                    int MedicionId, 
                                    int UserId)
        {
            Analisis? analisis = await _analisisRepository.GetAnalisis(id);
            if (analisis == null)
            {
                throw new Exception("Analisis no encontrado");
            }

            if (Fecha != null)
            {
                analisis.Fecha = Fecha;
            }

            if (ResultadoAnalisis != null)
            {
                analisis.ResultadoAnalisis = ResultadoAnalisis;
            }

            if (MedicionId != null)
            {
                analisis.MedicionId = MedicionId;
            }
            if (UserId != null)
            {
                analisis.UserId = UserId;
            }
            return await _analisisRepository.UpdateAnalisis(analisis);
        }

        public async Task<Analisis?> DeleteAnalisis(int id)
        {
            return await _analisisRepository.DeleteAnalisis(id);
        }
    }
}

