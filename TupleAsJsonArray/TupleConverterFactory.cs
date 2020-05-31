using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TupleAsJsonArray
{
    /// <summary>
    /// JSON Tuple to Array Converter Factory
    /// </summary>
    public class TupleConverterFactory : JsonConverterFactory
    {
        /// <summary>
        /// Determines whether the converter instance can convert the specified object type.
        /// </summary>
        /// <param name="typeToConvert">
        /// The type of the object to check whether it can be converted by this converter instance.
        /// </param>
        /// <returns>true if the instance can convert the specified object type; otherwise, false.</returns>
        public override bool CanConvert(Type typeToConvert)
        {
            if (typeToConvert.IsAbstract || !typeToConvert.IsGenericType)
            {
                return false;
            }

            return TupleReflector.TupleTypes.Contains(typeToConvert.GetGenericTypeDefinition());
        }

        /// <summary>
        /// Creates a converter for a specified type.
        /// </summary>
        /// <param name="typeToConvert">The type handled by the converter.</param>
        /// <param name="options">The serialization options to use.</param>
        /// <returns>A converter for which T is compatible with typeToConvert.</returns>
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type converterType = TupleReflector.GetTupleConverter(typeToConvert);
            #pragma warning disable CS8600, CS8603
            return (JsonConverter)Activator.CreateInstance(converterType);
            #pragma warning restore CS8600, CS8603
        }

    }
}
