using ByteDecoder.RoyalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RoyalLibrary.Tests
{
  public class SortingExtensionTests
  {
    [Fact]
    public async void RoyalSortLastAsync_ThrowArgumentNullException_WhenSourceIsNull()
    {
      // Arrange
      IList<string> words = null;

      // Act
      // Assert
      await Assert.ThrowsAsync<ArgumentNullException>(() => words.RoyalSortLastAsync());
    }

    [Fact]
    public async void RoyalSortLastAsync_ReturnsTheRightSortedList_WhenCorrectSourceIsProvided()
    {
      // Arrange
      var unSortedlist = new List<string>()
            {
                "Ai Bi Bu",
                "Ai Bi Az",
                "Na Za",
                "Xa Ma Co",
                "AA bb"
            };
      var expected = new List<string>()
            {
                "Ai Bi Az",
                "AA bb",
                "Ai Bi Bu",
                "Xa Ma Co",
                "Na Za",

            };

      // Act
      var actual = await unSortedlist.RoyalSortLastAsync();

      // Assert
      Assert.True(expected[1] == actual.ElementAt(1));
    }
  }
}