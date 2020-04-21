using System;
using Xunit;

namespace RoyalLibrary.Tests
{
  public class RoyalExtensionsTests
  {
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
      var input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10, 344, 567, 348 };

      // Act
      var output = input.Evens();

      // Assert
      Assert.Equal(new int[] { 2, 4, 6, 8, 10, 344, 348 }, output);
    }
  }
}
