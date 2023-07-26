using INStore.Language;
using INStore.State.Navigators;
using INStore.State.UserStore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                services.AddSingleton<ILanguageSetter, LanguageSetter>();
            });
            return host;
        }
    }
}
