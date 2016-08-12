using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QuickPaste
{
    public class PasteHistory
    {
        public ObservableCollection<Paste> Pastes { get; set; }
        
        public PasteHistory()
        {
            Pastes = new ObservableCollection<Paste>(); 
        }

        public void Init()
        {
            Pastes.CollectionChanged += Pastes_CollectionChanged;
        }

        private void Pastes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.Save(UserData.HistoryFile);
        }

        public void AddPaste(string url)
        {
            Pastes.Add(new Paste(url));
        }
    }
}
