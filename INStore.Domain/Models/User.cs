namespace INStore.Domain.Models
{
    public enum AccountState
    {
        Admin,
        Employee
    }
    public class User : DomainObject
    {
        public string? UserName { get; set; } 
        public string? PasswordHash { get; set; } 
        public string? AdminPasswordHash { get; set; } 
        public AccountState? AccountState { get; set; }
        public Employee employee { get; set; }    


    }
}
