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
            AvailableAccents = new ReadOnlyCollection<string>(ThemeManager.Accents.Select(x => x.Name).OrderBy(x=>x).ToList());
        }
    }
}
