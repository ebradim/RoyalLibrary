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
