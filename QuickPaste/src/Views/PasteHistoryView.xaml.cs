using System.Windows.Controls;

namespace QuickPaste
{
    public partial class PasteHistoryView : UserControl
    {
        public PasteHistoryView()
        {
            InitializeComponent();
        }
        
        private void ListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var lb = (ListBox)sender;
            if (lb.SelectedValue != null)
            {
                var paste = lb.SelectedValue as Paste;
                System.Diagnostics.Process.Start(paste?.PasteURL);
            }
        }
    }
}