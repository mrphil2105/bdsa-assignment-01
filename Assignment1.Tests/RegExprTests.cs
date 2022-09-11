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

}