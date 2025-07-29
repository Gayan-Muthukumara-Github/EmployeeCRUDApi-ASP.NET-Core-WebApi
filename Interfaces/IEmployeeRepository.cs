using EmployeeCRUDApi.Models;

namespace EmployeeCRUDApi.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int Id);
        Task<Employee> AddNewEmployeeAsync(Employee employee);
        Task<bool> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(int Id);
        Task<bool> ExistsEmployeeAsync(int Id);

    }
}
