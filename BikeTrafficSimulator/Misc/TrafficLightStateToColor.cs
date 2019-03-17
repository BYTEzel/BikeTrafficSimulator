using BikeTrafficSimulator.Models;
using System;
using Windows.UI.Xaml.Data;

namespace BikeTrafficSimulator.Misc
{
    class TrafficLightStateToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var state = (TrafficLight.State)value;
            if (TrafficLight.State.Green == state)
                return "Green";
            else
                return "Red";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
