using System;
using System.Linq;

namespace ByteDecoder.RoyalLibrary
{
  /// <summary>
  /// 
  /// </summary>
  public static class PagingExtensions
  {
    /// <summary>
    /// Generic Page query object
    /// </summary>
    /// <param name="query">Sequence source</param>
    /// <param name="pageNumZeroStart">Starting offset.null Zero is the first page</param>
    /// <param name="pageSize">Page size</param>
    /// <typeparam name="T">Type of the source</typeparam>
    /// <returns></returns>
    public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageNumZeroStart, int pageSize)
    {
      if (query is null) throw new ArgumentNullException(nameof(query));

      if (pageSize == 0)
        throw new ArgumentOutOfRangeException(nameof(pageSize), "pageSize cannot be zero.");

      if (pageNumZeroStart != 0)
        query = query.Skip(pageNumZeroStart * pageSize);

      return query.Take(pageSize);
    }
  }
}