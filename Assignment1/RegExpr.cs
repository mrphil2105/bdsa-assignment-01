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
        var pattern = @$"<{tag}[\S\s]*?>(?<text>[\S\s]*?)<\/{tag}>";
        const string replacePattern = @"<[a-z]+[\S\s]*?>(?<text>[\S\s]*?)<\/[a-z]+>";

        var matches = Regex.Matches(html, pattern);

        foreach (Match match in matches)
        {
            yield return Regex.Replace(match.Groups["text"].Value, replacePattern, m => m.Groups["text"].Value);
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html)
    {
        const string pattern =
            "<a[\\S\\s]*?(href=\"(?<link>.+?)\")( title=\"(?<title>[\\S\\s]*?)\")?>(?<text>[\\S\\s]*?)<\\/a>";

        var matches = Regex.Matches(html, pattern);

        foreach (Match match in matches)
        {
            var url = match.Groups["link"].Value;
            var title = match.Groups["title"].Value;

            if (string.IsNullOrEmpty(title))
            {
                title = match.Groups["text"].Value;
            }

            yield return (new Uri(url), title);
        }
    }
}