using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace BindableLayoutIssue
{
    public class IsNotEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return false;
            }

            return value is IEnumerable enumerable && enumerable.Cast<object>().Any();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
