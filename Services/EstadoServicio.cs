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
        Task<Estado> AddEstado(
                                   string Nombre);
        Task<Estado> UpdateEstado(
                                   string Nombre);
        Task<Estado?> DeleteEstado(int id);
    }
    public class EstadoServicio
    {
    }
}
