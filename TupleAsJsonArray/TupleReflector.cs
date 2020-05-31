using System;
using System.Collections.Generic;
using System.Text;

namespace TupleAsJsonArray
{
    internal static class TupleReflector
    {
        public static readonly HashSet<Type> TupleTypes = new HashSet<Type>(new Type[]
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
        public static Type GetTupleConverter(Type typeToConvert)
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

        public static TRest GenerateTuple<TRest>(object[] values)
        {
            return (TRest)Activator.CreateInstance(typeof(TRest), values);
        }
    }
}
