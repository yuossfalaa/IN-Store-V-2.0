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
using System.Globalization;
using INStore.Domain.Services;
using INStore.EntityFramework.Services;
using MaterialDesignThemes.Wpf;
using INStore.Domain.Models;
using System.Collections.Generic;

namespace INStore
{
    public partial class App : Application
    {
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
                  .AddViewModels();
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
            WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.SetCurrentThreadCulture = true;
            WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.Culture = new CultureInfo("en-US");
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
