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

    [Fact]
    public void IsEqualTo_ReturnsFalse_WhenIsNotEqual()
    {
      // Arrange
      var number = 12;

      // Act
      var result = number.IsEqualTo(123);

      // Assert
      Assert.False(result);
    }

    [Fact]
    public void IsNotEqualTo_ReturnsTrue_WhenIsNotEqual()
    {
      // Arrange
      var number = 1234;

      // Act
      var result = number.IsNotEqualTo(123);

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void IsNotEqualTo_ReturnsFalse_WhenIsNotEqual()
    {
      // Arrange
      var number = 123;

      // Act
      var result = number.IsNotEqualTo(123);

      // Assert
      Assert.False(result);
    }

    [Fact]
    public void IsGreaterThanOrEqualTo_ReturnsTrue_WhenIsGreater()
    {
      // Arrange
      var number = 1234;

      // Act
      var result = number.IsGreaterThanOrEqualTo(123);

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void IsGreaterThanOrEqualTo_ReturnsTrue_WhenIsEqual()
    {
      // Arrange
      var number = 123;

      // Act
      var result = number.IsGreaterThanOrEqualTo(123);

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void IsGreaterThanOrEqualTo_ReturnsFalse_WhenIsNotGreaterOrEqual()
    {
      // Arrange
      var number = 122;

      // Act
      var result = number.IsGreaterThanOrEqualTo(123);

      // Assert
      Assert.False(result);
    }

    [Fact]
    public void IsLessThanOrEqualTo_ReturnsTrue_WhenIsLess()
    {
      // Arrange
      var number = 122;

      // Act
      var result = number.IsLessThanOrEqualTo(123);

      // Assert
      Assert.True(result);
    }
  }
}