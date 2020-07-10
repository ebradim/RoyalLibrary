using System;
using System.Collections.Generic;
using System.Linq;
using ByteDecoder.RoyalLibrary;
using RoyalLibrary.Tests.Factories;
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
      var result = ParityMathExtensions.EvenPredicate.Invoke(0);

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

    [Fact]
    public void OddPredicate_ReturnsTrue_WhenValueIsOdd()
    {
      // Arrange
      // Act
      var result = ParityMathExtensions.OddPredicate.Invoke(1);

      // Assert
      Assert.True(result);
    }

    [Fact]
    public void OddPredicate_ReturnsFalse_WhenValueIsNotOdd()
    {
      // Arrange
      // Act
      var result = ParityMathExtensions.OddPredicate.Invoke(4);

      // Assert
      Assert.False(result);
    }

    #endregion

    [Fact]
    public void EvaluatorBase_ThrowsArgumentNullException_WhenSourceIsNull()
    {
      // Arrange
      IEnumerable<TestPerson> persons = null;

      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() =>
        persons.ParityEvaluator((Func<int, bool>)null, (Func<TestPerson, int>)null)
        .Count());
    }

    [Fact]
    public void EvaluatorBase_ThrowsArgumentNullException_WhenEvaluatorPredicateIsNull()
    {
      // Arrange
      var persons = new TestPersonFactory().CreatePersons();

      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() =>
        persons.ParityEvaluator((Func<int, bool>)null, (Func<TestPerson, int>)null)
        .Count());
    }

    [Fact]
    public void EvaluatorBase_ThrowsArgumentNullException_WhenEvaluatorSelectorIsNull()
    {
      // Arrange
      var persons = new TestPersonFactory().CreatePersons();

      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() =>
        persons.ParityEvaluator(ParityMathExtensions.EvenPredicate, (Func<TestPerson, int>)null)
        .Count());
    }

    [Fact]
    public void EvaluatorBase_ReturnsTotalElements_WhenParamsAreCorrect()
    {
      // Arrange
      var persons = new TestPersonFactory().CreatePersons();

      // Act
      var result = persons.ParityEvaluator(ParityMathExtensions.EvenPredicate, p => p.Age)
                          .Count();

      // Assert
      Assert.Equal(1, result);
    }

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