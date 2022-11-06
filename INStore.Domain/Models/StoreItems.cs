namespace INStore.Domain.Models
{
    public class StoreItems : DomainObject
    {
        public StoreItemProperties Item { get; set; }    
        public string ItemPlace { get; set; }
        public int ItemNumberInStore { get; set; }
        public int ItemNumberInStock { get; set; }
       



    }
}
