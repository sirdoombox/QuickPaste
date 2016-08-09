using System.Windows.Controls;

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
            foreach (var item in StaticVars.AvailableLanguages)
                cboLangs.Items.Add(item.Key);
        }

        private void cboLangs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
