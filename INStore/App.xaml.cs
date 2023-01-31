using INStore.EntityFramework;
using INStore.State.Navigators;
using INStore.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading.Tasks;
using System.Windows;
using INStore.HostBuilders;

namespace INStore
{
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            _host = Host.CreateDefaultBuilder()
                  .AddSerilog()
                  .ConfigureServices(services =>
                  {
                      services.AddScoped<MainViewModel>();
                      services.AddScoped<INavigator, Navigator>();

                      services.AddScoped<MainWindow>(s => new MainWindow(_host!.Services.GetRequiredService<MainViewModel>()));

                  })
                  .AddDbContext()
                  .Build(); 
        }
        public static IHostBuilder CreatHostBuilder(string[] args = null)
        {
            return null;
        }
        private async Task DbContextCreator()
        {
            using (INStoreDbContext iNStoreDbContext = _host.Services.GetRequiredService<INStoreDbContextFactory>().CreateDbContext())
            {
                iNStoreDbContext.Database.MigrateAsync().Wait();
            }

        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            DbContextCreator();
            await _host.StartAsync();
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
