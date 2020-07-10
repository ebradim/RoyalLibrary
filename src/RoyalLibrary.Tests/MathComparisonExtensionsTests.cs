using Xunit;

namespace RoyalLibrary.Tests
{
  public class MathComparisonExtensionsTests
  {
    [Fact]
    public void IsGreaterThan_ReturnsTrue_WhenIsGreater()
    {
      // Arrange
      var number = 123;

      // Act
      var result = number.IsGreaterThan(12);

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void IsGreaterThan_ReturnsFalse_WhenIsNotGreater()
    {
      // Arrange
      var number = 1;

      // Act
      var result = number.IsGreaterThan(12);

      // Assert
      Assert.False(result);
    }

    [Fact]
    public void IsLessThan_ReturnsTrue_WhenIsLess()
    {
      // Arrange
      var number = 123;

      // Act
      var result = number.IsLessThan(666);

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void IsLessThan_ReturnsFalse_WhenIsNotLess()
    {
      // Arrange
      var number = 123;

      // Act
      var result = number.IsLessThan(12);

      // Assert
      Assert.False(result);
    }

    [Fact]
    public void IsEqualTo_ReturnsTrue_WhenIsEqual()
    {
      // Arrange
      var number = 123;

      // Act
      var result = number.IsEqualTo(123);

      // Assert
      Assert.True(result);
    }
  }
}