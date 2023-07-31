namespace ElegantCode.Fundamental.Core.Entities;

public interface IPaginationRequest
{
    int PageNumber { get; set; }

    int PageSize { get; set; }
}