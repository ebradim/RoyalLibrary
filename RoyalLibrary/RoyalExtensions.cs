using System;
using System.Collections.Generic;
using System.Linq;

namespace RoyalLibrary
{
  public static class RoyalExtensions
  {
    /// <summary>
    /// Executes n times an Action delegate without returning anything 
    /// </summary>
    /// <param name="source">Current collection</param>
    /// <param name="action">Action type to execute on each iteration</param>
    public static void Times(this int source, Action<int> action)
    {
      if (action == null)
        throw new ArgumentNullException(nameof(action));

      for (var i = 0; i < source; i++)
      {
        action(i);
      }
    }

    #region Count Utilities
    /// <summary>
    /// Return an array of evens integers from an integer source collection
    /// </summary>
    /// <param name="numbers">Integer source collection</param>
    /// <returns></returns>
    public static IEnumerable<int> Evens(this IEnumerable<int> numbers) => numbers.Where(n => n % 2 == 0);

    /// <summary>
    /// Return an array of odds integers from an integer source collection
    /// </summary>
    /// <param name="numbers">Integer source collection</param>
    /// <returns></returns>
    public static IEnumerable<int> Odds(this IEnumerable<int> numbers) => numbers.Where(n => n % 2 != 0);

    /// <summary>
    /// Return a sum of all evens integers from an integer source collection
    /// </summary>
    /// <param name="numbers">Integer source collection</param>
    /// <returns></returns>
    public static long TotalAllEvens(this IEnumerable<int> numbers) => numbers.Evens().Sum();

    /// <summary>
    /// Return a sum of all oods integers from an integer source collection
    /// </summary>
    /// <param name="numbers">Integer source collection</param>
    /// <returns></returns>
    public static long TotalAllOdds(this IEnumerable<int> numbers) => numbers.Odds().Sum();
    #endregion 

    #region Comparision Utilities 
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
    public static void Each<T>(this IEnumerable<T> source, Action<T> action)
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
    public static void Each<T>(this IEnumerable<T> source, Action<T, int> action)
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
    /// Returns a new IEnumerable collection, after applying  the action on each current collection element
    /// without  mutating the current collection
    /// </summary>
    /// <typeparam name="T">Element collection type</typeparam>
    /// <typeparam name="TU">Result collection type</typeparam>
    /// <param name="source">Current collection</param>
    /// <param name="action">Applied action to transform each collection element</param>
    /// <returns></returns>
    public static IEnumerable<TU> Map<T, TU>(this IEnumerable<T> source, Func<T, TU> action)
    {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      var enumerable = new List<TU>();
      foreach (var element in source)
      {
        enumerable.Add(action(element));
      }

      return enumerable;
    }

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
