using System.Diagnostics;

namespace ElegantCode.Fundamental.Core;

public class Error
{
    public string Message { get; }

    public Error(string message)
    {
        Message = message;
    }




}
public static class ErrorExtensions
{

    public static bool IsError(this Error error)
    {
        return error != null || error.Message.IsNullOrEmpty();
    }
}

public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string me)
    {
        return string.IsNullOrEmpty(me);
    }
}