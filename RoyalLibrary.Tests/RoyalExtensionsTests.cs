using System.Linq;
using RoyalLibrary.Tests.Fakes;
using Xunit;

namespace RoyalLibrary.Tests
{
  public class RoyalExtensionsTests
  {
    private static readonly int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10, 344, 567, 348 };
    private readonly FakeLogger _fakeLogger;

    public RoyalExtensionsTests()
    {
      _fakeLogger = new FakeLogger();
    }

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

      // Act
      words.Each(word =>
      {
        _fakeLogger.Log($"Drawing material/technique is {word}.");
      });

      // Assert
      Assert.Equal(5, _fakeLogger.Messages.Count);
      Assert.Contains(_fakeLogger.Messages, word => word.Contains("Sephia"));
    }

    [Fact]
    public void EachWithIndexReturnsValidOutput()
    {
      // Arrange
      var words = new string[] { "Soft Pastel", "Charcoral", "Sephia", "Oil", "Graphite" };

      // Act
      words.Each((word, index) =>
      {
        _fakeLogger.Log($"{index} - Drawing material/technique is {word}.");
      });

      // Assert
      Assert.Equal(5, _fakeLogger.Messages.Count);
      Assert.Contains("0", _fakeLogger.Messages.FirstOrDefault());
      Assert.Contains("4", _fakeLogger.Messages.LastOrDefault());
    }

    [Fact]
    public void MapReturnsValidOutput()
    {
      // Arrange 

      // Act
      var output = input.Map(number => number * 2);

      // Assert
      Assert.Equal(new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 20, 688, 1_134, 696 }, output);
      Assert.Equal(2610, output.Sum());
    }
  }
}
