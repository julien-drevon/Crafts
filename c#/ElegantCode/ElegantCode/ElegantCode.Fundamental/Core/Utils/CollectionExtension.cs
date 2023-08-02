namespace ElegantCode.Fundamental.Core.Utils;

public static class CollectionExtension
{
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

    /// <summary> Effectue la pagination d'un IEnumerable<T> suivant le nulmero de page
    /// (pageIndex) et le nombre d'élémpent par page (pageSize) un page size a 0 renvois TOUS les
    /// éléments. un page index inferieur à 1 est considéré comme 1
    /// </summary>
    /// <typeparam  name="T"></typeparam>
    /// <param name="query"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public static IEnumerable<T> GetPage<T>(this IEnumerable<T> query, int pageIndex = 1, int pageSize = 0)
    {
        int pi = pageIndex < 2 ? 1 : pageIndex;
        if (pageSize > 0)
        {
            return query.Skip((pi - 1) * pageSize)
                        .Take(pageSize);
        }

        return query;
    }

    /// <summary>
    /// Test si la collection est differente de null et contient au moins un élément
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <returns></returns>
    public static bool IsAny<T>(this IEnumerable<T> collection, Func<T, bool> predicate = null)
    {
        return (collection.IsNotNull() &&
                 (predicate.IsNotNull() ? collection.Any(predicate) : collection.Any()));
    }

    /// <summary>
    /// retourne true si la connection possede au moins un élément.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="li"></param>
    /// <returns></returns>
    public static bool IsAny<T>(this IPaginatedResponse<T> li, Func<T, bool> predicate = null)
    {
        return li.IsNotNull() && (predicate.IsNull() ? li.Datas.IsAny() : li.Datas.IsAny(predicate));
    }
}