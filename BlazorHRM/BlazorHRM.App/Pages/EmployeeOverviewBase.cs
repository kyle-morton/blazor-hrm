using BethanysPieShopHRM.Shared;
using BlazorHRM.App.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorHRM.App.Pages
{
    public partial class EmployeeOverviewBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }

        [Inject]
        private IEmployeeService _employeeService { get; set; }

        // Life-cycle method called on page-init
        protected async override Task OnInitializedAsync()
        {
            Employees = await _employeeService.GetAllEmployees();
        }


    }
}
