using INStore.State.Navigators;
using INStore.UserControls.SignUp_IN.ViewModels;

namespace INStore.ViewModels
{

    public class ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();

    }
}
