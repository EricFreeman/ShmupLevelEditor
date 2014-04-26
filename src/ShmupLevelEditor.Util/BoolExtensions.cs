namespace ShmupLevelEditor.Util
{
    public static class BoolExtensions
    {
        public static bool IsTrue(this bool? b)
        {
            return b ?? false;
        }

        public static bool IsFalse(this bool? b)
        {
            return b.HasValue && b.Value == false;
        }
    }
}
