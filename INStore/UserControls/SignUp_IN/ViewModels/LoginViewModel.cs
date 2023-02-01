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
        private readonly ILogger<LoginViewModel> _MainViewModelLogger;

        public LoginViewModel(ILogger<LoginViewModel> mainViewModelLogger)
        {
            _MainViewModelLogger = mainViewModelLogger;
            text = "brah";
            mainViewModelLogger.LogError(text);
        }
        private string _text;

        public string text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged(nameof(text)); }
        }

    }
}
