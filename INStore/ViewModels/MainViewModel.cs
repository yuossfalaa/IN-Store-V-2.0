using INStore.Commands;
using INStore.Factories;
using INStore.Language;
using INStore.State.Authenticators;
using INStore.State.Navigators;
using MaterialDesignThemes.Wpf;
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
        private readonly ILanguageSetter _languageSetter;
        private readonly IAuthenticators authenticators;
        private readonly IRenavigator loginRenavigator;
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private Visibility _logoVisibilty;
        private bool _IsEnglish;

        public bool IsEnglish
        {
            get { return _IsEnglish; }
            set 
            {
                _IsEnglish = value;
                OnPropertyChanged(nameof(IsEnglish));
                if (!IsEnglish)
                {
                    _languageSetter.SetToArabic();
                }
                else if (IsEnglish)
                {
                    _languageSetter.SetToEnglish();
                }
            }
        }

        public ISnackbarMessageQueue MyMessageQueue { get; set; }
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
        public ICommand logoutCommand { get; set; }
        public MainViewModel(ILogger<MainViewModel> mainViewModelLogger, 
            INavigator navigator, 
            IINStoreViewModelFactory viewModelFactory, 
            ISnackbarMessageQueue myMessageQueue,
            ILanguageSetter languageSetter,
            IAuthenticators authenticators,
            IRenavigator loginRenavigator)
        {
            //Fields
            _MainViewModelLogger = mainViewModelLogger;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            MyMessageQueue = myMessageQueue;
            _languageSetter = languageSetter;
            this.authenticators = authenticators;
            this.loginRenavigator = loginRenavigator;
            _IsEnglish = _languageSetter.IsArabic();
            //Events
            _navigator.StateChanged += Navigator_StateChanged;
            OnPropertyChanged(nameof(IsEnglish));

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_viewModelFactory, _navigator);
            UpdateCurrentViewModelCommand.Execute(INavigator.ViewType.Login);
            logoutCommand = new LogoutCommand(this.authenticators, this.loginRenavigator);

            dispatcherTimerInit();

            _MainViewModelLogger.Log(LogLevel.Information, "MainViewModel Initialized");
        }

        private void Navigator_StateChanged()
        {
            _MainViewModelLogger.Log(LogLevel.Information, "CurrentViewModel Changed To => " + CurrentViewModel.ToString());
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
