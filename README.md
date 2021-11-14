# EnumerationQuest
Avoids [multiple enumeration](https://www.jetbrains.com/help/resharper/PossibleMultipleEnumeration.html).

[![appveyor](https://ci.appveyor.com/api/projects/status/github/Orace/EnumerationQuest?svg=true)](https://ci.appveyor.com/project/Orace/EnumerationQuest)
[![codecov](https://codecov.io/gh/Orace/EnumerationQuest/branch/main/graph/badge.svg)](https://codecov.io/gh/Orace/EnumerationQuest)
[![nuget](https://img.shields.io/nuget/v/EnumerationQuest.svg)](https://www.nuget.org/packages/EnumerationQuest)

## Introduction

**EnumerationQuest** library allows the evaluation of multiple properties of an `IEnumerable` in a single enumeration. 

It's as simple as that:

```csharp
    var (min, max) = enumerable.GetMin().AndMax();
```

## Tell me more

**EnumerationQuest** provides the same methods as [LINQ to Objects](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/linq-to-objects)
to evaluate properties of `IEnumerable`.</br>
But unlike LINQ, **EnumerationQuest** allows the evaluation of *several* properties *at once*; that's it, in a single enumeration.

To achieve this, **EnumerationQuest** uses fluent pattern to construct an `EnumerationRequests` object.
 - The first method is called on the `IEnumerable` source object with the `Get` prefix.
 - The following ones are called on `EnumerationRequests` object with the `And` prefix.
 - The enumeration and the evaluations are performed at the [deconstruction](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types) of the `EnumerationRequests` object.

*Et voilà :*
```csharp
    var (min, avg, max, count) = e.GetMin()
                                  .AndAverage()
                                  .AndMax()
                                  .AndCount();
```

## Available methods

 - [Aggregate](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.aggregate):
   applies an accumulator function over a sequence.
 - [All](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.all):
   determines whether all elements of a sequence satisfy a condition.
 - [Any](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any):
   determines whether any element of a sequence exists or satisfies a condition.
 - [Average](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.average):
   computes the average of a sequence of numeric values.
 - [Contains](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.contains):
   determines whether a sequence contains a specified element.
 - [Count](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.count):
   returns the number of elements in a sequence; or the number of elements that satisfy a condition.
 - DelimitedString (aka [`String.Join`](https://docs.microsoft.com/en-us/dotnet/api/system.string.join)):
   concatenates the elements of a sequence, inserting the specified separator between each element.
 - [ElementAt](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.elementat):
   returns the element at a specified index in a sequence.
 - ElementsAt:
   returns the elements at the specified indices in a sequence.
 - [ElementAtOrDefault](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.elementatordefault):
   returns the element at a specified index in a sequence or a default value if the index is out of range.
 - [First](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.first):
   returns the first element of a sequence; or the first element that satisfies a condition.
 - [FirstOrDefault](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.firstordefault):
   returns the first element of a sequence; or the first element that satisfies a condition; or a default value if such an element does not exist .
 - IndexOf (from [`List<T>`](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.indexof)
            and [`Array`](https://docs.microsoft.com/en-us/dotnet/api/system.array.indexof)):
   returns the zero-based index of the first occurrence of a value in a sequence.
 - IndicesOf: returns the zero-based indices of all occurrences of a value in a sequence.
 - [Last](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.last):
   returns the last element of a sequence; or the last element that satisfies a condition.
 - [LastOrDefault](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.lastordefault):
   returns the last element of a sequence; or the last element that satisfies a condition; or a default value if such an element does not exist .
 - [LongCount](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.longcount):
   returns a [long](https://docs.microsoft.com/en-us/dotnet/api/system.int64) that represent the number of elements in a sequence; or the number of elements that satisfy a condition.
 - [Max](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.max):
   returns the maximum value in a sequence of value; or a sequence of transformed values.
 - [MaxBy](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.maxby):
   returns the maximum value in a sequence according to a specified key.
 - MaximumsBy:
   returns the maximums values in a sequence according to a specified key.
 - [Min](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.min):
   returns the minimum value in a sequence of value; or a sequence of transformed values.
 - [MinBy](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.minby):
   returns the minimum value in a sequence according to a specified key.
 - MinimumsBy:
   returns the minimums value in a sequence according to a specified key.
 - [SequenceEqual](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sequenceequal):
   determines whether two sequences are equal according to an equality comparer.
 - [Single](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.single):
   returns the single element of a sequence; or the single element that satisfies a condition.
 - [SingleOrDefault](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.singleordefault):
   returns the single element of a sequence; or the single element that satisfies a condition; or a default value if such an element does not exist .
 - Slice (replace [`Skip`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.skip),
                  [`SkipLast`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.skiplast),
                  [`Take`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.take) and
                  [`TakeLast`](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.takelast)):
   takes a specified range of contiguous elements from a sequence.
 - [Sum](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sum):
   computes the average of a sequence of numeric values.
 - [ToDictionary](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.todictionary):
   creates a `Dictionary<TKey,TValue>` from a sequence.
 - [ToHashSet](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.tohashset):
   creates a `HashSet<TValue>` from a sequence.
 - [ToLookup](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.tolookup):
   creates a `ILookup<TKey,TValue>` from a sequence.

## Status

See the [todo.md](todo.md) file to see the current status of the library.
