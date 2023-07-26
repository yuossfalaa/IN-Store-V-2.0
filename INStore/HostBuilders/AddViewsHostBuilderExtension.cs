using INStore.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace INStore.HostBuilders
{
    public static class AddViewsHostBuilderExtension
    {
        public static IHostBuilder AddViews(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            });

            return host;
        }

       
    }
}
