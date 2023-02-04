using INStore.Commands;
using INStore.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace INStore.State.Navigators
{
    public class Navigator : INavigator 
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get 
            {
                return _currentViewModel;
            }
            set 
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                StateChanged?.Invoke();

            }
        }
        public event Action StateChanged;



    }
}
