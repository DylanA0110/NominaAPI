using SharedModels.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public interface IUserRepository
    {
        Task<string> AuthenticateUserAsync(string username, string password);
        Task<bool> RegisterUserAsync(RegisterUserDTO user);
    }
}
