using System;
using System.Threading.Tasks;
using INStore.Commands;
using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.UserControls.MyStore.ViewModels;
using Microsoft.Extensions.Logging;

namespace INStore.UserControls.MyStore.Commands
{
    public class DeleteStoreItem : AsyncCommandBase
    {
        private readonly IStoreItemsService _storeItemsService;
        private readonly MyStoreViewModel _myStoreViewModel;

        public DeleteStoreItem(IStoreItemsService storeItemsService, MyStoreViewModel myStoreViewModel)
        {
            _storeItemsService = storeItemsService;
            _myStoreViewModel = myStoreViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                if (parameter != null) await _storeItemsService.Delete((StoreItems)parameter);
                _myStoreViewModel.GetAllStoreItemsCommand.Execute(null);
                _myStoreViewModel._MyStoreViewModelLogger.Log(LogLevel.Information, "Delete Store Items Done");
            }
            catch (Exception ex)
            {
                _myStoreViewModel._MyStoreViewModelLogger.LogError(ex.Message);
            }
        }
    }
}
