using INStore.UserControls.Home.ViewModels;
using INStore.UserControls.MyStore.ViewModels;
using INStore.UserControls.Orders.ViewModel;
using INStore.UserControls.SignUp_IN.ViewModels;
using INStore.ViewModels;
using System;
using static INStore.State.Navigators.INavigator;

namespace INStore.Factories
{
    public class INStoreViewModelFactory : IINStoreViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<RegisterViewModel> _createRegisterViewModel;
        private readonly CreateViewModel<RegisterEmployeeViewModel> _createRegisterEmployeeViewModel;
        private readonly CreateViewModel<MyStoreViewModel> _createMyStoreViewModel;
        private readonly CreateViewModel<OrdersViewModel> _createOrdersViewModel;

        public INStoreViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel,
            CreateViewModel<LoginViewModel> createLoginViewModel,
            CreateViewModel<RegisterViewModel> createRegisterViewModel,
            CreateViewModel<RegisterEmployeeViewModel> createRegisterEmployeeViewModel,
            CreateViewModel<MyStoreViewModel> createMyStoreViewModel,
            CreateViewModel<OrdersViewModel> createOrdersViewModel)

        {
            _createHomeViewModel = createHomeViewModel;
            _createLoginViewModel = createLoginViewModel;
            _createRegisterViewModel = createRegisterViewModel;
            _createRegisterEmployeeViewModel = createRegisterEmployeeViewModel;
            _createMyStoreViewModel = createMyStoreViewModel;
            _createOrdersViewModel = createOrdersViewModel;
        }
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createHomeViewModel();
                    break;
                case ViewType.Login:
                    return _createLoginViewModel();
                    break;               
                case ViewType.Register:
                    return _createRegisterViewModel();
                    break;
                case ViewType.RegisterEmployee:
                    return _createRegisterEmployeeViewModel();
                    break;
                case ViewType.MyStore:
                    return _createMyStoreViewModel();
                    break; 
                case ViewType.Orders:
                    return _createOrdersViewModel();
                    break;
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
