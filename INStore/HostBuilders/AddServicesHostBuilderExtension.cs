using INStore.Domain.Services;
using INStore.Domain.Services.AuthenticationService;
using INStore.EntityFramework.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace INStore.HostBuilders
{
    public static class AddServicesHostBuilderExtension
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {

            host.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IPasswordHasher, PasswordHasher>();
                services.AddSingleton<IUserService, UserDataService>();
                services.AddSingleton<IAuthenticationService, AuthenticationService>();
            });
            return host;
        }
    }
}
