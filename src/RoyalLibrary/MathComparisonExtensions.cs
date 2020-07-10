namespace RoyalLibrary
{
  /// <summary>
  /// 
  /// </summary>
  public static class MathComparisonExtensions
  {
    /// <summary>
    /// Integer extension method for Greater Than 
    /// </summary>
    /// <param name="i"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsGreaterThan(this int i, int value) => i > value;

    /// <summary>
    /// Integer extension method for Less Than 
    /// </summary>
    /// <param name="i"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsLessThan(this int i, int value) => i < value;

    /// <summary>
    /// Integer extension method for Equal To 
    /// </summary>
    /// <param name="i"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsEqualTo(this int i, int value) => i == value;

    /// <summary>
    /// Integer extension method for Not Equal To 
    /// </summary>
    /// <param name="i"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsNotEqualTo(this int i, int value) => i != value;

    /// <summary>
    /// Integer extension method for Greater Than Or Equal To
    /// </summary>
    /// <param name="i"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsGreaterThanOrEqualTo(this int i, int value) => i >= value;

    /// <summary>
    /// Integer extension method for Less Than Or Equal To
    /// </summary>
    /// <param name="i"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsLessThanOrEqualTo(this int i, int value) => i <= value;
  }
}