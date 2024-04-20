using System.ComponentModel.DataAnnotations;

namespace WeatherAPI.Model
{
    public class MaquinaTempe
    {
        [Key] public int MaquinaTId { get; set; }

        public DateTime Fecha { get; set; }
        public string Resultado { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
