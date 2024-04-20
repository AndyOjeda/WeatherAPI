using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherAPI.Model
{
    public class Medicion
    {
        [Key] public int MedicionId { get; set; }
        public  DateTime FechaMedicion { get; set; }


        [ForeignKey(nameof(MaquinaTempe))]
        public required int TemperaturaId { get; set; }


        [ForeignKey(nameof(MaquinaHumedad))]
        public required int HumedadId { get; set; }


        [ForeignKey(nameof(MaquinaPresion))]
        public required int PresionId { get; set; }


        [ForeignKey(nameof(MaquinaPrecipi))]
        public required int PrecipitacionId { get; set; }


        [ForeignKey(nameof(MaquinaRadia))]
        public required int RadiacionSolarId { get; set; }


        [ForeignKey(nameof(MaquinaViento))]
        public required int VelocidadVientoId { get; set; }


        [ForeignKey(nameof(MaquinaDireccion))]
        public required int DireccionVientoId { get; set; }



        public bool IsActive { get; set; } = true;




        public virtual MaquinaTempe? MaquinaTempe { get; set; }
        public virtual MaquinaHumedad? MaquinaHumedad { get; set; }
        public virtual MaquinaPresion? MaquinaPresion { get; set; }
        public virtual MaquinaPrecipi? MaquinaPrecipi { get; set; }
        public virtual MaquinaRadia? MaquinaRadia { get; set; }
        public virtual MaquinaViento? MaquinaViento { get; set; }
        public virtual MaquinaDireccion? MaquinaDireccion { get; set; }
        public virtual Estacion? Estacion { get; set; }
       

    }
}
