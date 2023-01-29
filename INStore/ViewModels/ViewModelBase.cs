using INStore.State.Navigators;

namespace INStore.ViewModels
{

    public class ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();

    }
}
