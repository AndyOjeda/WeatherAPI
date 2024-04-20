﻿using WeatherAPI.Context;
using WeatherAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WeatherAPI.Repositories
{

    public interface IEstadoRepository
    {
        Task<List<Estado>> GetAll();
        Task<Estado?> GetEstado(int id);
        Task<Estado> AddEstado(
            string EstadoActual,

            );
        Task<Estado> UpdateEstado(Estado Estado);
        Task<Estado?> DeleteEstado(int id);
    }

    public class EstadoRepository : IEstadoRepository
    {
        private readonly AppDbContext _context;

        public EstadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Estado>> GetAll()
        {
            return await _context.Estado.ToListAsync();
        }

        public async Task<Estado?> GetEstado(int id)
        {
            return await _context.Estado.FindAsync(id);
        }

        public async Task<Estado> AddEstado(
            string EstadoName,
            int EstadoAmount
        )
        {
            Estado Estado = new Estado
            {
                EstadoActual = EstadoActual,
                IsDeleted = false
            };
            _context.Estado.Add(Estado);
            await _context.SaveChangesAsync();
            return Estado;
        }

        public async Task<Estado> UpdateEstado(Estado Estado)
        {
            _context.Estado.Update(Estado);
            await _context.SaveChangesAsync();
            return Estado;
        }

        public async Task<Estado?> DeleteEstado(int id)
        {
            Estado? Estado = await _context.Estado.FindAsync(id);
            if (Estado != null)
            {
                Estado.IsDeleted = true;
                _context.Estado.Update(Estado);
                await _context.SaveChangesAsync();
            }
            return Estado;
        }
    }
}