using System;
using System.Globalization;
using System.Windows.Data;

namespace QuickPaste
{
    class StringToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value as string;
            if (string.IsNullOrEmpty(val))
                return 250;
            return int.Parse(val);
        }
    }
}
