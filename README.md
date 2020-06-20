# Royal Library

LINQ based extensions that replicate patterns from Ruby like .each .map and more...

Targeted to .Net Standard 2.0

## Installation

Install the [RoyalLibrary NuGet Package](https://www.nuget.org/packages/RoyalLibrary).

### Package Manager Console

```
Install-Package RoyalLibrary
```

### .NET Core CLI

```
dotnet add package RoyalLibrary
```

## Examples and usage

```csharp
var myArray = new[] { 1, 45, 34, 435 };

// Evens and odds
myArray.Evens();
myArray.Odds();

// Sum
myArray.TotalAllEvens();
myArray.TotalAllOdds();

// Each
myArray.Each(item => Debug.Log($"Using the strength: {item}"));

string[] shapes = { "circle", "square", "triangle", "octagon" };

shapes.Each(shape => {
  shape = shape.ToUpper();
  Debug.Log(shape);
});

shapes.Each((item, index) => {
  Debug.Log($"Item: {item.ToUpper()} with index: {index}");
});

// Map
myArray.Map(item => item * 2).Each(item => Debug.Log($"Using the strength doubled: {item}"));

// Times
5.Times(_ => {
  var theVar = 13;
  Debug.Log($"This is {theVar}");
});
```

## Contributing

Bug reports and pull requests are welcome on GitHub at https://github.com/ByteDecoder/RoyalLibrary.


Copyright (c) 2020 [Rodrigo Reyes](https://twitter.com/bytedecoder) released under the MIT license
