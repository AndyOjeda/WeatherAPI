using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI.Model;
using WeatherAPI.Repositories;

namespace WeatherAPI.Servicios
{
    public interface IEstacionService
    {
        Task<List<Estacion>> GetAll();
        Task<Estacion?> GetEstacion(int id);
        Task<Estacion> CreateEstacion(
                        string Nombre, 
                        string Ubicacion, 
                        string marca, 
                        int EstadoId);
        Task<Estacion> UpdateEstacion(
                         int id, 
                         string Nombre, 
                         string Ubicacion, 
                         string marca, 
                         int EstadoId); 
        Task<Estacion?> DeleteEstacion(int id);
    }

    public class EstacionService : IEstacionService
    {
        private readonly IEstacionRepository _estacionRepository;

        public EstacionService(IEstacionRepository estacionRepository)
        {
            _estacionRepository = estacionRepository;
        }

        public async Task<List<Estacion>> GetAll()
        {
            return await _estacionRepository.GetAll();
        }

        public async Task<Estacion?> GetEstacion(int id)
        {
            return await _estacionRepository.GetEstacion(id);
        }

        public async Task<Estacion> CreateEstacion(
                                    string Nombre, 
                                    string Ubicacion, 
                                    string marca,
                                    int EstadoId)
        {
            return await _estacionRepository.CreateEstacion(
                                                Nombre, 
                                                Ubicacion, 
                                                marca, 
                                                EstadoId);
        }

        public async Task<Estacion> UpdateEstacion(
                                        int id, 
                                        string Nombre, 
                                        string Ubicacion, 
                                        string marca, 
                                        int EstadoId)
        {
            Estacion? estacion = await _estacionRepository.GetEstacion(id);
            if (estacion == null)
            {
                throw new Exception("Estacion no encontrada");
            }
            if (Nombre != null)
            {
                estacion.Nombre = Nombre;
            }
            if (Ubicacion != null)
            {
                estacion.Ubicacion = Ubicacion;
            }
            if (marca != null)
            {
                estacion.marca = marca;
            }
            if (EstadoId != null)
            {
                estacion.EstadoId = EstadoId;
            }
            return await _estacionRepository.UpdateEstacion(estacion);
        }

        public async Task<Estacion?> DeleteEstacion(int id)
        {
            return await _estacionRepository.DeleteEstacion(id);
        }
    }
}


