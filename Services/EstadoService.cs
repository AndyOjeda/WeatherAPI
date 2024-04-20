using System.ComponentModel.DataAnnotations;
using WeatherAPI.Context;
using WeatherAPI.Model;
using WeatherAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Services
{
    public interface IEstadoService
    {
        Task<IEnumerable<Estado>> GetEstados();
        Task<Estado?> GetEstado(int id);
        Task<Estado> CreateEstado(
            string EstadoActual
            );
        Task<Estado> PutEstado(
            int EstadoId,
            string? EstadoActual
            );
            

        Task<Estado?> DeleteEstado(int id);
    }
    public class EstadoService(IEstadoRepository EstadoRepository) : IEstadoService
    {
        public async Task<Estado?> GetEstado(int id)
        {
            return await EstadoRepository.GetEstado(id);
        }

        public async Task<IEnumerable<Estado>> GetEstados()
        {
            return await EstadoRepository.GetEstados();
        }
        public async Task<Estado> CreateEstado(
            string EstadoActual
            )

        {
            return await EstadoRepository.CreateEstado(new Estado
            {
                EstadoActual = EstadoActual
                
            });
        }
        public async Task<Estado> PutEstado(
              int EstadoId,
              string? EstadoActual)
        {
            Estado? newEstado = await EstadoRepository.GetEstado(EstadoId);
            if (newEstado == null)
            {
                throw new Exception("Estado no encontrada");
            }
            else
            {
                newEstado.EstadoActual = EstadoActual ?? newEstado.EstadoActual;
                return await EstadoRepository.PutEstado(newEstado);
            }
        }

        public async Task<Estado?> DeleteEstado(int id)
        {
            return await EstadoRepository.DeleteEstado(id);
        }

    }
}

