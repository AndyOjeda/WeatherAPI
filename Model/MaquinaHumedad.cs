using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WeatherAPI.Model
{
    public class MaquinaHumedad
    {
        [Key]
        public int MaquinaHId { get; set; }

        public DateTime Fecha { get; set; }
        public string Resultado { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
