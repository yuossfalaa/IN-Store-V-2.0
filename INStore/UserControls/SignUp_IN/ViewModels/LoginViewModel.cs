using INStore.Domain.Models;
using INStore.Domain.Services.AuthenticationService;
using INStore.UserControls.SignUp_IN.Commands;
using INStore.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace INStore.UserControls.SignUp_IN.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly ILogger<LoginViewModel> _LoginViewModelLogger;
        private readonly IAuthenticationService _authenticationService;
        public ICommand LoginCommand { get; set; }

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


        public LoginViewModel(ILogger<LoginViewModel> LoginViewModelLogger, IAuthenticationService authenticationService)
        {
            _LoginViewModelLogger = LoginViewModelLogger;
            _authenticationService = authenticationService;
            LoginCommand = new LoginCommand(this, authenticationService);
        }


    }
}
