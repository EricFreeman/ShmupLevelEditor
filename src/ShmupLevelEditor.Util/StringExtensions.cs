namespace ShmupLevelEditor.Util
{
    public static class StringExtensions
    {
        public static string ToFormat(this string s, params object[] o)
        {
            return string.Format(s, o);
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNotNullOrEmpty(this string s)
        {
            return !string.IsNullOrEmpty(s);
        }

        public static string Default(this string s, string rtn)
        {
            return s.IsNullOrEmpty() ? rtn : s;
        }
    }
}
