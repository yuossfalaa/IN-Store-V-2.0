namespace INStore.Domain.Models
{
    public class Store : DomainObject
    {
        public string? StoreName { get; set; }
        public int? StorePhoneNumber { get; set; }
        public int? StoreCurrency { get; set; }
        public int? StoreRecieptSize { get; set; }
        public int? StoreBarcodeLength { get; set; }
    }
}
