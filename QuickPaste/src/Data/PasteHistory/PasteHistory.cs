using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPaste
{
    public class PasteHistory
    {
        public ObservableCollection<Paste> Pastes { get; set; }

        private static bool DirExists { get { return Directory.Exists(StaticVars.ProfileDir); } }
        private static bool FileExists { get { return File.Exists(StaticVars.HistoryFile); } }

        public PasteHistory()
        {
            Pastes = new ObservableCollection<Paste>();
            Pastes.CollectionChanged += Pastes_CollectionChanged; 
        }

        private void Pastes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SavePasteHistory();
        }

        public void AddPaste(string url)
        {
            Pastes.Add(new Paste(url));
        }

        public static PasteHistory LoadPasteHistory()
        {
            if (!DirExists || !FileExists)
            {
                Directory.CreateDirectory(StaticVars.ProfileDir);
                return new PasteHistory();
            }
            using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(StaticVars.HistoryFile)))
            using (BsonReader br = new BsonReader(ms))
            {
                return new JsonSerializer().Deserialize<PasteHistory>(br);
            }
        }

        public void SavePasteHistory()
        {
            if (!DirExists)
                Directory.CreateDirectory(StaticVars.ProfileDir);
            using (BinaryWriter bw = new BinaryWriter(File.Open(StaticVars.HistoryFile, FileMode.Create)))
            using (BsonWriter br = new BsonWriter(bw))
            {
                new JsonSerializer().Serialize(br, this);
            }
        }
    }

    public class Paste
    {
        public DateTime PastedAt { get; set; }
        public string PasteURL { get; set; }

        public Paste(string url)
        {
            PasteURL = url;
            PastedAt = DateTime.UtcNow;
        }
    }
}
