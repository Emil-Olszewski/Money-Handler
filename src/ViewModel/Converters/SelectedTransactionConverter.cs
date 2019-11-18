using System;
using System.Globalization;
using System.Windows.Data;

namespace Money_App.ViewModel.Converters
{
    public class SelectedTransactionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int? index = (int?)values[0];
            string value = (string)values[1];
            string title = (string)values[2];
            string category = (string)values[3];

            decimal dvalue;
            if (index.HasValue && !string.IsNullOrWhiteSpace(value) && decimal.TryParse(value, out dvalue))
                if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(category))
                    return new SelectedTransaction((int)index, new Transaction(dvalue, title, category));

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
