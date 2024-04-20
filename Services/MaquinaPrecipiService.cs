using System.ComponentModel.DataAnnotations;
using WeatherAPI.Context;
using WeatherAPI.Model;
using WeatherAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Services
{
    public interface IMaquinaPrecipiService
    {
        Task<IEnumerable<MaquinaPrecipi>> GetMaquinaPrecipis();
        Task<MaquinaPrecipi?> GetMaquinaPrecipi(int id);
        Task<MaquinaPrecipi> CreateMaquinaPrecipi(
            DateTime Fecha,
            string Resultado
            );
        Task<MaquinaPrecipi> PutMaquinaPrecipi(
            int MaquinaPId,
            DateTime? Fecha,
            string? Resultado
            );

        Task<MaquinaPrecipi?> DeleteMaquinaPrecipi(int id);
    }
    public class MaquinaPrecipiService(IMaquinaPrecipiRepository MaquinaPrecipiRepository) : IMaquinaPrecipiService
    {
        public async Task<MaquinaPrecipi?> GetMaquinaPrecipi(int id)
        {
            return await MaquinaPrecipiRepository.GetMaquinaPrecipi(id);
        }

        public async Task<IEnumerable<MaquinaPrecipi>> GetMaquinaPrecipis()
        {
            return await MaquinaPrecipiRepository.GetMaquinaPrecipis();
        }
        public async Task<MaquinaPrecipi> CreateMaquinaPrecipi(
            DateTime Fecha,
            string Resultado
            )

        {
            return await MaquinaPrecipiRepository.CreateMaquinaPrecipi(new MaquinaPrecipi
            {
                Fecha = Fecha,
                Resultado = Resultado

            });
        }
        public async Task<MaquinaPrecipi> PutMaquinaPrecipi(
              int MaquinaPId,
              DateTime? Fecha,
              string? Resultado
                )
        {
            MaquinaPrecipi? newMaquinaPrecipi = await MaquinaPrecipiRepository.GetMaquinaPrecipi(MaquinaPId);
            if (newMaquinaPrecipi == null)
            {
                throw new Exception("MaquinaPrecipi no encontrada");
            }
            else
            {
                newMaquinaPrecipi.Fecha = Fecha ?? newMaquinaPrecipi.Fecha;
                newMaquinaPrecipi.Resultado = Resultado ?? newMaquinaPrecipi.Resultado;
                return await MaquinaPrecipiRepository.PutMaquinaPrecipi(newMaquinaPrecipi);
            }
        }

        public async Task<MaquinaPrecipi?> DeleteMaquinaPrecipi(int id)
        {
            return await MaquinaPrecipiRepository.DeleteMaquinaPrecipi(id);
        }

    }
}

