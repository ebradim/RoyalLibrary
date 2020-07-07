using ByteDecoder.RoyalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
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

    [Fact]
    public void TopIndexes_ReturnsTotalNumberIndexes_WhenHaveCorrectData()
    {
      // Arrange
      var source = new bool[] { true, false, false, true, true, false, false, false, false, false, false };

      // Act
      var result = source.TopIndexes(e => e, 4);

      // Assert
      Assert.Equal(3, result.Count());
    }

    [Fact]
    public void TopIndexes_ReturnsIndexes_WhenHaveCorrectData()
    {
      // Arrange
      var source = new bool[] { true, false, false, true, true, false, false, false, false, false, false };

      // Act
      var result = source.TopIndexes(e => e, 4);

      // Assert
      Assert.True(new int[] { 0, 3, 4 }.All(index => result.Contains(index)));
    }
  }
}