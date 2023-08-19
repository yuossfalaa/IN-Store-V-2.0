using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using INStore.Commands;
using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.ViewModels;
using Microsoft.Extensions.Logging;

namespace INStore.Services.StoreItemServices
{
    public class GetAllStoreItems : AsyncCommandBase
    {
        private readonly IStoreItemsService _storeItemsService;
        public readonly ILogger<object> ViewModelLogger;
        private readonly ViewModelBase _viewModel;
        private readonly string _collectionPropertyName;

        public GetAllStoreItems(IStoreItemsService storeItemsService, ILogger<object> myStoreViewModelLogger, ViewModelBase viewModel, string collectionPropertyName)
        {
            _storeItemsService = storeItemsService;
            ViewModelLogger = myStoreViewModelLogger;
            _viewModel = viewModel;
            _collectionPropertyName = collectionPropertyName;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await Task.Run(async () =>
                {
                    List<StoreItems> storeItems = await _storeItemsService.GetAll(false);
                    await LoadData(storeItems);
                });
                ViewModelLogger.Log(LogLevel.Information, "All Store Items Loaded");
            }
            catch (Exception ex)
            {
                ViewModelLogger.LogError(ex.Message);
            }
        }

        private async Task LoadData(List<StoreItems> storeItems)
        {
            await Task.Run( async () => 
            {
                var propertyInfo = _viewModel.GetType().GetProperty(_collectionPropertyName);
                if (propertyInfo != null && propertyInfo.PropertyType == typeof(ObservableCollection<StoreItems>))
                {
                    propertyInfo.SetValue(_viewModel, new ObservableCollection<StoreItems>(storeItems));
                }
            });
        }
    }
}
