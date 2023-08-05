using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INStore.Domain.Models;
using INStore.ViewModels;

namespace INStore.UserControls.Home.ViewModels
{
    public class SellerDashboard : ViewModelBase
    {
		private Receipts _receipt;

		public Receipts Receipt
		{
			get { return _receipt; }
			set { _receipt = value; OnPropertyChanged(nameof(Receipt)); }
		}
		private string _DashboardName;

		public string DashboardName
        {
			get { return _DashboardName; }
			set { _DashboardName = value; OnPropertyChanged(nameof(DashboardName)); }
		}
        public SellerDashboard()
        {
            Receipt = new Receipts();
        }

    }
}
