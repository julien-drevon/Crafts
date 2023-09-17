using System.Text;

namespace ElegantCode.Fundamental.Core.Utils;

public static class StringExtensions
{
    public static bool IsNotEmpty(this string me)
    {
        return !me.IsNullOrEmpty();
    }

    public static bool IsNullOrEmpty(this string me)
    {
        return string.IsNullOrEmpty(me);
    }

    /// <summary>
    /// Joins the string with Tostring() ^^ Can use a factory for transform T toString.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="stringLi">la liste de string</param>
    /// <param name="transformToStringFactory">Methode pour convertir un objet T en string</param>
    /// <param name="isAddLine">Si ce parametre est à true chaque objet est concaténé à la ligne, sionon à la suite</param>
    /// <param name="concatString">chaine ajouté à la fin de chaque ligne</param>
    /// <returns></returns>
    public static string ToJoinString<T>(
        this IEnumerable<T> stringLi,
        bool isAddLine = true,
        string concatString = "",
        Func<T, string> transformToStringFactory = null)
    {
        if (stringLi.IsNull())
            return string.Empty;

        transformToStringFactory ??= (x => x.IsNotNull() ? x.ToString() : string.Empty);

        var retour = stringLi.Aggregate(
            new StringBuilder(),
            (sb, line) =>
            {
                return AppendEachLineForJoinString(isAddLine, concatString, transformToStringFactory, sb, line);
            });

        var howManyCharToremove = ComputeLengthOfNewLine(isAddLine);

        return ToStringWithRemoveLastConcat(concatString, howManyCharToremove, retour);
    }

    private static StringBuilder AppendEachLineForJoinString<T>(
        bool isAddLine,
        string concatString,
        Func<T, string> transformToString,
        StringBuilder stringBuilder,
        T line)
    {
        if (transformToString(line).IsNullOrEmpty())
            return stringBuilder;

        var joinStringBuilder = stringBuilder.Append(transformToString(line))
                                             .Append(concatString);

        if (isAddLine)
            joinStringBuilder.AppendLine();

        return joinStringBuilder;
    }

    private static int ComputeLengthOfNewLine(bool addLine)
    { return addLine ? Environment.NewLine.Length : 0; }

    private static string ToStringWithRemoveLastConcat(string concatString, int addLineValue, StringBuilder stringBuilder)
    {
        return stringBuilder.Length > 0
            ? stringBuilder.Remove(stringBuilder.Length - concatString.Length - addLineValue, concatString.Length + addLineValue)
                           .ToString()
            : string.Empty;
    }
}