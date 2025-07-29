using System;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUDApi.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }
        public DbSet<Employee> Employees => Set<Employee>();
    }
}
