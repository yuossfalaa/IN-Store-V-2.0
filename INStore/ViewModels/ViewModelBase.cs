using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace INStore.ViewModels
{

    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;

    public partial class ViewModelBase : ObservableObject
    {
        public virtual void Dispose() { }
    }

}
