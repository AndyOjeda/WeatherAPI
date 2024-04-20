using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherAPI.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Medicion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MaquinaViento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MaquinaTemperatura",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MaquinaRadiacionSolar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MaquinaPresion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MaquinaPrecipitacion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MaquinaHumedad",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MaquinaDireccion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Estado",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Estacion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Analisis",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Medicion");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MaquinaViento");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MaquinaTemperatura");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MaquinaRadiacionSolar");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MaquinaPresion");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MaquinaPrecipitacion");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MaquinaHumedad");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MaquinaDireccion");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Estacion");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Analisis");
        }
    }
}
