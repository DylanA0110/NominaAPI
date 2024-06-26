using SharedModels.Dto;
using SharedModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIPayroll.Repositorios
{
    public interface IUserRepository
    {
        Task<string> AuthenticateUserAsync(string username, string password);
        Task RegisterUserAsync(RegisterUserDTO user);
        Task<bool> ValidateUserAsync(string username, string password);
        Task<User> GetUserByUserNameAsync(string username);
    }
}
