using ElegantCode.Fundamental.Core.Entities;

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
    { return nbElementPerPage != 0 ? (int)Math.Ceiling(totalEntry / (double)nbElementPerPage) : 1; }

    /// <summary>
    /// Retrun nb of page of nbElementPerPage for this number
    /// </summary>
    /// <param name="totalEntry"></param>
    /// <param name="nbElementPerPage"></param>
    /// <returns></returns>
    public static long ComputeNbOfPage(this long totalEntry, int nbElementPerPage)
    { return nbElementPerPage != 0 ? Convert.ToInt64(Math.Ceiling(totalEntry / (double)nbElementPerPage)) : 1; }

    /// <summary>
    /// Retourne une collection response en foction d'une collection response (optimisation, et facilite la vie car
    /// passe automatiquement les bon paramètres
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="query"></param>
    /// <returns></returns>
    public static IPaginatedResponse<TResponse> ToPaginationResponse<TResponse>(
        this IPaginatedResponse<TResponse> query)
    {
        if (query.IsNull())
            return CreateDefaultPaginationResponse<TResponse>(Guid.Empty, 0);

        var pageNumberCompute = query.Pagination?.CurrentPage ?? 0;
        var pageSizeCompute = query.Pagination?.PageSize ?? 0;

        var values = query.Datas;
        return new PaginatedResponse<TResponse>(
            query.CorrelationToken,
            values ?? new List<TResponse>(),
            query.Pagination?.Total ?? 0,
            pageNumberCompute,
            pageSizeCompute);
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
    public static IPaginatedResponse<TResponse> ToPaginationResponse<TResponse>(
        this IEnumerable<TResponse> query,
        Guid correlationToken,
        IPaginationRequest pagination)
    {
        if (query.IsNull())
            return CreateDefaultPaginationResponse<TResponse>(correlationToken, pagination?.PageSize);

        var pageNumberCompute = pagination?.PageNumber ?? 1;
        var pageSizeCompute = pagination?.PageSize ?? 0;
        var total = query?.Count();
        var values = query.GetPage(pageNumberCompute, pageSizeCompute);
        return new PaginatedResponse<TResponse>(correlationToken, values ?? new List<TResponse>(), total ?? 0, pageNumberCompute, pageSizeCompute);
    }

    /// <summary>
    /// Converts to paginationresponse.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <param name="query">The query.</param>
    /// <param name="correlationToken">The correlation token.</param>
    /// <param name="convert">The convert.</param>
    /// <param name="pagination">The pagination.</param>
    /// <returns></returns>
    public static IPaginatedResponse<TResponse> ToPaginationResponse<T, TResponse>(
        this IEnumerable<T> query,
        Guid correlationToken,
        Func<T, TResponse> convert,
        IPaginationRequest pagination = null)
    {
        if (query.IsNull())
            return CreateDefaultPaginationResponse<TResponse>(correlationToken, pagination?.PageSize);

        var pageNumberCompute = pagination?.PageNumber ?? 1;
        var pageSizeCompute = pagination?.PageSize ?? 0;
        var total = query?.Count();
        var values = query.GetPage(pageNumberCompute, pageSizeCompute);
        var collect = values.Select(convert).ToList();
        return new PaginatedResponse<TResponse>(correlationToken, collect ?? new List<TResponse>(), total ?? 0, pageNumberCompute, pageSizeCompute);
    }

    /// <summary>
    /// Converts to paginationresponse.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <param name="query">The query.</param>
    /// <param name="correlationToken">The correlation token.</param>
    /// <param name="convert">The convert.</param>
    /// <param name="pagination">The pagination.</param>
    /// <returns></returns>
    public static IPaginatedResponse<TResponse> ToPaginationResponse<T, TResponse>(
        this IList<T> query,
        Guid correlationToken,
        Func<T, TResponse> convert,
        IPaginationRequest pagination = null)
    {
        if (query.IsNull())
            return CreateDefaultPaginationResponse<TResponse>(correlationToken, pagination?.PageSize);

        var pageNumberCompute = pagination?.PageNumber ?? 1;
        var pageSizeCompute = pagination?.PageSize ?? 0;
        var total = query?.Count;
        var values = query.GetPage(pageNumberCompute, pageSizeCompute);
        var collect = values.Select(convert).ToList();
        return new PaginatedResponse<TResponse>(correlationToken, collect ?? new List<TResponse>(), total ?? 0, pageNumberCompute, pageSizeCompute);
    }

    /// <summary>
    /// Converts to paginationresponse.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <param name="query">The query.</param>
    /// <param name="correlationToken">The correlation token.</param>
    /// <param name="convert">The convert.</param>
    /// <param name="pagination">The pagination.</param>
    /// <returns></returns>
    public static IPaginatedResponse<TResponse> ToPaginationResponse<T, TResponse>(
        this IQueryable<T> query,
        Guid correlationToken,
        Func<T, TResponse> convert,
        IPaginationRequest pagination = null)
    {
        if (query.IsNull())
            return CreateDefaultPaginationResponse<TResponse>(correlationToken, pagination?.PageSize);

        var pageNumberCompute = pagination?.PageNumber ?? 1;
        var pageSizeCompute = pagination?.PageSize ?? 0;
        var total = query?.Count();
        var values = query.GetPage(pageNumberCompute, pageSizeCompute);
        var collect = values.Select(convert).ToList();
        return new PaginatedResponse<TResponse>(correlationToken, collect ?? new List<TResponse>(), total ?? 0, pageNumberCompute, pageSizeCompute);
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
    public static IPaginatedResponse<TResponse> ToPaginationResponse<TResponse>(
        this IEnumerable<TResponse> query,
        Guid correlationToken,
        int pageNumber = 1,
        int pageSize = 0,
        long? totalItem = null)
    {
        if (query.IsNull())
            return CreateDefaultPaginationResponse<TResponse>(correlationToken, pageSize);

        var total = totalItem ?? query.Count();
        var values = query.GetPage(pageNumber, pageSize);
        return new PaginatedResponse<TResponse>(correlationToken, values ?? new List<TResponse>(), total, pageNumber, pageSize);
    }

    /// <summary>
    /// Converts to paginationresponse.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <param name="query">The query.</param>
    /// <param name="convert">The convert.</param>
    /// <returns></returns>
    public static IPaginatedResponse<TResponse> ToPaginationResponse<T, TResponse>(
        this IPaginatedResponse<T> query,
        Func<T, TResponse> convert)
    {
        if ((query?.Datas).IsNull())
            return CreateDefaultPaginationResponse<TResponse>(query.IsNull() ? Guid.Empty : query.CorrelationToken, 0);

        var pageNumberCompute = query.Pagination.CurrentPage;
        var pageSizeCompute = query.Pagination.PageSize;
        var values = query.Datas;
        var collect = values.Select(convert).ToList();
        return new PaginatedResponse<TResponse>(query.CorrelationToken, collect, query.Pagination.Total, pageNumberCompute, pageSizeCompute);
    }

    /// <summary>
    /// Converts to paginationresponse.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <param name="query">The query.</param>
    /// <param name="correlationToken">The correlation token.</param>
    /// <param name="convert">The convert.</param>
    /// <param name="pageNumber">The page number.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <param name="totalItem">The total item.</param>
    /// <returns></returns>
    public static IPaginatedResponse<TResponse> ToPaginationResponse<T, TResponse>(
        this IEnumerable<T> query,
        Guid correlationToken,
        Func<T, TResponse> convert,
        int? pageNumber = 1,
        int pageSize = 0,
        long? totalItem = null)
    {
        if (query.IsNull())
            return CreateDefaultPaginationResponse<TResponse>(correlationToken, pageSize);

        var pageNumberCompute = pageNumber ?? 1;
        var total = totalItem ?? query.Count();
        var values = query.GetPage(pageNumberCompute, pageSize);
        var collect = values.Select(convert).ToList();
        return new PaginatedResponse<TResponse>(correlationToken, collect ?? new List<TResponse>(), total, pageNumberCompute, pageSize);
    }

    /// <summary>
    /// Converts to paginationresponse.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <param name="query">The query.</param>
    /// <param name="correlationToken">The correlation token.</param>
    /// <param name="convert">The convert.</param>
    /// <param name="pageNumber">The page number.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <param name="totalItem">The total item.</param>
    /// <returns></returns>
    public static IPaginatedResponse<TResponse> ToPaginationResponse<T, TResponse>(
        this IList<T> query,
        Guid correlationToken,
        Func<T, TResponse> convert,
        int? pageNumber = 1,
        int pageSize = 0,
        long? totalItem = null)
    {
        if (query.IsNull())
            return CreateDefaultPaginationResponse<TResponse>(correlationToken, pageSize);

        var pageNumberCompute = pageNumber ?? 1;
        var total = totalItem ?? query.Count;
        var values = query.GetPage(pageNumberCompute, pageSize);
        var collect = values.Select(convert).ToList();
        return new PaginatedResponse<TResponse>(correlationToken, collect ?? new List<TResponse>(), total, pageNumberCompute, pageSize);
    }

    /// <summary>
    /// Converts to paginationresponse.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <param name="query">The query.</param>
    /// <param name="correlationToken">The correlation token.</param>
    /// <param name="convert">The convert.</param>
    /// <param name="pageNumber">The page number.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <param name="totalItem">The total item.</param>
    /// <returns></returns>
    public static IPaginatedResponse<TResponse> ToPaginationResponse<T, TResponse>(
        this IQueryable<T> query,
        Guid correlationToken,
        Func<T, TResponse> convert,
        int? pageNumber = 1,
        int pageSize = 0,
        long? totalItem = null)
    {
        if (query.IsNull())
            return CreateDefaultPaginationResponse<TResponse>(correlationToken, pageSize);

        var pageNumberCompute = pageNumber ?? 1;
        var total = totalItem ?? query.Count();
        var values = query.GetPage(pageNumberCompute, pageSize);
        var collect = values.Select(convert).ToList();
        return new PaginatedResponse<TResponse>(correlationToken, collect ?? new List<TResponse>(), total, pageNumberCompute, pageSize);
    }

    private static IPaginatedResponse<TResponse> CreateDefaultPaginationResponse<TResponse>(Guid correlationToken, int? pageSize = 0)
    {
        return new PaginatedResponse<TResponse>(
            correlationToken,
            new List<TResponse>(),
            0,
            1,
            pageSize ?? 0);
    }
}