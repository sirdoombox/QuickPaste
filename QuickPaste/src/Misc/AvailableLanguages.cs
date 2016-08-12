using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QuickPaste
{
    public static class AvailableLanguages
    {
        public static ReadOnlyDictionary<string, string> LangDict { get; }

        static AvailableLanguages()
        {
            LangDict = new ReadOnlyDictionary<string, string>(
            new Dictionary<string, string>
            {
                { "C#", "cs" },
                { "C++", "cpp" },
                { "JavaScript", "js" },
                { "JSON", "json" },
                { "Plain Text", "txt" },
                { "XML", "xml" }
            });
        }
    }
}
