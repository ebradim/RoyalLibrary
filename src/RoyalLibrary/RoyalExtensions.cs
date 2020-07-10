using System;
using System.Collections.Generic;

namespace ByteDecoder.RoyalLibrary
{
  /// <summary>
  /// 
  /// </summary>
  public static class RoyalExtensions
  {
    /// <summary>
    /// Deferred execution returnning a LINQ sequence of elements, after applying the selector on each sequence element
    /// </summary>
    /// <typeparam name="TInput">Element type</typeparam>
    /// <typeparam name="TResult">Result data type</typeparam>
    /// <param name="source">Input LINQ sequence</param>
    /// <param name="element">Applied action to transform each collection element</param>
    /// <returns></returns>
    public static IEnumerable<TResult> Map<TInput, TResult>(this IEnumerable<TInput> source, Func<TInput, TResult> element)
    {
      if (source == null)
        throw new ArgumentNullException(nameof(source));

      if (element == null)
        throw new ArgumentNullException(nameof(element));

      foreach (var item in source)
      {
        yield return element(item);
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
  }
}
