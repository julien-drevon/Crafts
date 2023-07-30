namespace ElegantCode.Fundamental.Core.Utils;

/// <summary>
/// PAgination contract. Is composition between DataList and pagination abstraction
/// </summary>
/// <typeparam name="T"></typeparam>
/// <seealso cref="Agaetis.ServicesModel.IBaseResponse" />
public interface IPaginatedResponse<T> : IBaseResponse, IGotCorrelationToken
{
    /// <summary>
    /// Gets or sets the datas list.
    /// </summary>
    /// <value>
    /// The datas.
    /// </value>
    IList<T> Datas { get; set; }

    /// <summary>
    /// Gets the pagination.
    /// </summary>
    /// <value>
    /// The pagination.
    /// </value>
    IPagination Pagination { get; }
}