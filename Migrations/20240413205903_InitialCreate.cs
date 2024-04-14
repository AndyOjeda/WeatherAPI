using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoActual = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Estacion",
                columns: table => new
                {
                    EstacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacion", x => x.EstacionId);
                    table.ForeignKey(
                        name: "FK_Estacion_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicion",
                columns: table => new
                {
                    MedicionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaMedicion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperatura = table.Column<float>(type: "real", nullable: false),
                    Humedad = table.Column<float>(type: "real", nullable: false),
                    Presion = table.Column<float>(type: "real", nullable: false),
                    Precipitacion = table.Column<float>(type: "real", nullable: false),
                    TradiacionSolar = table.Column<float>(type: "real", nullable: false),
                    VelocidadViento = table.Column<float>(type: "real", nullable: false),
                    DireccionViento = table.Column<float>(type: "real", nullable: false),
                    EstacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicion", x => x.MedicionId);
                    table.ForeignKey(
                        name: "FK_Medicion_Estacion_EstacionId",
                        column: x => x.EstacionId,
                        principalTable: "Estacion",
                        principalColumn: "EstacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Analisis",
                columns: table => new
                {
                    AnalisisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResultadoAnalisis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analisis", x => x.AnalisisId);
                    table.ForeignKey(
                        name: "FK_Analisis_Medicion_MedicionId",
                        column: x => x.MedicionId,
                        principalTable: "Medicion",
                        principalColumn: "MedicionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Analisis_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analisis_MedicionId",
                table: "Analisis",
                column: "MedicionId");

            migrationBuilder.CreateIndex(
                name: "IX_Analisis_UserId",
                table: "Analisis",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Estacion_EstadoId",
                table: "Estacion",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicion_EstacionId",
                table: "Medicion",
                column: "EstacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analisis");

            migrationBuilder.DropTable(
                name: "Medicion");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Estacion");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
