using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace INStore.EntityFramework
{
    public class INStoreDbContextFactory : IDesignTimeDbContextFactory<INStoreDbContext>
    {
     
        public INStoreDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<INStoreDbContext>();
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=INStoreDB;Trusted_Connection=True;");
            return new INStoreDbContext(options.Options);
          
        }
    }
}
