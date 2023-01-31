using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace INStore.EntityFramework
{
    public class INStoreDbContextFactory 
    {

        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public INStoreDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public INStoreDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<INStoreDbContext> options = new DbContextOptionsBuilder<INStoreDbContext>();
            _configureDbContext(options);
            return new INStoreDbContext(options.Options);
        }

    }
}
