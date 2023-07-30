namespace ElegantCode.Fundamental.Core.Utils;

public static class PaginationResponseExtensions
{
    /// <summary>
    /// Retrun nb of page of nbElementPerPage for this number
    /// </summary>
    /// <param name="totalEntry"></param>
    /// <param name="nbElementPerPage"></param>
    /// <returns></returns>
    public static int ComputeNbOfPage(this int totalEntry, int nbElementPerPage)
    {
        return nbElementPerPage != 0 ? (int)Math.Ceiling(totalEntry / (double)nbElementPerPage) : 1;
    }

    /// <summary>
    /// Retrun nb of page of nbElementPerPage for this number
    /// </summary>
    /// <param name="totalEntry"></param>
    /// <param name="nbElementPerPage"></param>
    /// <returns></returns>
    public static long ComputeNbOfPage(this long totalEntry, int nbElementPerPage)
    {
        return nbElementPerPage != 0 ? Convert.ToInt64(Math.Ceiling(totalEntry / (double)nbElementPerPage)) : 1;
    }

    /// <summary>
    /// Retourne une collection response en foction d'une collection response (optimisation, et facilite la vie car passe automatiquement les bon paramètres
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="query"></param>
    /// <returns></returns>
    public static IPaginatedResponse<TResponse> ToPaginationResponse<TResponse>(this IPaginatedResponse<TResponse> query)
    {
        if (query == null)
        {
            return new PaginatedResponse<TResponse>(Guid.Empty, new List<TResponse>(), 0, 1, 0);
        }

        var pi = query.Pagination.CurrentPage;
        var ps = query.Pagination.PageSize;

        var values = query.Datas;
        return new PaginatedResponse<TResponse>(query.CorrelationToken, values ?? new List<TResponse>(), query.Pagination.Total, pi, ps);
    }

    /// <summary>
    /// Retourne une collection response, paginée.
    /// </summary>
    /// <typeparam name="TResponse">Type de retour de la collection</typeparam>
    /// <param name="query"></param>
    /// <param name="pageNumber">collection à convertir</param>
    /// <param name="pageSize">nombre d'élément dans la page (0 = tout)</param>
    /// <param name="totalItem">nombre d'élément total. Si passé alors la methode Count() n'est pas appellé sur la collection</param>
    /// <returns></returns>
    public static IPaginatedResponse<TResponse> ToPaginationResponse<TResponse>(this IEnumerable<TResponse> query, Guid correlationToken,
                                                                                IPaginationRequest pagination)
    {
        if (query == null)
        {
            return new PaginatedResponse<TResponse>(correlationToken, new List<TResponse>(), 0, 1, pagination?.PageSize ?? 0);
        }

        var pi = pagination?.PageNumber ?? 1;
        var ps = pagination?.PageSize ?? 0;
        var total = query?.Count();
        var values = query.GetPage(pi, ps);
        return new PaginatedResponse<TResponse>(correlationToken, values ?? new List<TResponse>(), total ?? 0, pi, ps);
    }

    public static IPaginatedResponse<TResponse> ToPaginationResponse<T, TResponse>(this IEnumerable<T> query, Guid correlationToken,
                                                                                   Func<T, TResponse> convert,
                                                                                   IPaginationRequest pagination = null)
    {
        if (query == null)
        {
            return new PaginatedResponse<TResponse>(correlationToken, new List<TResponse>(), 0, 1, pagination?.PageSize ?? 0);
        }

        var pi = pagination?.PageNumber ?? 1;
        var ps = pagination?.PageSize ?? 0;
        var total = query?.Count();
        var values = query.GetPage(pi, ps);
        var collect = values.Select(convert).ToList();
        return new PaginatedResponse<TResponse>(correlationToken, collect ?? new List<TResponse>(), total ?? 0, pi, ps);
    }

    public static IPaginatedResponse<TResponse> ToPaginationResponse<T, TResponse>(this IList<T> query, Guid correlationToken,
                                                                                    Func<T, TResponse> convert,
                                                                                    IPaginationRequest pagination = null)
    {
        if (query == null)
        {
            return new PaginatedResponse<TResponse>(correlationToken, new List<TResponse>(), 0, 1, pagination?.PageSize ?? 0);
        }

        var pi = pagination?.PageNumber ?? 1;
        var ps = pagination?.PageSize ?? 0;
        var total = query?.Count;
        var values = query.GetPage(pi, ps);
        var collect = values.Select(convert).ToList();
        return new PaginatedResponse<TResponse>(correlationToken, collect ?? new List<TResponse>(), total ?? 0, pi, ps);
    }

    public static IPaginatedResponse<TResponse> ToPaginationResponse<T, TResponse>(this IQueryable<T> query, Guid correlationToken,
                                                                                    Func<T, TResponse> convert,
                                                                                    IPaginationRequest pagination = null)
    {
        if (query == null)
        {
            return new PaginatedResponse<TResponse>(correlationToken, new List<TResponse>(), 0, 1, pagination?.PageSize ?? 0);
        }

        var pi = pagination?.PageNumber ?? 1;
        var ps = pagination?.PageSize ?? 0;
        var total = query?.Count();
        var values = query.GetPage(pi, ps);
        var collect = values.Select(convert).ToList();
        return new PaginatedResponse<TResponse>(correlationToken, collect ?? new List<TResponse>(), total ?? 0, pi, ps);
    }

    /// <summary>
    /// Retourne une collection response, paginée.
    /// </summary>
    /// <typeparam name="TResponse">Type de retour de la collection</typeparam>
    /// <param name="query"></param>
    /// <param name="pageNumber">collection à convertir</param>
    /// <param name="pageSize">nombre d'élément dans la page (0 = tout)</param>
    /// <param name="totalItem">nombre d'élément total. Si passé alors la methode Count() n'est pas appellé sur la collection</param>
    /// <returns></returns>
    public static IPaginatedResponse<TResponse> ToPaginationResponse<TResponse>(this IEnumerable<TResponse> query, Guid correlationToken,
                                                                                int pageNumber = 1, int pageSize = 0
                                                                                , long? totalItem = null)
    {
        if (query == null)
        {
            return new PaginatedResponse<TResponse>(correlationToken, new List<TResponse>(), 0, 1, pageSize);
        }

        var pi = pageNumber;
        var ps = pageSize;
        var total = totalItem ?? query.Count();
        var values = query.GetPage(pi, ps);
        return new PaginatedResponse<TResponse>(correlationToken, values ?? new List<TResponse>(), total, pi, ps);
    }

    public static IPaginatedResponse<TResponse> ToPaginationResponse<T, TResponse>(this IPaginatedResponse<T> query, Func<T, TResponse> convert)
    {
        if (query?.Datas == null)
        {
            return new PaginatedResponse<TResponse>(query == null ? Guid.Empty : query.CorrelationToken, new List<TResponse>(), 0, 1, 0);
        }

        var pi = query.Pagination.CurrentPage;
        var ps = query.Pagination.PageSize;
        var values = query.Datas;
        var collect = values.Select(convert).ToList();
        return new PaginatedResponse<TResponse>(query.CorrelationToken, collect, query.Pagination.Total, pi, ps);
    }

    public static IPaginatedResponse<TResponse> ToPaginationResponse<T, TResponse>(this IEnumerable<T> query, Guid correlationToken,
                                                                                    Func<T, TResponse> convert,
                                                                                    int? pageNumber = 1,
                                                                                    int pageSize = 0,
                                                                                    long? totalItem = null)
    {
        if (query == null)
        {
            return new PaginatedResponse<TResponse>(correlationToken, new List<TResponse>(), 0, 1, pageSize);
        }

        var pi = pageNumber ?? 1;
        var ps = pageSize;
        var total = totalItem ?? query.Count();
        var values = query.GetPage(pi, ps);
        var collect = values.Select(convert).ToList();
        return new PaginatedResponse<TResponse>(correlationToken, collect ?? new List<TResponse>(), total, pi, ps);
    }

    public static IPaginatedResponse<TResponse> ToPaginationResponse<T, TResponse>(this IList<T> query, Guid correlationToken,
                                                                                    Func<T, TResponse> convert,
                                                                                    int? pageNumber = 1,
                                                                                    int pageSize = 0,
                                                                                    long? totalItem = null)
    {
        if (query == null)
        {
            return new PaginatedResponse<TResponse>(correlationToken, new List<TResponse>(), 0, 1, pageSize);
        }

        var pi = pageNumber ?? 1;
        var ps = pageSize;
        var total = totalItem ?? query.Count;
        var values = query.GetPage(pi, ps);
        var collect = values.Select(convert).ToList();
        return new PaginatedResponse<TResponse>(correlationToken, collect ?? new List<TResponse>(), total, pi, ps);
    }

    public static IPaginatedResponse<TResponse> ToPaginationResponse<T, TResponse>(this IQueryable<T> query, Guid correlationToken,
                                                                                    Func<T, TResponse> convert,
                                                                                    int? pageNumber = 1,
                                                                                    int pageSize = 0,
                                                                                    long? totalItem = null)
    {
        if (query == null)
        {
            return new PaginatedResponse<TResponse>(correlationToken, new List<TResponse>(), 0, 1, pageSize);
        }

        var pi = pageNumber ?? 1;
        var ps = pageSize;
        var total = totalItem ?? query.Count();
        var values = query.GetPage(pi, ps);
        var collect = values.Select(convert).ToList();
        return new PaginatedResponse<TResponse>(correlationToken, collect ?? new List<TResponse>(), total, pi, ps);
    }
}