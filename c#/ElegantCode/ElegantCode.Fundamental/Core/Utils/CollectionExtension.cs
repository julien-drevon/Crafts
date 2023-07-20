namespace ElegantCode.Fundamental.Core.Utils
{
    public static class CollectionExtension
    {
        /// <summary>
        /// Test si la collection est differente de null et contient au moins un élément
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool IsAny<T>(this IEnumerable<T> collection, Func<T, bool> predicate = null)
        {
            return (collection != null &&
                     (predicate != null ? collection.Any(predicate) : collection.Any()));
        }

        public static void Foreach<T>(this IEnumerable<T> li, Action<T> doIt)
        {
            if (li.IsAny())
            {
                foreach (var x in li)
                {
                    doIt(x);
                }
            }
        }
    }
}