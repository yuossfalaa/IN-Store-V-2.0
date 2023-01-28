using INStore.EntityFramework;
using INStore.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Windows;

namespace INStore
{
    public partial class App : Application
    {
        private readonly INStoreDbContextFactory iNStoreDbContextFactory = new INStoreDbContextFactory();
        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextCreator();
            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();
            base.OnStartup(e);
        }
        async Task DbContextCreator()
        {
            using (INStoreDbContext iNStoreDbContext = iNStoreDbContextFactory.CreateDbContext())
            {
                iNStoreDbContext.Database.MigrateAsync().Wait();
            }
            
        }
    }
}
