using System.ComponentModel.DataAnnotations;

namespace WeatherAPI.Model
{
    public class Estado
    {

        //Estado Estacion 
        [Key] public  int EstadoId { get; set; }
        public required string EstadoActual { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
