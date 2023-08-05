namespace INStore.Domain.Models
{
    public class SellingHistory : DomainObject
    {
        public int ReceiptID { get; set; }
        public Receipts Receipt { get; set; }
        public string ItemName { get; set; } = "";

        private int _ItemNumber=0;

        public int ItemNumber
        {
            get { return _ItemNumber; }
            set { _ItemNumber = value; OnPropertyChanged(nameof(ItemNumber)); }
        }



        private double _ItemSellingPrice=0.0;

        public double ItemSellingPrice
        {
            get { return _ItemSellingPrice; }
            set { _ItemSellingPrice = value; OnPropertyChanged(nameof(ItemSellingPrice)); }
        }



        private double _ItemTotalCost = 0.0;

        public double ItemTotalCost
        {
            get { return _ItemTotalCost; }
            set { _ItemTotalCost = value; OnPropertyChanged(nameof(ItemTotalCost)); }
        } 


    }
}
