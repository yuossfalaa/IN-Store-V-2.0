using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace INStore.EntityFramework.Services
{
    public class StoreItemsDataService : IStoreItemsService
    {
        private readonly INStoreDbContextFactory _contextFactory;
        private readonly NonQueryDataService<StoreItems> _nonQueryDataService;
        public StoreItemsDataService(INStoreDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<StoreItems>(_contextFactory);
        }
        public async Task<StoreItems> Create(StoreItems entity)
        {
            return await _nonQueryDataService.Create(entity);
        }
        public async Task<StoreItems> Update(int id, StoreItems entity)
        {
            return await _nonQueryDataService.Update(id, entity);

        }
        public async Task<bool> Delete(StoreItems entity)
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                entity.IsDeleted =true;
                context.Set<StoreItems>().Update(entity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<StoreItems> Get(int id)
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                StoreItems entity = await context.Set<StoreItems>()
                    .Include(u => u.Item)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<List<StoreItems>> GetAll(bool IncludeDeletedItems)
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                List<StoreItems> entities = new List<StoreItems>();
                if (!IncludeDeletedItems)
                {
                    entities = await context.Set<StoreItems>()
                        .Include(u => u.Item)
                        .Where(e => e.IsDeleted == false)
                        .ToListAsync();
                }
                else
                {
                    entities = await context.Set<StoreItems>()
                        .Include(u => u.Item)
                        .ToListAsync();
                }
                return entities;
            }
        }

        public async Task<List<StoreItems>> Get(string StoreItemProp)
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                List<StoreItems> entity = await context.Set<StoreItems>()
                    .Where((e) => 
                        e.IsDeleted == false &&
                        (e.Item.ItemName.ToLower().Contains(StoreItemProp.ToLower()) ||
                        e.Item.ItemBarCode.ToLower().Contains(StoreItemProp.ToLower())))
                    .Include(u => u.Item)
                    .ToListAsync();
                return entity;
            }
        }
       
    }
}
