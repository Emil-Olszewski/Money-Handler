using System;
using System.Globalization;
using System.Windows.Data;

namespace Money_App.ViewModel.Converters
{
    public class TransactionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string value = (string)values[0];
            string title = (string)values[1];
            string category = (string)values[2];

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
