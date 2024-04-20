using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI.Model;
using WeatherAPI.Repositories;

namespace WeatherAPI.Servicios
{
    public interface IEstadoService
    {
        Task<List<Estado>> GetAll();
        Task<Estado?> GetEstado(int id);
        Task<Estado> CreateEstado(string EstadoActual);
        Task<Estado> UpdateEstado(int EstadoId, string EstadoActual);
        Task<Estado?> DeleteEstado(int id);
    }

    public class EstadoService : IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoService(IEstadoRepository estadoRepository)
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

        public async Task<Estado> CreateEstado(string EstadoActual)
        {
            return await _estadoRepository.CreateEstado(EstadoActual);
        }

        public async Task<Estado> UpdateEstado(int EstadoId, string EstadoActual)
        {
            if (EstadoActual == null)
            {
                throw new ArgumentNullException(nameof(EstadoActual));
            }
            Estado? estado = await _estadoRepository.GetEstado(EstadoId);
            if (estado == null)
            {
                throw new Exception("Estado no encontrado");
            }
            estado.EstadoActual = EstadoActual;
            return await _estadoRepository.UpdateEstado(estado);

}

        public async Task<Estado?> DeleteEstado(int id)
        {
            return await _estadoRepository.DeleteEstado(id);
        }
    }
}

