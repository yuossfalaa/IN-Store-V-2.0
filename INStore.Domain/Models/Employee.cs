using System.ComponentModel.DataAnnotations.Schema;

namespace INStore.Domain.Models
{
    public class Employee : DomainObject
    {
        public string? EmployeeName { get; set; }    
        public string? EmployeeAddress { get; set; }
        public string? EmployeeDescription { get; set; }
        public string? EmployeePhoneNumber { get; set; }
        public string? EmployeeJob { get; set; }
        public DateTime? EmployeeShiftStartsAt { get; set; }
        public DateTime? EmployeeShiftEndsAt { get; set; }
        public double? EmployeeSalary { get; set; }

        public int? UserId { get; set; }
        public User? user { get; set; }
    }
}
