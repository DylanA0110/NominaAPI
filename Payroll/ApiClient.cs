using Payroll.Repository;
using SharedModels.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Payroll
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        public IRepository<EmployeeDTO> Employees { get; }
        public IRepository<DeductionDTO> Deductions { get; }
        public IRepository<IncomeDTO> Incomes { get; }
        public IRepository<PayrollDTO> Payrolls { get; }
        public IUserRepository LoginUsers { get; }
        public IUserRepository registerUsers { get; }

        public ApiClient()
        {
            string apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            _httpClient = new HttpClient { BaseAddress = new Uri(apiBaseUrl) };
            Employees = new Repository<EmployeeDTO>(_httpClient, "Employee");
            Deductions = new Repository<DeductionDTO>(_httpClient, "Deduction");
            Incomes = new Repository<IncomeDTO>(_httpClient, "Income");
            Payrolls = new Repository<PayrollDTO>(_httpClient, "Payroll");
            LoginUsers = new UserRepository(_httpClient, "Auth/login");
            registerUsers = new UserRepository(_httpClient, "Auth/register");

        }
        public void SetAuthToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<string> RegisterUserAndGetTokenAsync(RegisterUserDTO user)
        {
            try
            {
                var token = await registerUsers.RegisterUserAsync(user);
                return token;
            }
            catch (Exception ex)
            {
                throw new Exception($"Registration failed: {ex.Message}");
            }
        }

    }
}
