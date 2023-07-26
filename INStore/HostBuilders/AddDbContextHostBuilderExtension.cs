using INStore.EntityFramework;
using INStore.State.Registers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace INStore.HostBuilders
{
    public static class AddDbContextHostBuilderExtension
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
            IRegister registerApi = new Register();
            return registerApi.GetDBConnectionString();


        }
    }
}
