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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace INStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            size();
        }
        public void size()
        {

            int width = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
            int hight = (int)System.Windows.SystemParameters.PrimaryScreenHeight;
            this.MaxHeight = System.Windows.SystemParameters.MaximizedPrimaryScreenHeight;

            if (width <= 1280 || hight <= 690)
            {
                this.Width = System.Windows.SystemParameters.MaximizedPrimaryScreenWidth;
                this.Height = System.Windows.SystemParameters.MaximizedPrimaryScreenHeight;
            }
        }

        private void CloseApplication(object sender, RoutedEventArgs e)
        {
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.1));
            anim.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void MaximizeWindow(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {

                this.WindowState = WindowState.Maximized;
                MaximizeWindowPackIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowMaximize;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                MaximizeWindowPackIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.FullscreenExit;
            }
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void TriggerMoveWindow(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (WindowState == System.Windows.WindowState.Maximized)
                {
                    WindowState = System.Windows.WindowState.Normal;

                    double pct = PointToScreen(e.GetPosition(this)).X / System.Windows.SystemParameters.PrimaryScreenWidth;
                    Top = 0;
                    Left = e.GetPosition(this).X - (pct * Width);
                }

                DragMove();
            }
        }
    }
}
