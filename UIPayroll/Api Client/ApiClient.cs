using SharedModels.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UIPayroll.Repositorios;

namespace UIPayroll.Api_Client
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        IRepository<EmployeeDTO> Employees { get; }
        IRepository<DeductionDTO> Deductions { get; }
        IRepository<IncomeDTO> Incomes { get; }
        IRepository<PayrollDTO> Payrolls { get; }
        public IUserRepository UserRepo { get; }

        public ApiClient()
        {
            string apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            _httpClient = new HttpClient { BaseAddress = new Uri(apiBaseUrl) };
            Employees = new Repository<EmployeeDTO>(_httpClient, "Employee");
            Deductions = new Repository<DeductionDTO>(_httpClient, "Deduction");
            Incomes = new Repository<IncomeDTO>(_httpClient, "Income");
            Payrolls = new Repository<PayrollDTO>(_httpClient, "Payroll");
            UserRepo = new UserRepository(_httpClient, "Auth");

        }
        public void SetAuthToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<bool> RegisterUserAsync(RegisterUserDTO userDto)
        {
            try
            {
                await UserRepo.RegisterUserAsync(userDto);
                return true;
            }
            catch (Exception ex)
            {
                // Manejo de errores o logging según sea necesario
                Console.WriteLine($"Error registering user: {ex.Message}");
                return false;
            }
        }
    }
}

