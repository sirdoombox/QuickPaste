using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QuickPaste
{
    public class UserSettings : INotifyPropertyChanged
    {
        private bool _minimisetosystemtray;
        public bool MinimiseToSystemTray
        {
            get
            {
                return _minimisetosystemtray;
            }
            set
            {
                _minimisetosystemtray = value;
                NotifyPropertyChanged();
            }
        }

        private bool _openonwindowsstart;
        public bool OpenOnWindowsStart
        {
            get
            {
                return _openonwindowsstart;
            }
            set
            {
                _openonwindowsstart = value;
                RegisterStartup(value);
                NotifyPropertyChanged();
            }
        }

        private HotkeyCombination _hotkeycombination;
        public HotkeyCombination HotkeyCombination
        {
            get
            {
                return _hotkeycombination;
            }
            set
            {
                _hotkeycombination = value;
                NotifyPropertyChanged();
            }
        }

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

        private bool _displaynotification;
        public bool DisplayNotifications
        {
            get
            {
                return _displaynotification;
            }
            set
            {
                _displaynotification = value;
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

        public UserSettings()
        {
            HotkeyCombination = new HotkeyCombination(true, true, false, "L");
            DefaultLanguage = "txt";
            DisplayNotifications = true;
        }

        void RegisterStartup(bool value)
        {
            var regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (value)
                regKey.SetValue("QuickPaste", System.Reflection.Assembly.GetExecutingAssembly().Location);
            else
                if (regKey.GetValue("QuickPaste") != null)
                    regKey.DeleteValue("QuickPaste");         
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string p = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
            this.Save(UserData.SettingsFile);
        }
    }
}