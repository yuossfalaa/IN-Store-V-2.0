using INStore.State.Navigators;
using INStore.State.UserStore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INStore.HostBuilders
{
    public static class AddStateHostBuilderExtension
    {
        public static IHostBuilder AddState(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigator, Navigator>();
                services.AddSingleton<IUserStore, UserStore>();
                services.AddSingleton<IInRegistrationUser, InRegistrationUser>();
            });
            return host;
        }
    }
}
