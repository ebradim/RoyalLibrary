using System;
using System.Collections.Generic;
using System.Linq;

namespace RoyalLibrary {
  public static class RoyalExtensions {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="action"></param>
    public static void Times(this int source, Action<int> action) {
      for(var i = 0; i < source; i++) {
        action(i);
      }
    }

    #region Count Utilities
    /// <summary>
    /// 
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public static IEnumerable<int> Evens(this IEnumerable<int> numbers) => numbers.Where(n => n % 2 == 0);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public static IEnumerable<int> Odds(this IEnumerable<int> numbers) => numbers.Where(n => n % 2 != 0);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public static long TotalAllEvens(this IEnumerable<int> numbers) => numbers.Evens().Sum();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public static long TotalAllOdds(this IEnumerable<int> numbers) => numbers.Odds().Sum();
    #endregion 

    #region Enumerables
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="action"></param>
    public static void Each<T>(this IEnumerable<T> source, Action<T> action) {
      foreach(var element in source) {
        action(element);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="action"></param>
    public static void Each<T>(this IEnumerable<T> source, Action<T, int> action) {
      var index = 0;
      foreach(var element in source) {
        action(element, index++);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TU"></typeparam>
    /// <param name="source"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static IEnumerable<TU> Map<T, TU>(this IEnumerable<T> source, Func<T, TU> action) {
      var enumerable = new List<TU>();
      foreach(var element in source) {
        enumerable.Add(action(element));
      }

      return enumerable;
    }
    #endregion
  }
}
