namespace INStore.Domain.Models
{
    public class Vendor : DomainObject
    {
        public string VendorName {get; set;} = "";
        public string VendorPhoneNumber { get; set;} = "";
        public string VendorAddress { get; set;} = "";
        public int? VendorTypeId { get; set;}
        public VendorType? VendorType { get; set;}
    }
}
