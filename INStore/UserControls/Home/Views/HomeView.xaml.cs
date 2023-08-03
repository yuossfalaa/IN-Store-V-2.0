using System.Windows;
using System.Windows.Controls;
using Squirrel;


namespace INStore.UserControls.Home.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        UpdateManager manager;

        public HomeView()
        {
            InitializeComponent();
        }

       

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    System.Diagnostics.Process.Start("calc");

        //}

        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    await manager.UpdateApp();

        //    MessageBox.Show("Updated succesfuly!");
        //}



        //private async void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    var updateInfo = await manager.CheckForUpdate();

        //    if (updateInfo.ReleasesToApply.Count > 0)
        //    {
        //        UpdateButton.IsEnabled = true;
        //    }
        //    else
        //    {
        //        UpdateButton.IsEnabled = false;
        //    }
        //}

        //private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        //{
        //    manager = await UpdateManager
        //       .GitHubUpdateManager(@"https://github.com/yuossfalaa/INStore-Updates");

        //    MessageBox.Show( manager.CurrentlyInstalledVersion().ToString());
        //}
    }
}
