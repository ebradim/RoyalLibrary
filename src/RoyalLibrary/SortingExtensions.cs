using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async static Task<ICollection<string>> RoyalSortLastAsync(this IEnumerable<string> source)
        {
            int rowsCount = source.Count();
            byte lastspaceIndex = 0;
            string firstName, lastName = null;
            var tempDic = new MultiKeysValue() { Capacity = rowsCount };
            var tempList = new List<string>(rowsCount);
            var tempResult = new List<string>(rowsCount);

            await Task.Run(() =>
            {
                foreach (var item in source)
                {

                    var spaces = item.Count(char.IsWhiteSpace);
                    lastspaceIndex = (byte)item.IndexOfNth(' ', spaces - 1);

                    //get the whole firstname(s) , then the lastName, add them to tempDic which will be used
                    //to get firstname(s) by lastName
                    //lastname will be added to the temp list and sorted everytime 
                    firstName = item.Substring(0, lastspaceIndex);
                    var lastNameLength = item.Length - firstName.Length;
                    lastName = item.Substring(lastspaceIndex, lastNameLength);

                    tempDic.Add(firstName, lastName);
                    tempList.Add(lastName);
                    tempList.Sort();


                }
            }).ContinueWith(async (filtering) =>
            {
                foreach (var LastName in tempList)
                {
                    //get the firstName(s) from tempDic by lastName

                    var dicfirstName = tempDic.AsParallel().First(x => x.Value == LastName).Key;
                    await Task.Delay(0);//fake await to run everything smoothly
                                        //combine names again with sorted
                    tempResult.Add(dicfirstName + LastName);

                }
            });
            tempDic = null;
            tempList = null;
            return tempResult;





        }
        /// <summary>
        /// returns a new sorted ICollection 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <returns>An Enumerable sorted collection by LastName</returns>
        public async static Task<ICollection<string>> RoyalSortLastAsync(this IEnumerable<string> source, Action<string> action)
        {
            int rowsCount = source.Count();
            byte lastspaceIndex = 0;
            string firstName, lastName = null;
            var tempDic = new MultiKeysValue() { Capacity=rowsCount};
            var tempList = new List<string>(rowsCount);
            var tempResult = new List<string>(rowsCount);

            await Task.Run(() =>
            {
                foreach (var item in source)
                {

                    var spaces = item.Count(char.IsWhiteSpace);
                    lastspaceIndex = (byte)item.IndexOfNth(' ', spaces - 1);

                    //get the whole firstname(s) , then the lastName, add them to tempDic which will be used
                    //to get firstname(s) by lastName
                    //lastname will be added to the temp list and sorted everytime 
                    firstName = item.Substring(0, lastspaceIndex);
                    var lastNameLength = item.Length - firstName.Length;
                    lastName = item.Substring(lastspaceIndex, lastNameLength);

                    tempDic.Add(firstName, lastName);
                    tempList.Add(lastName);
                    tempList.Sort();


                }
            }).ContinueWith(async (filtering) =>
            {
                foreach (var LastName in tempList)
                {
                    //get the firstName from tempDic by lastName

                    var dicfirstName = tempDic.AsParallel().First(x => x.Value == LastName).Key;
                    await Task.Delay(0);//fake await to run everything smoothly
                                        //combine names again with sorted
                    tempResult.Add(dicfirstName + LastName);

                }
            });
            tempDic = null;
            tempList = null;

            foreach (var item in tempResult.AsParallel())
            {
                action.Invoke(item);
            }

            return tempResult;





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
