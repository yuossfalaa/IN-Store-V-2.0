using INStore.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.Threading.Tasks;
using System.Windows;
using INStore.HostBuilders;
using Squirrel;
using Application = System.Windows.Application;

namespace INStore
{
    // Last Migration = > add-Migration InitialCreate_0.1
    public partial class App : Application
    {
        private UpdateManager manager;

        private readonly IHost _host;
        public App()
        {

            _host = CreateHostBuilder().Build();
        }
        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host
                  .CreateDefaultBuilder(args)
                  .AddSerilog()
                  .AddState()
                  .AddDbContext()
                  .AddServices()
                  .AddViews()
                  .AddViewModels()
                  .UseDefaultServiceProvider(options => options.ValidateScopes = false);
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
            try
            {
                manager = await UpdateManager
                        .GitHubUpdateManager(@"https://github.com/yuossfalaa/INStore-Updates");
                SquirrelAwareApp.HandleEvents(
                                onInitialInstall: v => manager.CreateShortcutForThisExe(),
                                onAppUpdate: v => manager.CreateShortcutForThisExe(),
                                onAppUninstall: v => manager.RemoveShortcutForThisExe());
            }
            catch
            {

            }
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
