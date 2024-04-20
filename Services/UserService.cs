using System.ComponentModel.DataAnnotations;
using WeatherAPI.Context;
using WeatherAPI.Model;
using WeatherAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CORNWAY.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User?> GetUser(int id);
        Task<User> CreateUser(
            string Nombre,
            string Apellido,
            string Correo,
            string Contrasena
            );
        Task<User> PutUser(
            int UserId,
            string? Nombre,
            string? Apellido,
            string? Correo,
            string? Contrasena
            );
            

        Task<User?> DeleteUser(int id);
    }
    public class UserService(IUserRepository UserRepository) : IUserService
    {
        public async Task<User?> GetUser(int id)
        {
            return await UserRepository.GetUser(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await UserRepository.GetUsers();
        }
        public async Task<User> CreateUser(
            string Nombre,
            string Apellido,
            string Correo,
            string Contrasena
            )

        {
            return await UserRepository.CreateUser(new User
            {
                Nombre = Nombre,
                Apellido = Apellido,
                Correo = Correo,
                Contrasena = Contrasena
            });
        }
        public async Task<User> PutUser(
              int UserId,
              string? Nombre,
              string? Apellido,
              string? Correo,
              string? Contrasena
              )

        {
            User? newUser = await UserRepository.GetUser(UserId);
            if (newUser == null)
            {
                throw new Exception("User no encontrada");
            }
            else
            {
                newUser.Nombre = Nombre ?? newUser.Nombre;
                newUser.Apellido = Apellido ?? newUser.Apellido;
                newUser.Correo = Correo ?? newUser.Correo;
                newUser.Contrasena = Contrasena ?? newUser.Contrasena;
                return await UserRepository.PutUser(newUser);
            }
        }

        public async Task<User?> DeleteUser(int id)
        {
            return await UserRepository.DeleteUser(id);
        }

    }
}

