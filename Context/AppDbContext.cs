using Microsoft.EntityFrameworkCore;
using WeatherAPI.Model;



namespace WeatherAPI.Context
{
    public class AppDbContext: DbContext
    {
        public DbSet<Analisis> Analisis { get; set; }
        public DbSet<Estacion> Estacion { get; set; }
        public DbSet<Medicion> Medicion {  get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<User> User {  get; set; }
        public DbSet<MaquinaDireccion> MaquinaDireccion { get; set; }
        public DbSet<MaquinaHumedad> MaquinaHumedad { get; set; }
        public DbSet<MaquinaTempe> MaquinaTemperatura { get; set; }
        public DbSet<MaquinaPresion> MaquinaPresion { get; set; }
        public DbSet<MaquinaPrecipi> MaquinaPrecipitacion { get; set; }
        public DbSet<MaquinaRadia> MaquinaRadiacionSolar { get; set; }
        public DbSet<MaquinaViento> MaquinaViento { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicion>().ToTable("Medicion");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Estado>().ToTable("Estado");
            modelBuilder.Entity<Estacion>().ToTable("Estacion");
            modelBuilder.Entity<Analisis>().ToTable("Analisis");
            modelBuilder.Entity<MaquinaHumedad>().ToTable("MaquinaHumedad");
            modelBuilder.Entity<MaquinaTempe>().ToTable("MaquinaTemperatura");
            modelBuilder.Entity<MaquinaPresion>().ToTable("MaquinaPresion");
            modelBuilder.Entity<MaquinaPrecipi>().ToTable("MaquinaPrecipitacion");
            modelBuilder.Entity<MaquinaRadia>().ToTable("MaquinaRadiacionSolar");
            modelBuilder.Entity<MaquinaViento>().ToTable("MaquinaViento");
            modelBuilder.Entity<MaquinaDireccion>().ToTable("MaquinaDireccion");
        }
    }
}
