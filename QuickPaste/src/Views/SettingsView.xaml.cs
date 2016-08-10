using System;
using System.Linq;
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
            cboLangs.ItemsSource = StaticVars.AvailableLanguages;;
            cboWinPos.ItemsSource = StaticVars.WindowPositions;
        }
    }
}
