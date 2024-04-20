using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI.Model;
using WeatherAPI.Repositories;

namespace WeatherAPI.Servicios
{
    public interface IUserServicio
    {
        Task<List<User>> GetAll();
        Task<User?> GetUser(int id);
        Task<User> AddUser(
                                   
                    string Nombre, 
                                                          
                    string Apellido, 
                                                                                 
                    string Email, 
                                                                                                        
                    string Password);
        public async Task<User> UpdateUser(
            string Nombre,
            string Apellido,
            string Email,
            string Password)
        {
            if (Nombre == null)
            {
                throw new ArgumentNullException(nameof(Nombre));
            }
            if (Apellido == null)
            {
                throw new ArgumentNullException(nameof(Apellido));
            }
            if (Email == null)
            {
                throw new ArgumentNullException(nameof(Email));
            }
            if (Password == null)
            {
                throw new ArgumentNullException(nameof(Password));
            }
            return await _userRepository.UpdateUser(user);
        }

        Task<User?> DeleteUser(int id);
    }
    public class UserService
    {
    }
}
