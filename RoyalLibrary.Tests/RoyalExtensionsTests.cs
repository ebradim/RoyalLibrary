using System.Linq;
using RoyalLibrary.Tests.Fakes;
using Xunit;

namespace RoyalLibrary.Tests
{
  public class RoyalExtensionsTests
  {
    private static readonly int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10, 344, 567, 348 };

    [Fact]
    public void TimesExecutesFiveTimes()
    {
      // Arrange
      var count = 0;

      // Act
      5.Times(_ => count++);

      // Assert
      Assert.Equal(5, count);
    }

    [Fact]
    public void EvensReturnsValidOutput()
    {
      // Arrange 

      // Act
      var output = input.Evens();

      // Assert
      Assert.Equal(new int[] { 2, 4, 6, 8, 10, 344, 348 }, output);
    }

    [Fact]
    public void OddsReturnsValidOutput()
    {
      // Arrange 

      // Act
      var output = input.Odds();

      // Assert
      Assert.Equal(new int[] { 1, 3, 5, 7, 567 }, output);
    }

    [Fact]
    public void TotalAllEvensReturnsValidOutput()
    {
      // Arrange

      // Act
      var output = input.TotalAllEvens();

      // Assert
      Assert.Equal(722, output);
    }


    [Fact]
    public void TotalAllOddsReturnsValidOutput()
    {
      // Arrange

      // Act
      var output = input.TotalAllOdds();

      // Assert
      Assert.Equal(583, output);
    }

    [Fact]
    public void EachReturnsValidOutput()
    {
      // Arrange
      var words = new string[] { "Soft Pastel", "Charcoral", "Sephia", "Oil", "Graphite" };
      var fakerLogger = new FakeLogger();

      // Act
      words.Each(word =>
      {
        fakerLogger.Log($"Drawing material/technique is {word}.");
      });

      // Assert
      Assert.Equal(5, fakerLogger.Messages.Count);
      Assert.Contains(fakerLogger.Messages, word => word.Contains("Sephia"));
    }
  }
}
