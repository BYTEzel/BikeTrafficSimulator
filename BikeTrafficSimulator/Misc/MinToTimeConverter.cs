using System;
using Windows.UI.Xaml.Data;

namespace BikeTrafficSimulator.Misc
{
    class MinToTimeConverter : IValueConverter
    {
        private const string SEPARATOR = ":";

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            decimal min = (decimal)value;
            int hours = (int)min / 60;
            int minDisplay = (int)min % 60;
            return hours.ToString("00") + SEPARATOR + minDisplay.ToString("00");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string[] val = ((string)value).Split(SEPARATOR);
            int hours = int.Parse(val[0]) * 60;
            int minutes = int.Parse(val[1]);
            return hours + minutes;
        }
    }
}
