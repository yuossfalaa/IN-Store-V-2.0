using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
