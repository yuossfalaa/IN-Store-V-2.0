using INStore.Commands;
using INStore.Factories;
using INStore.State.Navigators;
using Microsoft.Extensions.Logging;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace INStore.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private readonly ILogger<MainViewModel> _MainViewModelLogger;
        private readonly INavigator _navigator;
        private readonly IINStoreViewModelFactory _viewModelFactory;
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private Visibility _logoVisibilty;
        public Visibility LogoVisibilty
        {
            get { return _logoVisibilty; }
            set
            {
                _logoVisibilty = value;
                OnPropertyChanged(nameof(LogoVisibilty));
            }
        }
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;
        public ICommand UpdateCurrentViewModelCommand { get; }
        public MainViewModel(ILogger<MainViewModel> mainViewModelLogger, INavigator navigator, IINStoreViewModelFactory viewModelFactory)
        {
            _MainViewModelLogger = mainViewModelLogger;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;

            _navigator.StateChanged += Navigator_StateChanged;


            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_viewModelFactory,_navigator);
            UpdateCurrentViewModelCommand.Execute(INavigator.ViewType.Login);
            dispatcherTimerInit();
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        private void dispatcherTimerInit()
        {
            LogoVisibilty = Visibility.Collapsed;

            dispatcherTimer.Tick += LogoVisibiltyTimer;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        private void LogoVisibiltyTimer(object sender, EventArgs e)
        {
            LogoVisibilty = Visibility.Visible;
            dispatcherTimer.Stop();
        }
    }
}
