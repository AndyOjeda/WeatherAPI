using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.ComTypes;
using WeatherAPI.Model;



namespace WeatherAPI.Context
{
    public class AppDbContext: DbContext
    {
        public DbSet<Medicion> Medicion {  get; set; }
        public DbSet<User> User {  get; set; }
        public DbSet<Estado> Estado {  get; set; }
        public DbSet<Estacion> Estacion { get; set; }
        public DbSet<Analisis> Analisis { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
