using ByteDecoder.RoyalLibrary;

using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace RoyalLibrary.Tests
{
    
    public class SortingExtensionTests
    {
        [Fact]
        public async void RoyalSorting_ReturnsTheRight_Sorted_list()
        {
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
                "Na Za",
                "AA bb",
                "Ai Bi Bu",
                "Ai Bi Az",
                "Xa Ma Co",

            };
            var actual = await unSortedlist.RoyalSortLastAsync();

            Assert.True(expected[1] == actual.ElementAt(1));
        }
    }
}