using INStore.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INStore.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context,services) =>
            {
                Action<DbContextOptionsBuilder> configerdbContext = o => o.UseSqlite(ConnectionStringAssembler());
                services.AddSingleton<INStoreDbContextFactory>(new INStoreDbContextFactory(configerdbContext));
                services.AddDbContext<INStoreDbContext>(configerdbContext);

            });
            return host;
        }
        private static string ConnectionStringAssembler()
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
