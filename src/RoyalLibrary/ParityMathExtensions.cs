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
    ///  Even expression evaluation delegate type
    /// </summary>
    public static Func<int, bool> EvenPredicate = value => value % 2 == 0;

    /// <summary>
    /// Odd expression evaluation delegate type
    /// </summary>
    public static Func<int, bool> OddPredicate = value => value % 2 != 0;

    /// <summary>
    /// Return an array of evens integers from an integer source collection
    /// </summary>
    /// <param name="numbers">Integer source collection</param>
    /// <returns></returns>
    public static IEnumerable<int> Evens(this IEnumerable<int> numbers) => numbers.Where(EvenPredicate);

    /// <summary>
    /// Return an array of odds integers from an integer source collection
    /// </summary>
    /// <param name="numbers">Integer source collection</param>
    /// <returns></returns>
    public static IEnumerable<int> Odds(this IEnumerable<int> numbers) => numbers.Where(OddPredicate);

    /// <summary>
    /// Deferred execution
    /// </summary>
    /// <param name="source"></param>
    /// <param name="evaluatorPredicate"></param>
    /// <param name="selector"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> ParityEvaluator<T>(this IEnumerable<T> source, Func<int, bool> evaluatorPredicate, Func<T, int> selector)
    {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      if (evaluatorPredicate == null)
        throw new ArgumentNullException(nameof(evaluatorPredicate));

      if (selector == null)
        throw new ArgumentNullException(nameof(selector));

      foreach (var item in source)
      {
        if (evaluatorPredicate(selector(item)))
          yield return item;
      }
    }

    /// <summary>
    /// Deferred execution
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    public static IEnumerable<T> Evens<T>(this IEnumerable<T> source, Func<T, int> selector) =>
      source.ParityEvaluator(EvenPredicate, selector);

    /// <summary>
    /// Deferred Execution
    /// </summary>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    public static IEnumerable<T> Odds<T>(this IEnumerable<T> source, Func<T, int> selector) =>
      source.ParityEvaluator(OddPredicate, selector);

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