using System.Collections.ObjectModel;

namespace INStore.Domain.Models
{
    public enum PaymentStatus
    {
        Paid,
        Pending
    }
    public enum TypeofSellingOperation
    {
        Delivery,
        Order
    }
    public enum Status
    {
        Done,
        Refunded
    }
    public class Receipts : DomainObject
    {
        public double ReceiptTotal { get; set; } = 0;
        public DateTime ReceiptDate { get; set; } = DateTime.Now;

        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int? UserID { get; set; }
        public User? User { get; set; }

        public string Notes { get; set; } = "";


        public TypeofSellingOperation typeofSellingOperation { get; set; } = TypeofSellingOperation.Order;
        public PaymentStatus paymentStatus { get; set; } = PaymentStatus.Pending;
        public Status status { get; set; } = Status.Done;




        private ObservableCollection<SellingHistory> _SoldItems= new ObservableCollection<SellingHistory>();

        public ObservableCollection<SellingHistory> SoldItems 
        {
            get { return _SoldItems; }
            set { _SoldItems = value; OnPropertyChanged(nameof(SoldItems)); }
        }
        
    }
}
