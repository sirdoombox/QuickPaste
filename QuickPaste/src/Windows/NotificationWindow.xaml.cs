using System;
using System.Windows.Threading;

namespace QuickPaste
{
    public partial class NotificationWindow
    {
        public NotificationWindow(string title, string line1, string line2)
        {
            InitializeComponent();
            txtTitle.Text = title;
            txtLine1.Text = line1;
            txtLine2.Text  = line2;
            DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(3) };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= Timer_Tick;
            Close();
        }
    }
}
