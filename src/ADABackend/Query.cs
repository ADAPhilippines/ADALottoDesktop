using System.Collections.Generic;
using Cardano.Data;
using HotChocolate;
using System.Linq;
using Cardano.Data.Entities;

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

        public IEnumerable<Block> TestEF(
            [Service] CardanoContext cardanoDb
        )
        {
            return cardanoDb.Blocks.OrderByDescending(b => b.EpochNo).Take(10).ToList();
        }
    }

    public class Test
    {
        public string Name { get; set; }
    }
}
