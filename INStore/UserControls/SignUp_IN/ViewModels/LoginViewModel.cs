using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using INStore.Commands;
using INStore.Domain.Exceptions;
using INStore.Domain.Models;
using INStore.Language;
using INStore.State.Authenticators;
using INStore.State.Navigators;
using INStore.State.UserStore;
using INStore.UserControls.Home.ViewModels;
using INStore.ViewModels;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace INStore.UserControls.SignUp_IN.ViewModels
{
    public partial class LoginViewModel : ViewModelBase
    {
        #region Private Vars
        private readonly ILogger<LoginViewModel> _LoginViewModelLogger;
        private readonly IAuthenticators _Authenticators;
        private readonly IRenavigator _loginRenavigator;
        private readonly IRenavigator _registerRenavigator;
        private readonly ISnackbarMessageQueue snackbarMessageQueue;
        private readonly IInRegistrationUser _inRegistrationUser;
        #endregion

        [ObservableProperty]
        User currentUser;
        
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
             RegisterCommand = new RenavigateCommand(registerRenavigator);
            _inRegistrationUser.RegisteringUser = new User();

            _LoginViewModelLogger.Log(LogLevel.Information, "LoginViewModel Initialized");

#if DEBUG
            CurrentUser.UserName = "admin";
            CurrentUser.PasswordHash = "admin";
#endif
        }

        #region Commands
        [RelayCommand]
        public async Task Login()
        {
            
            try
            {
                await Task.Run(async () => 
                {
                    await _Authenticators.Login(CurrentUser.UserName, CurrentUser.PasswordHash);
                });
                _LoginViewModelLogger.LogInformation("successful login");
                snackbarMessageQueue.Enqueue(LocalizedStrings.Instance["LoginCommandWelcomeBack"] + _Authenticators.CurrentUser.Employee.EmployeeName);
                _loginRenavigator.Renavigate();
            }
            catch (UserNotFoundException userNotFound)
            {
                snackbarMessageQueue.Enqueue(LocalizedStrings.Instance["LoginCommandTheUser"] + userNotFound.Username + LocalizedStrings.Instance["LoginCommandNotFound"]);
                _LoginViewModelLogger.LogTrace("The User : " + userNotFound.Username + " Not Found");

            }
            catch (WrongPasswordExcption wrongPassword)
            {
                snackbarMessageQueue.Enqueue(LocalizedStrings.Instance["LoginCommandWrongPassword"]);
                _LoginViewModelLogger.LogTrace("Wrong Password");

            }
            catch (Exception exception)
            {
                _LoginViewModelLogger.LogError(exception.Message);
            }
        }
        #endregion

    }
}
