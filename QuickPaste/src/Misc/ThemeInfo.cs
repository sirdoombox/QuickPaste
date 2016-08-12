using MahApps.Metro;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace QuickPaste
{
    public static class ThemeInfo
    {
        public static ReadOnlyCollection<string> AvailableAccents{ get; }

        static ThemeInfo()
        {
            AvailableAccents = new ReadOnlyCollection<string>(new List<string>{
                "Red", "Green", "Blue", "Purple", "Orange", "Lime", "Emerald","Teal",
                "Cyan","Cobalt", "Indigo", "Violet", "Pink", "Magenta", "Crimson",
                "Amber", "Yellow", "Brown", "Olive", "Steel", "Mauve", "Taupe",
                "Sienna" }.OrderBy(x=>x).ToList());
        }
    }
}
