using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INStore.Commands;
using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.Language;
using INStore.UserControls.MyStore.ViewModels;
using Microsoft.Extensions.Logging;

namespace INStore.UserControls.MyStore.Commands
{
    public class EditStoreItem : AsyncCommandBase
    {
        private readonly IStoreItemsService _storeItemsService;
        private readonly MyStoreViewModel _myStoreViewModel;
        private readonly EditItemViewModel _editItemViewModel;
        public EditStoreItem(IStoreItemsService storeItemsService, MyStoreViewModel myStoreViewModel, EditItemViewModel editItemViewModel)
        {
            _storeItemsService = storeItemsService;
            _myStoreViewModel = myStoreViewModel;
            _editItemViewModel = editItemViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (await TheSameBarcodeExist())
            {
                _myStoreViewModel._SnackbarMessageQueue.Enqueue(LocalizedStrings.Instance["AddStoreItemTheSameBarcodeExist"]);
                return;
            }
            try
            {
                await _storeItemsService.Update(_editItemViewModel.StoreItem.Id, _editItemViewModel.StoreItem);
                _myStoreViewModel.GetAllStoreItemsCommand.Execute(null);
                MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand.Execute(null, null);

            }
            catch (Exception ex)
            {
                _myStoreViewModel._MyStoreViewModelLogger.LogError(ex.Message);
            }
        }
        private async Task<bool> TheSameBarcodeExist()
        {
            List<StoreItems> HavethesameBarcode = await _storeItemsService.Get(_editItemViewModel.StoreItem.Item.ItemBarCode);
            if (HavethesameBarcode.Where(a => a.Id != _editItemViewModel.StoreItem.Id && a.Item.ItemBarCode == _editItemViewModel.StoreItem.Item.ItemBarCode).Count() >= 1)
            {
                return true;
            }
            return false;
        }
    }
}
