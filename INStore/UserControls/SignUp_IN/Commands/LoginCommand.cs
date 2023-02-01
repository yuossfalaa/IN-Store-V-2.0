using INStore.Commands;
using INStore.Domain.Services.AuthenticationService;
using INStore.UserControls.SignUp_IN.ViewModels;
using System.Threading.Tasks;

namespace INStore.UserControls.SignUp_IN.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly LoginViewModel _loginViewModel;

        public LoginCommand(LoginViewModel loginViewModel, IAuthenticationService authenticationService)
        {
            _loginViewModel = loginViewModel;
            _authenticationService = authenticationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _authenticationService.LogIn(_loginViewModel.Username, _loginViewModel.Password);
        }
    }
}
