
namespace INStore.Domain.Models
{
    public class StoreItemProperties : DomainObject
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemBarCode { get; set; }
        public double ItemSellingPrice { get; set; }
        public double ItemPurchasingPrice { get; set; }

    }
}
