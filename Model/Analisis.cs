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

        [ForeignKey(nameof(Medicion))]
        public required int MedicionId { get; set; }

        [ForeignKey(nameof(User))]
        public required int UserId { get; set; }
        public bool IsActive { get; set; } = true;


        public virtual Medicion? Medicion { get; set; }
        public virtual User? User { get; set; }
    }
}
