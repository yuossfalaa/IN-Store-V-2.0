using INStore.Commands;
using INStore.Domain.Models;
using INStore.State.Authenticators;
using INStore.State.Navigators;
using INStore.State.UserStore;
using INStore.UserControls.SignUp_IN.Commands;
using INStore.ViewModels;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace INStore.UserControls.SignUp_IN.ViewModels
{
    public class RegisterEmployeeViewModel : ViewModelBase
    {
        private readonly ILogger<RegisterEmployeeViewModel> _RegisterEmployeeViewModelLogger;
        private readonly IRenavigator RegisterRenavigator;
        private readonly IRenavigator LoginRenavigator;
        private readonly IInRegistrationUser _InRegistrationUser;
        private readonly IAuthenticators _Authenticators;
        private readonly ISnackbarMessageQueue snackbarMessageQueue;

        private User _currentUser;

        public User CurrentUser
        {
            get { return _currentUser; }
            set 
            { 
                _currentUser = value;
                _InRegistrationUser.RegisteringUser = _currentUser;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }
        public ICommand RegisterRenavigatCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public RegisterEmployeeViewModel(ILogger<RegisterEmployeeViewModel> registerEmployeeViewModelLogger,
            ViewModelDelegateRenavigator<RegisterViewModel> registerRenavigator,
            ViewModelDelegateRenavigator<LoginViewModel> loginRenavigator,
            IInRegistrationUser inRegistrationUser,
            IAuthenticators authenticators, 
            ISnackbarMessageQueue snackbarMessageQueue)
        {
            _RegisterEmployeeViewModelLogger = registerEmployeeViewModelLogger;
            RegisterRenavigator = registerRenavigator;
            _InRegistrationUser = inRegistrationUser;
            _Authenticators = authenticators;
            this.snackbarMessageQueue = snackbarMessageQueue;
            LoginRenavigator = loginRenavigator;
            CurrentUser = _InRegistrationUser.RegisteringUser;
            RegisterRenavigatCommand = new RenavigateCommand(RegisterRenavigator);
            RegisterCommand = new RegisterCommand(_Authenticators, _InRegistrationUser, LoginRenavigator, snackbarMessageQueue, _RegisterEmployeeViewModelLogger);

            _RegisterEmployeeViewModelLogger.Log(LogLevel.Information, "RegisterEmployeeViewModel Initialized");
        }
    }
}
