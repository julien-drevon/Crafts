namespace ElegantCode.Fundamental.Core.Utils;

public static class UtilsExtension
{
    public static bool IsFalse(this bool me)
    {
        return !me;
    }

    public static bool IsFalseOrNull(this bool? me)
    {
        return !me.HasValue || !me.Value;
    }

    public static bool IsNotNull<T>(this T me)
    {
        return me is not null;
    }

    public static bool IsNull<T>(this T me)
    {
        return me is null;
    }

    public static bool IsTrue(this bool? me)
    {
        return me.HasValue && me.Value;
    }

    public static bool IsEmpty(this Guid me)
    {
        return me == Guid.Empty;
    }
}