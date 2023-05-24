using EmployeeApp.Models;

namespace EmployeeApp.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
    }
}