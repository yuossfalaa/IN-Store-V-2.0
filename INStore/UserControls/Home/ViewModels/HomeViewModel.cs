using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DocumentFormat.OpenXml.Spreadsheet;
using GalaSoft.MvvmLight.Command;
using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.Services.StoreItemServices;
using INStore.State.FloatingWindow;
using INStore.State.SellerDashbords;
using INStore.UserControls.MyStore.ViewModels;
using INStore.ViewModels;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;

namespace INStore.UserControls.Home.ViewModels
{

    public class HomeViewModel : ViewModelBase
    {
        #region Private Vars
        private readonly IStoreItemsService _storeItemsService;
        public readonly ILogger<HomeViewModel> _HomeViewModelLogger;
        public readonly ISnackbarMessageQueue _SnackbarMessageQueue;
        private readonly FloatingWindow _floatingWindow;
        private readonly SellerDashboardsState _sellerDashboardsState;
        #endregion
        #region Public Vars
        private ObservableCollection<StoreItems> _StoreItemsCollection;

        public ObservableCollection<StoreItems> StoreItemsCollections
        {
            get { return _StoreItemsCollection; }
            set { _StoreItemsCollection = value; OnPropertyChanged(nameof(StoreItemsCollections)); }
        }
        private StoreItems _NewStoreItem;

        public StoreItems NewStoreItem
        {
            get { return _NewStoreItem; }
            set { _NewStoreItem = value; OnPropertyChanged(nameof(NewStoreItem)); }
        }
        private string _StoreItemProp;

        public string StoreItemProp
        {
            get { return _StoreItemProp; }
            set { _StoreItemProp = value; OnPropertyChanged(nameof(StoreItemProp)); }
        }
        private ObservableCollection<SellerDashboard> _sellerDashboards;

        public ObservableCollection<SellerDashboard> SellerDashboards
        {
            get { return _sellerDashboards; }
            set { _sellerDashboards = value; OnPropertyChanged(nameof(SellerDashboards)); }
        }

        private SellerDashboard _CurrentSellerDashboard;

        public SellerDashboard CurrentSellerDashboard
        {
            get { return _CurrentSellerDashboard; }
            set { _CurrentSellerDashboard = value; OnPropertyChanged(nameof(CurrentSellerDashboard)); }
        }

        private string _Total;

        public string Total
        {
            get { return _Total; }
            set { _Total = value; OnPropertyChanged(nameof(Total)); }
        }



        #endregion
        #region Commands
        public ICommand GetAllStoreItemsCommand { get; set; }
        public ICommand SearchStoreItemCommand { get; set; }
        public ICommand DeleteSellerDashboardCommand { get; set; }
        public ICommand DeleteReceiptItemCommand { get; set; }
        public ICommand SelectedSellerDashboardChangedCommand { get; set; }
        public ICommand AddSellerDashboardCommand { get; set; }
        public ICommand AddStoreItemToReceiptCommand { get; set; }
        public ICommand EditStoreItemInReceiptCommand { get; set; }
        public ICommand ClearStoreItemInReceiptCommand { get; set; }
        #endregion

        public HomeViewModel(IStoreItemsService storeItemsService, ILogger<HomeViewModel> homeViewModelLogger, ISnackbarMessageQueue snackbarMessageQueue, FloatingWindow floatingWindow, SellerDashboardsState sellerDashboardsState)
        {
            _storeItemsService = storeItemsService;
            _HomeViewModelLogger = homeViewModelLogger;
            _SnackbarMessageQueue = snackbarMessageQueue;
            _floatingWindow = floatingWindow;
            _sellerDashboardsState = sellerDashboardsState;
            Total = "0";
            SellerDashboards = _sellerDashboardsState.SellerDashboards;
            CurrentSellerDashboard = SellerDashboards[0];
            DeleteSellerDashboardCommand = new RelayCommand<SellerDashboard>(DeleteSellerDashboardFunc);
            SelectedSellerDashboardChangedCommand = new RelayCommand<SellerDashboard>(SelectedSellerDashboardChangedFunc);
            AddStoreItemToReceiptCommand = new RelayCommand<StoreItems>(AddStoreItemToReceiptFunc);
            DeleteReceiptItemCommand = new RelayCommand<SellingHistory>(DeleteReceiptItemFunc);
            AddSellerDashboardCommand = new RelayCommand(AddSellerDashboardFunc);
            ClearStoreItemInReceiptCommand = new RelayCommand(ClearStoreItemInReceiptFunc);
            EditStoreItemInReceiptCommand = new RelayCommand<SellingHistory>(EditStoreItemInReceiptFunc);
            SearchStoreItemCommand = new SearchStoreItem(_storeItemsService, _HomeViewModelLogger, this, nameof(StoreItemsCollections));
            //Load Data
            StoreItemsCollections = new ObservableCollection<StoreItems>();
            GetAllStoreItemsCommand = new GetAllStoreItems(_storeItemsService, _HomeViewModelLogger, this, nameof(StoreItemsCollections));
            GetAllStoreItemsCommand.Execute(null);
            _HomeViewModelLogger.Log(LogLevel.Information, "HomeViewModel Initialized");
            CalcTotal();
        }

    

        public async void CalcTotal()
        {
            await Task.Run(async () =>
            {
                double TotalDouble = 0;
                foreach (var item in CurrentSellerDashboard.Receipt.SoldItems)
                {
                    TotalDouble += item.ItemTotalCost;
                }
                TotalDouble = Math.Round(TotalDouble, 2);
                Total = TotalDouble.ToString();
            });

        }
        #region Private Methods
        private void ClearStoreItemInReceiptFunc()
        {
            CurrentSellerDashboard.Receipt = new Receipts();
        }
        private void EditStoreItemInReceiptFunc(SellingHistory history)
        {
            if (history.ItemNumber == 0) history.ItemNumber = 1;
            history.ItemTotalCost = history.ItemNumber * history.ItemSellingPrice;
            CalcTotal();
        }
        private void DeleteReceiptItemFunc(SellingHistory history)
        {
            CurrentSellerDashboard.Receipt.SoldItems.Remove(history);
            CalcTotal();
        }
        private async void AddStoreItemToReceiptFunc(StoreItems items)
        {
            await Task.Run(async () => 
            {
                if (!AddExistingStoreItem(items)) AddNewStoreItem(items);
                CalcTotal();
            });
           
        }
        private bool AddExistingStoreItem(StoreItems items) 
        {
            foreach (var item in CurrentSellerDashboard.Receipt.SoldItems.Where(item => item.ItemSellingPrice == items.Item.ItemSellingPrice && item.ItemName == items.Item.ItemName))
            {
                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    item.ItemNumber++;
                    item.ItemTotalCost = item.ItemSellingPrice * item.ItemNumber;
                });
                return true;
            }

            return false;
        }
        private void AddNewStoreItem(StoreItems items)
        {
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                CurrentSellerDashboard.Receipt.SoldItems.Add(new SellingHistory
                {
                    ItemName = items.Item.ItemName,
                    ItemNumber = 1,
                    ItemSellingPrice = items.Item.ItemSellingPrice,
                    ItemTotalCost = items.Item.ItemSellingPrice,
                });
            });
        }
        private void AddSellerDashboardFunc()
        {
            int Index = SellerDashboards.Count + 1;
            SellerDashboards.Add(new SellerDashboard { DashboardName = "Dashboard "+ Index });
            CurrentSellerDashboard = SellerDashboards.Last();
            CalcTotal();
        }
        private void SelectedSellerDashboardChangedFunc(SellerDashboard dashboard)
        {
            CurrentSellerDashboard = dashboard;
            CalcTotal();
        }
        private void DeleteSellerDashboardFunc(SellerDashboard dashboard)
        {
            if (SellerDashboards.Count > 1)
            {
                SellerDashboards.Remove(dashboard);

            }
            foreach (var (item, index) in SellerDashboards.Select((item, index) => (item, index)))
            {
                item.DashboardName = "Dashboard " + (index+1);
            }
            CurrentSellerDashboard = SellerDashboards[0];
            CalcTotal();

        }
        #endregion
    }

}
