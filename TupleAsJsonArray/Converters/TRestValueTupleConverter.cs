using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace TupleAsJsonArray
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1">The type of the value tuple's first element.</typeparam>
    /// <typeparam name="T2">The type of the value tuple's second element.</typeparam>
    /// <typeparam name="T3">The type of the value tuple's third element.</typeparam>
    /// <typeparam name="T4">The type of the value tuple's fourth element.</typeparam>
    /// <typeparam name="T5">The type of the value tuple's fifth element.</typeparam>
    /// <typeparam name="T6">The type of the value tuple's sixth element.</typeparam>
    /// <typeparam name="T7">The type of the value tuple's seventh element.</typeparam>
    /// <typeparam name="TRest">Any generic value tuple instance that defines the types of the tuple's remaining elements.</typeparam>
    public class ValueTupleConverter<T1, T2, T3, T4, T5, T6, T7, TRest> : TupleConverterBase<ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>>
        where TRest : struct
    {
        public override ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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

            Type[] restTypes = typeof(TRest).GetGenericArguments();
            object[] restValues = new object[restTypes.Length];
            for (var i = 0; i < restTypes.Length; i++)
            {
                reader.Read();
                Type restType = restTypes[i];
                restValues[i] = JsonSerializer.Deserialize(ref reader, restType, options);
            }
            tRest = TupleReflector.GenerateTuple<TRest>(restValues);

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndArray)
            {
                throw new JsonException();
            }

            return new ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>(t1, t2, t3, t4, t5, t6, t7, tRest);
        }

        public override void Write(Utf8JsonWriter writer, ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            WriteValue(writer, value.Item1, options);
            WriteValue(writer, value.Item2, options);
            WriteValue(writer, value.Item3, options);
            WriteValue(writer, value.Item4, options);
            WriteValue(writer, value.Item5, options);
            WriteValue(writer, value.Item6, options);
            WriteValue(writer, value.Item7, options);

            if (value.Rest is ITuple rest)
            {
                for (var i = 0; i < rest.Length; i++)
                {
                    object? tRestValue = rest[i];
                    JsonSerializer.Serialize(writer, tRestValue, options);
                }
            }
            else
            {
                throw new JsonException();
            }

            writer.WriteEndArray();
        }
    }
}
