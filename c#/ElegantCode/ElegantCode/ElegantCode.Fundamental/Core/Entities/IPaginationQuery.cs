namespace ElegantCode.Fundamental.Core.Entities;

public interface IPaginationQuery
{
    int PageNumber { get; set; }

    int PageSize { get; set; }
}