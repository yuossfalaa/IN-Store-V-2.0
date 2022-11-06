namespace INStore.Domain.Models
{
    public class Employees : DomainObject
    {
        public string EmployeeName { get; set; }    
        public string EmployeeAddress { get; set; }
        public string EmployeeDescription { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public string EmployeeJob { get; set; }
        public DateTime EmployeeShiftStartsAt { get; set; }
        public DateTime EmployeeShiftEndsAt { get; set; }

        public double EmployeeSalary { get; set; }


    }
}
