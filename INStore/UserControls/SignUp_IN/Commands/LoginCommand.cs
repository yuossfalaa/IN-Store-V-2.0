using INStore.Commands;
using INStore.Domain.Services.AuthenticationService;
using INStore.State.Authenticators;
using INStore.UserControls.SignUp_IN.ViewModels;
using System.Threading.Tasks;

namespace INStore.UserControls.SignUp_IN.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticators _authenticators;

        public LoginCommand(LoginViewModel loginViewModel, IAuthenticators authenticators)
        {
            _authenticators = authenticators;
            _loginViewModel = loginViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _authenticators.Login(_loginViewModel.Username, _loginViewModel.Password);
        }
    }
}
