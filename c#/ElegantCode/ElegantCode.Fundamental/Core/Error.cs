using System.Diagnostics;

namespace ElegantCode.Fundamental.Core;

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

public static class ErrorExtensions
{

    public static bool IsError(this Error error)
    {
        return error != null && error.Message.IsNullOrEmpty() is false;
    }
}

public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string me)
    {
        return string.IsNullOrEmpty(me);
    }
}