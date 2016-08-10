using System;
using System.Collections.Generic;
using System.IO;

namespace QuickPaste
{
    public static class StaticVars
    {
        public static string SettingsDir;
        public static string SettingsFile;

        public static Dictionary<string, string> AvailableLanguages;
        public static Dictionary<string, LangWindowPosition> WindowPositions;

        static StaticVars()
        {
            SettingsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QuickPaste");
            SettingsFile = Path.Combine(SettingsDir, "UserProfile");

            // I have to manually add these because there's no concrete documentation on Hastebin's syntax highlighting extensions.
            AvailableLanguages = new Dictionary<string, string>
            {
                { "C#", "cs" },
                { "C++", "cpp" },
                { "JavaScript", "js" },
                { "JSON", "json" },
                { "Plain Text", "txt" },
                { "XML", "xml" }
            };

            WindowPositions = new Dictionary<string, LangWindowPosition>
            {
                { "Top Left", LangWindowPosition.TopLeft },
                { "Top Right", LangWindowPosition.TopRight },
                { "Bottom Left", LangWindowPosition.BottomLeft },
                { "Bottom Right", LangWindowPosition.BottomRight },
            };
        }
    }
}
