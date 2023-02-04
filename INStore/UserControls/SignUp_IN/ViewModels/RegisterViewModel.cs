using INStore.State.Authenticators;
using INStore.State.Navigators;
using INStore.ViewModels;
using Microsoft.Extensions.Logging;

namespace INStore.UserControls.SignUp_IN.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly ILogger<RegisterViewModel> _RegisterViewModelLogger;
        private readonly IAuthenticators _Authenticators;
        private readonly IRenavigator _loginRenavigator;
        public RegisterViewModel(
            ILogger<RegisterViewModel> RegisterViewModelLogger, 
            IAuthenticators authenticators,
            IRenavigator loginRenavigator)
        {
            _RegisterViewModelLogger = RegisterViewModelLogger;
            _Authenticators = authenticators;
            _loginRenavigator = loginRenavigator;
        }
    }
}
