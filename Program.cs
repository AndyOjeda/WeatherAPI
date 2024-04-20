
using Microsoft.EntityFrameworkCore;
using WeatherAPI.Context;
using WeatherAPI.Repositories;
using WeatherAPI.Services;

//using static Tabi.Services.ICropService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add connection string to the database
var connString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repositories
builder.Services.AddScoped<IAnalisisRepository, AnalisisRepository>();
builder.Services.AddScoped<IEstacionRepository, EstacionRepository>();
builder.Services.AddScoped<IMedicionRepository, MedicionRepository>();
builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMaquinaDireccionRepository, MaquinaDireccionRepository>();
builder.Services.AddScoped<IMaquinaHumedadRepository, MaquinaHumedadRepository>();
builder.Services.AddScoped<IMaquinaTempeRepository, MaquinaTempeRepository>();
builder.Services.AddScoped<IMaquinaPresionRepository, MaquinaPresionRepository>();
builder.Services.AddScoped<IMaquinaPrecipiRepository, MaquinaPrecipiRepository>();
builder.Services.AddScoped<IMaquinaRadiaRepository, MaquinaRadiaRepository>();
builder.Services.AddScoped<IMaquinaVientoRepository, MaquinaVientoRepository>();

//Services
builder.Services.AddScoped<IAnalisisService, AnalisisService>();
builder.Services.AddScoped<IEstacionService, EstacionService>();
builder.Services.AddScoped<IMedicionService, MedicionService>();
builder.Services.AddScoped<IEstadoService, EstadoService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMaquinaDireccionService, MaquinaDireccionService>();
builder.Services.AddScoped<IMaquinaHumedadService, MaquinaHumedadService>();
builder.Services.AddScoped<IMaquinaTempeService, MaquinaTempeService>();
builder.Services.AddScoped<IMaquinaPresionService, MaquinaPresionService>();
builder.Services.AddScoped<IMaquinaPrecipiService, MaquinaPrecipiService>();
builder.Services.AddScoped<IMaquinaRadiaService, MaquinaRadiaService>();
builder.Services.AddScoped<IMaquinaVientoService, MaquinaVientoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
