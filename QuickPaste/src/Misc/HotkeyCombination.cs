using System.Windows.Input;

namespace QuickPaste
{
    public class HotkeyCombination
    {
        public ModifierKeys Modifiers { get; }
        public Key Key { get; }

        public HotkeyCombination(ModifierKeys mods, Key key)
        {
            Modifiers = mods;
            Key = key;
        }

        public static HotkeyCombination Default()
        {
            return new HotkeyCombination(ModifierKeys.Control | ModifierKeys.Alt, Key.L);
        }
    }
}
