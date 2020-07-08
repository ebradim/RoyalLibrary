using System;
using Xunit;
using ByteDecoder.RoyalLibrary;

namespace RoyalLibrary.Tests
{
  public class LinqSumExtensionsTests
  {
    [Fact]
    public void LongSum_ThrowsArgumentNullException_WhenSourceIsNull()
    {
      // Arrange
      int[] source = null;

      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() => source.LongSum());
    }

    [Fact]
    public void LongSum_CalculateCorrectResult_WhenSourceIsNotNull()
    {
      // Arrange
      int[] source = new[] { int.MaxValue, 1, 2, 4 };

      // Act
      var result = source.LongSum();

      // Assert
      Assert.Equal((long)int.MaxValue + 1 + 2 + 4, result);
    }

    [Fact]
    public void LongSumNullable_ThrowsArgumentNullException_WhenSourceIsNull()
    {
      // Arrange
      int?[] source = null;

      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() => source.LongSum());
    }
  }
}