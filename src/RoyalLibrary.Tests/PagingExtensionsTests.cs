using System.Linq;
using Xunit;
using ByteDecoder.RoyalLibrary;
using System;

namespace RoyalLibrary.Tests
{
  public class PagingExtensionsTests
  {
    private string[] Words = new string[] { "news", "wandering", "crack", "lunch", "fiction", "sweater", "stoop", "hideous", "awake", "grandmother" };

    [Fact]
    public void Page_ThrowsArgumentNullException_WhenSourceIsNull()
    {
      // Arrange
      string[] words = null;

      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() => words.AsQueryable().Page(1, 1));
    }

    [Fact]
    public void Page_ThrowsArgumentOutOfRangeException_WhenPageSizeIsZero()
    {
      // Arrange
      // Act
      // Assert
      Assert.Throws<ArgumentOutOfRangeException>(() => Words.AsQueryable().Page(1, 0));
    }

    [Fact]
    public void Page_GetFiveWords_WhenParamsAreCorrect()
    {
      // Arrange
      // Act
      var result = Words.AsQueryable().Page(0, 5);

      // Assert
      Assert.Equal(5, result.Count());
    }

    [Fact]
    public void Page_GetCorrectWords_WhenParamsAreCorrect()
    {
      // Arrange
      // Act
      var result = Words.AsQueryable().Page(1, 5);

      // Assert
      Assert.True(new string[] { "sweater", "stoop", "hideous", "awake", "grandmother" }.All(word => result.Contains(word)));
    }

    [Fact]
    public void Page_ReturnsZeroRecords_WhenPageNumberExceedDataAvailable()
    {
      // Arrange
      // Act
      var result = Words.AsQueryable().Page(2, 5);

      // Assert
      Assert.Equal(0, result.Count());
    }
  }
}
