using INStore.Domain.Models;

namespace INStore.Domain.Services
{
    public interface IStoreItemsService : IDataService<StoreItems>
    {
        /// <summary>
        /// Get a Store Item Based on the Name or the Barcode
        /// </summary>
        /// <param name="StoreItemProp"></param>
        /// <returns>Store Items List with all Matching Items</returns>
        public Task<List<StoreItems>> Get(string StoreItemProp);
    }
}
