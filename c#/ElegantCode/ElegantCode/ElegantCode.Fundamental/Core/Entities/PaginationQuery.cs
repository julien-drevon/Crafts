using System.Runtime.Serialization;

namespace ElegantCode.Fundamental.Core.Entities;

public class PaginationQuery : IPaginationQuery
{
    public static readonly PaginationQuery DefaultPage = new PaginationQuery();

    public PaginationQuery(int pageNumber = 1, int pageSize = 0)
    {
        PageNumber = pageNumber < 2 ? 1 : pageNumber;
        PageSize = pageSize < 1 ? 0 : pageSize;
    }

    [DataMember]
    public virtual int PageNumber { get; set; }

    [DataMember]
    public virtual int PageSize { get; set; }
}