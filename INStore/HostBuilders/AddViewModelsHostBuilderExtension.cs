using INStore.Factories;
using INStore.State.Navigators;
using INStore.UserControls.Home.ViewModels;
using INStore.UserControls.MyStore.ViewModels;
using INStore.UserControls.SignUp_IN.ViewModels;
using INStore.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace INStore.HostBuilders
{
    public static class AddViewModelsHostBuilderExtension
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services => 
            {
                #region Main factory and Main View Model
                services.AddSingleton<IINStoreViewModelFactory, INStoreViewModelFactory>();
                services.AddTransient<MainViewModel>();
                #endregion
                #region Home View Model
                services.AddTransient<HomeViewModel>();
                services.AddSingleton<CreateViewModel<HomeViewModel>>(services => () => services.GetRequiredService<HomeViewModel>());
                services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
                #endregion
                #region Register View Model
                services.AddTransient<RegisterViewModel>();
                services.AddTransient<RegisterEmployeeViewModel>();
                services.AddSingleton<CreateViewModel<RegisterViewModel>>(services => () => services.GetRequiredService<RegisterViewModel>());
                services.AddSingleton<CreateViewModel<RegisterEmployeeViewModel>>(services => () => services.GetRequiredService<RegisterEmployeeViewModel>());
                services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<RegisterEmployeeViewModel>>();
                #endregion
                #region MyStore View Model
                services.AddTransient<MyStoreViewModel>();
                services.AddSingleton<ViewModelDelegateRenavigator<MyStoreViewModel>>();
                services.AddSingleton<CreateViewModel<MyStoreViewModel>>(services => () => services.GetRequiredService<MyStoreViewModel>());
                #endregion
                #region Login View Model
                services.AddTransient<LoginViewModel>();
                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => services.GetRequiredService<LoginViewModel>());
                services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                #endregion
            });
            return host;
        }
    }

}
