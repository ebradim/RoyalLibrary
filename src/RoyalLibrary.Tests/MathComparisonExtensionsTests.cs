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
      var number = 123;

      // Act
      var result = number.IsGreaterThan(12);

      // Assert
      Assert.True(result);
    }
  }
}