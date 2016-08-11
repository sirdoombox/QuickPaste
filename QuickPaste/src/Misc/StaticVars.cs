using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;

namespace QuickPaste
{
    public static class StaticVars
    {
        static StaticVars()
        {
            

            // I have to manually add these because there's no concrete documentation on Hastebin's syntax highlighting extensions.
            AvailableLanguages = new Dictionary<string, string>
            {
                { "C#", "cs" },
                { "C++", "cpp" },
                { "JavaScript", "js" },
                { "JSON", "json" },
                { "Plain Text", "txt" },
                { "XML", "xml" }
            };
        }



        public static Dictionary<string, string> AvailableLanguages;

        #region Modifier Key Info
        public static bool AltIsDown
        {
            get
            {
                return ((Keyboard.Modifiers & (ModifierKeys.Alt)) == (ModifierKeys.Alt));
            }
        }
        public static bool CtrlIsDown
        {
            get
            {
                return ((Keyboard.Modifiers & (ModifierKeys.Control)) == (ModifierKeys.Control));
            }
        }

        public static bool ShiftIsDown
        {
            get
            {
                return ((Keyboard.Modifiers & (ModifierKeys.Shift)) == (ModifierKeys.Shift));
            }
        }
        #endregion
    }
}
