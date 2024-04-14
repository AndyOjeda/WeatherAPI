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
    [Migration("20240413205903_InitialCreate")]
    partial class InitialCreate
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

                    b.ToTable("Analisis");
                });

            modelBuilder.Entity("WeatherAPI.Model.Estacion", b =>
                {
                    b.Property<int>("EstacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstacionId"));

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstacionId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Estacion");
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

                    b.HasKey("EstadoId");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("WeatherAPI.Model.Medicion", b =>
                {
                    b.Property<int>("MedicionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicionId"));

                    b.Property<float>("DireccionViento")
                        .HasColumnType("real");

                    b.Property<int>("EstacionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaMedicion")
                        .HasColumnType("datetime2");

                    b.Property<float>("Humedad")
                        .HasColumnType("real");

                    b.Property<float>("Precipitacion")
                        .HasColumnType("real");

                    b.Property<float>("Presion")
                        .HasColumnType("real");

                    b.Property<float>("Temperatura")
                        .HasColumnType("real");

                    b.Property<float>("TradiacionSolar")
                        .HasColumnType("real");

                    b.Property<float>("VelocidadViento")
                        .HasColumnType("real");

                    b.HasKey("MedicionId");

                    b.HasIndex("EstacionId");

                    b.ToTable("Medicion");
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

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
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
                    b.HasOne("WeatherAPI.Model.Estado", "estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("estado");
                });

            modelBuilder.Entity("WeatherAPI.Model.Medicion", b =>
                {
                    b.HasOne("WeatherAPI.Model.Estacion", "Estacion")
                        .WithMany()
                        .HasForeignKey("EstacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estacion");
                });
#pragma warning restore 612, 618
        }
    }
}
