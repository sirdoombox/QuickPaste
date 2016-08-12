using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System;
using System.IO;

namespace QuickPaste
{
    public static class UserData
    {
        public static string ProfileDir;
        public static string SettingsFile;
        public static string HistoryFile;

        static UserData()
        {
            ProfileDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QuickPaste");
            SettingsFile = Path.Combine(ProfileDir, "UserSettings");
            HistoryFile = Path.Combine(ProfileDir, "PasteHistory");
        }

        public static T Load<T>(string path) where T : new()
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)) || !File.Exists(path))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                return new T();
            }
            using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(path)))
            using (BsonReader br = new BsonReader(ms))
            {
                return new JsonSerializer().Deserialize<T>(br);
            }
        }

        public static void Save<T>(this T obj, string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            using (BsonWriter br = new BsonWriter(bw))
            {
                new JsonSerializer().Serialize(br, obj);
            }
        }
    }
}
