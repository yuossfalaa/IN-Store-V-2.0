using System;
using System.Threading.Tasks;
using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.UserControls.Home.ViewModels;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Logging;

namespace INStore.Services.ReceiptsServices
{
    public class ReceiptService : IReceiptService
    {
        private readonly ISnackbarMessageQueue _SnackbarMessageQueue;
        private readonly IReceiptsDataService _receiptsService;
        public ILogger<HomeViewModel> _Logger;


        public ReceiptService(ISnackbarMessageQueue snackbarMessageQueue, IReceiptsDataService receiptsService, ILogger<HomeViewModel> homeViewModelLogger)
        {
            _SnackbarMessageQueue = snackbarMessageQueue;
            _receiptsService = receiptsService;
            _Logger = homeViewModelLogger;
        }

        public async Task PayReceipt(Receipts receipts)
        {
            if (receipts.Id == 0)
            {
                await CreateAndPayReceipt(receipts);
            }
            else
            {
                await UpdateAndPayReceipt(receipts);
            }

            _SnackbarMessageQueue.Enqueue("Order Paid");
        }
        private async Task CreateAndPayReceipt(Receipts receipts)
        {
            try
            {
                receipts.paymentStatus = PaymentStatus.Paid;
                await _receiptsService.Create(receipts);
                _Logger.LogInformation("Order Created and Paid");
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex.Message);
            }
           
        }
        private async Task UpdateAndPayReceipt(Receipts receipts)
        {
            try
            {
                receipts.paymentStatus = PaymentStatus.Paid;
                await _receiptsService.Update(receipts.Id, receipts);
                _Logger.LogInformation("Order Updated and Paid");
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex.Message);
            }
        }
        public async Task RefundReceipt(Receipts receipts)
        {
            try
            {
                receipts.status = Status.Refunded;
                await _receiptsService.Update(receipts.Id, receipts);
                _SnackbarMessageQueue.Enqueue("Order Refunded");
                _Logger.LogInformation("Order Refunded");

            }
            catch (Exception ex)
            {
                _Logger.LogError(ex.Message);
            }
        }
        public async Task UpdateReceipt(Receipts receipts)
        {
            try
            {
                await _receiptsService.Update(receipts.Id, receipts);
                _SnackbarMessageQueue.Enqueue("Order Updated");
                _Logger.LogInformation("Order Updated ");
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex.Message);
            }
        }
    }
}
