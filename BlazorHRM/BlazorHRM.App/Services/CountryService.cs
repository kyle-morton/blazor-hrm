using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorHRM.App.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryById(int countryId);
    }
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;

        public CountryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            var response = await _httpClient.GetStreamAsync($"api/country");
            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>(response, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Country> GetCountryById(int countryId)
        {
            var response = await _httpClient.GetStreamAsync($"api/country{countryId}");
            return await JsonSerializer.DeserializeAsync<Country>(response, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
