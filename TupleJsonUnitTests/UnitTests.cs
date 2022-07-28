using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using TupleAsJsonArray;
using static TupleJsonUnitTests.TestHelper;

namespace TupleJsonUnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void IntegerTest()
        {
            RunTest(1);
            RunTest(1, 2);
            RunTest(1, 2, 3);
            RunTest(1, 2, 3, 4);
            RunTest(1, 2, 3, 4, 5);
            RunTest(1, 2, 3, 4, 5, 6);
            RunTest(1, 2, 3, 4, 5, 6, 7);
        }

        [TestMethod]
        public void PrimiteTypesTest()
        {
            RunTest(1);
            RunTest(1, "2");
            RunTest(1, "2", 3f);
            RunTest(1, "2", 3f, 4d);
            RunTest(1, "2", 3f, 4d, 5m);
            RunTest(1, "2", 3f, 4d, 5m, (byte)6);
            RunTest(1, "2", 3f, 4d, 5m, (byte)6, (short)7);
        }

        [TestMethod]
        public void DateTimeTest() {
            RunTest(DateTime.Now, DateTime.Today);
        }

        [TestMethod]
        public void TupleInTuple()
        {
            RunTest(1, (2, (3, 4)));
        }

        [TestMethod]
        public void TestEnum()
        {
            RunTest(SampleEnum.One, SampleEnum.Two);
        }

        [TestMethod]
        public void TestObject()
        {
            RunTest(new TestObject());
        }

        [TestMethod]
        public void ExampleTest() {
            var options = new JsonSerializerOptions
            {
                Converters =
                {
                    new TupleConverterFactory(),
                },
            };

            var (a, b, c, d) = JsonSerializer.Deserialize<(int, int, int, int)>("[1, 2, 3, 4]", options);
        }

        [TestMethod]
        public void ReadTupleWithComments()
        {
            var options = new JsonSerializerOptions
            {
                Converters =
                {
                    new TupleConverterFactory(),
                },
                ReadCommentHandling = JsonCommentHandling.Skip
            };

            var (tupleA, tupleB) = JsonSerializer.Deserialize<ValueTuple<ValueTuple<int, int>, ValueTuple<int, int>>>("[[1,2], /*Meh*/[3 //Test \r\n,4]] // Test 2", options);

            Assert.AreEqual((1, 2), tupleA);
            Assert.AreEqual((3, 4), tupleB);
        }

        [TestMethod]
        public void ReadMultilineTuple() {
            var options = new JsonSerializerOptions
            {
                Converters =
                {
                    new TupleConverterFactory(),
                },
                ReadCommentHandling = JsonCommentHandling.Skip
            };

            var (tupleA, tupleB) = JsonSerializer.Deserialize<ValueTuple<ValueTuple<int, int>, ValueTuple<int, int>>>(
                    @"
                        [
                            [1,2], /*Meh*/
                            [3 //Test
                              ,4]
                        ] // Test 2
                    ", options);

            Assert.AreEqual((1, 2), tupleA);
            Assert.AreEqual((3, 4), tupleB);
        }

        [TestMethod]
        public void GinormousValueTuple() {
            var options = new JsonSerializerOptions
            {
                Converters =
                {
                    new TupleConverterFactory(),
                },
            };

            ValueTuple<int, int, int, int, int, int, int, ValueTuple<int, int, int, int, int>> valueTuple = (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            string result = JsonSerializer.Serialize(valueTuple, options);
            Assert.AreEqual("[1,2,3,4,5,6,7,8,9,10,11,12]", result);

            var valueTuple2 = 
                JsonSerializer.Deserialize<ValueTuple<int, int, int, int, int, int, int, ValueTuple<int, int, int, int, int>>>(result, options);

            Assert.AreEqual(valueTuple, valueTuple2);
        }

        [TestMethod]
        public void GinormousTuple()
        {
            var options = new JsonSerializerOptions
            {
                Converters =
                {
                    new TupleConverterFactory(),
                },
            };

            // If someone does this in real code, they should be fired to be honest
            Tuple<int, int, int, int, int, int, int, Tuple<int, int, int, int, int>> valueTuple =
                new Tuple<int, int, int, int, int, int, int, Tuple<int, int, int, int, int>>(1, 2, 3, 4, 5, 6, 7, new Tuple<int, int, int, int, int>(8, 9, 10, 11, 12));
            string result = JsonSerializer.Serialize(valueTuple, options);
            Assert.AreEqual("[1,2,3,4,5,6,7,8,9,10,11,12]", result);

            var valueTuple2 =
                JsonSerializer.Deserialize<Tuple<int, int, int, int, int, int, int, Tuple<int, int, int, int, int>>>(result, options);

            Assert.AreEqual(valueTuple, valueTuple2);
        }
#if NET6_0_OR_GREATER
        [TestMethod]
        public async Task ReadLargeStreamWithUnusualRecords()
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new TupleConverterFactory());

            var biglist = new List<(Guid, DataRecord)>();

            for (int i = 0; i < 100000; i++)
            {
                biglist.Add((Guid.NewGuid(), new DataRecord(new[] { "blah" })));
            }

            var memoryStream = new MemoryStream();

            await JsonSerializer.SerializeAsync(memoryStream, biglist, options);
            memoryStream.Position = 0;

            await JsonSerializer.DeserializeAsync<List<(Guid, DataRecord)>>(memoryStream, options);
        }

        public record DataRecord(string[] Strings)
        {
            public string SomeInternalValue => "example";
        }
#endif


    }
}
