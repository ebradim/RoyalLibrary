using System.Linq;
using ByteDecoder.RoyalLibrary;
using Xunit;

namespace RoyalLibrary.Tests
{
  public class RoyalExtensionsTests
  {
    private static readonly int[] Input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10, 344, 567, 348 };

    [Fact]
    public void MapReturnsValidOutput()
    {
      // Arrange 

      // Act
      var output = Input.Map(number => number * 2).ToArray();

      // Assert
      Assert.Equal(new[] { 2, 4, 6, 8, 10, 12, 14, 16, 20, 688, 1_134, 696 }, output);
      Assert.Equal(2610, output.Sum());
    }
  }
}
