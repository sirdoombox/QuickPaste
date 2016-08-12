using MahApps.Metro;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuickPaste
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
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
        }
    }
}
