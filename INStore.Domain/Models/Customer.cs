namespace INStore.Domain.Models
{
    public class Customer: DomainObject
    {
        public string CustomerName { get; set; } = "";
        public string CustomerAddress { get; set; } = "";
        public string CustomerPhoneNumber { get; set; } = "";


    }
}
