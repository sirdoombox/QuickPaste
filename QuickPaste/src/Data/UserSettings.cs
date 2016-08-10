using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace QuickPaste
{
    public class UserSettings : INotifyPropertyChanged
    {
        private bool _openurlonupload;
        public bool OpenURLOnUpload
        {
            get
            {
                return _openurlonupload;
            }
            set
            {
                _openurlonupload = value;
                NotifyPropertyChanged();
            }
        }

        private bool _copyurlonupload;
        public bool CopyURLOnUpload
        {
            get
            {
                return _copyurlonupload;
            }
            set
            {
                _copyurlonupload = value;
                NotifyPropertyChanged();
            }
        }

        private string _defaultlanguage;
        public string DefaultLanguage
        {
            get
            {
                return _defaultlanguage;
            }
            set
            {
                _defaultlanguage = value;
                NotifyPropertyChanged();
            }
        }

        private static bool DirExists { get { return Directory.Exists(StaticVars.ProfileDir); } }
        private static bool FileExists { get { return File.Exists(StaticVars.SettingsFile); } }

        public static UserSettings LoadUserSettings()
        {
            if ( !DirExists || !FileExists )
            {
                Directory.CreateDirectory(StaticVars.ProfileDir);
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
                Directory.CreateDirectory(StaticVars.ProfileDir);
            using (BinaryWriter bw = new BinaryWriter(File.Open(StaticVars.SettingsFile, FileMode.Create)))
            using (BsonWriter br = new BsonWriter(bw))
            {
                new JsonSerializer().Serialize(br, this);
            }
        }

        #region NotifyImplementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string p = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
            SaveUserSettings();
        }
        #endregion
    }
}
