using System;
using System.ComponentModel;
using System.Windows.Controls;
using INStore.ViewModels;

namespace INStore.State.FloatingWindow
{
    public class FloatingWindow 
    {
        private ViewModelBase _FloatingWindowControl;

        public ViewModelBase FloatingWindowControl
        {
            get { return _FloatingWindowControl; }
            set { _FloatingWindowControl = value; StateChanged?.Invoke(); }
        }
        public event Action StateChanged;
    }
}
