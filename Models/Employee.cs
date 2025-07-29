using System.ComponentModel.DataAnnotations;

namespace EmployeeCRUDApi.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't exceed 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        [StringLength(50, ErrorMessage = "Department can't exceed 50 characters.")]
        public string? Department { get; set; }

        [Required(ErrorMessage = "Position is required.")]
        [StringLength(50, ErrorMessage = "Position can't exceed 50 characters.")]
        public string? Position { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public decimal Salary { get; set; }


    }
}
