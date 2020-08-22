using BethanysPieShopHRM.Shared;
using BlazorHRM.App.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorHRM.App.Pages
{
    public class EmployeeDetailBase : ComponentBase
    {
        [Parameter]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();

        [Inject]
        private IEmployeeService _employeeService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await _employeeService.GetEmployeeDetails(int.Parse(EmployeeId));
            
        }
    }
}
