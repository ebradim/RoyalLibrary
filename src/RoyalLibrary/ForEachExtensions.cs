using System;
using System.Collections.Generic;

namespace ByteDecoder.RoyalLibrary
{
  /// <summary>
  /// 
  /// </summary>
  public static class ForEachExtensions
  {
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
  }
}