using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using INStore.UserControls.Home.ViewModels;
using INStore.UserControls.SignUp_IN.ViewModels;

namespace INStore.Converters
{
    public class CurrentViewModelToHelpVisibilityConverter:IValueConverter
    {
        public Visibility TrueValue { get; set; }
        public Visibility FalseValue { get; set; }

        public CurrentViewModelToHelpVisibilityConverter()
        {
            FalseValue = Visibility.Collapsed;
            TrueValue = Visibility.Visible;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value.ToString() == typeof(HomeViewModel).ToString())
            {
                return TrueValue;
            }
            else
            {
                return FalseValue;

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
