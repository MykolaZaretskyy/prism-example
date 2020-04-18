using System;
using System.Globalization;
using Prism.Test.Models.Abstract;
using Xamarin.Forms;

namespace Prism.Test.Converters
{
    class ListItemStateToBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var state = (ListItemState)value;
            switch (state)
            {
                case ListItemState.Focused:
                    return Color.Cyan;
                case ListItemState.Selected:
                    return Color.Chartreuse;
                default:
                    return Color.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
