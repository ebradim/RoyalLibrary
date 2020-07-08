using System;
using System.Collections.Generic;
using System.Linq;

namespace ByteDecoder.RoyalLibrary
{
  /// <summary>
  /// 
  /// </summary>
  public static class RoyalExtensions
  {
    #region Count Utilities
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
    #endregion 

    #region Comparision Utilities 
    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsGreaterThan(this int i, int value) => i > value;

    #endregion

    #region Enumerables
    /// <summary>
    /// Applies the action on each element in the current collection. Do not return a new 
    /// collection and do not mutate the current collection
    /// </summary>
    /// <typeparam name="T">Element collection type</typeparam>
    /// <param name="source">Current collection</param>
    /// <param name="action">Applied action on to transform each collection element</param>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      foreach (var element in source)
      {
        action(element);
      }
    }

    /// <summary>
    /// Applies the action on each element in the current collection and passes back on each iteration the
    /// current index. Do not return a new collection and do not mutate the current collection
    /// </summary>
    /// <typeparam name="T">Element collection type</typeparam>
    /// <param name="source">Current collection</param>
    /// <param name="action">Applied action on to transform each collection element</param>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
    {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      if (action == null)
        throw new ArgumentNullException(nameof(action));

      var index = 0;
      foreach (var element in source)
      {
        action(element, index++);
      }
    }

    /// <summary>
    /// Deferred execution returnning a LINQ sequence of elements, after applying the selector on each sequence element
    /// </summary>
    /// <typeparam name="T">Element type</typeparam>
    /// <typeparam name="TResult">Result data type</typeparam>
    /// <param name="source">Input LINQ sequence</param>
    /// <param name="selector">Applied action to transform each collection element</param>
    /// <returns></returns>
    public static IEnumerable<TResult> Map<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
    {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      if (selector == null)
        throw new ArgumentNullException(nameof(selector));

      foreach (var element in source)
      {
        yield return selector(element);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    /// <typeparam name="TData"></typeparam>
    /// <param name="source"></param>
    /// <param name="selector"></param>
    /// <returns></returns>
    public static TElement MaxElement<TElement, TData>(this IEnumerable<TElement> source,
      Func<TElement, TData> selector) where TData : IComparable<TData>
    {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      if (selector == null)
        throw new ArgumentNullException(nameof(selector));

      var firstElement = true;
      var result = default(TElement);
      var maxValue = default(TData);

      foreach (var element in source)
      {
        var candidate = selector(element);
        if (!firstElement && (candidate.CompareTo(maxValue) <= 0)) continue;
        firstElement = false;
        maxValue = candidate;
        result = element;
      }
      return result;
    }
    #endregion
  }
}
