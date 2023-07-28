using INStore.Domain.Models;

namespace INStore.Domain.Services
{
    public interface IStoreItemsService : IDataService<StoreItems>
    {
        public Task<List<StoreItems>> Get(string StoreItemProp);
    }
}
