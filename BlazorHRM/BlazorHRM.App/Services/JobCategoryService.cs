using BethanysPieShopHRM.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorHRM.App.Services
{
    public interface IJobCategoryService
    {
        Task<IEnumerable<JobCategory>> GetAllJobCategories();
        Task<JobCategory> GetJobCategoryById(int jobCategoryId);
    }
    public class JobCategoryService : IJobCategoryService
    {
        private readonly HttpClient _httpClient;

        public JobCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<JobCategory>> GetAllJobCategories()
        {
            var response = await _httpClient.GetStreamAsync($"api/jobcategory");
            return await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>(response, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<JobCategory> GetJobCategoryById(int jobCategoryId)
        {
            return await JsonSerializer.DeserializeAsync<JobCategory>
                (await _httpClient.GetStreamAsync($"api/jobcategory/{jobCategoryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
