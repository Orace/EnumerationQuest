// EnumerableQuest - Avoids multiple enumeration
// 
// Copyright 2021 Pierre Lando
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//    http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using Castle.DynamicProxy.Internal;
using NUnit.Framework;

namespace EnumerationQuest.Test
{
    public class LonelyConsumerTests
    {
        [TestCaseSource(typeof(CaseProvider), nameof(CaseProvider.GetTestCases))]
        public void LonelyConsumerIsConsistentTest<TSource, TResult>(IReadOnlyList<TSource> source,
                                                                     Func<IEnumerable<TSource>, TResult?> actualFunc,
                                                                     Func<IEnumerable<TSource>, TResult?> expectedFunc)
        {
            var actualResult = Result.Evaluate(() => actualFunc(source));
            var expectedResult = Result.Evaluate(() => expectedFunc(source));

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        private static class CaseProvider
        {
            private static readonly IReadOnlyList<TestCaseDataSet> TestCaseDataSets = new TestCaseDataSet[]
            {
                TestCaseDataSet.From<int>(),
                TestCaseDataSet.From(0),
                TestCaseDataSet.From(-1, 0, 1),
                TestCaseDataSet.From(1, 0, -1),
                TestCaseDataSet.From(1, 0, 1),
                TestCaseDataSet.From(0, 1, 0),
                TestCaseDataSet.From<int?>(),
                TestCaseDataSet.From<int?>(0),
                TestCaseDataSet.From(default(int?)),
                TestCaseDataSet.From<int?>(null, null, null),
                TestCaseDataSet.From<int?>(null, -1, 0, 1),
                TestCaseDataSet.From<int?>(1, 0, -1, null),
                TestCaseDataSet.From<int?>(1, null, 0, 1),
                TestCaseDataSet.From<int?>(0, null, 1, 0),
                TestCaseDataSet.From<double>(),
                TestCaseDataSet.From(double.NaN),
                TestCaseDataSet.From(double.NaN, 0),
                TestCaseDataSet.From(0, double.NaN),
                TestCaseDataSet.From(double.NaN, double.NaN),
                TestCaseDataSet.From(0, double.NaN, double.NaN),
                TestCaseDataSet.From(double.NaN, 0, double.NaN),
                TestCaseDataSet.From(double.NaN, double.NaN, 0),
                TestCaseDataSet.From<string>(),
                TestCaseDataSet.From(default(string)),
                TestCaseDataSet.From("A"),
                TestCaseDataSet.From("A", "B", "C"),
                TestCaseDataSet.From("C", "B", "A"),
                TestCaseDataSet.From<string?>(null, "A", "B", "C"),
                TestCaseDataSet.From<string?>("C", "B", null, "A"),
                TestCaseDataSet.From(new EqualsMock("A", -1), new EqualsMock("B", -1), new EqualsMock("C", -1)),
                TestCaseDataSet.From(new EqualsMock("A", 0), new EqualsMock("B", 0), new EqualsMock("C", 0)),
                TestCaseDataSet.From(new EqualsMock("A", 1), new EqualsMock("B", 1), new EqualsMock("C", 1))
            };

            public static IEnumerable<object> GetTestCases()
            {
                return TestCaseDataSets.SelectMany(s => s.GetTestCases());
            }
        }

        private class EqualsMock : IComparable<EqualsMock>
        {
            private readonly string _name;
            private readonly int _compareResult;

            public EqualsMock(string name, int compareResult)
            {
                _name = name;
                _compareResult = compareResult;
            }

            public int CompareTo(EqualsMock? other) => other is null ? -1 : _compareResult;

            public override string ToString() => $"Mock {_name}({_compareResult})";
        }

        private abstract class TestCaseDataSet
        {
            public static TestCaseDataSet<TSource> From<TSource>(params TSource[] values)
            {
                return new TestCaseDataSet<TSource>(values);
            }

            public abstract IEnumerable<object> GetTestCases();
        }

        private class TestCaseDataSet<TSource> : TestCaseDataSet
        {
            private readonly IReadOnlyList<(string, Func<IEnumerable<TSource>, TSource?>, Func<IEnumerable<TSource>, TSource?>)> _methods;
            private readonly IReadOnlyList<TSource> _values;

            public TestCaseDataSet(IReadOnlyList<TSource> values)
            {
                _values = values;
                _methods = new[]
                {
                    (nameof(EnumerationRequests.GetFirst), Get(EnumerationRequests.GetFirst), Get(Enumerable.First)),
                    (nameof(EnumerationRequests.GetFirstOrDefault), Get(EnumerationRequests.GetFirstOrDefault), Get(Enumerable.FirstOrDefault)),
                    (nameof(EnumerationRequests.GetLast), Get(EnumerationRequests.GetLast), Get(Enumerable.Last)),
                    (nameof(EnumerationRequests.GetLastOrDefault), Get(EnumerationRequests.GetLastOrDefault), Get(Enumerable.LastOrDefault)),
                    (nameof(EnumerationRequests.GetMax), Get(EnumerationRequests.GetMax), Get(Enumerable.Max)),
                    (nameof(EnumerationRequests.GetMin), Get(EnumerationRequests.GetMin), Get(Enumerable.Min)),
                    (nameof(EnumerationRequests.GetSingle), Get(EnumerationRequests.GetSingle), Get(Enumerable.Single)),
                    (nameof(EnumerationRequests.GetSingleOrDefault), Get(EnumerationRequests.GetSingleOrDefault), Get(Enumerable.SingleOrDefault)),
                };
            }

            public override IEnumerable<object> GetTestCases()
            {
                var items = $"({string.Join(", ", _values.Select(v => v?.ToString() ?? "null"))})";
                return _methods.Select(method => new TestCaseData(_values, method.Item2, method.Item3) { TestName = $"{method.Item1} on {items} of type {GetTypeName(typeof(TSource))}" });
            }

            private static string GetTypeName(Type type)
            {
                return type.IsNullableType() ? $"{Nullable.GetUnderlyingType(type)?.Name}?" : type.Name;
            }

            private static Func<IEnumerable<TSource>, TResult?> Get<TResult>(Func<IEnumerable<TSource>, TResult?> func)
            {
                return func;
            }

            private static Func<IEnumerable<TSource>, TResult?> Get<TResult>(Func<IEnumerable<TSource>, EnumerationRequests1<TSource, TResult>> func)
            {
                return e => func(e).Deconstruct();
            }
        }
    }
}