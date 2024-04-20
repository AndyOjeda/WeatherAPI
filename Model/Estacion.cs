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
        public required string marca { get; set; }

        public required int EstadoId { get; set; }

        [ForeignKey("EstadoId")]
        public Estado estado{ get; set; }


    }
}
