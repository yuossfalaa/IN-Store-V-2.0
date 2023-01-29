using INStore.UserControls.SignUp_IN.ViewModels;

namespace INStore.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
            Navigator.CurrentViewModel = new LoginViewModel();
        }
    }
}
