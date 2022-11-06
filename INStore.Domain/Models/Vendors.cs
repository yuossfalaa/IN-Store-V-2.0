namespace INStore.Domain.Models
{
    public class Vendors : DomainObject
    {
        public string VendorName {get; set;}
        public string VendorPhoneNumber { get; set;}    
        public string VendorAddress { get; set;}    
        public string VendorType { get; set;}    
    }
}
