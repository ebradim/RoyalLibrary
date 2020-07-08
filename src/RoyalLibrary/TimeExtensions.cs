using System;

namespace ByteDecoder.RoyalLibrary
{
  /// <summary>
  /// 
  /// </summary>
  public static class TimeExtensions
  {
    /// <summary>
    /// Executes n times a code block
    /// </summary>
    /// <param name="source"></param>
    /// <param name="action"></param>
    public static void Times(this int source, Action action)
    {
      if (action == null)
        throw new ArgumentNullException(nameof(action));

      for (var i = 0; i < source; i++)
      {
        action();
      }
    }

    /// <summary>
    /// Executes n times an Action delegate without returning anything 
    /// </summary>
    /// <param name="source">Current collection</param>
    /// <param name="action">Action type to execute on each iteration + current iteration number</param>
    public static void Times(this int source, Action<int> action)
    {
      if (action == null)
        throw new ArgumentNullException(nameof(action));

      for (var i = 0; i < source; i++)
      {
        action(i);
      }
    }

  }
}