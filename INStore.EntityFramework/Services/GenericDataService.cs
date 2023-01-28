using INStore.Domain.Models;
using INStore.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace INStore.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly INStoreDbContextFactory _contextFactory;

        public GenericDataService(INStoreDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult =   await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdResult.Entity;
            }
        }

         public async Task<bool> Delete(T entity)
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                T ToBeDeletedEntity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == entity.Id);
                context.Set<T>().Remove(ToBeDeletedEntity);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<T> Get(int id)
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<List<T>> GetAll()
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                List<T> entities  = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            }
           
        }
    }
}
