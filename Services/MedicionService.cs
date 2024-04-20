using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI.Model;
using WeatherAPI.Repositories;

namespace WeatherAPI.Servicios
{
    public interface IMedicionService
    {
        Task<List<Medicion>> GetAll();
        Task<Medicion?> GetMedicion(int id);
        Task<Medicion> CreateMedicion(DateTime Fecha, float Temperatura, float Humedad, float Presion, float Precipitacion, float RadiacionSolar, float VelocidadViento, float DireccionViento, int EstacionId);
        Task<Medicion> UpdateMedicion(int MedicionId, DateTime Fecha, float Temperatura, float Humedad, float Presion, float Precipitacion, float RadiacionSolar, float VelocidadViento, float DireccionViento, int EstacionId);
        Task<Medicion?> DeleteMedicion(int id);
    }

    public class MedicionService : IMedicionService
    {
        private readonly IMedicionRepository _medicionRepository;

        public MedicionService(IMedicionRepository medicionRepository)
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

        public async Task<Medicion> CreateMedicion(DateTime Fecha, float Temperatura, float Humedad, float Presion, float Precipitacion, float RadiacionSolar, float VelocidadViento, float DireccionViento, int EstacionId)
        {
            return await _medicionRepository.CreateMedicion(Fecha, Temperatura, Humedad, Presion, Precipitacion, RadiacionSolar, VelocidadViento, DireccionViento, EstacionId);
        }

        public async Task<Medicion> UpdateMedicion(int MedicionId, DateTime Fecha, float Temperatura, float Humedad, float Presion, float Precipitacion, float RadiacionSolar, float VelocidadViento, float DireccionViento, int EstacionId)
        {
            Medicion? medicion = await _medicionRepository.GetMedicion(MedicionId);
            if (medicion == null)
            {
                throw new Exception("Medicion no encontrada");
            }
            if (EstacionId == 0)
            {
                throw new Exception("EstacionId no puede ser 0");
            }
            if (Fecha == null)
            {
                throw new Exception("Fecha no puede ser nula");
            }
            if (Temperatura == 0)
            {
                throw new Exception("Temperatura no puede ser 0");
            }
            if (Humedad == 0)
            {
                throw new Exception("Humedad no puede ser 0");
            }
            if (Presion == 0)
            {
                throw new Exception("Presion no puede ser 0");
            }
            if (Precipitacion == 0)
            {
                throw new Exception("Precipitacion no puede ser 0");
            }
            if (RadiacionSolar == 0)
            {
                throw new Exception("RadiacionSolar no puede ser 0");
            }
            if (VelocidadViento == 0)
            {
                throw new Exception("VelocidadViento no puede ser 0");
            }
            if (DireccionViento == 0)
            {
                throw new Exception("DireccionViento no puede ser 0");
            }
            medicion.FechaMedicion = Fecha;
            medicion.Temperatura = Temperatura;
            medicion.Humedad = Humedad;
            medicion.Presion = Presion;
            medicion.Precipitacion = Precipitacion;
            medicion.RadiacionSolar = RadiacionSolar;
            medicion.VelocidadViento = VelocidadViento;
            medicion.DireccionViento = DireccionViento;
            medicion.EstacionId = EstacionId;

            return await _medicionRepository.UpdateMedicion(medicion);

        }

            

        public async Task<Medicion?> DeleteMedicion(int id)
        {
            return await _medicionRepository.DeleteMedicion(id);
        }
    }
}
