using System;
using System.Linq;
using ByteDecoder.RoyalLibrary;
using RoyalLibrary.Tests.Fakes;
using Xunit;

namespace RoyalLibrary.Tests
{
  public class RoyalExtensionsTests
  {
    private static readonly int[] Input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10, 344, 567, 348 };
    private readonly FakeLogger _fakeLogger;

    public RoyalExtensionsTests()
    {
      _fakeLogger = new FakeLogger();
    }

    [Fact]
    public void EachReturnsValidOutput()
    {
      // Arrange
      var words = new[] { "Soft Pastel", "Charcoral", "Sephia", "Oil", "Graphite" };

      // Act
      words.ForEach(word =>
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
      var words = new[] { "Soft Pastel", "Charcoral", "Sephia", "Oil", "Graphite" };

      // Act
      words.ForEach((word, index) =>
      {
        _fakeLogger.Log($"{index} - Drawing material/technique is {word}.");
      });

      // Assert
      Assert.Equal(5, _fakeLogger.Messages.Count);
      Assert.Contains("0", _fakeLogger.Messages.FirstOrDefault() ?? string.Empty);
      Assert.Contains("4", _fakeLogger.Messages.LastOrDefault() ?? string.Empty);
    }

    [Fact]
    public void MapReturnsValidOutput()
    {
      // Arrange 

      // Act
      var output = Input.Map(number => number * 2).ToArray();

      // Assert
      Assert.Equal(new[] { 2, 4, 6, 8, 10, 12, 14, 16, 20, 688, 1_134, 696 }, output);
      Assert.Equal(2610, output.Sum());
    }

    [Fact]
    public void IsGreaterThan_ReturnsValidResult_WhenHaveValidInput()
    {
      // Arrange
      var number = 123;

      // Act
      var result = number.IsGreaterThan(12);

      // Assert
      Assert.True(result);
    }
  }
}
