using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherAPI.Model
{
    public class Estacion
    {

        //Estacion Meteorologica

        [Key] public int EstacionId { get; set; }
        public required string Nombre { get; set; }
        public required string Ubicacion { get; set; }


        [ForeignKey(nameof(Medicion))]
        public required int MedicionId { get; set; }

        [ForeignKey(nameof(Estado))]
        public required int EstadoId { get; set; }
        public bool IsActive { get; set; } = true;


        public virtual Medicion? Medicion { get; set; }
        public virtual Estado? Estado { get; set; }

    }
}
