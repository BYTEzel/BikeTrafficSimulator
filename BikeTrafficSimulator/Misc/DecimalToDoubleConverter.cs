using System;
using Windows.UI.Xaml.Data;

namespace BikeTrafficSimulator.Misc
{
    class DecimalToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return double.Parse(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (decimal)value;
        }
    }
}
