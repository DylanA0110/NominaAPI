using Newtonsoft.Json;
using SharedModels.Dto;
using SharedModels.Entities;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UIPayroll.Repositorios
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public UserRepository(HttpClient httpClient, string endpoint)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
        }

        public async Task RegisterUserAsync(RegisterUserDTO userDto)
        {
            var json = JsonConvert.SerializeObject(userDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_endpoint}/register", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to register user: {errorMessage}");
            }
        }

        public async Task<bool> ValidateUserAsync(string username, string password)
        {
            var loginDto = new LoginUserDTO
            {
                UserName = username,
                Password = password
            };

            var json = JsonConvert.SerializeObject(loginDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_endpoint, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<User> GetUserByUserNameAsync(string username)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/users/{username}");

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(responseData);
            }
            else
            {
                return null; // Devuelve null si no se encuentra el usuario o hay un error
            }
        }

        public async Task<string> AuthenticateUserAsync(string username, string password)
        {
            var loginDto = new LoginUserDTO
            {
                UserName = username,
                Password = password
            };

            var json = JsonConvert.SerializeObject(loginDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<dynamic>(responseData).token;
            }
            else
            {
                throw new Exception("Invalid credentials");
            }
        }
    }
}
