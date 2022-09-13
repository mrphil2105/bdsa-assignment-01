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

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions) {
        foreach (var resolution in resolutions) {
            var matches = Regex.Matches(resolution, @"(?<width>\d+)x(?<height>\d+)");

            foreach (Match match in matches) {
                yield return (Int32.Parse(match.Groups["width"].Value), Int32.Parse(match.Groups["height"].Value));
            }
        }
    }

    public static IEnumerable<string> InnerText(string html, string tag)
    {
        string pattern = @$"<{tag}[\S\s]*?>(?<text>[\S\s]*?)<\/{tag}>";

        var matches = Regex.Matches(html, pattern);

        foreach (Match match in matches)
        {
            yield return match.Groups["text"].Value;
        }
    }
}