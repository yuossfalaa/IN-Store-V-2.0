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
        Task<RegistrationResult> Registre(string UserName,
            string Password, string AdminPassword,
            AccountState accountState, Employee employee);

        Task<User> LogIn(string UserName, string Password);
    }
}
