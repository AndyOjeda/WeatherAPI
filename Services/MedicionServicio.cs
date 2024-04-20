using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI.Model;
using WeatherAPI.Repositories;

namespace WeatherAPI.Servicios
{
    public interface IMedicionServicio
    {
        Task<List<Medicion>> GetAll();
        Task<Medicion?> GetMedicion(int id);
        Task<Medicion> AddMedicion(DateTime Fecha, double Temperatura, double Humedad, double Presion, int EstacionId);
        Task<Medicion> UpdateMedicion(DateTime Fecha, double Temperatura, double Humedad, double Presion, int EstacionId);
        Task<Medicion?> DeleteMedicion(int id);
    }

    public class MedicionServicio : IMedicionServicio
    {
        private readonly IMedicionRepository _medicionRepository;

        public MedicionServicio(IMedicionRepository medicionRepository)
        {
            _medicionRepository = medicionRepository;
        }

        public async Task<List<Medicion>> GetAll()
        {
            return await _medicionRepository.GetAll();
        }

        public async Task<Medicion?> GetMedicion(int id)
        {
            return await _medicionRepository.GetMedicion(id);
        }

        public async Task<Medicion> AddMedicion(DateTime Fecha, double Temperatura, double Humedad, double Presion, int EstacionId)
        {
            return await _medicionRepository.AddMedicion(Fecha, Temperatura, Humedad, Presion, EstacionId);
        }

        public async Task<Medicion> UpdateMedicion(DateTime Fecha, double Temperatura, double Humedad, double Presion, int EstacionId)
        {
            // No se pueden asignar valores nulos a tipos no anulables como DateTime y double,
            // por lo tanto, los valores predeterminados ya son 0 para double y DateTime.Now para DateTime.
            return await _medicionRepository.UpdateMedicion(Fecha, Temperatura, Humedad, Presion, EstacionId);
        }

        public async Task<Medicion?> DeleteMedicion(int id)
        {
            return await _medicionRepository.DeleteMedicion(id);
        }
    }
}
