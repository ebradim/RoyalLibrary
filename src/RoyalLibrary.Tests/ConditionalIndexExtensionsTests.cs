using ByteDecoder.RoyalLibrary;
using System;
using System.Collections.Generic;
using Xunit;

namespace RoyalLibrary.Tests
{
  public class ConditionalIndexExtensionsTests
  {
    [Fact]
    public void TopIndexes_ThrowsAnArgumentNullException_WhenSourceIsNull()
    {
      // Arrange
      List<bool> source = null;

      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() => source.TopIndexes(element => element, 4));
    }

    [Fact]
    public void TopIndexes_ThrowsAnArgumentNullException_WhenPredicateDelegateIsNull()
    {
      // Arrange
      var source = new bool[] { true, true, false };

      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() => source.TopIndexes(null, 4));
    }
  }
}