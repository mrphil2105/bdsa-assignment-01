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
}