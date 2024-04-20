using System.ComponentModel.DataAnnotations;

namespace WeatherAPI.Model
{
    public class MaquinaRadia
    {
        [Key] public int MaquinaRId { get; set; }

        public DateTime Fecha { get; set; }
        public string Resultado { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
