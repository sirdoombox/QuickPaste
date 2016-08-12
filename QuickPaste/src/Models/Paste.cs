using System;

namespace QuickPaste
{

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
