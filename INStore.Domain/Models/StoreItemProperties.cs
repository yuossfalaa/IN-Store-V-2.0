
namespace INStore.Domain.Models
{
    public class StoreItemProperties : DomainObject
    {
        public string ItemName { get; set; } = "";
        public string ItemDescription { get; set; } = "";
        public string ItemBarCode { get; set; } = "0";
        public double ItemSellingPrice { get; set; } = 0.0;
        public double ItemPurchasingPrice { get; set; } = 0.0;
        public byte[] Image { get; set; } = {0};
        public int StoreItemId { get; set; }
        public StoreItems StoreItem { get; set; }


    }
}
