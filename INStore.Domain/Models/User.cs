namespace INStore.Domain.Models
{
    public class User : DomainObject
    {
        public string? UserName { get; set; } 
        public string? PasswordHash { get; set; } 
        public string? AdminPasswordHash { get; set; } 
        public bool? AccountState { get; set; }
        public string? EmployeeName { get; set; }
    


    }
}
