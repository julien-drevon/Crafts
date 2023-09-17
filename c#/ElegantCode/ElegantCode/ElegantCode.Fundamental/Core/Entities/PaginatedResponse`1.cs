using ElegantCode.Fundamental.Core.Utils;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ElegantCode.Fundamental.Core.Entities;

/// <summary>
/// Collection paginée
/// </summary>
/// <typeparam name="T"></typeparam>
//[JsonObject(MemberSerialization.OptIn)]
[DataContract]
public class PaginatedResponse<T> : BaseResponse, IPaginatedResponse<T>
{
    public const string PAGE_UNDER_1_ERROR = "pageNumber cannot be below 1.";

    [JsonConstructor]
    public PaginatedResponse()
        : base(Guid.Empty, null, false)
    { }

    public PaginatedResponse(Guid correlationToken, long totalEntry = 0, int pageIndex = 1, string message = "", bool isOk = true)
                : this(correlationToken, new List<T>(), totalEntry, pageIndex, 0, message, isOk) { }

    public PaginatedResponse(Guid correlationToken, IEnumerable<T> values, long totalEntry, int pageIndex, int nbElementPerPage, string message = "", bool isOk = true)
        : base(correlationToken, message, isOk)
    {
        if (values is not null)
            Datas = values.ToList();

        InitValue(totalEntry, pageIndex, nbElementPerPage);
    }

    public IList<T> Datas { get; set; } = new List<T>();

    [DataMember(Name = "Pagination")]
    [JsonPropertyName("pagination")]
    [JsonConverter(typeof(IPaginationJsonConverter))]
    public IPagination Pagination { get; set; } = new Pagination();

    protected void InitValue(long totalEntry, int pageNumber, int nbElementPerPage)
    {
        if (pageNumber < 1)
            throw new ArgumentOutOfRangeException(nameof(pageNumber), pageNumber, PAGE_UNDER_1_ERROR);


        Pagination = new Pagination
        {
            PageSize = nbElementPerPage
        };

        long totalPage = totalEntry.ComputeNbOfPage(nbElementPerPage);
        PaginationStateCompute(totalEntry, pageNumber, totalPage);
    }

    private void PaginationStateCompute(long totalEntry, int pageNumber, long totalPage)
    {
        Pagination.PageNumber = totalPage;
        Pagination.Total = totalEntry;
        Pagination.CurrentPage = pageNumber;
        Pagination.PageIndex = pageNumber - 1;
        PaginationBooleanAttributesCompute();

    }

    private void PaginationBooleanAttributesCompute()
    {
        Pagination.IsLast = Pagination.PageIndex >= Pagination.PageNumber - 1;
        Pagination.IsFirst = Pagination.PageIndex <= 0;
        Pagination.HasPrevious = Pagination.PageIndex > 0;
        Pagination.HasNext = Pagination.PageIndex < Pagination.PageNumber - 1;
    }
}