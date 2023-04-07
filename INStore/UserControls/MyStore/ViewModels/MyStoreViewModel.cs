using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using INStore.ViewModels;
using MaterialDesignThemes.Wpf;
namespace INStore.UserControls.MyStore.ViewModels
{
    public class MyStoreViewModel : ViewModelBase
    {
        public ICommand EditCommand { get;set; }
        public ICommand FinishEditCommand { get;set; }
        private Visibility textBlockVisabilty;

        public Visibility TextBlockVisabilty
        {
            get { return textBlockVisabilty; }
            set { textBlockVisabilty = value; OnPropertyChanged(nameof(TextBlockVisabilty)); }
        }
        private Visibility textVisabilty;

        public Visibility TextVisabilty
        {
            get { return textVisabilty; }
            set { textVisabilty = value; OnPropertyChanged(nameof(TextVisabilty)); }
        }
        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; OnPropertyChanged(nameof(Text)); }

        }
        private PackIconKind editsaveIcon;

        public PackIconKind EditSaveIcon
        {
            get { return editsaveIcon; }
            set { editsaveIcon = value; OnPropertyChanged(nameof(EditSaveIcon)); }
        }


        public MyStoreViewModel()
        {
            EditCommand = new RelayCommand(EditTextBox);
            FinishEditCommand = new RelayCommand(FinishEditTextBox);
            TextBlockVisabilty = Visibility.Visible;
            TextVisabilty = Visibility.Collapsed;
            Text = " Before Edit";
            EditSaveIcon = PackIconKind.PencilOutline;

        }

        private void FinishEditTextBox()
        {
            TextBlockVisabilty = Visibility.Visible;
            TextVisabilty = Visibility.Collapsed;
            EditSaveIcon = PackIconKind.PencilOutline;

        }

        private void EditTextBox()
        {
            TextBlockVisabilty = Visibility.Collapsed;
            TextVisabilty = Visibility.Visible;
            EditSaveIcon = PackIconKind.ContentSaveOutline;


        }
    }
}
