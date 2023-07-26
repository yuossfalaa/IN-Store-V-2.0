namespace INStore.Domain.Models
{
    public class StoreItems : DomainObject
    {
        public int StoreItemPropertiesId { get; set; }  
        public StoreItemProperties Item { get; set; }
        public int ItemNumberInStore { get; set; } = 0;
        public int ItemNumberInStock { get; set; }=0;
       
    }
}
