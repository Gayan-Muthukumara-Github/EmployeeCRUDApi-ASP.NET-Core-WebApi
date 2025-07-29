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

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int Id)
        { 
            return await _context.Employees.FindAsync(Id);
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return await ExistsAsync(employee.Id);
            }
        }

        public async Task<bool> DeleteAsync(int Id)
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
        
        public async Task<bool> ExistsAsync(int Id)
        {
            return await _context.Employees.AnyAsync(e => e.Id == Id);
        }

    }
}
