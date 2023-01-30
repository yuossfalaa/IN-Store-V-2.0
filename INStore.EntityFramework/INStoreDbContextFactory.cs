using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace INStore.EntityFramework
{
    public class INStoreDbContextFactory : IDesignTimeDbContextFactory<INStoreDbContext>
    {
     
        public INStoreDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<INStoreDbContext>();
            options.UseSqlite(ConnectionStringAssembler());
            return new INStoreDbContext(options.Options);
          
        }
        private string ConnectionStringAssembler()
        {
            string connectionstring = "";
            try
            {
                connectionstring = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); //AppData\Roaming
                connectionstring = connectionstring + @"\IN Store\Data";
                System.IO.Directory.CreateDirectory(connectionstring);
                connectionstring = "Data Source = " + connectionstring + "\\INStore.db";
                
            }
            catch (Exception ConnectionStringAssemblerFailed)
            {

            }
            return connectionstring;


        }
    }
}
