using INStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string AccountState, string EmployeeName);

        Task<User> LogIn(string UserName, string Password);
    }
}
