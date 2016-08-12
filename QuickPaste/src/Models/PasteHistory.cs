using System;
using System.Collections.ObjectModel;

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

        private void Pastes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.Save(UserData.HistoryFile);
        }

        public void AddPaste(string url)
        {
            Pastes.Add(new Paste(url));
        }
    }

    public class Paste
    {
        public DateTime PastedAt { get; set; }
        public string PasteURL { get; set; }

        public Paste(string url)
        {
            PasteURL = url;
            PastedAt = DateTime.Now;
        }
    }
}
