using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorHRM.App.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeDetails(int employeeId);
        Task<Employee> AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);

    }
    public class EmployeeService : IEmployeeService
    {

        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var response = await _httpClient.GetStreamAsync($"api/employee");
            return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(response, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Employee> GetEmployeeDetails(int employeeId)
        {
            var response = await _httpClient.GetStreamAsync($"api/employee/{employeeId}");
            return await JsonSerializer.DeserializeAsync<Employee>(response, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var employeeJson = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/employee", employeeJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var employeeJson = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/employee", employeeJson);
        }

        public async Task DeleteEmployee(int employeeId)
        {
            await _httpClient.DeleteAsync($"api/employee/{employeeId}");
        }

    }
}
