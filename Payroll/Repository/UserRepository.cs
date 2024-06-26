using Newtonsoft.Json;
using SharedModels.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public UserRepository(HttpClient httpClient,
            string endpoint)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
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

        public async Task<string> RegisterUserAsync(RegisterUserDTO user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<dynamic>(responseData).token;
                return token;
            }
            else
            {
                throw new Exception($"Failed to register user. Server returned status code: {response.StatusCode}");
            }
        }

      
    }
}
