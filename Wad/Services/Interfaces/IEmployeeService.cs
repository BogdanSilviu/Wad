using Wad.Models;

namespace Wad.Services
{
    public interface IEmployeeService
    {
        void CreateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        Employee GetEmployeeById(int id);

        List<Employee> GetEmployees();

    }
}
