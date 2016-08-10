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

        bool altIsDown { get { return ((Keyboard.Modifiers & (ModifierKeys.Alt)) == (ModifierKeys.Alt)); } }
        bool ctrlIsDown { get { return ((Keyboard.Modifiers & (ModifierKeys.Control)) == (ModifierKeys.Control)); } }
        bool shiftIsDown { get { return ((Keyboard.Modifiers & (ModifierKeys.Shift)) == (ModifierKeys.Shift)); } }
        private void KeyboardHook_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            //if(altIsDown && ctrlIsDown && e.KeyPressed == Key.OemQuestion)
        }

        #region Window Minimise Implementation
        private void MetroWindow_StateChanged(object sender, System.EventArgs e)
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
