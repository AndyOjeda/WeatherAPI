using System.ComponentModel.DataAnnotations;
using WeatherAPI.Context;
using WeatherAPI.Model;
using WeatherAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Services
{
    public interface IEstacionService
    {
        Task<IEnumerable<Estacion>> GetEstacions();
        Task<Estacion?> GetEstacion(int id);
        Task<Estacion> CreateEstacion(
            string Nombre,
            string Ubicacion,
            int MedicionId,
            int EstadoId
            );
        Task<Estacion> PutEstacion(
            int EstacionId,
            string? Nombre,
            string? Ubicacion,
            int? MedicionId,
            int? EstadoId
            );


        Task<Estacion?> DeleteEstacion(int id);
    }
    public class EstacionService(IEstacionRepository EstacionRepository) : IEstacionService
    {
        public async Task<Estacion?> GetEstacion(int id)
        {
            return await EstacionRepository.GetEstacion(id);
        }

        public async Task<IEnumerable<Estacion>> GetEstacions()
        {
            return await EstacionRepository.GetEstacions();
        }
        public async Task<Estacion> CreateEstacion(
            string Nombre,
            string Ubicacion,
            int MedicionId,
            int EstadoId
            )

        {
            return await EstacionRepository.CreateEstacion(new Estacion
            {
                Nombre = Nombre,
                Ubicacion = Ubicacion,
                MedicionId = MedicionId,
                EstadoId = EstadoId

            });
        }
        public async Task<Estacion> PutEstacion(
              int EstacionId,
              string? Nombre,
              string? Ubicacion,
              int? MedicionId,
              int? EstadoId
              )

        {
            Estacion? newEstacion = await EstacionRepository.GetEstacion(EstacionId);
            if (newEstacion == null)
            {
                throw new Exception("Estacion no encontrada");
            }
            else
            {
                newEstacion.Nombre = Nombre ?? newEstacion.Nombre;
                newEstacion.Ubicacion = Ubicacion ?? newEstacion.Ubicacion;
                newEstacion.MedicionId = MedicionId ?? newEstacion.MedicionId;
                newEstacion.EstadoId = EstadoId ?? newEstacion.EstadoId;
                return await EstacionRepository.PutEstacion(newEstacion);
            }
        }

        public async Task<Estacion?> DeleteEstacion(int id)
        {
            return await EstacionRepository.DeleteEstacion(id);
        }

    }
}

