using Microsoft.EntityFrameworkCore;
using WeatherAPI.Model;
using WeatherAPI.Repositories;
using WeatherAPI.Services;
using WeatherAPI.Context;



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
            modelBuilder.Entity<Analisis>().ToTable("Analisis");
            modelBuilder.Entity<Estacion>().ToTable("Estacion");
            modelBuilder.Entity<Medicion>().ToTable("Medicion");
            modelBuilder.Entity<Estado>().ToTable("Estado");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<MaquinaDireccion>().ToTable("MaquinaDireccion");
            modelBuilder.Entity<MaquinaHumedad>().ToTable("MaquinaHumedad");
            modelBuilder.Entity<MaquinaTempe>().ToTable("MaquinaTempe");
            modelBuilder.Entity<MaquinaPresion>().ToTable("MaquinaPresion");
            modelBuilder.Entity<MaquinaPrecipi>().ToTable("MaquinaPrecipi");
            modelBuilder.Entity<MaquinaRadia>().ToTable("MaquinaRadia");
            modelBuilder.Entity<MaquinaViento>().ToTable("MaquinaViento");


            modelBuilder.Entity<Analisis>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<Estacion>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<Medicion>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<Estado>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<User>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<MaquinaDireccion>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<MaquinaHumedad>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<MaquinaTempe>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<MaquinaPresion>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<MaquinaPrecipi>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<MaquinaRadia>().HasQueryFilter(e => e.IsActive);
            modelBuilder.Entity<MaquinaViento>().HasQueryFilter(e => e.IsActive);
        }



    }
}
