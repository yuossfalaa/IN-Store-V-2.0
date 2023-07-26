using System.ComponentModel.DataAnnotations.Schema;

namespace INStore.Domain.Models
{
    public class Employee : DomainObject
    {
        public string EmployeeName { get; set; } = "";    
        public string EmployeeAddress { get; set; } = "";
        public string EmployeeDescription { get; set; } = "";
        public string EmployeePhoneNumber { get; set; } = "";
        public string EmployeeJob { get; set; } = "";   
        public DateTime EmployeeShiftStartsAt { get; set; }= DateTime.Now;
        public DateTime EmployeeShiftEndsAt { get; set; } = DateTime.Now;
        public double EmployeeSalary { get; set; } = 0.0;
        public User? User { get; set; }
    }
}
