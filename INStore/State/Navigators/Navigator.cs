﻿using INStore.Commands;
using INStore.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace INStore.State.Navigators
{
    public class Navigator : ViewModelBase,INavigator 
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
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
       


    }
}
