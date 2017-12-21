namespace Checklist.Classes
{
    public static class Propriedades
    {
        public static string PastaRelease { get { return @"\\Planet_press-pc\000\Dev Team\Checklist\Release"; } }
        public static string PastaChecklists { get { return @"\\Planet_press-pc\000\Dev Team\Checklist\Data"; } }
        public static string PastaEstado { get { return @"\\Planet_press-pc\000\Dev Team\Checklist\Estado"; } }
        private static bool _Writing;
        public static bool Writing
        {
            get { return _Writing; }
            set
            {
                _Writing = value;
                _WritingStateChanged?.Invoke(value);
            }
        }
        private static event WritingStateChange _WritingStateChanged;
        public static event WritingStateChange WritingStateChanged
        {
            add
            {
                if (_WritingStateChanged != null)
                {
                    _WritingStateChanged += value;
                }
            }
            remove
            {
                _WritingStateChanged -= value;
            }
        }
        public delegate void WritingStateChange(bool value);

    }
}
