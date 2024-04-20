using System.ComponentModel.DataAnnotations;
using WeatherAPI.Context;
using WeatherAPI.Model;
using WeatherAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Services
{
    public interface IMedicionService
    {
        Task<IEnumerable<Medicion>> GetMedicions();
        Task<Medicion?> GetMedicion(int id);
        Task<Medicion> CreateMedicion(
            DateTime FechaMedicion,
            int TemperaturaId,
            int HumedadId,
            int PresionId,
            int PrecipitacionId,
            int RadiacionSolarId,
            int VelocidadVientoId,
            int DireccionVientoId
            );
        Task<Medicion> PutMedicion(
            int MaquinaRId,
            DateTime? FechaMedicion,
            int? TemperaturaId,
            int? HumedadId,
            int? PresionId,
            int? PrecipitacionId,
            int? RadiacionSolarId,
            int? VelocidadVientoId,
            int? DireccionVientoId
            );

        Task<Medicion?> DeleteMedicion(int id);
    }
    public class MedicionService(IMedicionRepository MedicionRepository) : IMedicionService
    {
        public async Task<Medicion?> GetMedicion(int id)
        {
            return await MedicionRepository.GetMedicion(id);
        }

        public async Task<IEnumerable<Medicion>> GetMedicions()
        {
            return await MedicionRepository.GetMedicions();
        }
        public async Task<Medicion> CreateMedicion(
            DateTime FechaMedicion,
            int TemperaturaId,
            int HumedadId,
            int PresionId,
            int PrecipitacionId,
            int RadiacionSolarId,
            int VelocidadVientoId,
            int DireccionVientoId
            )

        {
            return await MedicionRepository.CreateMedicion(new Medicion
            {
                FechaMedicion = FechaMedicion,
                TemperaturaId = TemperaturaId,
                HumedadId = HumedadId,
                PresionId = PresionId,
                PrecipitacionId = PrecipitacionId,
                RadiacionSolarId = RadiacionSolarId,
                VelocidadVientoId = VelocidadVientoId,
                DireccionVientoId = DireccionVientoId

            });
        }
        public async Task<Medicion> PutMedicion(
            int MaquinaRId,
            DateTime? FechaMedicion,
            int? TemperaturaId,
            int? HumedadId,
            int? PresionId,
            int? PrecipitacionId,
            int? RadiacionSolarId,
            int? VelocidadVientoId,
            int? DireccionVientoId
                )
        {
            Medicion? newMedicion = await MedicionRepository.GetMedicion(MaquinaRId);
            if (newMedicion == null)
            {
                throw new Exception("Medicion no encontrada");
            }
            else
            {
                newMedicion.FechaMedicion = FechaMedicion ?? newMedicion.FechaMedicion;
                newMedicion.TemperaturaId = TemperaturaId ?? newMedicion.TemperaturaId;
                newMedicion.HumedadId = HumedadId ?? newMedicion.HumedadId;
                newMedicion.PresionId = PresionId ?? newMedicion.PresionId;
                newMedicion.PrecipitacionId = PrecipitacionId ?? newMedicion.PrecipitacionId;
                newMedicion.RadiacionSolarId = RadiacionSolarId ?? newMedicion.RadiacionSolarId;
                newMedicion.VelocidadVientoId = VelocidadVientoId ?? newMedicion.VelocidadVientoId;
                newMedicion.DireccionVientoId = DireccionVientoId ?? newMedicion.DireccionVientoId;
                return await MedicionRepository.PutMedicion(newMedicion);
            }
        }

        public async Task<Medicion?> DeleteMedicion(int id)
        {
            return await MedicionRepository.DeleteMedicion(id);
        }

    }
}

