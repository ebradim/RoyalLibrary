using System;
using System.Collections.Generic;
using System.Linq;
using ByteDecoder.RoyalLibrary;
using RoyalLibrary.Tests.Fakes;
using Xunit;

namespace RoyalLibrary.Tests
{
  public class ForEachExtensionsTests
  {
    private readonly FakeLogger _fakeLogger;
    private readonly IEnumerable<string> _words = new[] { "Soft Pastel", "Charcoral", "Sephia", "Oil", "Graphite" };

    public ForEachExtensionsTests()
    {
      _fakeLogger = new FakeLogger();
    }

    [Fact]
    public void ForEach_ThrowsArgumentNullException_WhenSourceIsNull()
    {
      // Arrange
      IEnumerable<string> words = null;
      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() => words.ForEach(word => _fakeLogger.Log(word)));
    }

    [Fact]
    public void ForEach_ReturnsValidOutput_WhenSourceIsValid()
    {
      // Arrange
      // Act
      _words.ForEach(word =>
      {
        _fakeLogger.Log($"Drawing material/technique is {word}.");
      });

      // Assert
      Assert.Equal(5, _fakeLogger.Messages.Count);
      Assert.Contains(_fakeLogger.Messages, word => word.Contains("Sephia"));
    }

    [Fact]
    public void ForEachWithIndex_ReturnsValidOutput_WhenSourceIsValid()
    {
      // Arrange
      // Act
      _words.ForEach((word, index) =>
      {
        _fakeLogger.Log($"{index} - Drawing material/technique is {word}.");
      });

      // Assert
      Assert.Equal(5, _fakeLogger.Messages.Count);
      Assert.Contains("0", _fakeLogger.Messages.FirstOrDefault() ?? string.Empty);
      Assert.Contains("4", _fakeLogger.Messages.LastOrDefault() ?? string.Empty);
    }
  }
}