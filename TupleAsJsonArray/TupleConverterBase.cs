using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TupleAsJsonArray
{
    public abstract class TupleConverterBase<TTuple> : JsonConverter<TTuple>
        where TTuple : ITuple
    {
        public override void Write(Utf8JsonWriter writer, TTuple value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            WriteTupleToArray(writer, value, options);
            writer.WriteEndArray();
        }

        protected abstract void WriteTupleToArray(Utf8JsonWriter writer, TTuple value, JsonSerializerOptions options);

        protected void WriteValue<T>(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var converter = (JsonConverter<T>)options.GetConverter(typeof(T));

            if (converter == null)
            {
                JsonSerializer.Serialize(writer, value, options);
            }
            else
            {
                converter.Write(writer, value, options);
            }
        }

        protected T ReadValue<T>(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            var converter = (JsonConverter<T>)options.GetConverter(typeof(T));

            if (converter == null)
            {
                return JsonSerializer.Deserialize<T>(ref reader, options);
            }
            else
            {
                return converter.Read(ref reader, typeof(T), options);
            }
        }
    }
}
