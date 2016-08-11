using System;
using System.Windows.Input;

namespace QuickPaste
{
    class ClearHistoryCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var ph = parameter as PasteHistory;
            ph?.Pastes.Clear();
        }
    }
}
