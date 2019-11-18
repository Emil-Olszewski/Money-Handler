using System;
using System.Globalization;
using System.Windows.Data;

namespace Money_App.ViewModel.Converters
{
    public class DotValueToCommaValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string dot = ((decimal)value).ToString();
            dot.Replace(".", ",");
            return dot;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
            => throw new NotImplementedException();
    }
}
