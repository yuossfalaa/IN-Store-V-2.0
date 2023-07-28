using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using INStore.Commands;
using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.UserControls.MyStore.ViewModels;
using Microsoft.Extensions.Logging;

namespace INStore.UserControls.MyStore.Commands
{
    public class GetAllStoreItems : AsyncCommandBase
    {
        private readonly IStoreItemsService _storeItemsService;
        private readonly MyStoreViewModel _myStoreViewModel;

        public GetAllStoreItems(IStoreItemsService storeItemsService, MyStoreViewModel myStoreViewModel)
        {
            _storeItemsService = storeItemsService;
            _myStoreViewModel = myStoreViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                List<StoreItems> storeItems = await _storeItemsService.GetAll(false);
                _myStoreViewModel.StoreItemsCollections = new ObservableCollection<StoreItems>(storeItems);
                _myStoreViewModel._MyStoreViewModelLogger.Log(LogLevel.Information, "All Store Items Loaded");
            }
            catch (Exception ex)
            {
                _myStoreViewModel._MyStoreViewModelLogger.LogError(ex.Message);
            }
        }
    }
}
