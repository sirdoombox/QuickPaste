using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;

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
            if ((combo.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                sb.Append("Ctrl+");
            if ((combo.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                sb.Append("Shift+");
            if ((combo.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt)
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

            ModifierKeys mk = ModifierKeys.None;
            if (vals.Any(x => string.Compare(x, "Ctrl", true) == 0))
                mk |= ModifierKeys.Control;
            if (vals.Any(x => string.Compare(x, "Shift", true) == 0))
                mk |= ModifierKeys.Shift;
            if (vals.Any(x => string.Compare(x, "Alt", true) == 0))
                mk |= ModifierKeys.Alt;

            Key key = Key.L;
            if (Enum.TryParse(vals.Last(), out key) && mk != ModifierKeys.None)
                return new HotkeyCombination(mk, key);
            else
                return HotkeyCombination.Default(); 
        }
    }
}
