using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace QuickPaste
{
    public class UserSettings : INotifyPropertyChanged
    {
        public bool OpenURLOnUpload { get; set; }
        public bool CopyURLOnUpload { get; set; }
        public string DefaultLanguage { get; set; }
        public bool ShowLanguageWindow { get; set; }
        public LangWindowPosition WindowPosition { get; set; }
        public List<string> PasteHistoryURL { get; set; }

        private static bool DirExists { get { return Directory.Exists(StaticVars.SettingsDir); } }
        private static bool FileExists { get { return File.Exists(StaticVars.SettingsFile); } }

        public static UserSettings LoadUserSettings()
        {
            if ( !DirExists || !FileExists )
            {
                Directory.CreateDirectory(StaticVars.SettingsDir);
                return new UserSettings();
            }
            using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(StaticVars.SettingsFile)))
            using (BsonReader br = new BsonReader(ms))
            {
                    return new JsonSerializer().Deserialize<UserSettings>(br);
            }
        }

        public void SaveUserSettings()
        {
            if (!DirExists)
                Directory.CreateDirectory(StaticVars.SettingsDir);
            using (BinaryWriter bw = new BinaryWriter(File.Open(StaticVars.SettingsFile, FileMode.Create)))
            using (BsonWriter br = new BsonWriter(bw))
            {
                new JsonSerializer().Serialize(br, this);
            }
        }

        #region NotifyImplementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
            SaveUserSettings();
        }
        #endregion
    }
}
