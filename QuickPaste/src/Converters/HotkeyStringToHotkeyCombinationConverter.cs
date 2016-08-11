using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace QuickPaste
{
    class HotkeyStringToHotkeyCombinationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            HotkeyCombination combo = value as HotkeyCombination;
            if (value == null)
                return "";
            StringBuilder sb = new StringBuilder();
            if (combo.UseCtrl)
                sb.Append("Ctrl+");
            if (combo.UseShift)
                sb.Append("Shift+");
            if (combo.UseAlt)
                sb.Append("Alt+");
            sb.Append(combo.Key);
            return sb.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value as string;
            if (string.IsNullOrEmpty(val))
                return string.Empty;

            string[] vals = val.Split('+');
            string key = vals.Last();
            bool hasCtrl = false;
            bool hasShift = false;
            bool hasAlt = false;
            if (vals.Any(x => string.Compare(x, "Ctrl", true) == 0))
                hasCtrl = true;
            if (vals.Any(x => string.Compare(x, "Shift", true) == 0))
                hasShift = true;
            if (vals.Any(x => string.Compare(x, "Alt", true) == 0))
                hasAlt = true;
            return new HotkeyCombination(hasCtrl, hasShift, hasAlt, key);
        }
    }
}
