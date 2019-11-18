using System;
using System.Globalization;
using System.Windows.Data;
using static Money_App.ViewModel.Categories;

namespace Money_App.ViewModel.Converters
{
    public class EditedCategoryConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var oldName = values[0] as string;
            var newName = values[1] as string;

            if (!string.IsNullOrWhiteSpace(oldName) && !string.IsNullOrWhiteSpace(newName))
                return new EditedCategory(oldName, newName);
            else
                return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
