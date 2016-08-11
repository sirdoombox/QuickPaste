using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
