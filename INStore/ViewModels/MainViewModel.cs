using INStore.State.Navigators;
using INStore.UserControls.SignUp_IN.ViewModels;
using Microsoft.Extensions.Logging;

namespace INStore.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private readonly ILogger<MainViewModel> _MainViewModelLogger;
        public INavigator Navigator { get; set; }

        public MainViewModel(ILogger<MainViewModel> MainViewModelLogger , INavigator navigator)
        {
            _MainViewModelLogger = MainViewModelLogger;
            Navigator = navigator;
            Navigator.CurrentViewModel = new LoginViewModel();
        }
    }
}
