using Xunit;

namespace RoyalLibrary.Tests
{
  public class MathComparisonExtensionsTests
  {
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