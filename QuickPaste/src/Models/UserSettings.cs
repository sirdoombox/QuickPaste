using MahApps.Metro;
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

        private int _maxpastehistorycount;
        public int MaxPasteHistoryCount
        {
            get
            {
                return _maxpastehistorycount;
            }
            set
            {
                _maxpastehistorycount = value > 1000 ? 1000 : value ;
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

        private string _windowaccent;
        public string WindowAccent
        {
            get
            {
                return _windowaccent;
            }
            set
            {
                _windowaccent = value;
                NotifyPropertyChanged();
                UpdateTheme();
            }
        }

        private bool _isdarktheme;
        public bool IsDarkTheme
        {
            get
            {
                return _isdarktheme;
            }
            set
            {
                _isdarktheme = value;
                NotifyPropertyChanged();
                UpdateTheme();
            }
        }

        public UserSettings()
        {
            HotkeyCombination = HotkeyCombination.Default();
            WindowAccent = ThemeManager.DetectAppStyle().Item2.Name;
            IsDarkTheme = true;
            DefaultLanguage = "txt";
            DisplayNotifications = true;
            MaxPasteHistoryCount = 250;
            NotifyPropertyChanged();
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

        void UpdateTheme()
        {
            if(_windowaccent != null)
                ThemeManager.ChangeAppStyle(System.Windows.Application.Current,
                                            ThemeManager.GetAccent(_windowaccent),
                                            ThemeManager.GetAppTheme(_isdarktheme ? "BaseDark" : "BaseLight" ));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string p = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
            this.Save(UserData.SettingsFile);
        }
    }
}