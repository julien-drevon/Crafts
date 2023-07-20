namespace ElegantCode.Fundamental.Core.Errors
{
    public static class ErrorExtensions
    {

        public static bool IsError(this Error error)
        {
            return error != null && error.Message.IsNullOrEmpty() is false;
        }
    }
}
