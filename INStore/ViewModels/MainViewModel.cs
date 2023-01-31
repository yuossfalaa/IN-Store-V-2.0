using INStore.Commands;
using INStore.Factories;
using INStore.State.Navigators;
using INStore.UserControls.SignUp_IN.ViewModels;
using Microsoft.Extensions.Logging;
using System.Windows.Input;

namespace INStore.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private readonly ILogger<MainViewModel> _MainViewModelLogger;
        private readonly INavigator _navigator;
        private readonly IINStoreViewModelFactory _viewModelFactory;
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;
        public ICommand UpdateCurrentViewModelCommand { get;}

        public MainViewModel(ILogger<MainViewModel> mainViewModelLogger, INavigator navigator, IINStoreViewModelFactory viewModelFactory)
        {
            _MainViewModelLogger = mainViewModelLogger;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_viewModelFactory,_navigator);
            UpdateCurrentViewModelCommand.Execute(INavigator.ViewType.Login);

        }




    }
}
