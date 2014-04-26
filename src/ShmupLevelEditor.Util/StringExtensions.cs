namespace ShmupLevelEditor.Util
{
    public static class StringExtensions
    {
        public static string ToFormat(this string s, params object[] o)
        {
            return string.Format(s, o);
        }
    }
}
