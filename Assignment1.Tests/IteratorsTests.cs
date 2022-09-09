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


    [Fact]
    public void Filter_FiltersEven_WhenGivenEvenNumberPredicate() {
        //Arragne
        var items = new[] {1, 2, 3, 4, 5};
        
        Predicate<int> even = Even;
        bool Even(int i) => i % 2 == 0;

        //Act
        var result = Iterators.Filter(items, even);

        //Assert
        Assert.Equal(new[] {2, 4}, result);

    }

}