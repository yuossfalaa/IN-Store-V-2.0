using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace INStore.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly INStoreDbContextFactory _contextFactory;
        private readonly NonQueryDataService<T> _nonQueryDataService;

        public GenericDataService(INStoreDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<T>(contextFactory);
        }

        public async Task<T> Create(T entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(T entity)
        {
            return await _nonQueryDataService.Delete(entity);
        }
        public async Task<T> Update(int id, T entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<T> Get(int id)
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<List<T>> GetAll(bool IncludeDeletedItems)
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                List<T> entities  = await context.Set<T>().ToListAsync();
                if (!IncludeDeletedItems) entities = new List<T>(entities.Where(e => e.IsDeleted == false)); 
                return entities;
            }
        }


    }
}
