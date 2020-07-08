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

    [Fact]
    public void LongSumNullable_CalculateCorrectResult_WhenSourceIsNotNull()
    {
      // Arrange
      int?[] source = new int?[] { int.MaxValue, 1, null, 4, null, 666 };

      // Act
      var result = source.LongSum();

      // Assert
      Assert.Equal((long)int.MaxValue + 1 + 4 + 666, result);
    }

    [Fact]
    public void LongSumWithDelegeateSelector_CalculateCorrectResult_WhenSourceIsNotNull()
    {
      // Arrange
      var people = new[] {
        new { Name = "Julie", Age = 23},
        new { Name = "Anna", Age = 35}
      };

      // Act
      var result = people.LongSum(people => people.Age);

      // Assert
      Assert.Equal(23 + 35, result);
    }
  }
}