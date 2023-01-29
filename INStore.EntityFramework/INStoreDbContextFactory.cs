using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace INStore.EntityFramework
{
    public class INStoreDbContextFactory : IDesignTimeDbContextFactory<INStoreDbContext>
    {
     
        public INStoreDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<INStoreDbContext>();
            //options.UseSqlite(ConnectionStringAssembler());
            options.UseSqlite("Data Source = INStore.db");
            return new INStoreDbContext(options.Options);
          
        }
        private string ConnectionStringAssembler()
        {
            string connectionstring = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); //AppData\Roaming
            connectionstring = connectionstring + @"\IN Store";
            System.IO.Directory.CreateDirectory(connectionstring);
            connectionstring = "Data Source = " + connectionstring + "\\INStore.db";
            return connectionstring;
        }
    }
}
