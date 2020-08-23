using BethanysPieShopHRM.Shared;
using BlazorHRM.App.Components;
using BlazorHRM.App.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorHRM.App.Pages
{
    public partial class EmployeeOverviewBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }

        [Inject]
        private IEmployeeService _employeeService { get; set; }

        // instance of child-component in .razor
        protected AddEmployeeDialog AddEmployeeDialog { get; set; }

        // Life-cycle method called on page-init
        protected async override Task OnInitializedAsync()
        {
            Employees = await _employeeService.GetAllEmployees();
        }

        protected void QuickAddEmployee()
        {
            AddEmployeeDialog.Show();
        }

        protected async Task AddEmployeeDialog_OnDialogClose()
        {
            // reload employees and refresh UI
            Employees = (await _employeeService.GetAllEmployees()).ToList();
            StateHasChanged();
        }

    }
}
