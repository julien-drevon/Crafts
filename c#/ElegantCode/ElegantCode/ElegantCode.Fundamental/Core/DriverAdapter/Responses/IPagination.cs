using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ElegantCode.Fundamental.Core.DriverAdapter.Responses;

public interface IPagination
{
    /// <summary>
    /// Gets or sets the current page.
    /// </summary>
    /// <value>
    /// The current page.
    /// </value>
    [DataMember(Name = "CurrentPage")]
    [JsonPropertyName("currentPage")]
    [JsonInclude]
    int CurrentPage { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance has next.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance has next; otherwise, <c>false</c>.
    /// </value>
    [DataMember(Name = "HasNext")]
    [JsonPropertyName("hasNext")]
    [JsonInclude]
    bool HasNext { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance has previous.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance has previous; otherwise, <c>false</c>.
    /// </value>
    [DataMember(Name = "HasPrevious")]
    [JsonPropertyName("hasPrevious")]
    [JsonInclude] bool HasPrevious { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is first page.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is first page; otherwise, <c>false</c>.
    /// </value>
    [DataMember(Name = "IsFirst")]
    [JsonPropertyName("isFirst")]
    [JsonInclude]
    bool IsFirst { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is last page.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is last page; otherwise, <c>false</c>.
    /// </value>
    [DataMember(Name = "IsLast")]
    [JsonPropertyName("isLast")]
    [JsonInclude]
    bool IsLast { get; set; }

    /// <summary>
    /// Gets or sets the index of the page. (start to 0)
    /// </summary>
    /// <value>
    /// The index of the page.
    /// </value>
    [DataMember(Name = "PageIndex")]
    [JsonPropertyName("pageIndex")]
    [JsonInclude]
    int PageIndex { get; set; }

    /// <summary>
    /// Gets or sets the page count. (start to 1)
    /// </summary>
    /// <value>
    /// The page count.
    /// </value>
    [DataMember(Name = "PageNumber")]
    [JsonPropertyName("pageNumber")]
    [JsonInclude]
    long PageNumber { get; set; }

    /// <summary>
    /// Gets or sets the request size of the page.
    /// </summary>
    /// <value>
    /// The size of the page.
    /// </value>
    [DataMember(Name = "PageSize")]
    [JsonPropertyName("pageSize")]
    [JsonInclude]
    int PageSize { get; set; }

    /// <summary>
    /// Gets or sets the total of elements in not paginiton request.
    /// </summary>
    /// <value>
    /// The total.
    /// </value>
    [DataMember(Name = "Total")]
    [JsonPropertyName("total")]
    [JsonInclude]
    long Total { get; set; }
}