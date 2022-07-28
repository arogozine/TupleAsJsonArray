using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TupleAsJsonArray
{
    /// <summary>
    /// Tuple Converter Helper Base Class
    /// </summary>
    /// <typeparam name="TTuple">Class Tuple or Value Tuple</typeparam>
    public abstract class TupleConverterBase<TTuple> : JsonConverter<TTuple>
        where TTuple : ITuple, IStructuralComparable, IStructuralEquatable, IComparable
    {
        /// <summary>
        /// Writes Value in the Tuple
        /// </summary>
        /// <typeparam name="T">Tuple Element Type</typeparam>
        /// <param name="writer">Writer</param>
        /// <param name="value">Tuple Value</param>
        /// <param name="options">Existing Options</param>
        protected void WriteValue<T>(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }

        /// <summary>
        /// Read Value in the Array
        /// </summary>
        /// <typeparam name="T">Tuple Element Type</typeparam>
        /// <param name="reader">Reader</param>
        /// <param name="options">Existing Options</param>
        /// <returns>Deserialized Value</returns>
        protected T ReadValue<T>(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<T>(ref reader, options);
        }
    }
}
