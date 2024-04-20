using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI.Model;
using WeatherAPI.Repositories;

namespace WeatherAPI.Servicios
{
    public interface IEstadoServicio
    {
        Task<List<Estado>> GetAll();
        Task<Estado?> GetEstado(int id);
        Task<Estado> AddEstado(string EstadoActual);
        Task<Estado> UpdateEstado(string EstadoActual);
        Task<Estado?> DeleteEstado(int id);
    }

    public class EstadoServicio : IEstadoServicio
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoServicio(IEstadoRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }

        public async Task<List<Estado>> GetAll()
        {
            return await _estadoRepository.GetAll();
        }

        public async Task<Estado?> GetEstado(int id)
        {
            return await _estadoRepository.GetEstado(id);
        }

        public async Task<Estado> AddEstado(string EstadoActual)
        {
            return await _estadoRepository.AddEstado(EstadoActual);
        }

        public async Task<Estado> UpdateEstado(string EstadoActual)
        {
            if (EstadoActual == null)
            {
                throw new ArgumentNullException(nameof(EstadoActual));
            }
            return await _estadoRepository.UpdateEstado(EstadoActual);
        }

        public async Task<Estado?> DeleteEstado(int id)
        {
            return await _estadoRepository.DeleteEstado(id);
        }
    }
}

