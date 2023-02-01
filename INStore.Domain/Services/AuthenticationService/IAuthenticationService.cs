using INStore.Domain.Models;

namespace INStore.Domain.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        public enum RegistrationResult
        {
            Success,
            AdminPasswordDoNotMatch,
            UsernameAlreadyExists
        }
        User user { get; }
        Task<RegistrationResult> Registre(string UserName,
            string Password, string AdminPassword,
            string AccountState, string EmployeeName);

        Task<User> LogIn(string UserName, string Password);
    }
}
