using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI.Model;
using WeatherAPI.Repositories;

namespace WeatherAPI.Servicios
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User?> GetUser(int id);
        Task<User> CreateUser(string Nombre,
            string Apellido,
            string Correo,
            string Contrasena);
        Task<User> UpdateUser(int UserId, string Nombre,
            string Apellido,
            string Correo,
            string Contrasena);
        Task<User?> DeleteUser(int id);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<List<User>> GetAll()
        {
            return await _UserRepository.GetAll();
        }

        public async Task<User?> GetUser(int id)
        {
            return await _UserRepository.GetUser(id);
        }

        public async Task<User> CreateUser(
            string Nombre,
            string Apellido,
            string Correo,
            string Contrasena)
        {
            return await _UserRepository.CreateUser(Nombre, Apellido, Correo, Contrasena);
        }

        public async Task<User> UpdateUser(int UserId, string Nombre,
            string Apellido,
            string Correo,
            string Contrasena)
        {
            User? User = await _UserRepository.GetUser(UserId);
            if (User == null)
            {
                throw new Exception("User no encontrado");
            }

            User.Nombre = Nombre;
            User.Apellido = Apellido;
            User.Correo = Correo;
            User.Contrasena = Contrasena;

            return await _UserRepository.UpdateUser(User);
        }

        public async Task<User?> DeleteUser(int id)
        {
            return await _UserRepository.DeleteUser(id);
        }
    }
}


