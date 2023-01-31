using INStore.Factories;
using INStore.State.Navigators;
using System;
using System.Windows.Input;
using static INStore.State.Navigators.INavigator;

namespace INStore.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private INavigator _navigator;
        private readonly IINStoreViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(IINStoreViewModelFactory viewModelFactory, INavigator navigator)
        {
            _viewModelFactory = viewModelFactory;
            _navigator = navigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}