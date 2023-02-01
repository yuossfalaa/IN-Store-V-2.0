using INStore.Domain.Services.AuthenticationService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INStore.HostBuilders
{
    public static class AddServicesHostBuilderExtension
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {

            host.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IAuthenticationService, AuthenticationService>();
            });
            return host;
        }
    }
}
