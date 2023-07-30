namespace ElegantCode.Fundamental.Core.Utils
{
    public interface IPaginationRequest
    {
        int PageNumber { get; set; }

        int PageSize { get; set; }
    }
}