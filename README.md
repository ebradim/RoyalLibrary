# Royal Library

Some extensions methods like the ones in Ruby .each .map and more

Package available in **Nuget**

https://www.nuget.org/packages/RoyalLibrary/


## Examples

```
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
