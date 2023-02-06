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
        public ICommand LoginRenavigatCommand { get; set; }
        public ICommand RegisterEmployeeRenavigatcommand { get; set; }
        private string _userName;

        public string Username
        {
            get 
            {
                return _userName;
            }
            set 
            { 
                _userName = value; 
                OnPropertyChanged(nameof(Username));
                _InRegistrationUser.RegisteringUser.UserName = Username; 
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
                _InRegistrationUser.RegisteringUser.PasswordHash = Password;
            }
        }
        private string _adminPassword;

        public string AdminPassword
        {
            get { return _adminPassword; }
            set 
            { 
                _adminPassword = value;
                OnPropertyChanged(nameof(AdminPassword));
                _InRegistrationUser.RegisteringUser.AdminPasswordHash = AdminPassword;
            }
        }
        private bool _isAdmin;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set 
            {
                _isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
                _InRegistrationUser.RegisteringUser.AccountState = AccountState.Admin;
            }
        }
        private bool _isEmployee;

        public bool IsEmployee
        {
            get { return _isEmployee; }
            set 
            { 
                _isEmployee = value;
                OnPropertyChanged(nameof(IsEmployee));
                _InRegistrationUser.RegisteringUser.AccountState = AccountState.Employee;
            }
        }



        public RegisterViewModel(ILogger<RegisterViewModel> registerViewModelLogger,
            IRenavigator registerEmployeeRenavigator, IRenavigator loginRenavigator,
            IInRegistrationUser inRegistrationUser)
        {

            LoginRenavigatCommand = new RenavigateCommand(loginRenavigator);
            RegisterEmployeeRenavigatcommand = new RenavigateCommand(registerEmployeeRenavigator);
            _RegisterViewModelLogger = registerViewModelLogger;
            RegisterEmployeeRenavigator = registerEmployeeRenavigator;
            _loginRenavigator = loginRenavigator;
            _InRegistrationUser = inRegistrationUser;

            _RegisterViewModelLogger.Log(LogLevel.Information, "RegisterViewModel Initialized");
        }
    }
}
