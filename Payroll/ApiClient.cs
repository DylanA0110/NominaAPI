using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Payroll.Repository;
using SharedModels.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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
        private readonly string _baseUrl;

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
            _baseUrl = apiBaseUrl;
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

       

        public async Task<List<EmployeeDTO>> SearchEmployeesAsync(string searchTerm)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}/api/Employees/search?searchTerm={searchTerm}");

                response.EnsureSuccessStatusCode(); // Throws exception on error

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<EmployeeDTO>>(content);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al buscar empleados: {ex.Message}");
            }
        }
        public async Task<List<DeductionDTO>> GetAllDeductionsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Deduction");

                response.EnsureSuccessStatusCode(); // Lanza una excepción en caso de error HTTP

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<DeductionDTO>>(content);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al obtener todas las deducciones: {ex.Message}");
            }
        }
        public async Task<List<IncomeDTO>> GetIncomesByPayrollIdAsync(int payrollId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Income/GetByPayrollId/{payrollId}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<IncomeDTO>>(content);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return new List<IncomeDTO>(); // Devolver lista vacía si no se encontraron ingresos
                }
                else
                {
                    throw new Exception($"Error al obtener ingresos por PayrollId {payrollId}: {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de solicitud HTTP al obtener ingresos por PayrollId {payrollId}: {ex.Message}");
            }
        }
        public async Task<DeductionDTO> GetDeductionByPayrollIdAsync(int payrollId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Deduction/{payrollId}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DeductionDTO>(content);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null; // Si no se encuentra la deducción
                }
                else
                {
                    throw new Exception($"Error al obtener la deducción para la nómina con ID {payrollId}: {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de solicitud HTTP al obtener la deducción para la nómina con ID {payrollId}: {ex.Message}");
            }
        }
        public async Task<List<DeductionDTO>> GetDeductionsByPayrollIdAsync(int payrollId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Deduction/GetByPayrollId/{payrollId}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<DeductionDTO>>(content);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return new List<DeductionDTO>(); // Devolver lista vacía si no se encontraron deducciones
                }
                else
                {
                    throw new Exception($"Error al obtener deducciones por PayrollId {payrollId}: {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de solicitud HTTP al obtener deducciones por PayrollId {payrollId}: {ex.Message}");
            }
        }
        // Método para obtener una deducción por su ID
        public async Task<IncomeDTO> GetIncomeByPayrollIdAsync(int payrollId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Income/{payrollId}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IncomeDTO>(content);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null; // Devolver null si no se encontró ningún ingreso
                }
                else
                {
                    throw new Exception($"Error al obtener ingresos por PayrollId {payrollId}: {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de solicitud HTTP al obtener ingresos por PayrollId {payrollId}: {ex.Message}");
            }
        }

        // Método para crear una nueva deducción
        public async Task<DeductionDTO> CreateDeductionAsync(DeductionCreateDTO deductionDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Deduction", deductionDto);

                response.EnsureSuccessStatusCode(); // Lanza una excepción en caso de error HTTP

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DeductionDTO>(content);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al crear la deducción: {ex.Message}");
            }
        }

        // Método para actualizar una deducción existente
        public async Task UpdateDeductionAsync(int deductionId, DeductionUpdateDTO updateDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Deduction/{deductionId}", updateDto);

                response.EnsureSuccessStatusCode(); // Lanza una excepción en caso de error HTTP
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al actualizar la deducción con ID {deductionId}: {ex.Message}");
            }
        }

        // Método para eliminar una deducción por su ID
        public async Task DeleteDeductionAsync(int deductionId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Deduction/{deductionId}");

                response.EnsureSuccessStatusCode(); // Lanza una excepción en caso de error HTTP
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al eliminar la deducción con ID {deductionId}: {ex.Message}");
            }
        }
        public async Task<List<IncomeDTO>> GetAllIncomesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Income");

                response.EnsureSuccessStatusCode(); // Lanza una excepción en caso de error HTTP

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<IncomeDTO>>(content);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al obtener todos los ingresos: {ex.Message}");
            }
        }

        // Método para obtener un ingreso por su ID
        public async Task<IncomeDTO> GetIncomeByIdAsync(int incomeId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Income/{incomeId}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IncomeDTO>(content);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null; // Si no se encuentra el ingreso
                }
                else
                {
                    throw new Exception($"Error al obtener el ingreso con ID {incomeId}: {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de solicitud HTTP al obtener el ingreso con ID {incomeId}: {ex.Message}");
            }
        }

        // Método para crear un nuevo ingreso
        public async Task<IncomeDTO> CreateIncomeAsync(IncomeCreateDTO createDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Income", createDto);

                response.EnsureSuccessStatusCode(); // Lanza una excepción en caso de error HTTP

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IncomeDTO>(content);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al crear el ingreso: {ex.Message}");
            }
        }

        // Método para actualizar un ingreso existente
        public async Task UpdateIncomeAsync(int incomeId, IncomeUpdateDTO updateDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Income/{incomeId}", updateDto);

                response.EnsureSuccessStatusCode(); // Lanza una excepción en caso de error HTTP
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al actualizar el ingreso con ID {incomeId}: {ex.Message}");
            }
        }

        // Método para eliminar un ingreso por su ID
        public async Task DeleteIncomeAsync(int incomeId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Income/{incomeId}");

                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al eliminar el ingreso con ID {incomeId}: {ex.Message}");
            }
        }
        public async Task<List<PayrollDTO>> GetAllPayrollsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Payroll");

                response.EnsureSuccessStatusCode(); // Lanza una excepción en caso de error HTTP

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<PayrollDTO>>(content);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al obtener todas las nóminas: {ex.Message}");
            }
        }

        public async Task<PayrollDTO> GetPayrollByIdAsync(int payrollId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Payroll/{payrollId}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PayrollDTO>(content);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null; // Si no se encuentra la nómina
                }
                else
                {
                    throw new Exception($"Error al obtener la nómina con ID {payrollId}: {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de solicitud HTTP al obtener la nómina con ID {payrollId}: {ex.Message}");
            }
        }

        public async Task<PayrollDTO> CreatePayrollAsync(PayrollCreateDTO createDto, int overTime)
        {
            try
            {
                // Construir la URL completa con el parámetro de consulta
                string apiUrl = $"api/Payroll?overTime={overTime}";

                // Enviar solicitud POST al API con los datos necesarios en el cuerpo
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiUrl, createDto);

                response.EnsureSuccessStatusCode(); // Asegurar que la solicitud fue exitosa

                // Leer el contenido de la respuesta como una cadena JSON
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserializar el contenido JSON en un objeto PayrollDTO
                var payroll = System.Text.Json.JsonSerializer.Deserialize<PayrollDTO>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Opción para ignorar mayúsculas y minúsculas en los nombres de propiedad
                });

                return payroll;
            }
            catch (HttpRequestException ex)
            {
                // Manejar errores de la solicitud HTTP
                throw new ApplicationException($"Error al crear la nómina: {ex.Message}");
            }
        }

        public async Task UpdatePayrollAsync(int payrollId, PayrollUpdateDTO updateDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Payroll/{payrollId}", updateDto);

                response.EnsureSuccessStatusCode(); // Lanza una excepción en caso de error HTTP
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al actualizar la nómina con ID {payrollId}: {ex.Message}");
            }
        }

        public async Task DeletePayrollAsync(int payrollId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Payroll/{payrollId}");

                response.EnsureSuccessStatusCode(); // Lanza una excepción en caso de error HTTP
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error al eliminar la nómina con ID {payrollId}: {ex.Message}");
            }
        }



    }





}

