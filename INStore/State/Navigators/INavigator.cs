using INStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Tools
        }
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
