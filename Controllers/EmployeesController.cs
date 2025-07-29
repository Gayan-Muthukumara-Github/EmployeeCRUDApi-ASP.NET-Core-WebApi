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
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            try
            {
                var employees = await _employeeRepository.GetAllAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Employee>> GetById(int Id)
        {
            try
            {
                var employee = await _employeeRepository.GetByIdAsync(Id);
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
        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            try
            {
                var createdEmployee = await _employeeRepository.AddAsync(employee);
                return CreatedAtAction(nameof(GetById), new { id = createdEmployee.Id }, createdEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<Employee>> Update (int Id,Employee employee)
        {
            try
            {
                if (Id != employee.Id)
                {
                    return BadRequest("Employee ID mismatch");
                }
                var existingEmployee = await _employeeRepository.ExistsAsync(Id);
                if (!existingEmployee)
                {
                    return NotFound();
                }
                var updatedEmployee = await _employeeRepository.UpdateAsync(employee);
                return Ok(updatedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var existingEmployee = await _employeeRepository.ExistsAsync(Id);
                if (!existingEmployee)
                {
                    return NotFound();
                }
                await _employeeRepository.DeleteAsync(Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
