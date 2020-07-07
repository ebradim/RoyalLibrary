using ByteDecoder.RoyalLibrary;
using System;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace RoyalLibrary.Tests
{
  public class StreamReaderExtensionsTests
  {
    internal string GetCvsData()
    {
      var sb = new StringBuilder();
      sb.AppendLine("\"LatD\", \"LatM\", \"LatS\", \"NS\", \"LonD\", \"LonM\", \"LonS\", \"EW\", \"City\", \"State\"");
      sb.AppendLine("41,    5,   59, \"N\",     80,   39,    0, \"W\", \"Youngstown\", OH");
      sb.AppendLine("42,   52,   48, \"N\",     97,   23,   23, \"W\", \"Yankton\", SD");
      sb.AppendLine("46,   35,   59, \"N\",    120,   30,   36, \"W\", \"Yakim\", WA");

      return sb.ToString();
    }

    [Fact]
    public void Lines_ThrowsArgumentNullException_WhenSourceIsNull()
    {
      // Arrange
      StreamReader streamer = null;

      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() => streamer.Lines().ToList());
    }

    [Fact]
    public void Lines_GetAllLinesFromStreamReader_WhenValidSourceIsProvided()
    {
      // Arrange
      using var ms = new MemoryStream(Encoding.UTF8.GetBytes(GetCvsData()));
      using var sr = new StreamReader(ms);

      // Act 
      var count = sr.Lines().Count();

      // Assert
      Assert.Equal(4, count);
    }
  }
}
