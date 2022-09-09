using Xunit;

namespace Assignment1.Tests;

public class IteratorsTests
{
    [Fact]
    public void Flatten_FlattensEnumerable_WhenGivenNumbers()
    {
        // Arrange
        var unflattened = new[] { new[] { 1, 2, 3 }, new[] { 4, 5 }, new[] { 6, 7, 8, 9 } };
        var flattened = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // Act
        var result = Iterators.Flatten(unflattened);

        // Assert
        Assert.Equal(flattened, result);
    }
}