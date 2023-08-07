using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using INStore.Commands;
using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.Services.StoreItemServices;
using INStore.State.Navigators;
using INStore.UserControls.Home.ViewModels;
using INStore.ViewModels;

namespace INStore.UserControls.Orders.ViewModel
{
    public class OrdersViewModel : ViewModelBase
    {
        #region Private Vars
        private readonly IRenavigator homeRenavigator;
        #endregion
        #region Commands
        public ICommand HomeNavigationCommand { get; set; }
        #endregion
        public OrdersViewModel(ViewModelDelegateRenavigator<HomeViewModel> homeRenavigator)
        {
            this.homeRenavigator = homeRenavigator;

            #region Init Command
            HomeNavigationCommand = new RenavigateCommand(this.homeRenavigator);
            #endregion

        }
    }
}
