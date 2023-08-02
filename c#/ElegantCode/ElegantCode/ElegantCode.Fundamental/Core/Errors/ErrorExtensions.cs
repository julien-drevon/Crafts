using ElegantCode.Fundamental.Core.Utils;

namespace ElegantCode.Fundamental.Core.Errors;

public static class ErrorExtensions
{
    public static bool IsError(this Error error)
    {
        return error.IsNotNull() && error.Message.IsNullOrEmpty() is false;
    }
}