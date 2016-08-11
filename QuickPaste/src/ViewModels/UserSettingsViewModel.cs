namespace QuickPaste
{
    internal class UserSettingsViewModel
    {
        public UserSettings Settings { get; set; }

        public UserSettingsViewModel()
        {
            Settings = UserData.Load<UserSettings>(UserData.SettingsFile);
            MainWindow.UserSettings = Settings;
        }
    }
}
