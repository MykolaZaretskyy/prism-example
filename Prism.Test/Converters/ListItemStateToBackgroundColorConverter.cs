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
            if (state.HasFlag(ListItemState.Focused))
            {
                return Color.Cyan;
            }
            if (state.HasFlag(ListItemState.Selected))
            {
                return Color.Chartreuse;
            }

            return Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
