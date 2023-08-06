using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace INStore.EntityFramework.Services
{
    public class ReceiptsDataService : IReceiptsDataService
    {
        private readonly INStoreDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Receipts> _nonQueryDataService;

        public ReceiptsDataService(INStoreDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<Receipts>(_contextFactory);
        }

        public async Task<Receipts> Create(Receipts entity)
        {
            return await _nonQueryDataService.Create(entity);
        }
        public async Task<Receipts> Update(int id, Receipts entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
        public async Task<bool> Delete(Receipts entity)
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                Receipts Receipt = await context.Set<Receipts>()
                    .Include(u => u.Customer)
                    .Include(u => u.User)
                    .Include(u => u.SoldItems)
                    .FirstOrDefaultAsync((e) => e.Id == entity.Id);

                context.Set<Receipts>().Remove(Receipt);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<Receipts> Get(int id)
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                Receipts Receipt = await context.Set<Receipts>()
                    .Include(u => u.Customer)
                    .Include(u => u.User)
                    .Include(u => u.SoldItems)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return Receipt;
            }
        }

        public async Task<List<Receipts>> GetAll(bool IncludeDeletedItems)
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                List<Receipts> Receipt = await context.Set<Receipts>()
                    .Include(u => u.Customer)
                    .Include(u => u.User)
                    .Include(u => u.SoldItems)
                    .ToListAsync();
                return Receipt;
            }
        }

       
    }
}
