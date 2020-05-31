# TupleAsJsonArray
Value Tuple to/from JSON Array

## About

1. Serialize Tuple and ValueTuples to JSON Array
2. Deserialize JSON Arrays as Tuples and ValueTuples

## Using

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

```JavaScript
// Tuples in Modals will now show up as arrays
// that you can destructure
const [a, b, c] = modelFromServer.TupleParam;
```