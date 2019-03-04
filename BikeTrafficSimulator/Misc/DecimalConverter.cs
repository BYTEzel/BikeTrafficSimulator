using System;
using Windows.UI.Xaml.Data;

namespace BikeTrafficSimulator.Misc
{
    public class DecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            Decimal.TryParse((string)value, out decimal result);
            return result;
        }
    }
}
