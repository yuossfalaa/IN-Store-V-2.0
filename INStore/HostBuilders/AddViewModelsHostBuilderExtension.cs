using INStore.Domain.Services.AuthenticationService;
using INStore.Factories;
using INStore.State.Authenticators;
using INStore.State.Navigators;
using INStore.UserControls.Home.ViewModels;
using INStore.UserControls.SignUp_IN.ViewModels;
using INStore.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;


namespace INStore.HostBuilders
{
    public static class AddViewModelsHostBuilderExtension
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services => 
            {
                services.AddTransient(CreateHomeViewModel);
                services.AddTransient<MainViewModel>();

                services.AddSingleton<CreateViewModel<HomeViewModel>>(services => () => services.GetRequiredService<HomeViewModel>());
                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
                services.AddSingleton<CreateViewModel<RegisterViewModel>>(services => () => CreateRegisterViewModel(services));

                services.AddSingleton<IINStoreViewModelFactory, INStoreViewModelFactory>();
                services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();
            });
            return host;
        }

        private static RegisterViewModel CreateRegisterViewModel(IServiceProvider services)
        {
            return new RegisterViewModel
                (
                services.GetRequiredService<ILogger<RegisterViewModel>>(),
                services.GetRequiredService<IAuthenticators>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>()
                ) ;
        }

        private static HomeViewModel CreateHomeViewModel(IServiceProvider services)
        {
            return new HomeViewModel();
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        {
            return new LoginViewModel
                (
                services.GetRequiredService<ILogger<LoginViewModel>>(),
                services.GetRequiredService<IAuthenticators>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>()
                );
        }
    }

}
