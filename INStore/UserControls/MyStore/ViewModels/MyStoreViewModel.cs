using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using ArrayToExcel;
using GalaSoft.MvvmLight.Command;
using INStore.Domain.ExportingModels;
using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.State.FloatingWindow;
using INStore.UserControls.MyStore.Commands;
using INStore.ViewModels;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;

namespace INStore.UserControls.MyStore.ViewModels
{
    public class MyStoreViewModel : ViewModelBase
    {
        #region Private Vars
        private readonly IStoreItemsService _storeItemsService;
        public readonly ILogger<MyStoreViewModel> _MyStoreViewModelLogger;
        public readonly ISnackbarMessageQueue _SnackbarMessageQueue;
        private readonly FloatingWindow _floatingWindow;
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

        #endregion
        #region Commands
        public ICommand GetAllStoreItemsCommand { get; set; }
        public ICommand SearchStoreItemCommand { get; set; }
        public ICommand DeleteStoreItemCommand { get; set; }
        public ICommand OpenEditItemStoreItemCommand { get; set; }
        public ICommand OpenAddItemStoreItemCommand { get; set; }
        public ICommand ExportStoreItemCommand { get; set; }
        public ICommand ImportStoreItemCommand { get; set; }

        #endregion

        public MyStoreViewModel(IStoreItemsService storeItemsService, FloatingWindow floatingWindow, ILogger<MyStoreViewModel> myStoreViewModelLogger, ISnackbarMessageQueue snackbarMessageQueue)
        {
            _storeItemsService = storeItemsService;
            _floatingWindow = floatingWindow;
            _MyStoreViewModelLogger = myStoreViewModelLogger;
            _SnackbarMessageQueue = snackbarMessageQueue;

            //initialize Commands
            SearchStoreItemCommand = new SearchStoreItem(_storeItemsService, this);
            DeleteStoreItemCommand = new DeleteStoreItem(_storeItemsService, this);
            OpenEditItemStoreItemCommand = new RelayCommand<StoreItems>(OpenEditItemStoreItemFunc);
            OpenAddItemStoreItemCommand = new RelayCommand(OpenAddItemStoreItemFunc);
            ExportStoreItemCommand = new RelayCommand(ExportStoreItemFunc);
            //Load Data
            GetAllStoreItemsCommand = new GetAllStoreItems(_storeItemsService, this);
            GetAllStoreItemsCommand.Execute(null);
            _MyStoreViewModelLogger.Log(LogLevel.Information, "MyStoreViewModel Initialized");
        }


        #region Private Methods
        private void ExportStoreItemFunc()
        {
            var sfd = new SaveFileDialog { Filter = "Excel Files|*.xlsx", FileName = "IN Store ( My Store Items )", AddExtension = true };
            if (sfd.ShowDialog().Value)
            {
                string dirPath = sfd.FileName;
                var ExcelFile = PrepareExportingItems().ToExcel();
                File.WriteAllBytes(dirPath, ExcelFile);
            }
        }
        private ObservableCollection<ExportingStoreItems> PrepareExportingItems()
        {
            ObservableCollection<ExportingStoreItems> items = new ObservableCollection<ExportingStoreItems>();
            foreach (var item in StoreItemsCollections)
            {
                items.Add(new ExportingStoreItems
                {
                    Item_Name = item.Item.ItemName,
                    Item_Description = item.Item.ItemDescription,
                    Item_BarCode = item.Item.ItemBarCode,
                    Item_Selling_Price = item.Item.ItemSellingPrice,
                    Item_Purchasing_Price = item.Item.ItemPurchasingPrice,
                    Item_Number_InStore = item.ItemNumberInStore,
                    Item_Number_InStock = item.ItemNumberInStock
                });
            }
            return items;
        }
        private void OpenAddItemStoreItemFunc()
        {
            _floatingWindow.FloatingWindowControl = new AddItemViewModel(_storeItemsService, this);
            MaterialDesignThemes.Wpf.DialogHost.OpenDialogCommand.Execute(null, null);
            _MyStoreViewModelLogger.Log(LogLevel.Information, "AddItemViewModel Initialized");

        }

        private void OpenEditItemStoreItemFunc(StoreItems items)
        {
            if (items != null)
            {
                _floatingWindow.FloatingWindowControl = new EditItemViewModel(_storeItemsService, this, items);
                MaterialDesignThemes.Wpf.DialogHost.OpenDialogCommand.Execute(null, null);
                _MyStoreViewModelLogger.Log(LogLevel.Information, "EditItemViewModel Initialized");
            }
        
        }
        #endregion
    }
}
