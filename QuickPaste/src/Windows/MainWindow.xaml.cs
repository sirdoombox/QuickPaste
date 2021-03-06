﻿using Newtonsoft.Json;
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
            if (Keyboard.Modifiers == UserSettings.HotkeyCombination.Modifiers && e.KeyPressed == UserSettings.HotkeyCombination.Key)
                Paste();
        }

        void Paste()
        {
            string clipText = Clipboard.GetText();
            if (string.IsNullOrEmpty(clipText))
                return;
            string url = PasteUploader.Upload(clipText, UserSettings);
            if(url == null && UserSettings.DisplayNotifications)
            {
                ShowNotificationWindow("Paste Failed", $"Unable To Connect To {UserSettings.UploadLocation}.", "");
                return;
            }
            if (UserSettings.OpenURLOnUpload)
                System.Diagnostics.Process.Start(url);
            if (UserSettings.CopyURLOnUpload)
                Clipboard.SetText(url);
            PasteHistory.AddPaste(url);
            if(UserSettings.DisplayNotifications)
                ShowNotificationWindow("Paste Succesful", $"Your paste was succesfully uploaded to {UserSettings.UploadLocation}.", url);          
        }

        public static void ShowNotificationWindow(string title, string l1, string l2)
        {
            var s = System.Windows.Forms.Screen.FromPoint(new System.Drawing.Point(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y));
            Window notif = new NotificationWindow(title,l1,l2);
            var desktopWorkingArea = s.WorkingArea;
            notif.Left = desktopWorkingArea.Right - notif.Width;
            notif.Top = desktopWorkingArea.Bottom - notif.Height;
            notif.Visibility = Visibility.Visible;
            notif.WindowState = WindowState.Normal;
            notif.Topmost = true;
        }
        
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
    }
}
