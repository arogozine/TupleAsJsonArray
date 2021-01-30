# TupleAsJsonArray
Convert C# Tuple to/from JSON Array

[![Nuget](https://img.shields.io/nuget/v/TupleAsJsonArray?style=flat-square)](https://www.nuget.org/packages/TupleAsJsonArray/)
[![Nuget](https://img.shields.io/nuget/dt/TupleAsJsonArray?style=flat-square)](https://www.nuget.org/packages/TupleAsJsonArray/)

## About

1. Serialize Tuple and ValueTuples to JSON Array
2. Deserialize JSON Arrays as Tuples and ValueTuples
3. Bridges the gap between JS Destructuring assignment and C# ValueTuples.

## Using
_.NET C#_
```CSharp
// 1. Import Library
using TupleAsJsonArray;

// 2. Set Up Json Serializer Options
var options = new JsonSerializerOptions
{
    Converters =
    {
        new TupleConverterFactory(),
    }
};

// 3. Serialize Tuples to Array
var jsonArray = JsonSerializer.Serialize((1, 2, 3, 4), options);

// 4. Deserialize Arrays to Tuples
var (a, b, c, d) = JsonSerializer.Deserialize<(int, int, int, int)>("[1, 2, 3, 4]", options);
```
_JavaScript_
```JavaScript
// Tuples in Models will now show up as arrays
// that you can destructure
const [a, b, c, d] = modelFromServer.TupleParam;
```
