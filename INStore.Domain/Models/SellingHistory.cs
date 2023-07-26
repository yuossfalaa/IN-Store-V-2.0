namespace INStore.Domain.Models
{
    public class SellingHistory : DomainObject
    {
        public int ReceiptID { get; set; }
        public Receipts Receipt { get; set; }
        public string ItemName { get; set; } = "";
        public int ItemNumber { get; set; } = 0;
        public double ItemSellingPrice { get; set; } = 0.0;
        public double ItemTotalCost { get; set; } =  0.0;
    }
}
