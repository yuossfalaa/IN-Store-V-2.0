using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using INStore.State.FloatingWindow;
using INStore.UserControls.MyStore.ViewModels;
using INStore.ViewModels;

namespace INStore.UserControls.Home.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public FloatingWindow FloatingWindowControl;
        public ICommand OpenFloatingWindow {  get; set; }
        public HomeViewModel(FloatingWindow floatingWindowControl)
        {
            FloatingWindowControl = floatingWindowControl;
            OpenFloatingWindow = new RelayCommand(OpenFloatingWindowFunc);

        }

        private void OpenFloatingWindowFunc()
        {
            MaterialDesignThemes.Wpf.DialogHost.OpenDialogCommand.Execute(null, null);
        }
    }
}
