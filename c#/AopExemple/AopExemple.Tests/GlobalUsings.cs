global using Xunit;

public static class Utils
{
    public static bool IsAny<T>(this IEnumerable<T> me)
    {
        return me!=null && me.Any();
    }
}