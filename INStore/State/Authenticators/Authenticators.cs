using INStore.Domain.Models;
using INStore.Domain.Services.AuthenticationService;
using INStore.State.UserStore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static INStore.Domain.Services.AuthenticationService.IAuthenticationService;

namespace INStore.State.Authenticators
{
    public class Authenticators : IAuthenticators
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserStore _userStore;

        public Authenticators(IUserStore userStore, IAuthenticationService authenticationService)
        {
            _userStore = userStore;
            _authenticationService = authenticationService;
        }
        public User CurrentUser
        {
            get
            {
                return _userStore.CurrentUser;
            }
            set
            {
                _userStore.CurrentUser = value;
                StateChanged?.Invoke();
            }
        }
        public bool IsLoggedIn => CurrentUser != null;
        public event Action StateChanged;
        public async Task Login(string UserName, string Password)
        {
            CurrentUser = await _authenticationService.LogIn(UserName, Password);
        }
        public void Logout()
        {
            CurrentUser = null;
        }
        public async Task<RegistrationResult> Register(string UserName, string Password, string AdminPassword, string AccountState, string EmployeeName)
        {
            return await _authenticationService.Registre(UserName, Password, AdminPassword, AccountState, EmployeeName);
        }

    }
}
