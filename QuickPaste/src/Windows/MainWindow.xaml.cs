using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace QuickPaste
{
    public partial class MainWindow
    {
        static Window Window;
        GlobalKeyboardHook _keyboardHook;
        public static PasteHistory PasteHistory;
        public static UserSettings UserSettings;

        public MainWindow()
        {
            InitializeComponent();
            Window = this;
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            _keyboardHook = new GlobalKeyboardHook();
            _keyboardHook.HookKeyboard();
            _keyboardHook.OnKeyPressed += KeyboardHook_OnKeyPressed;
        }

        private void KeyboardHook_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            HotkeyCombination combo = UserSettings.HotkeyCombination;
            Key key = (Key)Enum.Parse(typeof(Key), combo.Key);
            if (StaticVars.CtrlIsDown == combo.UseCtrl && StaticVars.ShiftIsDown == combo.UseShift && StaticVars.AltIsDown == combo.UseAlt && e.KeyPressed == key)
                Paste();
        }

        void Paste()
        {
            string clipText = Clipboard.GetText();
            if (string.IsNullOrEmpty(clipText))
                return;
            byte[] bytes = new ASCIIEncoding().GetBytes(clipText);
            var req = System.Net.WebRequest.Create("http://hastebin.com/documents");
            req.Method = "POST";
            req.ContentType = "text/plain";
            req.ContentLength = bytes.Length;
            using (var reqStream = req.GetRequestStream())
            {
                reqStream.Write(bytes, 0, bytes.Length);
            }
            using (var resp = req.GetResponse())
            {
                Dictionary<string, string> hr = JsonConvert.DeserializeObject<Dictionary<string, string>>(new StreamReader(resp.GetResponseStream()).ReadToEnd());
                string url = $"http://hastebin.com/{hr["key"]}.{UserSettings.DefaultLanguage}";
                if (UserSettings.OpenURLOnUpload)
                    System.Diagnostics.Process.Start(url);
                if (UserSettings.CopyURLOnUpload)
                    Clipboard.SetText(url);
                PasteHistory.AddPaste(url);
            }
        }

        #region Window Minimise Implementation
        private void MetroWindow_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized && UserSettings.MinimiseToSystemTray)
            {
                Window.Hide();
                sysTrayIcon.Visibility = Visibility.Visible;
            }
        }
        
        private void sysTrayIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        {
            Window.Show();
            WindowState = WindowState.Normal;
            Window.Focus();
            sysTrayIcon.Visibility = Visibility.Collapsed;
        }
        
        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _keyboardHook.UnHookKeyboard();
            Application.Current.Shutdown();
        }
        #endregion
    }
}
