using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2016.Excel;
using INStore.UserControls.Home.ViewModels;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;
using Squirrel;


namespace INStore.UserControls.Home.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private UpdateManager manager;
        private StringBuilder stringBuilder = new StringBuilder();
        private DispatcherTimer timer;
        private ILogger<HomeViewModel> _HomeViewModelLogger;
        private ISnackbarMessageQueue _SnackbarMessageQueue;
        private HomeViewModel homeViewModel;
        public HomeView()
        {
            InitializeComponent();
            // Initialize Loaded Event
            Loaded += HomeView_Loaded;
            // Initialize the timer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Interval = TimeSpan.FromMicroseconds(200);
            timer.Tick += Timer_Tick;

        }
        #region Process Key Down 
        public void PreviewKeyDownFunc(object sender, KeyEventArgs e)
        {
            CheckKeys(e);
            // Start the timer on key press
            timer.Stop();
            timer.Start();
            // Add the captured character to the string builder
            char keyChar = KeyToChar(e.Key);
            stringBuilder.Append(keyChar);
        }
        private void CheckKeys(KeyEventArgs e)
        {
            #region Ctrl Shortcuts
            if (e.Key == System.Windows.Input.Key.D && Keyboard.Modifiers == ModifierKeys.Control) AddSellerDashboardButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            if (e.Key == System.Windows.Input.Key.W && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int index = homeViewModel.SellerDashboards.IndexOf(homeViewModel.CurrentSellerDashboard);
                if (index == 0) homeViewModel.CurrentSellerDashboard = homeViewModel.SellerDashboards.Last();
                else
                {
                    index = index - 1;
                    homeViewModel.CurrentSellerDashboard = homeViewModel.SellerDashboards[index];
                }
            }
            if (e.Key == System.Windows.Input.Key.S && Keyboard.Modifiers == ModifierKeys.Control)
            {
                int index = homeViewModel.SellerDashboards.IndexOf(homeViewModel.CurrentSellerDashboard);
                if (index == homeViewModel.SellerDashboards.Count() - 1) homeViewModel.CurrentSellerDashboard = homeViewModel.SellerDashboards.First();
                else
                {
                    index = index + 1;
                    homeViewModel.CurrentSellerDashboard = homeViewModel.SellerDashboards[index];
                }
            }
            #endregion
            #region Shift Shortcuts
            if (e.Key == System.Windows.Input.Key.C && Keyboard.Modifiers == ModifierKeys.Shift) CancelButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            if (e.Key == System.Windows.Input.Key.Tab && Keyboard.Modifiers == ModifierKeys.Shift)
            {
               if ( TabControl.SelectedIndex == 0) TabControl.SelectedIndex =1;
               else TabControl.SelectedIndex = 0;
            }
            #endregion
            #region F's Shortcuts
            if (e.Key == System.Windows.Input.Key.F12) System.Diagnostics.Process.Start("calc");
            if (e.Key == System.Windows.Input.Key.F1) SearchBar.Focus();
            #endregion
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            // Timer elapsed, add the accumulated string and clear the string builder
            string accumulatedString = stringBuilder.ToString();

            if (!string.IsNullOrEmpty(accumulatedString))
            {


                // Clear the string builder
                stringBuilder.Clear();
            }

            // Stop the timer
            timer.Stop();
        }
        private char KeyToChar(Key key)
        {
            try
            {
                KeyConverter converter = new KeyConverter();
                string keyString = converter.ConvertToString(key);

                if (keyString.Length == 1) // Single character
                {
                    char character = keyString[0];

                    if (Char.IsLetterOrDigit(character)) // Letters and digits
                        return character;
                }
                else if ((key >= Key.NumPad0 && key <= Key.NumPad9) || (key >= Key.D0 && key <= Key.D9)) // Numpad numbers and regular number keys
                {
                    if (key >= Key.D0 && key <= Key.D9)
                        return (char)('0' + (key - Key.D0));
                    else
                        return (char)('0' + (key - Key.NumPad0));
                }
            }
            catch (Exception ex)
            {
                _HomeViewModelLogger.LogError(ex.Message);
            }
            return '\0'; // Default return value for unsupported keys
        }
        #endregion
        #region Update Func
        private async void HomeView_Loaded(object sender, RoutedEventArgs e)
        {
            //get Dependences
            homeViewModel = (HomeViewModel)this.DataContext;
            _HomeViewModelLogger = homeViewModel._HomeViewModelLogger;
            _SnackbarMessageQueue = homeViewModel._SnackbarMessageQueue;
            await UpdateApplication();
        }
        private async Task UpdateApplication()
        {
            await Task.Run(async () =>
            {
                try
                {
                    manager = await UpdateManager
                         .GitHubUpdateManager(@"https://github.com/yuossfalaa/INStore-Updates");
                    var updateInfo = await manager.CheckForUpdate();

                    if (updateInfo.ReleasesToApply.Count > 0)
                    {
                        try
                        {
                            _SnackbarMessageQueue.Enqueue("Updates on the Way !!");
                            _HomeViewModelLogger.LogInformation(updateInfo.ReleasesToApply.Count + " Update Found");
                            await manager.UpdateApp();
                            _SnackbarMessageQueue.Enqueue("Updated successfully !!");
                            _SnackbarMessageQueue.Enqueue("Restart For The New Version");
                            _HomeViewModelLogger.LogInformation("Application Updated to : " + manager.CurrentlyInstalledVersion().ToString());
                        }
                        catch (Exception ex)
                        {
                            _SnackbarMessageQueue.Enqueue("Update Failed !!");
                            _HomeViewModelLogger.LogError(ex.Message);
                        }

                    }

                }
                catch (Exception ex)
                {
                    _HomeViewModelLogger.LogError(ex.Message);
                }
            });
        }
        #endregion
    }
}
