namespace INStore.Domain.Models
{
    public class Users : DomainObject
    {
        public string UserName { get; set; } 
        public string Password { get; set; } 
        public string AdminPassword { get; set; } 
        public bool AccountState { get; set; }
        public string EmployeeName { get; set; }
    


    }
}
