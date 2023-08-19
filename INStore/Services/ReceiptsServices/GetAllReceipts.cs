using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INStore.Commands;
using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.UserControls.Home.ViewModels;
using INStore.ViewModels;
using Microsoft.Extensions.Logging;

namespace INStore.Services.ReceiptsServices
{
    public class GetAllReceipts : AsyncCommandBase
    {
        private readonly ILogger<object> ViewModelLogger;
        private readonly ViewModelBase _viewModel;
        private readonly string _collectionPropertyName;
        private readonly IReceiptsDataService _receiptsService;

        public GetAllReceipts(ILogger<object> viewModelLogger, ViewModelBase viewModel, string collectionPropertyName, IReceiptsDataService receiptsService)
        {
            ViewModelLogger = viewModelLogger;
            _viewModel = viewModel;
            _collectionPropertyName = collectionPropertyName;
            _receiptsService = receiptsService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                List<Receipts> ReceiptsList = await _receiptsService.GetAll(false);
                await LoadData(ReceiptsList);
                ViewModelLogger.Log(LogLevel.Information, "All Receipts Loaded");
            }
            catch (Exception ex)
            {
                ViewModelLogger.LogError(ex.Message);
            }
        }
        private async Task LoadData(List<Receipts> ReceiptsList)
        {
            await Task.Run(async () =>
            {
                var propertyInfo = _viewModel.GetType().GetProperty(_collectionPropertyName);
                if (propertyInfo != null && propertyInfo.PropertyType == typeof(ObservableCollection<StoreItems>))
                {
                    propertyInfo.SetValue(_viewModel, new ObservableCollection<Receipts>(ReceiptsList));
                }
            });
        }
    }
}
