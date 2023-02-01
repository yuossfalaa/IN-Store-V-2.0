using INStore.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INStore.UserControls.SignUp_IN.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly ILogger<LoginViewModel> _LoginViewModelLogger;

        public LoginViewModel(ILogger<LoginViewModel> LoginViewModelLogger)
        {
            _LoginViewModelLogger = LoginViewModelLogger;
        }
        

    }
}
