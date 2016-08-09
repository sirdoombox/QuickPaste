namespace QuickPaste
{
    internal class UserSettingsViewModel
    {
        public UserSettingsViewModel()
        {
            Settings = UserSettings.LoadUserSettings();
        }

        public UserSettings Settings { get; set; }
    }
}
