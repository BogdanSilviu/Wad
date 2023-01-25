using Wad.Models;
using Wad.Repositories.Interfaces;

namespace Wad.Services
{
    public class EmployeeService:IEmployeeService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public EmployeeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateEmployee(Employee employee)
        {
            _repositoryWrapper.EmployeeRepository.Create(employee);
            _repositoryWrapper.Save();
        }

        public void DeleteEmployee(Employee employee)
        {
            _repositoryWrapper.EmployeeRepository.Delete(employee);
            _repositoryWrapper.Save();
        }

        public Employee GetEmployeeById(int id)
        {
            return _repositoryWrapper.EmployeeRepository.FindByCondition(c=>c.Id==id).FirstOrDefault();
        }

        public List<Employee> GetEmployees()
        {
            return _repositoryWrapper.EmployeeRepository.FindAll().ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
           _repositoryWrapper.EmployeeRepository.Update(employee);
            _repositoryWrapper.Save();
        }
    }
}
