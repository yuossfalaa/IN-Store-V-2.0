using INStore.ViewModels;
using System;
using System.Windows.Input;

namespace INStore.State.Navigators
{
    public interface INavigator
    {
        public enum ViewType
        {
            Login,
            Register,
            Home
        }
        ViewModelBase CurrentViewModel { get; set; }
        event Action StateChanged;

    }
}
