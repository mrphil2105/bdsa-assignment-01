using System.Text.RegularExpressions;

namespace Assignment1;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            var matches = Regex.Matches(line, @"\w+");

            foreach (Match match in matches)
            {
                yield return match.Value;
            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions) => throw new NotImplementedException();

    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();
}