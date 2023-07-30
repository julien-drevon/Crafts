using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ElegantCode.Fundamental.Core.Utils;

public class Pagination : IPagination
{
    [DataMember(Name = "CurrentPage")]
    [JsonPropertyName("currentPage")]
    [JsonInclude]
    public virtual int CurrentPage { get; set; }

    [DataMember(Name = "HasNext")]
    [JsonPropertyName("hasNext")]
    [JsonInclude]
    public virtual bool HasNext { get; set; }

    [DataMember(Name = "HasPrevious")]
    [JsonPropertyName("hasPrevious")]
    [JsonInclude]
    public virtual bool HasPrevious { get; set; }

    [DataMember(Name = "IsFirst")]
    [JsonPropertyName("isFirst")]
    [JsonInclude]
    public virtual bool IsFirst { get; set; }

    [DataMember(Name = "IsLast")]
    [JsonPropertyName("isLast")]
    [JsonInclude]
    public virtual bool IsLast { get; set; }

    [DataMember(Name = "PageIndex")]
    [JsonPropertyName("pageIndex")]
    [JsonInclude]
    public virtual int PageIndex { get; set; }

    [DataMember(Name = "PageNumber")]
    [JsonPropertyName("pageNumber")]
    [JsonInclude]
    public virtual long PageNumber { get; set; }

    [DataMember(Name = "PageSize")]
    [JsonPropertyName("pageSize")]
    [JsonInclude]
    public virtual int PageSize { get; set; }

    [DataMember(Name = "Total")]
    [JsonPropertyName("total")]
    [JsonInclude]
    public virtual long Total { get; set; }
}