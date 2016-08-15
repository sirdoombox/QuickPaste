using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuickPaste
{
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            cboLangs.ItemsSource = AvailableLanguages.LangDict;
            cboAccents.ItemsSource = ThemeInfo.AvailableAccents;
        }
        
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            Key key = (e.Key == Key.System ? e.SystemKey : e.Key);
            if (key == Key.LeftShift || key == Key.RightShift
                || key == Key.LeftCtrl || key == Key.RightCtrl
                || key == Key.LeftAlt || key == Key.RightAlt
                || key == Key.LWin || key == Key.RWin)
                return;
            
            StringBuilder shortcutText = new StringBuilder();
            if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
                shortcutText.Append("Ctrl+");            
            if ((Keyboard.Modifiers & ModifierKeys.Shift) != 0)
                shortcutText.Append("Shift+");           
            if ((Keyboard.Modifiers & ModifierKeys.Alt) != 0)
                shortcutText.Append("Alt+");            
            shortcutText.Append(key.ToString());
            ((TextBox)sender).Text = shortcutText.ToString();
            Keyboard.ClearFocus();
        }

        private bool IsTextAllowed(string text)
        { 
            return !new Regex("[^0-9]+").IsMatch(text);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void TextBox_Pasting(object sender, System.Windows.DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
                if (!IsTextAllowed((string)e.DataObject.GetData(typeof(string))))
                    e.CancelCommand();                           
            else e.CancelCommand();        
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Keyboard.ClearFocus();
        }
    }
}
