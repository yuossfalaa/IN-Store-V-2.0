using INStore.UserControls.Home.ViewModels;
using INStore.UserControls.MyStore.ViewModels;
using INStore.UserControls.SignUp_IN.ViewModels;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace INStore.Converters
{
    public class CurrentViewModelToVisibilityConverter : IValueConverter
    {
        public Visibility TrueValue { get; set; }
        public Visibility FalseValue { get; set; }

        public CurrentViewModelToVisibilityConverter()
        {
            FalseValue = Visibility.Collapsed;
            TrueValue = Visibility.Visible;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            //if (value.ToString() == typeof(HomeViewModel).ToString())
            //{
            //    return FalseValue;
            //}
            //else
            //{
            //    return TrueValue;

            //}
            return TrueValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
