using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace QuickPaste
{

    public static class PasteUploader
    {
        public static string Upload(string code, UserSettings us)
        {
            switch (us.UploadLocation)
            {
                case UploadLocation.Hastebin:
                    return Hastebin(code);
                case UploadLocation.Pastebin:
                    return Pastebin(code, us.PastebinDevKey);
            }
            return null;
        }

        static string Hastebin(string code)
        {
            byte[] bytes = new ASCIIEncoding().GetBytes(code);
            var req = System.Net.WebRequest.Create("http://hastebin.com/documents");
            req.Timeout = 20000;
            req.Method = "POST";
            req.ContentType = "text/plain";
            req.ContentLength = bytes.Length;
            using (var reqStream = req.GetRequestStream())
            {
                reqStream.Write(bytes, 0, bytes.Length);
            }
            try
            {
                using (var resp = req.GetResponse())
                using (var rdr = new StreamReader(resp.GetResponseStream()))
                {
                    Dictionary<string, string> hr = JsonConvert.DeserializeObject<Dictionary<string, string>>(rdr.ReadToEnd());
                    string url = $"http://hastebin.com/{hr["key"]}";
                    return url;
                }
            }
            catch { return null; }
        }

        static string Pastebin(string code, string devkey)
        {
            if (string.IsNullOrEmpty(devkey))
                return null;
            var req = System.Net.WebRequest.Create("http://pastebin.com/api/api_post.php");
            req.Timeout = 20000;
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            string postString = $"api_dev_key={devkey}&api_option=paste&api_paste_code={code}";
            using (StreamWriter reqStream = new StreamWriter(req.GetRequestStream()))
            {
                reqStream.Write(postString);
            }
            try
            {
                using (var resp = req.GetResponse())
                using (var rdr = new StreamReader(resp.GetResponseStream()))
                {
                    string rslt = rdr.ReadToEnd();
                    if (!new Regex("http://pastebin.com/(.*)").IsMatch(rslt))
                        return null;
                    return rslt;
                }
            }
            catch { return null; }
        }
    }
}
