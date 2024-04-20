﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherAPI.Context;

#nullable disable

namespace WeatherAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240420211800_Second")]
    partial class Second
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WeatherAPI.Model.Analisis", b =>
                {
                    b.Property<int>("AnalisisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnalisisId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MedicionId")
                        .HasColumnType("int");

                    b.Property<string>("ResultadoAnalisis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AnalisisId");

                    b.HasIndex("MedicionId");

                    b.HasIndex("UserId");

                    b.ToTable("Analisis", (string)null);
                });

            modelBuilder.Entity("WeatherAPI.Model.Estacion", b =>
                {
                    b.Property<int>("EstacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstacionId"));

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MedicionId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstacionId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("MedicionId")
                        .IsUnique();

                    b.ToTable("Estacion", (string)null);
                });

            modelBuilder.Entity("WeatherAPI.Model.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoId"));

                    b.Property<string>("EstadoActual")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("EstadoId");

                    b.ToTable("Estado", (string)null);
                });

            modelBuilder.Entity("WeatherAPI.Model.MaquinaDireccion", b =>
                {
                    b.Property<int>("MaquinaDId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaquinaDId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Resultado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaquinaDId");

                    b.ToTable("MaquinaDireccion", (string)null);
                });

            modelBuilder.Entity("WeatherAPI.Model.MaquinaHumedad", b =>
                {
                    b.Property<int>("MaquinaHId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaquinaHId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Resultado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaquinaHId");

                    b.ToTable("MaquinaHumedad", (string)null);
                });

            modelBuilder.Entity("WeatherAPI.Model.MaquinaPrecipi", b =>
                {
                    b.Property<int>("MaquinaPId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaquinaPId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Resultado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaquinaPId");

                    b.ToTable("MaquinaPrecipitacion", (string)null);
                });

            modelBuilder.Entity("WeatherAPI.Model.MaquinaPresion", b =>
                {
                    b.Property<int>("MaquinaPreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaquinaPreId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Resultado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaquinaPreId");

                    b.ToTable("MaquinaPresion", (string)null);
                });

            modelBuilder.Entity("WeatherAPI.Model.MaquinaRadia", b =>
                {
                    b.Property<int>("MaquinaRId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaquinaRId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Resultado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaquinaRId");

                    b.ToTable("MaquinaRadiacionSolar", (string)null);
                });

            modelBuilder.Entity("WeatherAPI.Model.MaquinaTempe", b =>
                {
                    b.Property<int>("MaquinaTId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaquinaTId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Resultado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaquinaTId");

                    b.ToTable("MaquinaTemperatura", (string)null);
                });

            modelBuilder.Entity("WeatherAPI.Model.MaquinaViento", b =>
                {
                    b.Property<int>("MaquinaVId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaquinaVId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Resultado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaquinaVId");

                    b.ToTable("MaquinaViento", (string)null);
                });

            modelBuilder.Entity("WeatherAPI.Model.Medicion", b =>
                {
                    b.Property<int>("MedicionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicionId"));

                    b.Property<int>("DireccionVientoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaMedicion")
                        .HasColumnType("datetime2");

                    b.Property<int>("HumedadId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PrecipitacionId")
                        .HasColumnType("int");

                    b.Property<int>("PresionId")
                        .HasColumnType("int");

                    b.Property<int>("RadiacionSolarId")
                        .HasColumnType("int");

                    b.Property<int>("TemperaturaId")
                        .HasColumnType("int");

                    b.Property<int>("VelocidadVientoId")
                        .HasColumnType("int");

                    b.HasKey("MedicionId");

                    b.HasIndex("DireccionVientoId");

                    b.HasIndex("HumedadId");

                    b.HasIndex("PrecipitacionId");

                    b.HasIndex("PresionId");

                    b.HasIndex("RadiacionSolarId");

                    b.HasIndex("TemperaturaId");

                    b.HasIndex("VelocidadVientoId");

                    b.ToTable("Medicion", (string)null);
                });

            modelBuilder.Entity("WeatherAPI.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("WeatherAPI.Model.Analisis", b =>
                {
                    b.HasOne("WeatherAPI.Model.Medicion", "Medicion")
                        .WithMany()
                        .HasForeignKey("MedicionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeatherAPI.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicion");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WeatherAPI.Model.Estacion", b =>
                {
                    b.HasOne("WeatherAPI.Model.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeatherAPI.Model.Medicion", "Medicion")
                        .WithOne("Estacion")
                        .HasForeignKey("WeatherAPI.Model.Estacion", "MedicionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("Medicion");
                });

            modelBuilder.Entity("WeatherAPI.Model.Medicion", b =>
                {
                    b.HasOne("WeatherAPI.Model.MaquinaDireccion", "MaquinaDireccion")
                        .WithMany()
                        .HasForeignKey("DireccionVientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeatherAPI.Model.MaquinaHumedad", "MaquinaHumedad")
                        .WithMany()
                        .HasForeignKey("HumedadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeatherAPI.Model.MaquinaPrecipi", "MaquinaPrecipi")
                        .WithMany()
                        .HasForeignKey("PrecipitacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeatherAPI.Model.MaquinaPresion", "MaquinaPresion")
                        .WithMany()
                        .HasForeignKey("PresionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeatherAPI.Model.MaquinaRadia", "MaquinaRadia")
                        .WithMany()
                        .HasForeignKey("RadiacionSolarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeatherAPI.Model.MaquinaTempe", "MaquinaTempe")
                        .WithMany()
                        .HasForeignKey("TemperaturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeatherAPI.Model.MaquinaViento", "MaquinaViento")
                        .WithMany()
                        .HasForeignKey("VelocidadVientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaquinaDireccion");

                    b.Navigation("MaquinaHumedad");

                    b.Navigation("MaquinaPrecipi");

                    b.Navigation("MaquinaPresion");

                    b.Navigation("MaquinaRadia");

                    b.Navigation("MaquinaTempe");

                    b.Navigation("MaquinaViento");
                });

            modelBuilder.Entity("WeatherAPI.Model.Medicion", b =>
                {
                    b.Navigation("Estacion");
                });
#pragma warning restore 612, 618
        }
    }
}