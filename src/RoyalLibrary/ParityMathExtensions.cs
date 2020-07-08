using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteDecoder.RoyalLibrary
{
  /// <summary>
  /// 
  /// </summary>
  public static class ParityMathExtensions
  {
    /// <summary>
    /// Return an array of evens integers from an integer source collection
    /// </summary>
    /// <param name="numbers">Integer source collection</param>
    /// <returns></returns>
    public static IEnumerable<int> Evens(this IEnumerable<int> numbers) => numbers.Where(n => n % 2 == 0);

    /// <summary>
    /// Deferred execution
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    public static IEnumerable<T> Evens<T>(this IEnumerable<T> source, Func<T, int> selector)
    {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      if (selector == null)
        throw new ArgumentNullException(nameof(selector));

      foreach (var item in source)
      {
        if (selector(item) % 2 == 0)
          yield return item;
      }
    }

    /// <summary>
    /// Return an array of odds integers from an integer source collection
    /// </summary>
    /// <param name="numbers">Integer source collection</param>
    /// <returns></returns>
    public static IEnumerable<int> Odds(this IEnumerable<int> numbers) => numbers.Where(n => n % 2 != 0);

    /// <summary>
    /// Deferred Execution
    /// </summary>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    public static IEnumerable<T> Odds<T>(this IEnumerable<T> source, Func<T, int> selector)
    {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      if (selector == null)
        throw new ArgumentNullException(nameof(selector));

      foreach (var item in source)
      {
        if (selector(item) % 2 != 0)
          yield return item;
      }
    }

    /// <summary>
    /// Return a sum of all evens integers from an integer source collection
    /// </summary>
    /// <param name="numbers">Integer source collection</param>
    /// <returns></returns>
    public static long TotalAllEvens(this IEnumerable<int> numbers) => numbers.Evens().LongSum();

    /// <summary>
    /// Return a sum of all odds integers from an integer source collection
    /// </summary>
    /// <param name="numbers">Integer source collection</param>
    /// <returns></returns>
    public static long TotalAllOdds(this IEnumerable<int> numbers) => numbers.Odds().LongSum();
  }
}