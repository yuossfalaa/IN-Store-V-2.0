using INStore.Factories;
using INStore.Language;
using INStore.State.Authenticators;
using INStore.State.Navigators;
using INStore.UserControls.Home.ViewModels;
using INStore.UserControls.MyStore.ViewModels;
using INStore.UserControls.SignUp_IN.ViewModels;
using INStore.ViewModels;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace INStore.HostBuilders
{
    public static class AddViewsHostBuilderExtension
    {
        public static IHostBuilder AddViews(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            });

            return host;
        }

       
    }
}
