using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INStore.Commands;
using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.UserControls.MyStore.ViewModels;
using Microsoft.Extensions.Logging;

namespace INStore.UserControls.MyStore.Commands
{
    public class SearchStoreItem : AsyncCommandBase
    {
        private readonly IStoreItemsService _storeItemsService;
        private readonly MyStoreViewModel _myStoreViewModel;

        public SearchStoreItem(IStoreItemsService storeItemsService, MyStoreViewModel myStoreViewModel)
        {
            _storeItemsService = storeItemsService;
            _myStoreViewModel = myStoreViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                List<StoreItems> storeItems = await _storeItemsService.Get((string)parameter);
                _myStoreViewModel.StoreItemsCollections = new ObservableCollection<StoreItems>(storeItems);
                _myStoreViewModel._MyStoreViewModelLogger.Log(LogLevel.Information, "Search Store Items Done");
            }
            catch (Exception ex)
            {
                _myStoreViewModel._MyStoreViewModelLogger.LogError(ex.Message);
            }

        }
    }
}
