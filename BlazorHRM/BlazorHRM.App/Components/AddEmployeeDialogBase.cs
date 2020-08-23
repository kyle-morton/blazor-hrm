using BethanysPieShopHRM.Shared;
using BlazorHRM.App.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorHRM.App.Components
{
    public partial class AddEmployeeDialogBase : ComponentBase
    {
        public Employee Employee { get; set; } = new Employee
        {
            CountryId = 1,
            JobCategoryId = 1,
            BirthDate = DateTime.Now,
            JoinedDate = DateTime.Now
        };

        [Inject]
        public IEmployeeService _employeeService { get; set; }

        public bool ShowDialog { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged(); // tells razor to re-draw the component & refresh the UI
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
        }

        protected async Task HandleValidSubmit()
        {
            await _employeeService.AddEmployee(Employee);
            ShowDialog = false;

            // tell parent that something has changed
            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }

    }
}
