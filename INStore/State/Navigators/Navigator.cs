using INStore.Commands;
using INStore.ViewModels;
using System.Windows.Input;

namespace INStore.State.Navigators
{
    public class Navigator : INavigator
    {
        public ViewModelBase CurrentViewModel { get; set; }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
    }
}
