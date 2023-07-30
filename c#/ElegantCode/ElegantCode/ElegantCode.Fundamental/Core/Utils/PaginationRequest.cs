using System.Runtime.Serialization;

namespace ElegantCode.Fundamental.Core.Utils;

public class PaginationRequest : IPaginationRequest
{
    public static readonly PaginationRequest DefaultPage = new PaginationRequest();

    public PaginationRequest(int pageNumber = 1, int pageSize = 0)
    {
        PageNumber = pageNumber < 1 ? 1 : pageNumber;
        PageSize = pageSize < 1 ? 0 : pageSize;
    }

    [DataMember]
    public virtual int PageNumber { get; set; }

    [DataMember]
    public virtual int PageSize { get; set; }
}