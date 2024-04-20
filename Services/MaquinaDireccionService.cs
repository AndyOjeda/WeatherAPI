using System.ComponentModel.DataAnnotations;
using WeatherAPI.Context;
using WeatherAPI.Model;
using WeatherAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Services
{
    public interface IMaquinaDireccionService
    {
        Task<IEnumerable<MaquinaDireccion>> GetMaquinaDireccions();
        Task<MaquinaDireccion?> GetMaquinaDireccion(int id);
        Task<MaquinaDireccion> CreateMaquinaDireccion(
            DateTime Fecha,
            string Resultado
            );
        Task<MaquinaDireccion> PutMaquinaDireccion(
            int MaquinaDId,
            DateTime? Fecha,
            string? Resultado
            );

        Task<MaquinaDireccion?> DeleteMaquinaDireccion(int id);
    }
    public class MaquinaDireccionService(IMaquinaDireccionRepository MaquinaDireccionRepository) : IMaquinaDireccionService
    {
        public async Task<MaquinaDireccion?> GetMaquinaDireccion(int id)
        {
            return await MaquinaDireccionRepository.GetMaquinaDireccion(id);
        }

        public async Task<IEnumerable<MaquinaDireccion>> GetMaquinaDireccions()
        {
            return await MaquinaDireccionRepository.GetMaquinaDireccions();
        }
        public async Task<MaquinaDireccion> CreateMaquinaDireccion(
            DateTime Fecha,
            string Resultado
            )

        {
            return await MaquinaDireccionRepository.CreateMaquinaDireccion(new MaquinaDireccion
            {
                Fecha = Fecha,
                Resultado = Resultado

            });
        }
        public async Task<MaquinaDireccion> PutMaquinaDireccion(
              int MaquinaDId,
              DateTime? Fecha,
              string? Resultado
                ) 
        {
            MaquinaDireccion? newMaquinaDireccion = await MaquinaDireccionRepository.GetMaquinaDireccion(MaquinaDId);
            if (newMaquinaDireccion == null)
            {
                throw new Exception("MaquinaDireccion no encontrada");
            }
            else
            {
                newMaquinaDireccion.Fecha = Fecha ?? newMaquinaDireccion.Fecha;
                newMaquinaDireccion.Resultado = Resultado ?? newMaquinaDireccion.Resultado;
                return await MaquinaDireccionRepository.PutMaquinaDireccion(newMaquinaDireccion);
            }
        }

        public async Task<MaquinaDireccion?> DeleteMaquinaDireccion(int id)
        {
            return await MaquinaDireccionRepository.DeleteMaquinaDireccion(id);
        }

    }
}

