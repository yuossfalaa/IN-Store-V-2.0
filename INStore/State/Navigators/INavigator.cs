using INStore.ViewModels;
using System.Windows.Input;

namespace INStore.State.Navigators
{
    public interface INavigator
    {
        public enum ViewType
        {
            Home,
            About,
            DashBoard,
            MyStore,
            RefundDashboard,
            SellerDashboard,
            Tools,
            Login
        }
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
