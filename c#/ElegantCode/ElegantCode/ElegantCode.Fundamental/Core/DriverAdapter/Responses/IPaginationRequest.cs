namespace ElegantCode.Fundamental.Core.DriverAdapter.Responses;

public interface IPaginationRequest
{
    int PageNumber { get; set; }

    int PageSize { get; set; }
}