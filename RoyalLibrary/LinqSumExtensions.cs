using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteDecoder.RoyalLibrary
{
  /// <summary>
  /// 
  /// </summary>
  public static class LinqSumExtensions
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static long LongSum(this IEnumerable<int> source)
    {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      long sum = 0;
      checked
      {
        sum = source.Aggregate(sum, (total, number) => total + number);
      }
      return sum;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static long? LongSum(this IEnumerable<int?> source)
    {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      long? sum = 0;
      checked
      {
        foreach (var number in source)
        {
          if (number.HasValue) sum += number;
        }
      }
      return sum;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    public static long LongSum<T>(this IEnumerable<T> source, Func<T, int> selector)
    {
      return source.Select(selector).LongSum();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    public static long? LongSum<T>(this IEnumerable<T> source, Func<T, int?> selector)
    {
      return source.Select(selector).LongSum();
    }
  }
}
