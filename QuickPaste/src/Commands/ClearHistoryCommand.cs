using System;
using System.Windows.Input;

namespace QuickPaste
{
    class ClearHistoryCommand : ICommand
    {
        #pragma warning disable 67
        public event EventHandler CanExecuteChanged;
        #pragma warning restore

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