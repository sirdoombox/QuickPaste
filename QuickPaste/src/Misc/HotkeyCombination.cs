namespace QuickPaste
{
    public class HotkeyCombination
    {
        public bool UseCtrl { get; set; }
        public bool UseShift { get; set; }
        public bool UseAlt { get; set; }
        public string Key { get; set; }

        public HotkeyCombination(bool ctrl, bool shift, bool alt, string key)
        {
            UseCtrl = ctrl;
            UseShift = shift;
            UseAlt = alt;
            Key = key;
        }
    }
}
