using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;

namespace QuickPaste
{
    public static class ModifierKeyInfo
    {
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
    }
}
