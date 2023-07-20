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
    /// <param name="toString">Methode pour convertir un objet T en string</param>
    /// <param name="addLine">Si ce parametre est à true chaque objet est concaténé à la ligne, sionon à la suite</param>
    /// <param name="concatString">chaine ajouté à la fin de chaque ligne</param>
    /// <returns></returns>
    public static string JoinString<T>(
        this IEnumerable<T> me,
        bool addLine = true,
        string concatString = "",
        Func<T, string> toString = null)
    {
        if (me == null)
            return string.Empty;

        toString ??= (x => x != null ? x.ToString() : string.Empty);

        var retour = me.Aggregate(
            new StringBuilder(),
            (x, y) =>
            {
                return AppendLineForJoinString(addLine, concatString, toString, x, y);
            });

        var howManyCharToremove = ComputeLengthOfNewLine(addLine);
        return (retour != null && retour.Length > 0)
            ? RemoveLastJoinCaractere(concatString, retour, howManyCharToremove)
            : string.Empty;
    }

    private static StringBuilder AppendLineForJoinString<T>(
        bool addLine,
        string concatString,
        Func<T, string> toString,
        StringBuilder x,
        T y)
    {
        if (toString(y).IsNullOrEmpty())
            return x;

        var s = x.Append(toString(y)).Append(concatString);
        if (addLine)
            s.AppendLine();
        return s;
    }

    private static int ComputeLengthOfNewLine(bool addLine)
    { return addLine ? Environment.NewLine.Length : 0; }

    private static string RemoveLastJoinCaractere(string concatString, StringBuilder retour, int addLineValue)
    {
        return retour.Remove(retour.Length - concatString.Length - addLineValue, concatString.Length + addLineValue)
            .ToString();
    }
}