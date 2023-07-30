using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ElegantCode.Fundamental.Core.Utils;

public class BaseResponse : IBaseResponse
{
    [ExcludeFromCodeCoverage]
    [JsonConstructor]
    public BaseResponse()
    { }

    public BaseResponse(Guid correlationToken, string message = null, bool isOk = false)
    {
        CorrelationToken = correlationToken;
        Message = message;
        IsOk = isOk;
    }

    public virtual Guid CorrelationToken { get; set; }

    public virtual bool IsOk { get; set; }

    public virtual string Message { get; set; }
}