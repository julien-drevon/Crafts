using ElegantCode.Fundamental.Core.Utils;

namespace ElegantCode.Fundamental.Core.Errors;

public static class ErrorExtensions
{
    public static bool IsNotOnError(this Error error)
    {
        return error.IsOnError() is false;
    }

    public static bool IsNotOnError<TUseCaseQuery>(this (TUseCaseQuery UseCaseQuery, Error Error) error)
    {
        return error.Error.IsNotOnError();
    }

    public static bool IsOnError(this Error error)
    {
        return error.IsNotNull() && error.Message.IsNotNullOrEmpty();
    }

    public static bool IsOnError<TUseCaseQuery>(this (TUseCaseQuery UseCaseQuery, Error Error) error)
    {
        return error.Error.IsOnError();
    }
}