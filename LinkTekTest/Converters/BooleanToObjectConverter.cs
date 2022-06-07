using System;
using System.Globalization;
using System.Windows.Data;

namespace LinkTekTest.Converters
{
    public class BooleanToObjectConverter : IValueConverter
    {
        public object TrueValue { get; set; }
        public object FalseValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
                return null;

            return (bool)value ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (IsEqual(value, TrueValue))
                return true;
            if (IsEqual(value, FalseValue))
                return false;
            return null;
        }

        private static bool IsEqual(object x, object y)
        {
            if (Equals(x, y))
                return true;

            IComparable c = x as IComparable;
            if (c != null)
                return (c.CompareTo(y) == 0);

            return false;
        }
    }
}
