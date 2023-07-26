using INStore.Commands;
using INStore.Domain.Models;
using INStore.State.Authenticators;
using INStore.State.Navigators;
using INStore.State.UserStore;
using INStore.UserControls.Home.ViewModels;
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
        private readonly IInRegistrationUser _inRegistrationUser;
        private User _currentUser;

        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public LoginViewModel(ILogger<LoginViewModel> loginViewModelLogger, IAuthenticators authenticators,
            ViewModelDelegateRenavigator<HomeViewModel> loginRenavigator, ViewModelDelegateRenavigator<RegisterViewModel> registerRenavigator, 
            ISnackbarMessageQueue snackbarMessageQueue, IInRegistrationUser inRegistrationUser)
        {
            _Authenticators = authenticators;
            _loginRenavigator = loginRenavigator;
            _registerRenavigator = registerRenavigator;
            _LoginViewModelLogger = loginViewModelLogger;
            this.snackbarMessageQueue = snackbarMessageQueue;
            _inRegistrationUser = inRegistrationUser;


            CurrentUser = new User();
            LoginCommand = new LoginCommand(this, authenticators, loginRenavigator, snackbarMessageQueue, _LoginViewModelLogger);
            RegisterCommand = new RenavigateCommand(registerRenavigator);
            _inRegistrationUser.RegisteringUser = new User();

            _LoginViewModelLogger.Log(LogLevel.Information, "LoginViewModel Initialized");

        }


        public override void Dispose()
        {
            base.Dispose();
        }




    }
}
