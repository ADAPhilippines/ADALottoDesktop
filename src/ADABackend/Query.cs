using System.Collections.Generic;

namespace ADABackend
{
    public class Query
    {
        public Greetings GetGreetings() => new Greetings();
    }

    public class Greetings
    {
        public string Hello() => "World";
        public IEnumerable<Test> Tests() => new List<Test> { new Test { Name = "Hello World" } };
    }

    public class Test
    {
        public string Name { get; set; }
    }
}
