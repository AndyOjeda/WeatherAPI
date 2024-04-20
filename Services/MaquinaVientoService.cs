using System.ComponentModel.DataAnnotations;
using WeatherAPI.Context;
using WeatherAPI.Model;
using WeatherAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Services
{
    public interface IMaquinaVientoService
    {
        Task<IEnumerable<MaquinaViento>> GetMaquinaVientos();
        Task<MaquinaViento?> GetMaquinaViento(int id);
        Task<MaquinaViento> CreateMaquinaViento(
            DateTime Fecha,
            string Resultado
            );
        Task<MaquinaViento> PutMaquinaViento(
            int MaquinaVId,
            DateTime? Fecha,
            string? Resultado
            );

        Task<MaquinaViento?> DeleteMaquinaViento(int id);
    }
    public class MaquinaVientoService(IMaquinaVientoRepository MaquinaVientoRepository) : IMaquinaVientoService
    {
        public async Task<MaquinaViento?> GetMaquinaViento(int id)
        {
            return await MaquinaVientoRepository.GetMaquinaViento(id);
        }

        public async Task<IEnumerable<MaquinaViento>> GetMaquinaVientos()
        {
            return await MaquinaVientoRepository.GetMaquinaVientos();
        }
        public async Task<MaquinaViento> CreateMaquinaViento(
            DateTime Fecha,
            string Resultado
            )

        {
            return await MaquinaVientoRepository.CreateMaquinaViento(new MaquinaViento
            {
                Fecha = Fecha,
                Resultado = Resultado

            });
        }
        public async Task<MaquinaViento> PutMaquinaViento(
              int MaquinaVId,
              DateTime? Fecha,
              string? Resultado
                )
        {
            MaquinaViento? newMaquinaViento = await MaquinaVientoRepository.GetMaquinaViento(MaquinaVId);
            if (newMaquinaViento == null)
            {
                throw new Exception("MaquinaViento no encontrada");
            }
            else
            {
                newMaquinaViento.Fecha = Fecha ?? newMaquinaViento.Fecha;
                newMaquinaViento.Resultado = Resultado ?? newMaquinaViento.Resultado;
                return await MaquinaVientoRepository.PutMaquinaViento(newMaquinaViento);
            }
        }

        public async Task<MaquinaViento?> DeleteMaquinaViento(int id)
        {
            return await MaquinaVientoRepository.DeleteMaquinaViento(id);
        }

    }
}

