using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                name: "MaquinaDireccion",
                columns: table => new
                {
                    MaquinaDId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaquinaDireccion", x => x.MaquinaDId);
                });

            migrationBuilder.CreateTable(
                name: "MaquinaHumedad",
                columns: table => new
                {
                    MaquinaHId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaquinaHumedad", x => x.MaquinaHId);
                });

            migrationBuilder.CreateTable(
                name: "MaquinaPrecipitacion",
                columns: table => new
                {
                    MaquinaPId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaquinaPrecipitacion", x => x.MaquinaPId);
                });

            migrationBuilder.CreateTable(
                name: "MaquinaPresion",
                columns: table => new
                {
                    MaquinaPreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaquinaPresion", x => x.MaquinaPreId);
                });

            migrationBuilder.CreateTable(
                name: "MaquinaRadiacionSolar",
                columns: table => new
                {
                    MaquinaRId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaquinaRadiacionSolar", x => x.MaquinaRId);
                });

            migrationBuilder.CreateTable(
                name: "MaquinaTemperatura",
                columns: table => new
                {
                    MaquinaTId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaquinaTemperatura", x => x.MaquinaTId);
                });

            migrationBuilder.CreateTable(
                name: "MaquinaViento",
                columns: table => new
                {
                    MaquinaVId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaquinaViento", x => x.MaquinaVId);
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
                name: "Medicion",
                columns: table => new
                {
                    MedicionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaMedicion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TemperaturaId = table.Column<int>(type: "int", nullable: false),
                    HumedadId = table.Column<int>(type: "int", nullable: false),
                    PresionId = table.Column<int>(type: "int", nullable: false),
                    PrecipitacionId = table.Column<int>(type: "int", nullable: false),
                    RadiacionSolarId = table.Column<int>(type: "int", nullable: false),
                    VelocidadVientoId = table.Column<int>(type: "int", nullable: false),
                    DireccionVientoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicion", x => x.MedicionId);
                    table.ForeignKey(
                        name: "FK_Medicion_MaquinaDireccion_DireccionVientoId",
                        column: x => x.DireccionVientoId,
                        principalTable: "MaquinaDireccion",
                        principalColumn: "MaquinaDId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicion_MaquinaHumedad_HumedadId",
                        column: x => x.HumedadId,
                        principalTable: "MaquinaHumedad",
                        principalColumn: "MaquinaHId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicion_MaquinaPrecipitacion_PrecipitacionId",
                        column: x => x.PrecipitacionId,
                        principalTable: "MaquinaPrecipitacion",
                        principalColumn: "MaquinaPId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicion_MaquinaPresion_PresionId",
                        column: x => x.PresionId,
                        principalTable: "MaquinaPresion",
                        principalColumn: "MaquinaPreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicion_MaquinaRadiacionSolar_RadiacionSolarId",
                        column: x => x.RadiacionSolarId,
                        principalTable: "MaquinaRadiacionSolar",
                        principalColumn: "MaquinaRId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicion_MaquinaTemperatura_TemperaturaId",
                        column: x => x.TemperaturaId,
                        principalTable: "MaquinaTemperatura",
                        principalColumn: "MaquinaTId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicion_MaquinaViento_VelocidadVientoId",
                        column: x => x.VelocidadVientoId,
                        principalTable: "MaquinaViento",
                        principalColumn: "MaquinaVId",
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

            migrationBuilder.CreateTable(
                name: "Estacion",
                columns: table => new
                {
                    EstacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicionId = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Estacion_Medicion_MedicionId",
                        column: x => x.MedicionId,
                        principalTable: "Medicion",
                        principalColumn: "MedicionId",
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
                name: "IX_Estacion_MedicionId",
                table: "Estacion",
                column: "MedicionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicion_DireccionVientoId",
                table: "Medicion",
                column: "DireccionVientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicion_HumedadId",
                table: "Medicion",
                column: "HumedadId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicion_PrecipitacionId",
                table: "Medicion",
                column: "PrecipitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicion_PresionId",
                table: "Medicion",
                column: "PresionId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicion_RadiacionSolarId",
                table: "Medicion",
                column: "RadiacionSolarId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicion_TemperaturaId",
                table: "Medicion",
                column: "TemperaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicion_VelocidadVientoId",
                table: "Medicion",
                column: "VelocidadVientoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analisis");

            migrationBuilder.DropTable(
                name: "Estacion");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Medicion");

            migrationBuilder.DropTable(
                name: "MaquinaDireccion");

            migrationBuilder.DropTable(
                name: "MaquinaHumedad");

            migrationBuilder.DropTable(
                name: "MaquinaPrecipitacion");

            migrationBuilder.DropTable(
                name: "MaquinaPresion");

            migrationBuilder.DropTable(
                name: "MaquinaRadiacionSolar");

            migrationBuilder.DropTable(
                name: "MaquinaTemperatura");

            migrationBuilder.DropTable(
                name: "MaquinaViento");
        }
    }
}
