using INStore.Commands;
using INStore.Factories;
using INStore.Language;
using INStore.State.Authenticators;
using INStore.State.Navigators;
using INStore.UserControls.Home.ViewModels;
using INStore.UserControls.MyStore.ViewModels;
using INStore.UserControls.SignUp_IN.ViewModels;
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
        #region private Variables
        private readonly ILogger<MainViewModel> _MainViewModelLogger;
        private readonly INavigator _navigator;
        private readonly IINStoreViewModelFactory _viewModelFactory;
        private readonly ILanguageSetter _languageSetter;
        private readonly IAuthenticators authenticators;
        private readonly IRenavigator loginRenavigator;
        private readonly IRenavigator myStoreRenavigator;
        private readonly IRenavigator homeRenavigator;
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private Visibility _logoVisibilty;
        private bool _IsEnglish;
        #endregion
        #region public Variables
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
        #endregion
        #region Commands
        public ICommand UpdateCurrentViewModelCommand { get; }
        public ICommand logoutCommand { get; set; }
        public ICommand MyStoreRenavigatCommand { get; set; }
        public ICommand HomeRenavigatCommand { get; set; }
        #endregion
        public MainViewModel(ILogger<MainViewModel> mainViewModelLogger,
            INavigator navigator,
            IINStoreViewModelFactory viewModelFactory,
            ISnackbarMessageQueue myMessageQueue,
            ILanguageSetter languageSetter,
            IAuthenticators authenticators,
            ViewModelDelegateRenavigator<LoginViewModel> loginRenavigator,
            ViewModelDelegateRenavigator<MyStoreViewModel> myStoreRenavigator,
            ViewModelDelegateRenavigator<HomeViewModel> HomeRenavigator)
        {

            //Fields
            _MainViewModelLogger = mainViewModelLogger;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            MyMessageQueue = myMessageQueue;
            _languageSetter = languageSetter;
            this.authenticators = authenticators;
            this.loginRenavigator = loginRenavigator;
            this.myStoreRenavigator = myStoreRenavigator;
            homeRenavigator = HomeRenavigator;
            _IsEnglish = _languageSetter.IsArabic();


            //Events
            _navigator.StateChanged += Navigator_StateChanged;
            OnPropertyChanged(nameof(IsEnglish));

            //commands
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_viewModelFactory, _navigator);
            UpdateCurrentViewModelCommand.Execute(INavigator.ViewType.Login);
            logoutCommand = new LogoutCommand(this.authenticators, this.loginRenavigator);
            MyStoreRenavigatCommand = new RenavigateCommand(this.myStoreRenavigator);
            HomeRenavigatCommand = new RenavigateCommand(this.homeRenavigator);
            //func
            dispatcherTimerInit();
            _MainViewModelLogger.Log(LogLevel.Information, "MainViewModel Initialized");
        }




        #region Private Functions
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
        #endregion


    }
}
