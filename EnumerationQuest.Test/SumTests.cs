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
    public class SumTests
    {
        [TestCaseSource(nameof(SumOfDecimalTestCases))]
        public Result SumOfDecimalTest(IEnumerable<decimal> source)
        {
            return Result.Evaluate(() => source.GetSum().Deconstruct());
        }

        public static IEnumerable<object> SumOfDecimalTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<decimal>()) { ExpectedResult = Result.FromValue(0m), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (decimal)v)) { ExpectedResult = Result.FromValue(1m), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (decimal)v)) { ExpectedResult = Result.FromValue(3m), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfDoubleTestCases))]
        public Result SumOfDoubleTest(IEnumerable<double> source)
        {
            return Result.Evaluate(() => source.GetSum().Deconstruct());
        }

        public static IEnumerable<object> SumOfDoubleTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<double>()) { ExpectedResult = Result.FromValue(0d), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (double)v)) { ExpectedResult = Result.FromValue(1d), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (double)v)) { ExpectedResult = Result.FromValue(3d), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfInt32TestCases))]
        public Result SumOfInt32Test(IEnumerable<int> source)
        {
            return Result.Evaluate(() => source.GetSum().Deconstruct());
        }

        public static IEnumerable<object> SumOfInt32TestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>()) { ExpectedResult = Result.FromValue(0), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1)) { ExpectedResult = Result.FromValue(1), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2)) { ExpectedResult = Result.FromValue(3), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfInt64TestCases))]
        public Result SumOfInt64Test(IEnumerable<long> source)
        {
            return Result.Evaluate(() => source.GetSum().Deconstruct());
        }

        public static IEnumerable<object> SumOfInt64TestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<long>()) { ExpectedResult = Result.FromValue(0L), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (long)v)) { ExpectedResult = Result.FromValue(1L), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (long)v)) { ExpectedResult = Result.FromValue(3L), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfSingleTestCases))]
        public Result SumOfSingleTest(IEnumerable<float> source)
        {
            return Result.Evaluate(() => source.GetSum().Deconstruct());
        }

        public static IEnumerable<object> SumOfSingleTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<float>()) { ExpectedResult = Result.FromValue(0f), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (float)v)) { ExpectedResult = Result.FromValue(1f), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (float)v)) { ExpectedResult = Result.FromValue(3f), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfNullableDecimalTestCases))]
        public Result SumOfNullableDecimalTest(IEnumerable<decimal?> source)
        {
            return Result.Evaluate(() => source.GetSum().Deconstruct());
        }

        public static IEnumerable<object> SumOfNullableDecimalTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<decimal?>()) { ExpectedResult = Result.FromValue((decimal?)0m), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((decimal?)null, 2)) { ExpectedResult = Result.FromValue((decimal?)0m), TestName = "Null values sum" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (decimal?)v)) { ExpectedResult = Result.FromValue((decimal?)1m), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (decimal?)v)) { ExpectedResult = Result.FromValue((decimal?)3m), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfNullableDoubleTestCases))]
        public Result SumOfNullableDoubleTest(IEnumerable<double?> source)
        {
            return Result.Evaluate(() => source.GetSum().Deconstruct());
        }

        public static IEnumerable<object> SumOfNullableDoubleTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<double?>()) { ExpectedResult = Result.FromValue((double?)0d), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((double?)null, 2)) { ExpectedResult = Result.FromValue((double?)0d), TestName = "Null values sum" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (double?)v)) { ExpectedResult = Result.FromValue((double?)1d), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (double?)v)) { ExpectedResult = Result.FromValue((double?)3d), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfNullableInt32TestCases))]
        public Result SumOfNullableInt32Test(IEnumerable<int?> source)
        {
            return Result.Evaluate(() => source.GetSum().Deconstruct());
        }

        public static IEnumerable<object> SumOfNullableInt32TestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int?>()) { ExpectedResult = Result.FromValue((int?)0), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((int?)null, 2)) { ExpectedResult = Result.FromValue((int?)0), TestName = "Null values sum" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (int?)v)) { ExpectedResult = Result.FromValue((int?)1), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (int?)v)) { ExpectedResult = Result.FromValue((int?)3), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfNullableInt64TestCases))]
        public Result SumOfNullableInt64Test(IEnumerable<long?> source)
        {
            return Result.Evaluate(() => source.GetSum().Deconstruct());
        }

        public static IEnumerable<object> SumOfNullableInt64TestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<long?>()) { ExpectedResult = Result.FromValue((long?)0L), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((long?)null, 2)) { ExpectedResult = Result.FromValue((long?)0L), TestName = "Null values sum" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (long?)v)) { ExpectedResult = Result.FromValue((long?)1L), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (long?)v)) { ExpectedResult = Result.FromValue((long?)3L), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfNullableSingleTestCases))]
        public Result SumOfNullableSingleTest(IEnumerable<float?> source)
        {
            return Result.Evaluate(() => source.GetSum().Deconstruct());
        }

        public static IEnumerable<object> SumOfNullableSingleTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<float?>()) { ExpectedResult = Result.FromValue((float?)0f), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((float?)null, 2)) { ExpectedResult = Result.FromValue((float?)0f), TestName = "Null values sum" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (float?)v)) { ExpectedResult = Result.FromValue((float?)1f), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (float?)v)) { ExpectedResult = Result.FromValue((float?)3f), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfDecimalWithSelectorTestCases))]
        public Result SumOfDecimalWithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            return Result.Evaluate(() => source.GetSum(selector).Deconstruct());
        }

        public static IEnumerable<object> SumOfDecimalWithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<decimal>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<decimal>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<decimal>(), GetIdentity<decimal>()) { ExpectedResult = Result.FromValue(0m), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (decimal)v), GetIdentity<decimal>()) { ExpectedResult = Result.FromValue(1m), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (decimal)v), GetIdentity<decimal>()) { ExpectedResult = Result.FromValue(3m), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfDoubleWithSelectorTestCases))]
        public Result SumOfDoubleWithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, double> selector)
        {
            return Result.Evaluate(() => source.GetSum(selector).Deconstruct());
        }

        public static IEnumerable<object> SumOfDoubleWithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<double>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<double>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<double>(), GetIdentity<double>()) { ExpectedResult = Result.FromValue(0d), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (double)v), GetIdentity<double>()) { ExpectedResult = Result.FromValue(1d), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (double)v), GetIdentity<double>()) { ExpectedResult = Result.FromValue(3d), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfInt32WithSelectorTestCases))]
        public Result SumOfInt32WithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            return Result.Evaluate(() => source.GetSum(selector).Deconstruct());
        }

        public static IEnumerable<object> SumOfInt32WithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<int>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), GetIdentity<int>()) { ExpectedResult = Result.FromValue(0), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1), GetIdentity<int>()) { ExpectedResult = Result.FromValue(1), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2), GetIdentity<int>()) { ExpectedResult = Result.FromValue(3), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfInt64WithSelectorTestCases))]
        public Result SumOfInt64WithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, long> selector)
        {
            return Result.Evaluate(() => source.GetSum(selector).Deconstruct());
        }

        public static IEnumerable<object> SumOfInt64WithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<long>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<long>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<long>(), GetIdentity<long>()) { ExpectedResult = Result.FromValue(0L), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (long)v), GetIdentity<long>()) { ExpectedResult = Result.FromValue(1L), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (long)v), GetIdentity<long>()) { ExpectedResult = Result.FromValue(3L), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfSingleWithSelectorTestCases))]
        public Result SumOfSingleWithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            return Result.Evaluate(() => source.GetSum(selector).Deconstruct());
        }

        public static IEnumerable<object> SumOfSingleWithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<float>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<float>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<float>(), GetIdentity<float>()) { ExpectedResult = Result.FromValue(0f), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (float)v), GetIdentity<float>()) { ExpectedResult = Result.FromValue(1f), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (float)v), GetIdentity<float>()) { ExpectedResult = Result.FromValue(3f), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfNullableDecimalWithSelectorTestCases))]
        public Result SumOfNullableDecimalWithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, decimal?> selector)
        {
            return Result.Evaluate(() => source.GetSum(selector).Deconstruct());
        }

        public static IEnumerable<object> SumOfNullableDecimalWithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<decimal?>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<decimal?>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<decimal?>(), GetIdentity<decimal?>()) { ExpectedResult = Result.FromValue((decimal?)0m), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((decimal?)null, 2), GetIdentity<decimal?>()) { ExpectedResult = Result.FromValue((decimal?)0m), TestName = "Null values sum" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (decimal?)v), GetIdentity<decimal?>()) { ExpectedResult = Result.FromValue((decimal?)1m), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (decimal?)v), GetIdentity<decimal?>()) { ExpectedResult = Result.FromValue((decimal?)3m), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfNullableDoubleWithSelectorTestCases))]
        public Result SumOfNullableDoubleWithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, double?> selector)
        {
            return Result.Evaluate(() => source.GetSum(selector).Deconstruct());
        }

        public static IEnumerable<object> SumOfNullableDoubleWithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<double?>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<double?>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<double?>(), GetIdentity<double?>()) { ExpectedResult = Result.FromValue((double?)0d), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((double?)null, 2), GetIdentity<double?>()) { ExpectedResult = Result.FromValue((double?)0d), TestName = "Null values sum" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (double?)v), GetIdentity<double?>()) { ExpectedResult = Result.FromValue((double?)1d), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (double?)v), GetIdentity<double?>()) { ExpectedResult = Result.FromValue((double?)3d), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfNullableInt32WithSelectorTestCases))]
        public Result SumOfNullableInt32WithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            return Result.Evaluate(() => source.GetSum(selector).Deconstruct());
        }

        public static IEnumerable<object> SumOfNullableInt32WithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<int?>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int?>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<int?>(), GetIdentity<int?>()) { ExpectedResult = Result.FromValue((int?)0), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((int?)null, 2), GetIdentity<int?>()) { ExpectedResult = Result.FromValue((int?)0), TestName = "Null values sum" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (int?)v), GetIdentity<int?>()) { ExpectedResult = Result.FromValue((int?)1), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (int?)v), GetIdentity<int?>()) { ExpectedResult = Result.FromValue((int?)3), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfNullableInt64WithSelectorTestCases))]
        public Result SumOfNullableInt64WithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, long?> selector)
        {
            return Result.Evaluate(() => source.GetSum(selector).Deconstruct());
        }

        public static IEnumerable<object> SumOfNullableInt64WithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<long?>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<long?>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<long?>(), GetIdentity<long?>()) { ExpectedResult = Result.FromValue((long?)0L), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((long?)null, 2), GetIdentity<long?>()) { ExpectedResult = Result.FromValue((long?)0L), TestName = "Null values sum" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (long?)v), GetIdentity<long?>()) { ExpectedResult = Result.FromValue((long?)1L), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (long?)v), GetIdentity<long?>()) { ExpectedResult = Result.FromValue((long?)3L), TestName = "Two values sum" };
        }

        [TestCaseSource(nameof(SumOfNullableSingleWithSelectorTestCases))]
        public Result SumOfNullableSingleWithSelectorTest<TSource>(IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            return Result.Evaluate(() => source.GetSum(selector).Deconstruct());
        }

        public static IEnumerable<object> SumOfNullableSingleWithSelectorTestCases()
        {
            yield return new TestCaseData(null, GetIdentity<float?>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<float?>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(Enumerable.Empty<float?>(), GetIdentity<float?>()) { ExpectedResult = Result.FromValue((float?)0f), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Repeat((float?)null, 2), GetIdentity<float?>()) { ExpectedResult = Result.FromValue((float?)0f), TestName = "Null values sum" };
            yield return new TestCaseData(Enumerable.Range(1, 1).Select(v => (float?)v), GetIdentity<float?>()) { ExpectedResult = Result.FromValue((float?)1f), TestName = "One value sum" };
            yield return new TestCaseData(Enumerable.Range(1, 2).Select(v => (float?)v), GetIdentity<float?>()) { ExpectedResult = Result.FromValue((float?)3f), TestName = "Two values sum" };
        }

        private static Func<T, T> GetIdentity<T>() => v => v;
    }
}