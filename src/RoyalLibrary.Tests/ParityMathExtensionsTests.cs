using System;
using System.Collections.Generic;
using ByteDecoder.RoyalLibrary;
using Xunit;

namespace RoyalLibrary.Tests
{
  public class ParityMathExtensionsTests
  {
    private static readonly int[] Input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10, 344, 567, 348 };

    #region ByteDecoder.RoyalLibrary.ParityMathExtensions Delegates Types

    [Fact]
    public void EvenPredicate_ReturnsTrue_WhenValueIsEven()
    {
      // Arrange
      // Act
      var result = ParityMathExtensions.EvenPredicate.Invoke(2);

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void EvenPredicate_ReturnsFalse_WhenValueIsNotEven()
    {
      // Arrange
      // Act
      var result = ParityMathExtensions.EvenPredicate.Invoke(3);

      // Assert
      Assert.False(result);
    }

    #endregion

    [Fact]
    public void Evens_ThrowsArgumentNullException_WhenSourceIsNull()
    {
      // Arrange 
      IEnumerable<int> source = null;
      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() => source.Evens());
    }

    [Fact]
    public void Evens_ReturnsValidOutput_WhenHasValidSource()
    {
      // Arrange 
      // Act
      var output = Input.Evens();

      // Assert
      Assert.Equal(new[] { 2, 4, 6, 8, 10, 344, 348 }, output);
    }

    [Fact]
    public void Odds_ThrowsArgumentNullException_WhenSourceIsNull()
    {
      // Arrange 
      IEnumerable<int> source = null;
      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() => source.Odds());
    }

    [Fact]
    public void Odds_ReturnsValidOutput_WhenHasValidSource()
    {
      // Arrange 
      // Act
      var output = Input.Odds();

      // Assert
      Assert.Equal(new[] { 1, 3, 5, 7, 567 }, output);
    }

    [Fact]
    public void TotalAllEvens_ReturnsValidOutput_WhenHaveValidSource()
    {
      // Arrange
      // Act
      var output = Input.TotalAllEvens();

      // Assert
      Assert.Equal(722, output);
    }

    [Fact]
    public void TotalAllEvens_ThrowsArgumentNullException_WhenSourceIsNull()
    {
      // Arrange
      IEnumerable<int> source = null;

      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() => source.TotalAllEvens());
    }

    [Fact]
    public void TotalAllOdds_ReturnsValidOutput_WhenHaveValidSource()
    {
      // Arrange
      // Act
      var output = Input.TotalAllOdds();

      // Assert
      Assert.Equal(583, output);
    }

    [Fact]
    public void TotalAllOdds_ThrowsArgumentNullException_WhenSourceIsNull()
    {
      // Arrange
      IEnumerable<int> source = null;

      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() => source.TotalAllOdds());
    }
  }
}