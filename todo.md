| Methods                | Variant                   | Implementation  | Tests   | Documentation | Optimizations |
|------------------------|---------------------------|-----------------|---------|---------------|---------------|
| Aggregate              |                           | &check;         | &check; | &check;       |               |
| Aggregate              | seed                      | &check;         | &check; | &check;       |               |
| Aggregate              | seed, resultSelector      | &check;         | &check; | &check;       |               |
| All                    |                           | &check;         | &check; | &check;       |               |
| Any                    |                           | &check;         | &check; | &check;       |               |
| Any                    | predicate                 | &check;         | &check; | &check;       |               |
| Average                | decimal                   | &check;         | &check; | &check;       |               |
| Average                | decimal, selector         | &check;         | &check; | &check;       |               |
| Average                | double                    | &check;         | &check; | &check;       |               |
| Average                | double, selector          | &check;         | &check; | &check;       |               |
| Average                | float                     | &check;         | &check; | &check;       |               |
| Average                | float, selector           | &check;         | &check; | &check;       |               |
| Average                | int                       | &check;         | &check; | &check;       |               |
| Average                | int, selector             | &check;         | &check; | &check;       |               |
| Average                | long                      | &check;         | &check; | &check;       |               |
| Average                | long, selector            | &check;         | &check; | &check;       |               |
| Average                | decimal?                  | &check;         | &check; | &check;       |               |
| Average                | decimal?, selector        | &check;         | &check; | &check;       |               |
| Average                | double?                   | &check;         | &check; | &check;       |               |
| Average                | double?, selector         | &check;         | &check; | &check;       |               |
| Average                | float?                    | &check;         | &check; | &check;       |               |
| Average                | float?, selector          | &check;         | &check; | &check;       |               |
| Average                | int?                      | &check;         | &check; | &check;       |               |
| Average                | int?, selector            | &check;         | &check; | &check;       |               |
| Average                | long?                     | &check;         | &check; | &check;       |               |
| Average                | long?, selector           | &check;         | &check; | &check;       |               |
| Contains               |                           | &check;         | &check; | &check;       |               |
| Contains               | comparer                  | &check;         | &check; | &check;       |               |
| Count                  |                           | &check;         | &check; | &check;       |               |
| Count                  | predicate                 | &check;         | &check; | &check;       |               |
| DelimitedString        |                           | &check;         | &check; | &check;       |               |
| DelimitedString        | stringSelector            | &check;         | &check; | &check;       |               |
| ElementAt              |                           | &check;         | &check; | &check;       |               |
| ElementAt              | index                     | &check;         | &check; | &check;       |               |
| ElementsAt             |                           | &check;         | &check; | &check;       |               |
| ElementAtOrDefault     |                           | &check;         | &check; | &check;       |               |
| ElementAtOrDefault     | index                     | &check;         | &check; | &check;       |               |
| First                  |                           | &check;         | &check; | &check;       |               |
| First                  | predicate                 | &check;         | &check; | &check;       |               |
| FirstOrDefault         |                           | &check;         | &check; | &check;       |               |
| FirstOrDefault         | defaultValue              | &check;         | &check; | &check;       |               |
| FirstOrDefault         | predicate                 | &check;         | &check; | &check;       |               |
| FirstOrDefault         | predicate, defaultValue   | &check;         | &check; | &check;       |               |
| IndexOf                |                           | &check;         | &check; | &check;       |               |
| IndexOf                | comparer                  | &check;         | &check; | &check;       |               |
| IndicesOf              |                           | &check;         | &check; | &check;       |               |
| IndicesOf              | comparer                  | &check;         | &check; | &check;       |               |
| Last                   |                           | &check;         | &check; | &check;       |               |
| Last                   | predicate                 | &check;         | &check; | &check;       |               |
| LastOrDefault          |                           | &check;         | &check; | &check;       |               |
| LastOrDefault          | defaultValue              | &check;         | &check; | &check;       |               |
| LastOrDefault          | predicate                 | &check;         | &check; | &check;       |               |
| LastOrDefault          | predicate, defaultValue   | &check;         | &check; | &check;       |               |
| LongCount              |                           | &check;         | &check; | &check;       |               |
| LongCount              | predicate                 | &check;         | &check; | &check;       |               |
| Max                    |                           | &check;         | &check; | &check;       |               |
| Max                    | comparer                  | &check;         | &check; | &check;       |               |
| Max                    | selector                  | &check;         | &check; | &check;       |               |
| Max                    | selector, comparer        | &check;         | &check; | &check;       |               |
| MaxBy                  |                           | &check;         | &check; | &check;       |               |
| MaxBy                  | comparer                  | &check;         | &check; | &check;       |               |
| MaximumsBy             |                           | &check;         | &check; | &check;       |               |
| MaximumsBy             | comparer                  | &check;         | &check; | &check;       |               |
| Min                    |                           | &check;         | &check; | &check;       |               |
| Min                    | comparer                  | &check;         | &check; | &check;       |               |
| Min                    | selector                  | &check;         | &check; | &check;       |               |
| Min                    | selector, comparer        | &check;         | &check; | &check;       |               |
| MinBy                  |                           | &check;         | &check; | &check;       |               |
| MinBy                  | comparer                  | &check;         | &check; | &check;       |               |
| MinimumsBy             |                           | &check;         | &check; | &check;       |               |
| MinimumsBy             | comparer                  | &check;         | &check; | &check;       |               |
| SequenceEqual          |                           | &check;         | &check; | &check;       |               |
| SequenceEqual          | comparer                  | &check;         | &check; | &check;       |               |
| Single                 |                           | &check;         | &check; | &check;       |               |
| Single                 | predicate                 | &check;         | &check; | &check;       |               |
| SingleOrDefault        |                           | &check;         | &check; | &check;       |               |
| SingleOrDefault        | defaultValue              | &check;         | &check; | &check;       |               |
| SingleOrDefault        | predicate                 | &check;         | &check; | &check;       |               |
| SingleOrDefault        | predicate, defaultValue   | &check;         | &check; | &check;       |               |
| Slice                  |                           | &check;         | &check; | &check;       |               |
| Sum                    | decimal                   | &check;         | &check; | &check;       |               |
| Sum                    | decimal, selector         | &check;         | &check; | &check;       |               |
| Sum                    | double                    | &check;         | &check; | &check;       |               |
| Sum                    | double, selector          | &check;         | &check; | &check;       |               |
| Sum                    | float                     | &check;         | &check; | &check;       |               |
| Sum                    | float, selector           | &check;         | &check; | &check;       |               |
| Sum                    | int                       | &check;         | &check; | &check;       |               |
| Sum                    | int, selector             | &check;         | &check; | &check;       |               |
| Sum                    | long                      | &check;         | &check; | &check;       |               |
| Sum                    | long, selector            | &check;         | &check; | &check;       |               |
| Sum                    | decimal?                  | &check;         | &check; | &check;       |               |
| Sum                    | decimal?, selector        | &check;         | &check; | &check;       |               |
| Sum                    | double?                   | &check;         | &check; | &check;       |               |
| Sum                    | double?, selector         | &check;         | &check; | &check;       |               |
| Sum                    | float?                    | &check;         | &check; | &check;       |               |
| Sum                    | float?, selector          | &check;         | &check; | &check;       |               |
| Sum                    | int?                      | &check;         | &check; | &check;       |               |
| Sum                    | int?, selector            | &check;         | &check; | &check;       |               |
| Sum                    | long?                     | &check;         | &check; | &check;       |               |
| Sum                    | long?, selector           | &check;         | &check; | &check;       |               |
| ToDictionary           |                           | &check;         |         |               |               |
| ToDictionary           | comparer                  | &check;         |         |               |               |
| ToDictionary           | elementSelector           | &check;         |         |               |               |
| ToDictionary           | elementSelector, comparer | &check;         |         |               |               |
| ToHashSet              |                           | &check;         |         |               |               |
| ToHashSet              | comparer                  | &check;         |         |               |               |
| ToLookup               |                           | &check;         |         |               |               |
| ToLookup               | comparer                  | &check;         |         |               |               |
| ToLookup               | elementSelector           | &check;         |         |               |               |
| ToLookup               | elementSelector, comparer | &check;         |         |               |               |