using System;
using System.Globalization;
using System.Windows.Data;

namespace Money_App.ViewModel.Converters
{
    public class TransactionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string value = values[0] as string;
            string title = values[1] as string;
            string category = values[2] as string;

            decimal dvalue;
            if (!string.IsNullOrWhiteSpace(value) && decimal.TryParse(value, out dvalue))
                if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(category))
                    return new Transaction(dvalue, title, category);

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
