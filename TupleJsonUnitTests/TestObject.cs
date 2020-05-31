using System;
using System.Collections.Generic;
using System.Text;

namespace TupleJsonUnitTests
{
    public class TestObject
    {
        public ValueTuple<int, int> Meh { get; set; } = (1, 2);
        public Tuple<int, int> Meh2 { get; set; } = Tuple.Create(3, 4);
    }
}
