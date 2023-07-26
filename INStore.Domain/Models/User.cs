namespace INStore.Domain.Models
{
    public enum AccountState
    {
        Admin,
        Employee
    }
    public class User : DomainObject
    {
        public string UserName { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string AdminPasswordHash { get; set; } = "";
        public AccountState AccountState { get; set; } = AccountState.Employee;
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();
        public int SettingsId { get; set; }
        public Settings Settings { get; set; } = new Settings();

    }
}
