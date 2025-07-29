using Microsoft.AspNetCore.Mvc;
using EmployeeCRUDApi.Models;
using EmployeeCRUDApi.Interfaces;

namespace EmployeeCRUDApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeRepository.GetAllEmployeesAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int Id)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeByIdAsync(Id);
                if(employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> AddNewEmployee(Employee employee)
        {
            try
            {
                var createdEmployee = await _employeeRepository.AddNewEmployeeAsync(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.Id }, createdEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int Id,Employee employee)
        {
            try
            {
                if (Id != employee.Id)
                {
                    return BadRequest("Employee ID mismatch");
                }
                var existingEmployee = await _employeeRepository.ExistsEmployeeAsync(Id);
                if (!existingEmployee)
                {
                    return NotFound();
                }
                var updatedEmployee = await _employeeRepository.UpdateEmployeeAsync(employee);
                return Ok(updatedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            try
            {
                var existingEmployee = await _employeeRepository.ExistsEmployeeAsync(Id);
                if (!existingEmployee)
                {
                    return NotFound();
                }
                await _employeeRepository.DeleteEmployeeAsync(Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
