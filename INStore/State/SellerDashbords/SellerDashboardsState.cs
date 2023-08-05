using System.Collections.ObjectModel;
using INStore.UserControls.Home.ViewModels;
using INStore.ViewModels;

namespace INStore.State.SellerDashbords
{
    public class SellerDashboardsState : ViewModelBase
    {
        private ObservableCollection<SellerDashboard> _sellerDashboards;

        public ObservableCollection<SellerDashboard> SellerDashboards
        {
            get { return _sellerDashboards; }
            set { _sellerDashboards = value; OnPropertyChanged(nameof(SellerDashboards)); }
        }
        public SellerDashboardsState()
        {
            SellerDashboards = new ObservableCollection<SellerDashboard> { new SellerDashboard { DashboardName = "Dashboard 1" } };
        }
    }
}
