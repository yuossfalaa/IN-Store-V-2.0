using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using ArrayToExcel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using INStore.Domain.ExportingModels;
using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.Services.StoreItemServices;
using INStore.State.FloatingWindow;
using INStore.ViewModels;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;

namespace INStore.UserControls.MyStore.ViewModels
{
    public partial class MyStoreViewModel : ViewModelBase
    {
        #region Private Vars
        private readonly IStoreItemsService _storeItemsService;
        public readonly ILogger<MyStoreViewModel> _MyStoreViewModelLogger;
        public readonly ISnackbarMessageQueue _SnackbarMessageQueue;
        private readonly FloatingWindow _floatingWindow;
        #endregion
        #region Public Vars
        [ObservableProperty]
        ObservableCollection<StoreItems> storeItemsCollections;

        [ObservableProperty]
        StoreItems newStoreItem;

        [ObservableProperty]
        string storeItemProp;

        #endregion
        #region Commands
        public ICommand GetAllStoreItemsCommand { get; set; }
        public ICommand SearchStoreItemCommand { get; set; }
        #endregion
        public MyStoreViewModel(IStoreItemsService storeItemsService, FloatingWindow floatingWindow, ILogger<MyStoreViewModel> myStoreViewModelLogger, ISnackbarMessageQueue snackbarMessageQueue)
        {
            _storeItemsService = storeItemsService;
            _floatingWindow = floatingWindow;
            _MyStoreViewModelLogger = myStoreViewModelLogger;
            _SnackbarMessageQueue = snackbarMessageQueue;

            //initialize Commands
            SearchStoreItemCommand = new SearchStoreItem(_storeItemsService, _MyStoreViewModelLogger, this, nameof(StoreItemsCollections));
             //Load Data
            StoreItemsCollections = new ObservableCollection<StoreItems>();
            GetAllStoreItemsCommand = new GetAllStoreItems(_storeItemsService, _MyStoreViewModelLogger, this,nameof(StoreItemsCollections));
            GetAllStoreItemsCommand.Execute(null);
            _MyStoreViewModelLogger.Log(LogLevel.Information, "MyStoreViewModel Initialized");
        }
        #region Private Methods
        [RelayCommand]
        private void ExportStoreItem()
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

        [RelayCommand]
        private void OpenAddItemStoreItem()
        {
            _floatingWindow.FloatingWindowControl = new AddItemViewModel(_storeItemsService, this);
            MaterialDesignThemes.Wpf.DialogHost.OpenDialogCommand.Execute(null, null);
            _MyStoreViewModelLogger.Log(LogLevel.Information, "AddItemViewModel Initialized");

        }

        [RelayCommand]
        private void OpenEditItemStoreItem(StoreItems items)
        {
            if (items != null)
            {
                _floatingWindow.FloatingWindowControl = new EditItemViewModel(_storeItemsService, this, items);
                MaterialDesignThemes.Wpf.DialogHost.OpenDialogCommand.Execute(null, null);
                _MyStoreViewModelLogger.Log(LogLevel.Information, "EditItemViewModel Initialized");
            }
        
        }
        [RelayCommand]
        public async Task DeleteStoreItem(StoreItems storeItems)
        {
            try
            {
                await Task.Run(async () =>
                {
                    if (storeItems != null) await _storeItemsService.Delete(storeItems);
                    GetAllStoreItemsCommand.Execute(null);
                });

                _MyStoreViewModelLogger.Log(LogLevel.Information, "Delete Store Items Done");
            }
            catch (Exception ex)
            {
                _MyStoreViewModelLogger.LogError(ex.Message);
            }
        }
        #endregion
    }
}
