using System.Collections.Generic;

namespace QuickPaste
{
    public static class AvailableLanguages
    {
        public static Dictionary<string, string> LangDict;

        static AvailableLanguages()
        {
            LangDict = new Dictionary<string, string>
            {
                { "C#", "cs" },
                { "C++", "cpp" },
                { "JavaScript", "js" },
                { "JSON", "json" },
                { "Plain Text", "txt" },
                { "XML", "xml" }
            };
        }
    }
}
