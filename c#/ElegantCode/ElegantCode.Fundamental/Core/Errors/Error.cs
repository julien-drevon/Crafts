using System.Diagnostics;

namespace ElegantCode.Fundamental.Core.Errors;

public class Error
{
    public string Message { get; }


    public Guid CorrelationToken { get; }

    public Error(Guid correlationToken, string message)
    {
        Message = message;
        CorrelationToken = correlationToken;
    }
}
