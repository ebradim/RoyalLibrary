using System.Collections.Generic;

namespace RoyalLibrary.Tests.Fakes
{
  public class FakeLogger
  {
    public List<string> Messages { get; private set; } = new List<string>();

    public void Log(string message)
    {
      Messages.Add(message);
    }
  }
}