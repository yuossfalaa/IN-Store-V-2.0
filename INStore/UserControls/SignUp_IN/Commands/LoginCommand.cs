using INStore.Commands;
using INStore.Domain.Exceptions;
using INStore.State.Authenticators;
using INStore.State.Navigators;
using INStore.UserControls.SignUp_IN.ViewModels;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace INStore.UserControls.SignUp_IN.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticators _authenticators;
        private readonly IRenavigator _renavigator;
        private readonly ISnackbarMessageQueue snackbarMessageQueue;
        private readonly ILogger<LoginViewModel> _Logger;


        public LoginCommand(LoginViewModel loginViewModel, IAuthenticators authenticators, IRenavigator Renavigator, ISnackbarMessageQueue snackbarMessageQueue, ILogger<LoginViewModel> logger)
        {
            _authenticators = authenticators;
            _renavigator = Renavigator;
            _loginViewModel = loginViewModel;
            this.snackbarMessageQueue = snackbarMessageQueue;
            _Logger = logger;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _authenticators.Login(_loginViewModel.Username, _loginViewModel.Password);
                _Logger.LogInformation("successful login");
                _renavigator.Renavigate();
            }
            catch (UserNotFoundException userNotFound)
            { 
                snackbarMessageQueue.Enqueue("The User : " + userNotFound.Username +" Not Found");
                _Logger.LogTrace("The User : " + userNotFound.Username + " Not Found");

            }
            catch (WrongPasswordExcption wrongPassword)
            {
                snackbarMessageQueue.Enqueue("Wrong Password");
                _Logger.LogTrace("Wrong Password");

            }
            catch (Exception exception)
            {
                _Logger.LogError(exception.Message);
            }
        }
    }
}
