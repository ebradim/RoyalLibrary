using System.Collections.Generic;

namespace RoyalLibrary.Tests.Factories
{
  internal struct TestPerson
  {
    public TestPerson(string name, int age)
    {
      Name = name;
      Age = age;
    }

    public string Name { get; set; }
    public int Age { get; set; }
  }

  internal class TestPersonFactory
  {
    public IEnumerable<TestPerson> CreatePersons() => new List<TestPerson> {
        new TestPerson { Name = "Lucas", Age = 23 },
        new TestPerson { Name = "Samantha", Age = 25 },
        new TestPerson { Name = "Solarium", Age = 32 }
      };
  }
}