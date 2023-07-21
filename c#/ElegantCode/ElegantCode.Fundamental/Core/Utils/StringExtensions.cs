using System.Text;

namespace ElegantCode.Fundamental.Core.Utils;

public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string me)
    { return string.IsNullOrEmpty(me); }

    /// <summary>
    /// Joins the string.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="me">la liste de string</param>
    /// <param name="transformToString">Methode pour convertir un objet T en string</param>
    /// <param name="addLine">Si ce parametre est à true chaque objet est concaténé à la ligne, sionon à la suite</param>
    /// <param name="concatString">chaine ajouté à la fin de chaque ligne</param>
    /// <returns></returns>
    public static string JoinString<T>(
        this IEnumerable<T> me,
        bool addLine = true,
        string concatString = "",
        Func<T, string> transformToString = null)
    {
        if (me == null)
            return string.Empty;

        transformToString ??= (x => x != null ? x.ToString() : string.Empty);

        var retour = me.Aggregate(
            new StringBuilder(),
            (sb, line) =>
            {
                return AppendLineForJoinString(addLine, concatString, transformToString, sb, line);
            });

        var howManyCharToremove = ComputeLengthOfNewLine(addLine);
        return (retour != null && retour.Length > 0)
            ? RemoveLastJoinCaractere(concatString, retour, howManyCharToremove)
            : string.Empty;
    }

    private static StringBuilder AppendLineForJoinString<T>(
        bool addLine,
        string concatString,
        Func<T, string> transformToString,
        StringBuilder sb,
        T line)
    {
        if (transformToString(line).IsNullOrEmpty())
            return sb;

        var joinStringBuilder = sb.Append(transformToString(line)).Append(concatString);

        if (addLine)
            joinStringBuilder.AppendLine();

        return joinStringBuilder;
    }

    private static int ComputeLengthOfNewLine(bool addLine)
    { return addLine ? Environment.NewLine.Length : 0; }

    private static string RemoveLastJoinCaractere(string concatString, StringBuilder retour, int addLineValue)
    {
        return retour.Remove(retour.Length - concatString.Length - addLineValue, concatString.Length + addLineValue)
            .ToString();
    }
}