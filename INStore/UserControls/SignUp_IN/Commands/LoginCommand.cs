﻿using INStore.Commands;
using INStore.Domain.Exceptions;
using INStore.Domain.Models;
using INStore.Language;
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
        private readonly LoginViewModel _loginviewModel;
        private readonly IAuthenticators _authenticators;
        private readonly IRenavigator _renavigator;
        private readonly ISnackbarMessageQueue snackbarMessageQueue;
        private readonly ILogger<LoginViewModel> _Logger;


        public LoginCommand(LoginViewModel loginviewModel, IAuthenticators authenticators, IRenavigator Renavigator, ISnackbarMessageQueue snackbarMessageQueue, ILogger<LoginViewModel> logger)
        {
            _authenticators = authenticators;
            _renavigator = Renavigator;
            _loginviewModel = loginviewModel;
            this.snackbarMessageQueue = snackbarMessageQueue;
            _Logger = logger;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _authenticators.Login(_loginviewModel.CurrentUser.UserName, _loginviewModel.CurrentUser.PasswordHash);
                _Logger.LogInformation("successful login");
                snackbarMessageQueue.Enqueue(LocalizedStrings.Instance["LoginCommandWelcomeBack"] + _authenticators.CurrentUser.Employee.EmployeeName );
                _renavigator.Renavigate();
            }
            catch (UserNotFoundException userNotFound)
            {
                snackbarMessageQueue.Enqueue(LocalizedStrings.Instance["LoginCommandTheUser"] + userNotFound.Username + LocalizedStrings.Instance["LoginCommandNotFound"]);
                _Logger.LogTrace("The User : " + userNotFound.Username + " Not Found");

            }
            catch (WrongPasswordExcption wrongPassword)
            {
                snackbarMessageQueue.Enqueue(LocalizedStrings.Instance["LoginCommandWrongPassword"]);
                _Logger.LogTrace("Wrong Password");

            }
            catch (Exception exception)
            {
                _Logger.LogError(exception.Message);
            }
        }
    }
}
