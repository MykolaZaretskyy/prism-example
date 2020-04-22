using System;
using System.Globalization;
using Prism.Test.Models.Abstract;
using Xamarin.Forms;

namespace Prism.Test.Converters
{
    public class ListItemStateToCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var state = (ListItemState)value;
            return state.HasFlag(ListItemState.Selected);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
