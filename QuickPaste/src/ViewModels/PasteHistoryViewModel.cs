using System.Windows.Input;

namespace QuickPaste
{
    public class PasteHistoryViewModel
    {
        public PasteHistory History { get; set; }
        private ICommand _clearcommand;
        public ICommand ClearCommand
        {
            get
            {
                if (_clearcommand == null)
                    _clearcommand = new ClearHistoryCommand();
                return _clearcommand;
            }
            set
            {
                _clearcommand = value;
            }
        }

        public PasteHistoryViewModel()
        {
            History = UserData.Load<PasteHistory>(UserData.HistoryFile);
            History.Init();
            MainWindow.PasteHistory = History;
        }
    }
}
