using System;
using System.Threading.Tasks;
using INStore.Commands;
using INStore.Domain.Services;
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
    }
}
