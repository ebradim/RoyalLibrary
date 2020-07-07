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
  }
}