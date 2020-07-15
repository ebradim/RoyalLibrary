using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ByteDecoder.RoyalLibrary
{

    /// <summary>
    /// Advanced sorting for collections
    /// </summary>
    public static class SortingExtensions
    {


        /// <summary>
        /// returns a new sorted ICollection 
        /// </summary>
        /// <param name="source"></param>
        /// <returns>An Enumerable sorted collection by LastName</returns>
        public async static Task<ICollection<string>> SortByLastNameAsync(this IEnumerable<string> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            int rowsCount = source.Count();

            if (rowsCount == 0) return (ICollection<string>)source;

            byte lastspaceIndex = 0;
            string firstName, lastName = null;
            var orderedList = new SortedList<string, string>() { Capacity = rowsCount };

            await Task.Run(() =>
            {
                foreach (var item in source)
                {
                    var spaces = item.Count(char.IsWhiteSpace);
                    lastspaceIndex = (byte)item.IndexOfNth(' ', spaces - 1);

                    firstName = item.Substring(0, lastspaceIndex);
                    var lastNameLength = item.Length - firstName.Length;
                    lastName = item.Substring(lastspaceIndex, lastNameLength);

                    orderedList.Add(lastName, firstName);
                }
            });

            return orderedList.AsParallel()
              .AsOrdered()
              .Select((fullName) => fullName.Value + fullName.Key).ToList();
        }
        /// <summary>
        /// returns a new sorted ICollection 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns>An Enumerable sorted collection by LastName</returns>
        public async static Task<IEnumerable<string>> SortByLastNameAsync(this IEnumerable<string> source, Action<string> action)
        {
            var sortedList = await source.SortByLastNameAsync();
            sortedList.ForEach(action);
            return sortedList;
        }
        private static int IndexOfNth(this string str, char value, int nth)
        {
            if (nth < 0)
                throw new ArgumentException($"Negative index found {nameof(nth)} has negative value, it must start at 0");

            int offset = str.IndexOf(value);
            for (int i = 0; i < nth; i++)
            {
                if (offset == -1) return -1;
                offset = str.IndexOf(value, offset + 1);
            }

            return offset;
        }


    }
    class MultiKeysValue : List<KeyValuePair<string, string>>
    {
        public void Add(string key, string value)
        {
            var element = new KeyValuePair<string, string>(key, value);
            this.Add(element);
        }
    }
}
