using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using TupleAsJsonArray;

namespace TupleJsonUnitTests
{
    public static class TestHelper
    {
        public static void RunTest<T1>(T1 t1)
            => RunTestGeneric(ValueTuple.Create(t1), Tuple.Create(t1));

        public static void RunTest<T1, T2>(T1 t1, T2 t2)
            => RunTestGeneric(ValueTuple.Create(t1, t2), Tuple.Create(t1, t2));

        public static void RunTest<T1, T2, T3>(T1 t1, T2 t2, T3 t3)
            => RunTestGeneric(ValueTuple.Create(t1, t2, t3), Tuple.Create(t1, t2, t3));

        public static void RunTest<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4)
            => RunTestGeneric(ValueTuple.Create(t1, t2, t3, t4), Tuple.Create(t1, t2, t3, t4));

        public static void RunTest<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
            => RunTestGeneric(ValueTuple.Create(t1, t2, t3, t4, t5), Tuple.Create(t1, t2, t3, t4, t5));

        public static void RunTest<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
            => RunTestGeneric(ValueTuple.Create(t1, t2, t3, t4, t5, t6), Tuple.Create(t1, t2, t3, t4, t5, t6));

        public static void RunTest<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
            => RunTestGeneric(ValueTuple.Create(t1, t2, t3, t4, t5, t6, t7), Tuple.Create(t1, t2, t3, t4, t5, t6, t7));

        public static void RunTestGeneric<TValueTuple, TTuple>(TValueTuple valueTuple, TTuple tuple)
            where TValueTuple : struct, ITuple
            where TTuple : class, ITuple
        {
            var options = new JsonSerializerOptions
            {
                Converters =
                {
                    new TupleConverterFactory()
                }
            };

            // We should be comparing tuples of the same length
            Assert.AreEqual(valueTuple.Length, tuple.Length);

            // Tuple and ValueTuple should serialize
            string valueTupleString = JsonSerializer.Serialize(valueTuple, options);
            string tupleString = JsonSerializer.Serialize(tuple, options);

            // Tuple and ValueTuple should serialize the same
            Assert.AreEqual(tupleString, valueTupleString);

            // Both should deserialize to an array
            object[] valueTupleArray = JsonSerializer.Deserialize<object[]>(valueTupleString);
            object[] tupleArray = JsonSerializer.Deserialize<object[]>(tupleString);

            Assert.AreEqual(valueTuple.Length, valueTupleArray.Length);
            Assert.AreEqual(valueTuple.Length, tupleArray.Length);

            // Arrays should deserialize to Tuples
            TValueTuple valueTupleNew = JsonSerializer.Deserialize<TValueTuple>(valueTupleString, options);
            TTuple tupleNew = JsonSerializer.Deserialize<TTuple>(tupleString, options);

            // 
            Assert.AreEqual(valueTuple.Length, valueTupleNew.Length);
            Assert.AreEqual(valueTuple.Length, tupleNew.Length);
        }
    }
}
