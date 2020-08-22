using BlazorHRM.App.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BlazorHRM.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            // inject pre-configured http client for each service
            builder.Services.AddHttpClient<IEmployeeService, EmployeeService>(client => { client.BaseAddress = new Uri("https://localhost:44340/"); });
            builder.Services.AddHttpClient<ICountryService, CountryService>(client => { client.BaseAddress = new Uri("https://localhost:44340/"); });
            builder.Services.AddHttpClient<IJobCategoryService, JobCategoryService>(client => { client.BaseAddress = new Uri("https://localhost:44340/"); });

            await builder.Build().RunAsync();
        }
    }
}
