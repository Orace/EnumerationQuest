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
using NUnit.Framework;

namespace EnumerationQuest.Test
{
    public class AggregateTests
    {
        [TestCaseSource(nameof(AggregateTestCases))]
        public Result AggregateTest<TSource>(IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
        {
            return Result.Evaluate(() => source.GetAggregate(func).Deconstruct());
        }

        public static IEnumerable<object> AggregateTestCases()
        {
            yield return new TestCaseData(null, IntSum) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null func throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), IntSum) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 100), IntSum) { ExpectedResult = Result.FromValue(5050), TestName = "Simple int sum" };
            yield return new TestCaseData(Enumerable.Repeat("|", 10), StringConcat) { ExpectedResult = Result.FromValue(new string('|', 10)), TestName = "Simple string concatenation" };
        }

        [TestCaseSource(nameof(AggregateWithSeedTestCases))]
        public Result AggregateWithSeedTest<TSource>(IEnumerable<TSource> source, TSource seed, Func<TSource, TSource, TSource> func)
        {
            return Result.Evaluate(() => source.GetAggregate(seed, func).Deconstruct());
        }

        public static IEnumerable<object> AggregateWithSeedTestCases()
        {
            yield return new TestCaseData(null, 42, IntSum) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), 42, null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null func throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), 42, IntSum) { ExpectedResult = Result.FromValue(42), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Range(1, 100), 42, IntSum) { ExpectedResult = Result.FromValue(5092), TestName = "Simple int sum" };
            yield return new TestCaseData(Enumerable.Repeat("|", 10), "@", StringConcat) { ExpectedResult = Result.FromValue($"@{new string('|', 10)}"), TestName = "Simple string concatenation" };
        }

        [TestCaseSource(nameof(AggregateWithSeedAndResultSelectorTestCases))]
        public Result AggregateWithSeedAndResultSelectorTest<TSource>(IEnumerable<TSource> source, TSource seed, Func<TSource, TSource, TSource> func, Func<TSource, TSource> resultSelector)
        {
            return Result.Evaluate(() => source.GetAggregate(seed, func, resultSelector).Deconstruct());
        }

        public static IEnumerable<object> AggregateWithSeedAndResultSelectorTestCases()
        {
            yield return new TestCaseData(null, 42, IntSum, GetIdentity<int>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), 42, null, GetIdentity<int>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null func throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), 42, IntSum, null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null result selector throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), 42, IntSum, GetIdentity<int>()) { ExpectedResult = Result.FromValue(42), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Range(1, 100), 42, IntSum, GetIdentity<int>()) { ExpectedResult = Result.FromValue(5092), TestName = "Simple int sum" };
            yield return new TestCaseData(Enumerable.Repeat("|", 10), "@", StringConcat, GetIdentity<string>()) { ExpectedResult = Result.FromValue($"@{new string('|', 10)}"), TestName = "Simple string concatenation" };
        }

        private static Func<T, T> GetIdentity<T>() => v => v;
        private static Func<int, int, int> IntSum => (a, b) => a + b;
        private static Func<string, string, string> StringConcat => (a, b) => a + b;
    }
}