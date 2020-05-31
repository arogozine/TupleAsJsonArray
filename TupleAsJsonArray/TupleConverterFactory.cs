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
        private static readonly HashSet<Type> TupleTypes = new HashSet<Type>(new Type[]
        {
            typeof(Tuple<>),
            typeof(Tuple<,>),
            typeof(Tuple<,,>),
            typeof(Tuple<,,,>),
            typeof(Tuple<,,,,>),
            typeof(Tuple<,,,,,>),
            typeof(Tuple<,,,,,,>),
            typeof(Tuple<,,,,,,,>),

            typeof(ValueTuple<>),
            typeof(ValueTuple<,>),
            typeof(ValueTuple<,,>),
            typeof(ValueTuple<,,,>),
            typeof(ValueTuple<,,,,>),
            typeof(ValueTuple<,,,,,>),
            typeof(ValueTuple<,,,,,,>),
            typeof(ValueTuple<,,,,,,,>)
        });

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

            return TupleTypes.Contains(typeToConvert.GetGenericTypeDefinition());
        }

        /// <summary>
        /// Creates a converter for a specified type.
        /// </summary>
        /// <param name="typeToConvert">The type handled by the converter.</param>
        /// <param name="options">The serialization options to use.</param>
        /// <returns>A converter for which T is compatible with typeToConvert.</returns>
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type converterType = GetTupleConverter(typeToConvert);
            return (JsonConverter)Activator.CreateInstance(converterType);
        }

        private static Type GetTupleConverter(Type typeToConvert)
        {
            Type[] genericTupleArgs = typeToConvert.GetGenericArguments();

            if (typeToConvert.IsClass)
            {
                // Tuple
                return genericTupleArgs.Length switch
                {
                    1 => typeof(TupleConverter<>).MakeGenericType(genericTupleArgs),
                    2 => typeof(TupleConverter<,>).MakeGenericType(genericTupleArgs),
                    3 => typeof(TupleConverter<,,>).MakeGenericType(genericTupleArgs),
                    4 => typeof(TupleConverter<,,,>).MakeGenericType(genericTupleArgs),
                    5 => typeof(TupleConverter<,,,,>).MakeGenericType(genericTupleArgs),
                    6 => typeof(TupleConverter<,,,,,>).MakeGenericType(genericTupleArgs),
                    7 => typeof(TupleConverter<,,,,,,>).MakeGenericType(genericTupleArgs),
                    8 => typeof(TupleConverter<,,,,,,,>).MakeGenericType(genericTupleArgs),
                    _ => throw new NotSupportedException(),
                };
            }
            else
            {
                // Value Tuple
                return genericTupleArgs.Length switch
                {
                    1 => typeof(ValueTupleConverter<>).MakeGenericType(genericTupleArgs),
                    2 => typeof(ValueTupleConverter<,>).MakeGenericType(genericTupleArgs),
                    3 => typeof(ValueTupleConverter<,,>).MakeGenericType(genericTupleArgs),
                    4 => typeof(ValueTupleConverter<,,,>).MakeGenericType(genericTupleArgs),
                    5 => typeof(ValueTupleConverter<,,,,>).MakeGenericType(genericTupleArgs),
                    6 => typeof(ValueTupleConverter<,,,,,>).MakeGenericType(genericTupleArgs),
                    7 => typeof(ValueTupleConverter<,,,,,,>).MakeGenericType(genericTupleArgs),
                    8 => typeof(ValueTupleConverter<,,,,,,,>).MakeGenericType(genericTupleArgs),
                    _ => throw new NotSupportedException(),
                };
            }
        }
    }
}
