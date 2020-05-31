using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TupleAsJsonArray
{
    public class TupleConverter<T1> : TupleConverterBase<Tuple<T1>>
    {
        public override Tuple<T1> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }

            reader.Read();
            T1 value = ReadValue<T1>(ref reader, options);
            reader.Read(); // End of Array
            return new Tuple<T1>(value);
        }

        protected override void WriteTupleToArray(Utf8JsonWriter writer, Tuple<T1> value, JsonSerializerOptions options)
        {
            WriteValue(writer, value.Item1, options);
        }
    }

    public class TupleConverter<T1, T2> : TupleConverterBase<Tuple<T1, T2>>
    {
        public override Tuple<T1, T2> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            T1 t1;
            T2 t2;

            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }

            reader.Read();
            t1 = ReadValue<T1>(ref reader, options);

            reader.Read();
            t2 = ReadValue<T2>(ref reader, options);

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndArray)
            {
                throw new JsonException();
            }

            return new Tuple<T1, T2>(t1, t2);
        }

        protected override void WriteTupleToArray(Utf8JsonWriter writer, Tuple<T1, T2> value, JsonSerializerOptions options)
        {
            WriteValue(writer, value.Item1, options);
            WriteValue(writer, value.Item2, options);
        }
    }

    public class TupleConverter<T1, T2, T3> : TupleConverterBase<Tuple<T1, T2, T3>>
    {
        public override Tuple<T1, T2, T3> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            T1 t1;
            T2 t2;
            T3 t3;

            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }

            reader.Read();
            t1 = ReadValue<T1>(ref reader, options);

            reader.Read();
            t2 = ReadValue<T2>(ref reader, options);

            reader.Read();
            t3 = ReadValue<T3>(ref reader, options);

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndArray)
            {
                throw new JsonException();
            }

            return new Tuple<T1, T2, T3>(t1, t2, t3);
        }

        protected override void WriteTupleToArray(Utf8JsonWriter writer, Tuple<T1, T2, T3> value, JsonSerializerOptions options)
        {
            WriteValue(writer, value.Item1, options);
            WriteValue(writer, value.Item2, options);
            WriteValue(writer, value.Item3, options);
        }
    }

    public class TupleConverter<T1, T2, T3, T4> : TupleConverterBase<Tuple<T1, T2, T3, T4>>
    {
        public override Tuple<T1, T2, T3, T4> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            T1 t1;
            T2 t2;
            T3 t3;
            T4 t4;

            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }

            reader.Read();
            t1 = ReadValue<T1>(ref reader, options);

            reader.Read();
            t2 = ReadValue<T2>(ref reader, options);

            reader.Read();
            t3 = ReadValue<T3>(ref reader, options);

            reader.Read();
            t4 = ReadValue<T4>(ref reader, options);


            if (!reader.Read() || reader.TokenType != JsonTokenType.EndArray)
            {
                throw new JsonException();
            }

            return new Tuple<T1, T2, T3, T4>(t1, t2, t3, t4);
        }

        protected override void WriteTupleToArray(Utf8JsonWriter writer, Tuple<T1, T2, T3, T4> value, JsonSerializerOptions options)
        {
            WriteValue(writer, value.Item1, options);
            WriteValue(writer, value.Item2, options);
            WriteValue(writer, value.Item3, options);
            WriteValue(writer, value.Item4, options);
        }
    }

    public class TupleConverter<T1, T2, T3, T4, T5> : TupleConverterBase<Tuple<T1, T2, T3, T4, T5>>
    {
        public override Tuple<T1, T2, T3, T4, T5> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            T1 t1;
            T2 t2;
            T3 t3;
            T4 t4;
            T5 t5;

            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }

            reader.Read();
            t1 = ReadValue<T1>(ref reader, options);

            reader.Read();
            t2 = ReadValue<T2>(ref reader, options);

            reader.Read();
            t3 = ReadValue<T3>(ref reader, options);

            reader.Read();
            t4 = ReadValue<T4>(ref reader, options);

            reader.Read();
            t5 = ReadValue<T5>(ref reader, options);

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndArray)
            {
                throw new JsonException();
            }

            return new Tuple<T1, T2, T3, T4, T5>(t1, t2, t3, t4, t5);
        }

        protected override void WriteTupleToArray(Utf8JsonWriter writer, Tuple<T1, T2, T3, T4, T5> value, JsonSerializerOptions options)
        {
            WriteValue(writer, value.Item1, options);
            WriteValue(writer, value.Item2, options);
            WriteValue(writer, value.Item3, options);
            WriteValue(writer, value.Item4, options);
            WriteValue(writer, value.Item5, options);
        }
    }

    public class TupleConverter<T1, T2, T3, T4, T5, T6> : TupleConverterBase<Tuple<T1, T2, T3, T4, T5, T6>>
    {
        public override Tuple<T1, T2, T3, T4, T5, T6> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            T1 t1;
            T2 t2;
            T3 t3;
            T4 t4;
            T5 t5;
            T6 t6;

            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }

            reader.Read();
            t1 = ReadValue<T1>(ref reader, options);

            reader.Read();
            t2 = ReadValue<T2>(ref reader, options);

            reader.Read();
            t3 = ReadValue<T3>(ref reader, options);

            reader.Read();
            t4 = ReadValue<T4>(ref reader, options);

            reader.Read();
            t5 = ReadValue<T5>(ref reader, options);

            reader.Read();
            t6 = ReadValue<T6>(ref reader, options);

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndArray)
            {
                throw new JsonException();
            }

            return new Tuple<T1, T2, T3, T4, T5, T6>(t1, t2, t3, t4, t5, t6);
        }

        protected override void WriteTupleToArray(Utf8JsonWriter writer, Tuple<T1, T2, T3, T4, T5, T6> value, JsonSerializerOptions options)
        {
            WriteValue(writer, value.Item1, options);
            WriteValue(writer, value.Item2, options);
            WriteValue(writer, value.Item3, options);
            WriteValue(writer, value.Item4, options);
            WriteValue(writer, value.Item5, options);
            WriteValue(writer, value.Item6, options);
        }
    }

    public class TupleConverter<T1, T2, T3, T4, T5, T6, T7> : TupleConverterBase<Tuple<T1, T2, T3, T4, T5, T6, T7>>
    {
        public override Tuple<T1, T2, T3, T4, T5, T6, T7> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            T1 t1;
            T2 t2;
            T3 t3;
            T4 t4;
            T5 t5;
            T6 t6;
            T7 t7;

            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }

            reader.Read();
            t1 = ReadValue<T1>(ref reader, options);

            reader.Read();
            t2 = ReadValue<T2>(ref reader, options);

            reader.Read();
            t3 = ReadValue<T3>(ref reader, options);

            reader.Read();
            t4 = ReadValue<T4>(ref reader, options);

            reader.Read();
            t5 = ReadValue<T5>(ref reader, options);

            reader.Read();
            t6 = ReadValue<T6>(ref reader, options);

            reader.Read();
            t7 = ReadValue<T7>(ref reader, options);

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndArray)
            {
                throw new JsonException();
            }

            return new Tuple<T1, T2, T3, T4, T5, T6, T7>(t1, t2, t3, t4, t5, t6, t7);
        }

        protected override void WriteTupleToArray(Utf8JsonWriter writer, Tuple<T1, T2, T3, T4, T5, T6, T7> value, JsonSerializerOptions options)
        {
            WriteValue(writer, value.Item1, options);
            WriteValue(writer, value.Item2, options);
            WriteValue(writer, value.Item3, options);
            WriteValue(writer, value.Item4, options);
            WriteValue(writer, value.Item5, options);
            WriteValue(writer, value.Item6, options);
            WriteValue(writer, value.Item7, options);
        }
    }

    public class TupleConverter<T1, T2, T3, T4, T5, T6, T7, TRest> : TupleConverterBase<Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>>
        where TRest : notnull
    {
        public override Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            T1 t1;
            T2 t2;
            T3 t3;
            T4 t4;
            T5 t5;
            T6 t6;
            T7 t7;
            TRest tRest;

            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }

            reader.Read();
            t1 = ReadValue<T1>(ref reader, options);

            reader.Read();
            t2 = ReadValue<T2>(ref reader, options);

            reader.Read();
            t3 = ReadValue<T3>(ref reader, options);

            reader.Read();
            t4 = ReadValue<T4>(ref reader, options);

            reader.Read();
            t5 = ReadValue<T5>(ref reader, options);

            reader.Read();
            t6 = ReadValue<T6>(ref reader, options);

            reader.Read();
            t7 = ReadValue<T7>(ref reader, options);

            reader.Read();
            tRest = ReadValue<TRest>(ref reader, options);

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndArray)
            {
                throw new JsonException();
            }

            return new Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>(t1, t2, t3, t4, t5, t6, t7, tRest);
        }

        protected override void WriteTupleToArray(Utf8JsonWriter writer, Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> value, JsonSerializerOptions options)
        {
            WriteValue(writer, value.Item1, options);
            WriteValue(writer, value.Item2, options);
            WriteValue(writer, value.Item3, options);
            WriteValue(writer, value.Item4, options);
            WriteValue(writer, value.Item5, options);
            WriteValue(writer, value.Item6, options);
            WriteValue(writer, value.Item7, options);
            WriteValue(writer, value.Rest, options);
        }
    }
}
