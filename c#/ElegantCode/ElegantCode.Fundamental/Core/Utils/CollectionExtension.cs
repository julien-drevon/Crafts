namespace ElegantCode.Fundamental.Core.Utils
{
    public static class CollectionExtension
    {
        public static bool IsAny<T>(this IEnumerable<T> li)
        {
            return li != null && li.Any();
        }

        public static void Foreach<T>(this IEnumerable<T> li, Action<T> doIt)
        {
            if (!li.IsAny())
                return;
          
            foreach(var x in li)
            {
                doIt(x);
            }
        }
    }
}