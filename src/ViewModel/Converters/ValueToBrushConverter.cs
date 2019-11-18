using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Money_App.ViewModel.Converters
{
    public class ValueToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((decimal)value > 0)
                return new SolidColorBrush(Color.FromRgb(180, 255, 180));
            else
                return new SolidColorBrush(Color.FromRgb(255, 180, 180));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
