using EmployeeCRUDApi.Models;

namespace EmployeeCRUDApi.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int Id);
        Task<Employee> AddAsync(Employee employee);
        Task<bool> UpdateAsync(Employee employee);
        Task<bool> DeleteAsync(int Id);
        Task<bool> ExistsAsync(int Id);

    }
}
