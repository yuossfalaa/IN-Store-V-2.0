using INStore.Factories;
using INStore.State.Authenticators;
using INStore.State.Navigators;
using INStore.State.UserStore;
using INStore.UserControls.Home.ViewModels;
using INStore.UserControls.MyStore.ViewModels;
using INStore.UserControls.MyStore.Views;
using INStore.UserControls.SignUp_IN.ViewModels;
using INStore.ViewModels;
using MaterialDesignThemes.Wpf;
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
                services.AddTransient<MainViewModel>();

                services.AddTransient(CreateHomeViewModel);
                services.AddScoped(CreateRegisterViewModel);
                services.AddScoped(CreateRegisterEmployeeViewModel);
                services.AddScoped(CreateMyStoreViewModel);

                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
                services.AddScoped<CreateViewModel<RegisterViewModel>>(services => () => services.GetRequiredService<RegisterViewModel>());
                services.AddScoped<CreateViewModel<RegisterEmployeeViewModel>>(services => () => services.GetRequiredService<RegisterEmployeeViewModel>());
                services.AddSingleton<CreateViewModel<HomeViewModel>>(services => () => services.GetRequiredService<HomeViewModel>());
                services.AddScoped<CreateViewModel<MyStoreViewModel>>(services => () => services.GetRequiredService<MyStoreViewModel>());

                services.AddSingleton<IINStoreViewModelFactory, INStoreViewModelFactory>();
                services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                services.AddScoped<ViewModelDelegateRenavigator<RegisterViewModel>>();
                services.AddScoped<ViewModelDelegateRenavigator<RegisterEmployeeViewModel>>();
                services.AddScoped<ViewModelDelegateRenavigator<MyStoreViewModel>>();
            });
            return host;
        }

        private static MyStoreViewModel CreateMyStoreViewModel(IServiceProvider services)
        {
            return new MyStoreViewModel();
        }

        private static RegisterEmployeeViewModel CreateRegisterEmployeeViewModel(IServiceProvider services)
        {
            return new RegisterEmployeeViewModel
                (
                services.GetRequiredService<ILogger<RegisterEmployeeViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                services.GetRequiredService<IInRegistrationUser>(),
                services.GetRequiredService<IAuthenticators>(),
                services.GetRequiredService<ISnackbarMessageQueue>()
                );
        }

        private static RegisterViewModel CreateRegisterViewModel(IServiceProvider services)
        {
            return new RegisterViewModel
                (
                services.GetRequiredService<ILogger<RegisterViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<RegisterEmployeeViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                services.GetRequiredService<IInRegistrationUser>()
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
                services.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>(),
                services.GetRequiredService<ISnackbarMessageQueue>()
                );
        }
    }

}
