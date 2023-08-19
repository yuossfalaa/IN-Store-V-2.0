using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using INStore.Commands;
using INStore.Domain.Models;
using INStore.Language;
using INStore.State.Authenticators;
using INStore.State.Navigators;
using INStore.State.UserStore;
using INStore.ViewModels;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static INStore.Domain.Services.AuthenticationService.IAuthenticationService;

namespace INStore.UserControls.SignUp_IN.ViewModels
{
    public partial class RegisterEmployeeViewModel : ViewModelBase
    {
        #region Private Vars
        private readonly ILogger<RegisterEmployeeViewModel> _RegisterEmployeeViewModelLogger;
        private readonly IRenavigator RegisterRenavigator;
        private readonly IRenavigator LoginRenavigator;
        private readonly IInRegistrationUser _InRegistrationUser;
        private readonly IAuthenticators _Authenticators;
        private readonly ISnackbarMessageQueue snackbarMessageQueue;
        #endregion
        [ObservableProperty]
        User currentUser;

        public ICommand RegisterRenavigatCommand { get; set; }
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
 
            _RegisterEmployeeViewModelLogger.Log(LogLevel.Information, "RegisterEmployeeViewModel Initialized");
        }
        [RelayCommand]
        public async Task Register()
        {
            try
            {
                RegistrationResult result = RegistrationResult.Success;
                await Task.Run(async () => {
                    result = await _Authenticators.Register(_InRegistrationUser);
                });
                if (result == RegistrationResult.Success)
                {
                    LoginRenavigator.Renavigate();
                }
                else if (result == RegistrationResult.AdminPasswordDoNotMatch)
                {
                    snackbarMessageQueue.Enqueue(LocalizedStrings.Instance["RegisterCommandWrongAdminPassword"]);
                    _RegisterEmployeeViewModelLogger.LogTrace("Wrong Admin Password");

                }
                else if (result == RegistrationResult.UsernameAlreadyExists)
                {
                    snackbarMessageQueue.Enqueue(LocalizedStrings.Instance["RegisterCommandUsernameAlreadyExists"]);
                    _RegisterEmployeeViewModelLogger.LogTrace("Username Already Exists");

                }
            }
            catch (Exception excption)
            {
                _RegisterEmployeeViewModelLogger.LogError(excption.Message);
            }

        }
    }
}
