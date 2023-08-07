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
            receipts.paymentStatus = PaymentStatus.Paid;
            if (receipts.Id == 0)
            {
                await CreateReceipt(receipts);
            }
            else
            {
                await UpdateReceipt(receipts);
            }

            _SnackbarMessageQueue.Enqueue("Order Paid");
        }
        public async Task CreateReceipt(Receipts receipts)
        {
            try
            {
                receipts = ExtractReceiptInfo(receipts);
                await _receiptsService.Create(receipts);
                _SnackbarMessageQueue.Enqueue("Order Created");
                _Logger.LogInformation("Order Created and Paid");
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
                receipts = ExtractReceiptInfo(receipts);
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
                receipts = ExtractReceiptInfo(receipts);
                await _receiptsService.Update(receipts.Id, receipts);
                _SnackbarMessageQueue.Enqueue("Order Updated");
                _Logger.LogInformation("Order Updated ");
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex.Message);
            }
        }
        private Receipts ExtractReceiptInfo(Receipts receipts)
        {
            if (receipts.User != null)
            {
                receipts.UserID = receipts.User.Id;
                receipts.User = null;
            }
            if (receipts.Customer != null)
            {
                receipts.CustomerId = receipts.Customer.Id;
                receipts.Customer = null;
            }
            return receipts;
        }
    }
}
