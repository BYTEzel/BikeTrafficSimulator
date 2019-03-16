using System;
using Windows.UI.Xaml.Data;

namespace BikeTrafficSimulator.Misc
{
    class RoundDecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return Math.Round((decimal)value, 2);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
