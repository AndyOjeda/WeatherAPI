using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherAPI.Model
{
    public class Analisis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnalisisId { get; set; }
        public required DateTime Fecha { get; set; }
        public required string ResultadoAnalisis { get; set; }
        public required int MedicionId { get; set; }
        public required int UserId { get; set; }

        [ForeignKey("MedicionId")]
        public  Medicion medicion { get; set; }

        [ForeignKey("UserId")]
        public  User user { get; set; }
    }
}
