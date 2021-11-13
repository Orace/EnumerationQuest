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

namespace EnumerationQuest.Tests
{
    public class AverageTests
    {
        [TestCaseSource(nameof(AverageOfDecimalTestCases))]
        public Result AverageOfDecimalTest(IEnumerable<decimal> source)
        {
            return Result.Evaluate(() => source.GetAverage().Deconstruct());
        }

        public static IEnumerable<object> AverageOfDecimalTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<decimal>()) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (decimal)v)) { ExpectedResult = Result.FromValue(1.0m), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (decimal)v)) { ExpectedResult = Result.FromValue(1.5m), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfDoubleTestCases))]
        public Result AverageOfDoubleTest(IEnumerable<double> source)
        {
            return Result.Evaluate(() => source.GetAverage().Deconstruct());
        }

        public static IEnumerable<object> AverageOfDoubleTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<double>()) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (double)v)) { ExpectedResult = Result.FromValue(1.0d), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (double)v)) { ExpectedResult = Result.FromValue(1.5d), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfInt32TestCases))]
        public Result AverageOfInt32Test(IEnumerable<int> source)
        {
            return Result.Evaluate(() => source.GetAverage().Deconstruct());
        }

        public static IEnumerable<object> AverageOfInt32TestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>()) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1)) { ExpectedResult = Result.FromValue(1.0d), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2)) { ExpectedResult = Result.FromValue(1.5d), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfInt64TestCases))]
        public Result AverageOfInt64Test(IEnumerable<long> source)
        {
            return Result.Evaluate(() => source.GetAverage().Deconstruct());
        }

        public static IEnumerable<object> AverageOfInt64TestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<long>()) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (long)v)) { ExpectedResult = Result.FromValue(1.0d), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (long)v)) { ExpectedResult = Result.FromValue(1.5d), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfSingleTestCases))]
        public Result AverageOfSingleTest(IEnumerable<float> source)
        {
            return Result.Evaluate(() => source.GetAverage().Deconstruct());
        }

        public static IEnumerable<object> AverageOfSingleTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<float>()) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (float)v)) { ExpectedResult = Result.FromValue(1.0f), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (float)v)) { ExpectedResult = Result.FromValue(1.5f), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfNullableDecimalTestCases))]
        public Result AverageOfNullableDecimalTest(IEnumerable<decimal?> source)
        {
            return Result.Evaluate(() => source.GetAverage().Deconstruct());
        }

        public static IEnumerable<object> AverageOfNullableDecimalTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<decimal?>()) { ExpectedResult = Result.FromValue((decimal?)null), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((decimal?)null, 2)) { ExpectedResult = Result.FromValue((decimal?)null), TestName = "Null values average" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (decimal?)v)) { ExpectedResult = Result.FromValue((decimal?)1.0m), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (decimal?)v)) { ExpectedResult = Result.FromValue((decimal?)1.5m), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfNullableDoubleTestCases))]
        public Result AverageOfNullableDoubleTest(IEnumerable<double?> source)
        {
            return Result.Evaluate(() => source.GetAverage().Deconstruct());
        }

        public static IEnumerable<object> AverageOfNullableDoubleTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<double?>()) { ExpectedResult = Result.FromValue((double?)null), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((double?)null, 2)) { ExpectedResult = Result.FromValue((double?)null), TestName = "Null values average" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (double?)v)) { ExpectedResult = Result.FromValue((double?)1.0d), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (double?)v)) { ExpectedResult = Result.FromValue((double?)1.5d), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfNullableInt32TestCases))]
        public Result AverageOfNullableInt32Test(IEnumerable<int?> source)
        {
            return Result.Evaluate(() => source.GetAverage().Deconstruct());
        }

        public static IEnumerable<object> AverageOfNullableInt32TestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int?>()) { ExpectedResult = Result.FromValue((double?)null), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((int?)null, 2)) { ExpectedResult = Result.FromValue((double?)null), TestName = "Null values average" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (int?)v)) { ExpectedResult = Result.FromValue((double?)1.0d), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (int?)v)) { ExpectedResult = Result.FromValue((double?)1.5d), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfNullableInt64TestCases))]
        public Result AverageOfNullableInt64Test(IEnumerable<long?> source)
        {
            return Result.Evaluate(() => source.GetAverage().Deconstruct());
        }

        public static IEnumerable<object> AverageOfNullableInt64TestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<long?>()) { ExpectedResult = Result.FromValue((double?)null), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((long?)null, 2)) { ExpectedResult = Result.FromValue((double?)null), TestName = "Null values average" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (long?)v)) { ExpectedResult = Result.FromValue((double?)1.0d), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (long?)v)) { ExpectedResult = Result.FromValue((double?)1.5d), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfNullableSingleTestCases))]
        public Result AverageOfNullableSingleTest(IEnumerable<float?> source)
        {
            return Result.Evaluate(() => source.GetAverage().Deconstruct());
        }

        public static IEnumerable<object> AverageOfNullableSingleTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<float?>()) { ExpectedResult = Result.FromValue((float?)null), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((float?)null, 2)) { ExpectedResult = Result.FromValue((float?)null), TestName = "Null values average" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (float?)v)) { ExpectedResult = Result.FromValue((float?)1.0f), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (float?)v)) { ExpectedResult = Result.FromValue((float?)1.5f), TestName = "Two values average" };
        }
    
        [TestCaseSource(nameof(AverageOfDecimalWithSelectorTestCases))]
        public Result AverageOfDecimalWithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            return Result.Evaluate(() => source.GetAverage(selector).Deconstruct());
        }

        public static IEnumerable<object> AverageOfDecimalWithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<decimal>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<decimal>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<decimal>(), GetIdentity<decimal>()) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (decimal)v), GetIdentity<decimal>()) { ExpectedResult = Result.FromValue(1.0m), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (decimal)v), GetIdentity<decimal>()) { ExpectedResult = Result.FromValue(1.5m), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfDoubleWithSelectorTestCases))]
        public Result AverageOfDoubleWithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            return Result.Evaluate(() => source.GetAverage(selector).Deconstruct());
        }

        public static IEnumerable<object> AverageOfDoubleWithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<double>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<double>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<double>(), GetIdentity<double>()) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (double)v), GetIdentity<double>()) { ExpectedResult = Result.FromValue(1.0d), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (double)v), GetIdentity<double>()) { ExpectedResult = Result.FromValue(1.5d), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfInt32WithSelectorTestCases))]
        public Result AverageOfInt32WithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            return Result.Evaluate(() => source.GetAverage(selector).Deconstruct());
        }

        public static IEnumerable<object> AverageOfInt32WithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<int>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), GetIdentity<int>()) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1), GetIdentity<int>()) { ExpectedResult = Result.FromValue(1.0d), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2), GetIdentity<int>()) { ExpectedResult = Result.FromValue(1.5d), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfInt64WithSelectorTestCases))]
        public Result AverageOfInt64WithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            return Result.Evaluate(() => source.GetAverage(selector).Deconstruct());
        }

        public static IEnumerable<object> AverageOfInt64WithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<long>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<long>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<long>(), GetIdentity<long>()) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (long)v), GetIdentity<long>()) { ExpectedResult = Result.FromValue(1.0d), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (long)v), GetIdentity<long>()) { ExpectedResult = Result.FromValue(1.5d), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfSingleWithSelectorTestCases))]
        public Result AverageOfSingleWithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            return Result.Evaluate(() => source.GetAverage(selector).Deconstruct());
        }

        public static IEnumerable<object> AverageOfSingleWithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<float>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<float>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<float>(), GetIdentity<float>()) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (float)v), GetIdentity<float>()) { ExpectedResult = Result.FromValue(1.0f), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (float)v), GetIdentity<float>()) { ExpectedResult = Result.FromValue(1.5f), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfNullableDecimalWithSelectorTestCases))]
        public Result AverageOfNullableDecimalWithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            return Result.Evaluate(() => source.GetAverage(selector).Deconstruct());
        }

        public static IEnumerable<object> AverageOfNullableDecimalWithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<decimal?>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<decimal?>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<decimal?>(), GetIdentity<decimal?>()) { ExpectedResult = Result.FromValue((decimal?)null), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((decimal?)null, 2), GetIdentity<decimal?>()) { ExpectedResult = Result.FromValue((decimal?)null), TestName = "Null values average" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (decimal?)v), GetIdentity<decimal?>()) { ExpectedResult = Result.FromValue((decimal?)1.0m), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (decimal?)v), GetIdentity<decimal?>()) { ExpectedResult = Result.FromValue((decimal?)1.5m), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfNullableDoubleWithSelectorTestCases))]
        public Result AverageOfNullableDoubleWithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            return Result.Evaluate(() => source.GetAverage(selector).Deconstruct());
        }

        public static IEnumerable<object> AverageOfNullableDoubleWithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<double?>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<double?>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<double?>(), GetIdentity<double?>()) { ExpectedResult = Result.FromValue((double?)null), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((double?)null, 2), GetIdentity<double?>()) { ExpectedResult = Result.FromValue((double?)null), TestName = "Null values average" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (double?)v), GetIdentity<double?>()) { ExpectedResult = Result.FromValue((double?)1.0d), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (double?)v), GetIdentity<double?>()) { ExpectedResult = Result.FromValue((double?)1.5d), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfNullableInt32WithSelectorTestCases))]
        public Result AverageOfNullableInt32WithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            return Result.Evaluate(() => source.GetAverage(selector).Deconstruct());
        }

        public static IEnumerable<object> AverageOfNullableInt32WithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<int?>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int?>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<int?>(), GetIdentity<int?>()) { ExpectedResult = Result.FromValue((double?)null), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((int?)null, 2), GetIdentity<int?>()) { ExpectedResult = Result.FromValue((double?)null), TestName = "Null values average" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (int?)v), GetIdentity<int?>()) { ExpectedResult = Result.FromValue((double?)1.0d), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (int?)v), GetIdentity<int?>()) { ExpectedResult = Result.FromValue((double?)1.5d), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfNullableInt64WithSelectorTestCases))]
        public Result AverageOfNullableInt64WithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            return Result.Evaluate(() => source.GetAverage(selector).Deconstruct());
        }

        public static IEnumerable<object> AverageOfNullableInt64WithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<long?>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<long?>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<long?>(), GetIdentity<long?>()) { ExpectedResult = Result.FromValue((double?)null), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((long?)null, 2), GetIdentity<long?>()) { ExpectedResult = Result.FromValue((double?)null), TestName = "Null values average" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (long?)v), GetIdentity<long?>()) { ExpectedResult = Result.FromValue((double?)1.0d), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (long?)v), GetIdentity<long?>()) { ExpectedResult = Result.FromValue((double?)1.5d), TestName = "Two values average" };
        }

        [TestCaseSource(nameof(AverageOfNullableSingleWithSelectorTestCases))]
        public Result AverageOfNullableSingleWithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            return Result.Evaluate(() => source.GetAverage(selector).Deconstruct());
        }

        public static IEnumerable<object> AverageOfNullableSingleWithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<float?>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<float?>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<float?>(), GetIdentity<float?>()) { ExpectedResult = Result.FromValue((float?)null), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((float?)null, 2), GetIdentity<float?>()) { ExpectedResult = Result.FromValue((float?)null), TestName = "Null values average" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (float?)v), GetIdentity<float?>()) { ExpectedResult = Result.FromValue((float?)1.0f), TestName = "One value average" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (float?)v), GetIdentity<float?>()) { ExpectedResult = Result.FromValue((float?)1.5f), TestName = "Two values average" };
        }

        private static Func<T, T> GetIdentity<T>() => v => v;
    }
}