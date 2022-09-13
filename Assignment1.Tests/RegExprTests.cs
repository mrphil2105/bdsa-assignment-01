using Xunit;

namespace Assignment1.Tests;

public class RegExprTests
{
    public static IEnumerable<object[]> SentencesAndWords => new List<object[]>
    {
        new object[]
        {
            new[]
            {
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                "Nam porta nisl nisl, in elementum est convallis iaculis."
            },
            new[]
            {
                "Lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit", "Nam",
                "porta", "nisl", "nisl", "in", "elementum", "est", "convallis", "iaculis"
            }
        },
        new object[]
        {
            new[] { "Number-words like 48653 and word1234 should also work." },
            new[] { "Number", "words", "like", "48653", "and", "word1234", "should", "also", "work" }
        }
    };

    public static IEnumerable<object[]> ExerciseHtmlAndTags => new List<object[]>
    {
        new object[]
        {
            "<div>\n    <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p>\n</div>\n",
            "a",
            new[]
            {
                "theoretical computer science", "formal language", "characters", "pattern",
                "string searching algorithms", "strings"
            }
        },
        new object[]
        {
            "<div>\n    <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p>\n</div>\n",
            "p",
            new[]
            {
                "The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."
            }
        }
    };

    public static IEnumerable<object[]> HtmlWithAndWithoutLinks => new List<object[]>
    {
        new object[]
        {
            "<div>\n    <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=\"https://en.wikipedia.org/wiki/Theoretical_computer_science\" title=\"Theoretical computer science\">theoretical computer science</a> and <a href=\"https://en.wikipedia.org/wiki/Formal_language\" title=\"Formal language\">formal language</a> theory, a sequence of <a href=\"https://en.wikipedia.org/wiki/Character_(computing)\" title=\"Character (computing)\">characters</a> that define a <i>search <a href=\"https://en.wikipedia.org/wiki/Pattern_matching\" title=\"Pattern matching\">pattern</a></i>. Usually this pattern is then used by <a href=\"https://en.wikipedia.org/wiki/String_searching_algorithm\" title=\"String searching algorithm\">string searching algorithms</a> for \"find\" or \"find and replace\" operations on <a href=\"https://en.wikipedia.org/wiki/String_(computer_science)\" title=\"String (computer science)\">strings</a>.</p>\n</div>\n",
            new[]
            {
                (new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"),
                    "Theoretical computer science"),
                (new Uri("https://en.wikipedia.org/wiki/Formal_language"), "Formal language"),
                (new Uri("https://en.wikipedia.org/wiki/Character_(computing)"), "Character (computing)"),
                (new Uri("https://en.wikipedia.org/wiki/Pattern_matching"), "Pattern matching"),
                (new Uri("https://en.wikipedia.org/wiki/String_searching_algorithm"),
                    "String searching algorithm"),
                (new Uri("https://en.wikipedia.org/wiki/String_(computer_science)"),
                    "String (computer science)")
            }
        },
        new object[]
        {
            "<a href=\"https://www.google.com/\">Google</a><a href=\"https://itu.dk\" title=\"\">Go to ITU's website</a>",
            new[]
            {
                (new Uri("https://www.google.com/"), "Google"),
                (new Uri("https://itu.dk"), "Go to ITU's website")
            }
        },
        new object[]
        {
            "<a href=\"\">foo</a>",
            // Empty href attributes should not work.
            Array.Empty<object>()
        }
    };

    [Theory]
    [MemberData(nameof(SentencesAndWords))]
    public void SplitLine_SplitsSentencesToWords_WhenGivenSentences(IEnumerable<string> sentences,
        IEnumerable<string> words)
    {
        // Act
        var result = RegExpr.SplitLine(sentences);

        // Assert
        Assert.Equal(words, result);
    }


      [Fact]
    public void Resolution_WhenGivenAStreamOfResolutions() {
        // Arrange
        var items = new[] {"1920x1080", "1024x768", "800x600", "640x480"};

        // Act
        var result = RegExpr.Resolution(items);

        // Assert
        Assert.Equal(new[]{(1920, 1080), (1024, 768), (800, 600), (640, 480)}, result);
    }

    [Theory]
    [InlineData("<a href=\"https://www.google.com/search?q=foo\">foo</a>", "a", new[] { "foo" })]
    [InlineData("<span>foo</span><h1 id=\"section-0\">Title</h1><span class=\"fancy-text\">bar</span>", "span", new[] { "foo", "bar" })]
    [InlineData("<p></p>", "p", new[] { "" })]
    [MemberData(nameof(ExerciseHtmlAndTags))]
    public void InnerText_ReturnsInnerTexts_WhenGivenHtmlAndTag(string html, string tag, string[] innerTexts)
    {
        // Act
        var result = RegExpr.InnerText(html, tag);

        // Assert
        Assert.Equal(innerTexts, result);
    }

    [Theory]
    [MemberData(nameof(HtmlWithAndWithoutLinks))]
    public void Urls_ReturnsUrlsAndTitles_WhenGivenHtmlWithAnchors(string html, (Uri url, string title)[] urlTitles)
    {
        // Act
        var result = RegExpr.Urls(html);

        // Assert
        Assert.Equal(urlTitles, result);
    }
}
