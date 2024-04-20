using System.ComponentModel.DataAnnotations;

namespace WeatherAPI.Model
{
    public class MaquinaDireccion
    {
        [Key]
        public int MaquinaDId { get; set; }

        public DateTime Fecha { get; set; }
        public string Resultado { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
