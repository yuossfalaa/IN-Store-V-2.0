using INStore.Domain.Models;
using INStore.Domain.Services;
using INStore.EntityFramework.Services.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace INStore.EntityFramework.Services
{
    public class UserDataService : IUserService
    {
        private readonly INStoreDbContextFactory _contextFactory;
        private readonly NonQueryDataService<User> _nonQueryDataService;
        public UserDataService(INStoreDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<User>(contextFactory);
        }

        public async Task<User> Create(User entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(User entity)
        {
            return await _nonQueryDataService.Delete(entity);
        }
        public async Task<User> Update(int id, User entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<User> Get(int id)
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                User entity = await context.Set<User>()
                    .Include(u => u.Employee)
                    .Include(u => u.Settings)
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<List<User>> GetAll(bool IncludeDeletedItems)
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                List<User> entities = await context.Set<User>()
                    .Include(u => u.Employee)
                    .Include(u => u.Settings)
                    .ToListAsync();
                if (!IncludeDeletedItems) entities = new List<User>(entities.Where(e => e.IsDeleted == false));
                return entities;
            }
        }

        public async Task<User> GetByUsername(string username)
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                User entity = await context.Set<User>()
                    .Include(u => u.Employee)
                    .Include(u => u.Settings)
                    .FirstOrDefaultAsync(e => e.UserName == username && e.IsDeleted == false);
                return entity;
            }
        }

        public async Task<User> GetByAdminPassword(string HashedAdminPassword)
        {
            using (INStoreDbContext context = _contextFactory.CreateDbContext())
            {
                User entity = await context.Set<User>()
                    .Include(u => u.Employee)
                    .Include(u => u.Settings)
                    .FirstOrDefaultAsync((e) => e.AdminPasswordHash == HashedAdminPassword && e.IsDeleted == false);
                return entity;
            }
        }
    }
}
