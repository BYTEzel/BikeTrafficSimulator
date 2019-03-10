using BikeTrafficSimulator.Models;
using System;
using Windows.UI.Xaml.Data;

namespace BikeTrafficSimulator.Misc
{
    class BikerStateToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var state = (Biker.State)value;
            if (Biker.State.Driving == state)
                return "Aqua";
            else
                return "Gray";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
