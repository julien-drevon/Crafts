namespace ElegantCode.Fundamental.Core.Entities;

/// <summary>
/// Pagination contract. Is composition between DataList and pagination abstraction
/// </summary>
/// <typeparam name="T"></typeparam>
/// <seealso cref="Agaetis.ServicesModel.IBaseResponse" />
public interface IPaginatedResponse<T> : IBaseResponse, IGotCorrelationToken
{
    /// <summary>
    /// Gets or sets the datas list. set is required for serialization
    /// </summary>
    /// <value>
    /// The datas.
    /// </value>
    IList<T> Data { get; set; }

    /// <summary>
    /// Gets the pagination.
    /// </summary>
    /// <value>
    /// The pagination.
    /// </value>
    IPagination Pagination { get; }
}