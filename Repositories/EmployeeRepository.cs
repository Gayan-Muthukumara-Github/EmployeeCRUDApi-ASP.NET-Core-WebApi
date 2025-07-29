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


    }
}
