using System;
using System.Collections.Generic;
using System.IO;

namespace RoyalLibrary
{
  public static class StreamReaderExtensions
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static IEnumerable<string> Lines(this StreamReader source)
    {
      string line;

      if(source == null)
        throw new ArgumentNullException(nameof(source));

      while((line = source.ReadLine()) != null)
        yield return line;
    }
  }
}