using ElegantCode.Fundamental.Core.Entities;

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
        int pindex = pageIndex < 2 ? 1 : pageIndex;
        if (pageSize > 0)
        {
            return query.Skip((pindex - 1) * pageSize)
                        .Take(pageSize);
        }

        return query;
    }

    /// <summary>
    /// retourne true si la collection est differente de null et contient au moins un élément
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <returns></returns>
    public static bool IsAny<T>(this IEnumerable<T> collection, Func<T, bool> predicate = null)
    {
        return (collection.IsNotNull()
             && (predicate.IsNotNull()
                 ? collection.Any(predicate)
                 : collection.Any()));
    }

    /// <summary>
    /// retourne true si la répose paginée possède au moins un élément.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="paginedResponse"></param>
    /// <returns></returns>
    public static bool IsAny<T>(this IPaginatedResponse<T> paginedResponse, Func<T, bool> predicate = null)
    {
        return paginedResponse.IsNotNull()
              && (predicate.IsNull()
                 ? paginedResponse.Datas.IsAny()
                 : paginedResponse.Datas.IsAny(predicate));
    }

    /// <summary>
    /// Test si la collection est == à null ou ne contient pas d'élément
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection"></param>
    /// <returns></returns>
    public static bool IsEmptyOrNull<T>(this IEnumerable<T> collection)
    {
        return collection.IsAny()
                         .IsFalse();
    }

    /// <summary>
    /// retourne true si la collection est vide
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="paginedResponse"></param>
    /// <returns></returns>
    public static bool IsNotAny<T>(this IPaginatedResponse<T> paginedResponse, Func<T, bool> predicate = null)
    {
        return paginedResponse.IsAny(predicate)
                              .IsFalse();
    }
}