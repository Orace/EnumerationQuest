# EnumerationQuest
Avoids [multiple enumeration](https://www.jetbrains.com/help/resharper/PossibleMultipleEnumeration.html).

[![appveyor](https://ci.appveyor.com/api/projects/status/github/Orace/EnumerationQuest?svg=true)](https://ci.appveyor.com/project/Orace/EnumerationQuest)
[![codecov](https://codecov.io/gh/Orace/EnumerationQuest/branch/main/graph/badge.svg)](https://codecov.io/gh/Orace/EnumerationQuest)

## Introduction

**EnumerationQuest** library allows you to evaluate multiple properties of an `IEnumerable` in a single enumeration. 

It's as simple as that:

```csharp
    var (min, max) = enumerable.GetMin().AndMax();
```

## Available methods

**EnumerationQuest** purpose is to provide the same methods as [LINQ to Objects](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/linq-to-objects).

 - Aggregate
 - All
 - Any
 - Average
 - Contains
 - Count
 - DelimitedString
 - ElementAt
 - ElementsAt
 - ElementAtOrDefault
 - First
 - FirstOrDefault
 - IndexOf
 - IndicesOf
 - Last
 - LastOrDefault
 - LongCount
 - Max
 - MaxBy
 - MaximumsBy
 - Min
 - MinBy
 - MinimumsBy
 - SequenceEqual
 - Single
 - SingleOrDefault
 - Slice
 - Sum
 - ToDictionary
 - ToHashSet
 - ToLookup

## Status

See the [todo.md](todo.md) file to see the current status of the library.
