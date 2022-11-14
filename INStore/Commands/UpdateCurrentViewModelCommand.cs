using INStore.State.Navigators;
using INStore.ViewModels;
using System;
using System.Windows.Input;
using static INStore.State.Navigators.INavigator;

namespace INStore.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator; 
        }

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        { 
            if (parameter is ViewType)
            {
                ViewType viewtype = (ViewType)parameter;
                switch (viewtype)
                {
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel();
                        break;
                    case ViewType.About:
                        _navigator.CurrentViewModel = new AboutViewModel();
                        break;
                    case ViewType.DashBoard:
                        _navigator.CurrentViewModel = new DashBoardViewModel();
                        break;
                    case ViewType.MyStore:
                        _navigator.CurrentViewModel = new MyStoreViewModel();
                        break;
                    case ViewType.RefundDashboard:
                        _navigator.CurrentViewModel = new RefundDashboardViewModel();
                        break;
                    case ViewType.SellerDashboard:
                        _navigator.CurrentViewModel = new SellerDashboardViewModel();
                        break;
                    case ViewType.Tools:
                        _navigator.CurrentViewModel = new ToolsViewModel();
                        break;
                }
            }
        }
    }
}