using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPaste
{
    public class PasteHistoryViewModel
    {
        public PasteHistory History { get; set; }

        public PasteHistoryViewModel()
        {
            History = UserData.Load<PasteHistory>(UserData.HistoryFile);
            History.Init();
            MainWindow.PasteHistory = History;
        }
    }
}
