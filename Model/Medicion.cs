using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherAPI.Model
{
    public class Medicion
    {
        [Key] public int MedicionId { get; set; }
        public required DateTime FechaMedicion { get; set; }
        public required float Temperatura { get; set; }
        public required float Humedad { get; set; }
        public required float Presion { get; set; }
        public required float Precipitacion { get; set; }
        public required float TradiacionSolar { get; set; }
        public required float VelocidadViento { get; set; }
        public required float DireccionViento { get; set; }

        public required int EstacionId { get; set; }

        [ForeignKey("EstacionId")]
        public Estacion estacion { get; set; }
    
    }
}
