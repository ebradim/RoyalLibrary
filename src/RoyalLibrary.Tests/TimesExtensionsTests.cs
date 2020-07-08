using ByteDecoder.RoyalLibrary;
using System;
using Xunit;

namespace RoyalLibrary.Tests
{
  public class TimesExtensionsTests
  {

    [Fact]
    public void TimesParams_ExecutesProperly_WhenIsNeededFiveTimes()
    {
      // Arrange
      var count = 0;

      // Act
      5.Times(_ => count++);

      // Assert
      Assert.Equal(5, count);
    }

    [Fact]
    public void TimesNoParams_ExecutesProperly_WhenIsNeededFiveTimes()
    {
      // Arrange
      var count = 0;

      // Act
      5.Times(() => count++);

      // Assert
      Assert.Equal(5, count);
    }

    [Fact]
    public void TimesNoParams_ThrowsAnArgumentNullException_WhenActionDelegateIsNull()
    {
      // Arrange
      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() => 5.Times((Action)null));
    }


    [Fact]
    public void TimesParams_ThrowsAnArgumentNullException_WhenActionDelegateIsNull()
    {
      // Arrange
      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() => 5.Times((Action<int>)null));
    }
  }
}