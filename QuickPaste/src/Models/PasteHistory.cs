﻿using System.Collections.ObjectModel;
using System.Collections.Specialized;

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
            if (MainWindow.UserSettings.MaxPasteHistoryCount < Pastes.Count)
                Pastes.RemoveAt(Pastes.Count - 1);
            Pastes.Insert(0, new Paste(url));
        }
    }
}
