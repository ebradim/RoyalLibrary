using System;
using Xunit;

namespace RoyalLibrary.Tests
{
    public class RoyalExtensionsTests
    {
        [Fact]
        public void TimesExecutesFiveTimes()
        {
            // Arrange
            var count = 0;
            
            // Act
            5.Times { _ => count++ }    

            // Assert
            Assert.Equal(5, count);
        }
    }
}
