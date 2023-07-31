namespace ElegantCode.Fundamental.Core.Utils
{
    public static class UtilsExtension
    {
        public static bool IsNull<T>(this T me)
        {
            return me == null;
        }

        public static bool IsNotNull<T>(this T me)
        {
            return me != null;
        }
    }
}