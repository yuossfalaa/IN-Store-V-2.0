namespace INStore.Domain.Models
{
    public class SellingHistory : DomainObject
    {
        public Receipts Receipt { get; set; }
        public string ItemName { get; set; }
        public int ItemNumber { get; set; }
        public double ItemSellingPrice { get; set; }
        public double ItemTotalCost { get; set; }
        
       
     

    }
}
