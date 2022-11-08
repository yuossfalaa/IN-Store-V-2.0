namespace INStore.Domain.Models
{
    public class Receipts : DomainObject
    {
        public double? ReceipttTotal { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string? TypeofSellingOperation { get; set; }

        public IEnumerable<SellingHistory?> SoldItems { get; set; }   
    }
}
