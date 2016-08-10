using System.Windows;
using System.Windows.Input;

namespace QuickPaste
{
    public partial class MainWindow
    {
        static Window Window;
        LowLevelKeyboardListener _keyboardHook;

        public MainWindow()
        {
            InitializeComponent();
            Window = this;
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            _keyboardHook = new LowLevelKeyboardListener();
            _keyboardHook.HookKeyboard();
            _keyboardHook.OnKeyPressed += KeyboardHook_OnKeyPressed;
        }

        bool altIsDown { get { return ((Keyboard.Modifiers & (ModifierKeys.Alt)) == (ModifierKeys.Alt)); } }
        bool ctrlIsDown { get { return ((Keyboard.Modifiers & (ModifierKeys.Control)) == (ModifierKeys.Control)); } }
        bool shiftIsDown { get { return ((Keyboard.Modifiers & (ModifierKeys.Shift)) == (ModifierKeys.Shift)); } }
        private void KeyboardHook_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            if(altIsDown)
                System.Console.WriteLine(e.KeyPressed);
        }

        #region Window Minimise Implementation
        private void MetroWindow_StateChanged(object sender, System.EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
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
        #endregion
    }
}
