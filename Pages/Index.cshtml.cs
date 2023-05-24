using EmployeeApp.Models;
using EmployeeApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeApp.Pages
{
    public class IndexModel : PageModel
    {

        public List<Employee> employees;
        public readonly IEmployeeService _employeeService;

        public IndexModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public void OnGet()
        {
            employees = _employeeService.GetEmployees();
        }
    }
}