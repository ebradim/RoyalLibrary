using System;
using System.Collections.Generic;
using System.Linq;

namespace RoyalLibrary {
  public static class RoyalExtensions {
    public static void Times(this int source, Action<int> action) {
      for(var i = 0; i < source; i++) {
        action(i);
      }
    }

    #region Count Utilities
    public static IEnumerable<int> Evens(this IEnumerable<int> numbers) => numbers.Where(n => n % 2 == 0);

    public static IEnumerable<int> Odds(this IEnumerable<int> numbers) => numbers.Where(n => n % 2 != 0);

    public static long TotalAllEvens(this IEnumerable<int> numbers) => numbers.Evens().Sum();

    public static long TotalAllOdds(this IEnumerable<int> numbers) => numbers.Odds().Sum();
    #endregion 

    #region Enumerables
    public static void Each<T>(this IEnumerable<T> source, Action<T> action) {
      foreach(var element in source) {
        action(element);
      }
    }

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
