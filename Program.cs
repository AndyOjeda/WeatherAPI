using Microsoft.EntityFrameworkCore;
using WeatherAPI.Context;
//using WeatherAPI.Repositories;
//using WeatherAPI.Services;
using WeatherAPI.Context;
//using static Tabi.Services.ICropService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add connection string to the database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
