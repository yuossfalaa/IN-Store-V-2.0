using INStore.Commands;
using INStore.State.Authenticators;
using INStore.State.Navigators;
using INStore.UserControls.SignUp_IN.Commands;
using INStore.ViewModels;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;
using System.Windows.Input;

namespace INStore.UserControls.SignUp_IN.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly ILogger<LoginViewModel> _LoginViewModelLogger;
        private readonly IAuthenticators _Authenticators;
        private readonly IRenavigator _loginRenavigator;
        private readonly IRenavigator _registerRenavigator;
        private readonly ISnackbarMessageQueue snackbarMessageQueue;

        public LoginViewModel(ILogger<LoginViewModel> loginViewModelLogger,
                              IAuthenticators authenticators,
                              IRenavigator loginRenavigator,
                              IRenavigator registerRenavigator,
                              ISnackbarMessageQueue snackbarMessageQueue)
        {
            _Authenticators = authenticators;
            _loginRenavigator = loginRenavigator;
            _registerRenavigator = registerRenavigator;
            _LoginViewModelLogger = loginViewModelLogger;
            this.snackbarMessageQueue = snackbarMessageQueue;
            LoginCommand = new LoginCommand(this, authenticators, loginRenavigator, snackbarMessageQueue, _LoginViewModelLogger);
            RegisterCommand = new RenavigateCommand(registerRenavigator);
            _LoginViewModelLogger.Log(LogLevel.Information, "LoginViewModel Initialized");
        }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        private string _Username;
        public string Username
        {
            get { return _Username; }
            set 
            { 
                _Username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public override void Dispose()
        {
            base.Dispose();
        }




    }
}
