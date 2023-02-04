using INStore.Commands;
using INStore.Domain.Exceptions;
using INStore.State.Authenticators;
using INStore.State.Navigators;
using INStore.UserControls.SignUp_IN.ViewModels;
using System.Threading.Tasks;

namespace INStore.UserControls.SignUp_IN.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticators _authenticators;
        private readonly IRenavigator _renavigator;

        public LoginCommand(LoginViewModel loginViewModel, IAuthenticators authenticators, IRenavigator Renavigator)
        {
            _authenticators = authenticators;
            _renavigator = Renavigator;
            _loginViewModel = loginViewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                //await _authenticators.Login(_loginViewModel.Username, _loginViewModel.Password);

                _renavigator.Renavigate();
            }
            catch (UserNotFoundException)
            {

            }
        }
    }
}
