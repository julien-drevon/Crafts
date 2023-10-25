using System.Text;

namespace KataExemples.TennisClass;

public static class Transform
{
    public static string ToPolynome(params int[] valuesToTransform)
    {
        if (IsNoValue(valuesToTransform))
            return string.Empty;

        if (IsDegre0(valuesToTransform))
        {
            return valuesToTransform.First()
                                    .ToString();
        }

        return ExtractPolynome(new StringBuilder(), valuesToTransform, ComputeMaxDegree(valuesToTransform))
               .ToString();
    }

    private static int ComputeActualDegree(int[] valuesToTransform, int i)
    {
        return valuesToTransform.Length - 1 - i;
    }

    private static int ComputeMaxDegree(int[] valuesToTransform)
    {
        return valuesToTransform.Length - 1;
    }

    private static StringBuilder ExtractPolynome(StringBuilder sb, int[] valuesToTransform, int maxDegree)
    {
        for (int i = 0; i < valuesToTransform.Length; i++)
        {
            int actualDegree = ComputeActualDegree(valuesToTransform, i);
            sb.Append(valuesToTransform[i].PrintCoeffForPolynome(maxDegree, actualDegree) + PrintXPower(actualDegree));
        }
        return sb;
    }

    private static bool IsDegre0(int[] valuesToTransform)
    {
        return valuesToTransform.Length == 1;
    }

    private static bool IsNoValue(int[] valuesToTransform)
    {
        return valuesToTransform == null;
    }

    private static string PrintAfterSigne(int coef, int actualDegree, string ret)
    {
        if (Math.Abs(coef) != 1 || actualDegree == 0)
        {
            ret += Math.Abs(coef).ToString();
        }

        return ret;
    }

    private static string PrintCoeffForPolynome(this int coef, int maxDegree, int actualDegree)
    {
        if (coef == 0)
        {
            return string.Empty;
        }
        if (maxDegree == actualDegree)
        {
            return PrintMaxDegreeEqualActual(coef);
        }

        var ret = PrintSigne(coef, maxDegree, actualDegree);
        ret = PrintAfterSigne(coef, actualDegree, ret);

        return ret;
    }

    private static string PrintMaxDegreeEqualActual(int coef)
    {
        if (coef == 1)
            return string.Empty;
        if (coef == -1)
            return "-";

        return coef.ToString();
    }

    private static string PrintPowerLevel(int actualDegree)
    {
        return (actualDegree > 1 ? "^" + actualDegree : string.Empty);
    }

    private static string PrintSigne(int coef, int maxDegree, int actualDegree)
    {
        return coef > 0 ? " + " : " - ";
    }

    private static string PrintXPower(int actualDegree)
    {
        if (actualDegree == 0)
            return string.Empty;

        return "x" + PrintPowerLevel(actualDegree);
    }
}