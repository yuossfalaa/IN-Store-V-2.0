using INStore.Commands;
using INStore.Domain.Models;
using INStore.State.Authenticators;
using INStore.State.Navigators;
using INStore.State.UserStore;
using INStore.ViewModels;
using Microsoft.Extensions.Logging;
using System.Windows.Input;

namespace INStore.UserControls.SignUp_IN.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly ILogger<RegisterViewModel> _RegisterViewModelLogger;
        private readonly IRenavigator RegisterEmployeeRenavigator;
        private readonly IRenavigator _loginRenavigator;
        private readonly IInRegistrationUser _InRegistrationUser;

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
        private bool _IsEmployee;

        public bool IsEmployee
        {
            get { return _IsEmployee; }
            set
            { 
                _IsEmployee = value;
                OnPropertyChanged(nameof(IsEmployee));
                if (IsEmployee) _currentUser.AccountState = AccountState.Employee;
            }
        }
        private bool _IsAdmin;

        public bool IsAdmin
        {
            get { return _IsAdmin; }
            set 
            { 
                _IsAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
                if (IsAdmin) _currentUser.AccountState = AccountState.Admin;
            }
        }


        public ICommand LoginRenavigatCommand { get; set; }
        public ICommand RegisterEmployeeRenavigatcommand { get; set; }
        public RegisterViewModel(ILogger<RegisterViewModel> registerViewModelLogger,
            ViewModelDelegateRenavigator<RegisterEmployeeViewModel> registerEmployeeRenavigator, ViewModelDelegateRenavigator<LoginViewModel> loginRenavigator,
            IInRegistrationUser inRegistrationUser)
        {

            LoginRenavigatCommand = new RenavigateCommand(loginRenavigator);
            RegisterEmployeeRenavigatcommand = new RenavigateCommand(registerEmployeeRenavigator);
            _RegisterViewModelLogger = registerViewModelLogger;
            RegisterEmployeeRenavigator = registerEmployeeRenavigator;
            _loginRenavigator = loginRenavigator;
            _InRegistrationUser = inRegistrationUser;
            CurrentUser = _InRegistrationUser.RegisteringUser;

            _RegisterViewModelLogger.Log(LogLevel.Information, "RegisterViewModel Initialized");
        }
    }
}
