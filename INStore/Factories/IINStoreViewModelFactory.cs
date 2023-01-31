using INStore.State.Navigators;
using INStore.ViewModels;

namespace INStore.Factories
{
    public interface IINStoreViewModelFactory
    {
        ViewModelBase CreateViewModel(INavigator.ViewType viewType);
    }
}