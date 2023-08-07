using System.Collections.ObjectModel;
using System.Windows.Input;
using INStore.Commands;
using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.Services.ReceiptsServices;
using INStore.State.Navigators;
using INStore.UserControls.Home.ViewModels;
using INStore.ViewModels;
using Microsoft.Extensions.Logging;

namespace INStore.UserControls.Orders.ViewModel
{
    public class OrdersViewModel : ViewModelBase
    {
        #region Private Vars
        private readonly IRenavigator homeRenavigator; 
        private readonly IReceiptsDataService _receiptsService;
        private readonly ILogger<OrdersViewModel> ViewModelLogger;

        #endregion
        #region Public Vars

        private ObservableCollection<Receipts> _receipts;

        public ObservableCollection<Receipts> Receipts
        {
            get { return _receipts; }
            set { _receipts = value; OnPropertyChanged(nameof(Receipts)); }
        }


        #endregion
        #region Commands
        public ICommand HomeNavigationCommand { get; set; }
        public ICommand GetAllReceiptsCommand { get; set; }
        #endregion
        public OrdersViewModel(ViewModelDelegateRenavigator<HomeViewModel> homeRenavigator, IReceiptsDataService receiptsService, ILogger<OrdersViewModel> viewModelLogger)
        {
            this.homeRenavigator = homeRenavigator;
            _receiptsService = receiptsService;
            ViewModelLogger = viewModelLogger;
            #region Init Command
            HomeNavigationCommand = new RenavigateCommand(this.homeRenavigator);
            GetAllReceiptsCommand = new GetAllReceipts(ViewModelLogger, this, nameof(Receipts), _receiptsService);
            #endregion
            #region Load Data
            GetAllReceiptsCommand.Equals(null);
            #endregion

        }
    }
}
