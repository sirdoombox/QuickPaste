namespace QuickPaste
{
    internal class UserSettingsViewModel
    {
        public UserSettings Settings { get; set; }

        public UserSettingsViewModel()
        {
            Settings = UserSettings.LoadUserSettings();
            MainWindow.UserSettings = Settings;
        }
    }
}
