using Microsoft.EntityFrameworkCore;
using EmployeeCRUDApi.Interfaces;
using EmployeeCRUDApi.Models;

namespace EmployeeCRUDApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int Id)
        { 
            return await _context.Employees.FindAsync(Id);
        }

        public async Task<Employee> AddNewEmployeeAsync(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            if (!await ExistsEmployeeAsync(employee.Id))
            {
                return false;
            } 
            _context.Entry(employee).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return await ExistsEmployeeAsync(employee.Id);
            }
        }

        public async Task<bool> DeleteEmployeeAsync(int Id)
        {
            var employee = await _context.Employees.FindAsync(Id);
            if(employee == null) 
            {
                return false;
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;

        }
        
        public async Task<bool> ExistsEmployeeAsync(int Id)
        {
            if (Id <= 0)
            {
                return false;
            }  
            return await _context.Employees.AnyAsync(e => e.Id == Id);
        }

    }
}
