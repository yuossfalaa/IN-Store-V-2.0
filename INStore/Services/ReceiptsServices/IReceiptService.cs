using System.Threading.Tasks;
using INStore.Domain.Models;

namespace INStore.Services.ReceiptsServices
{
    public interface IReceiptService
    {
        Task PayReceipt(Receipts receipts);
        Task RefundReceipt(Receipts receipts);
        Task UpdateReceipt(Receipts receipts);
        Task CreateReceipt(Receipts receipts);
    }
}