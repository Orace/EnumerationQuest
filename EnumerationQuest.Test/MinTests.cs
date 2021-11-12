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
using Moq;
using NUnit.Framework;

namespace EnumerationQuest.Test
{
    public class MinTests
    {
        [TestCaseSource(nameof(MinTestCases))]
        public Result MinTest<TSource>(TSource _, IEnumerable<TSource> source)
        {
            return Result.Evaluate(() => source.GetMin().Deconstruct());
        }

        public static IEnumerable<object> MinTestCases()
        {
            // int
            yield return new TestCaseData(0, null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null value type source throw" };
            yield return new TestCaseData(0, Enumerable.Empty<int>()) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty value type source throw" };
            yield return new TestCaseData(0, new[] { 42 }) { ExpectedResult = Result.FromValue(42), TestName = "One item source" };
            yield return new TestCaseData(0, new[] { 42, 100, 101 }) { ExpectedResult = Result.FromValue(42), TestName = "Min is first" };
            yield return new TestCaseData(0, new[] { 100, 42, 101 }) { ExpectedResult = Result.FromValue(42), TestName = "Min is in the middle" };
            yield return new TestCaseData(0, new[] { 110, 100, 42 }) { ExpectedResult = Result.FromValue(42), TestName = "Min is last" };

            // nan. For Enumerable.Min, nan are not ignored (while for max they are). See: https://codeblog.jonskeet.uk/2011/01/09/reimplementing-linq-to-objects-part-29-min-max/
            yield return new TestCaseData(0d, new[] { double.NaN }) { ExpectedResult = Result.FromValue(double.NaN), TestName = "One nan" };
            yield return new TestCaseData(0d, new[] { double.NaN, 0 }) { ExpectedResult = Result.FromValue(double.NaN), TestName = "One nan at the beginning" };
            yield return new TestCaseData(0d, new[] { 0, double.NaN }) { ExpectedResult = Result.FromValue(double.NaN), TestName = "One nan at the end" };
            yield return new TestCaseData(0d, new[] { double.NaN, double.NaN }) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Two nan" };
            yield return new TestCaseData(0d, new[] { double.NaN, double.NaN, 0 }) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Two nan, value at the end" };
            yield return new TestCaseData(0d, new[] { double.NaN, 0, double.NaN }) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Two nan, value in the middle" };
            yield return new TestCaseData(0d, new[] { 0, double.NaN, double.NaN }) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Two nan, value at the beginning" };
            yield return new TestCaseData(0d, new[] { double.NaN, double.NaN, double.NaN }) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Three nan" };

            // reference type
            yield return new TestCaseData("", null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null reference type source throw" };
            yield return new TestCaseData("", Enumerable.Empty<string>()) { ExpectedResult = Result.FromValue<string?>(null), TestName = "Empty reference type source return null" };
            yield return new TestCaseData("", new[] { "X" }) { ExpectedResult = Result.FromValue("X"), TestName = "One item source" };
            yield return new TestCaseData("", new string?[] { null, null }) { ExpectedResult = Result.FromValue<string?>(null), TestName = "Only nulls" };
            yield return new TestCaseData("", new[] { "X", "A", null, "B" }) { ExpectedResult = Result.FromValue("A"), TestName = "Min is first" };
            yield return new TestCaseData("", new[] { "A", "X", null, "B" }) { ExpectedResult = Result.FromValue("A"), TestName = "Min is in the middle" };
            yield return new TestCaseData("", new[] { "B", "A", null, "X" }) { ExpectedResult = Result.FromValue("A"), TestName = "Min is last" };

            // many Minima
            var _ = new EqualsMock("_");
            var a = new EqualsMock("A");
            var b = new EqualsMock("B");
            yield return new TestCaseData(_, new[] { a, b }) { ExpectedResult = Result.FromValue(a), TestName = "Many Minima" };
        }
        
        [TestCaseSource(nameof(MinWithComparerTestCases))]
        public Result MinWithComparerTest<TSource>(TSource _, IEnumerable<TSource> source, IComparer<TSource> comparer)
        {
            return Result.Evaluate(() => source.GetMin(comparer).Deconstruct());
        }

        public static IEnumerable<object> MinWithComparerTestCases()
        {
            yield return new TestCaseData(0, Enumerable.Range(0, 10), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null comparer throw" };

            // int
            object c = Comparer<int>.Default;
            yield return new TestCaseData(0, null, c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null value type source throw" };
            yield return new TestCaseData(0, Enumerable.Empty<int>(), c) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty value type source throw" };
            yield return new TestCaseData(0, new[] { 42 }, c) { ExpectedResult = Result.FromValue(42), TestName = "One item source" };
            yield return new TestCaseData(0, new[] { 42, 100, 101 }, c) { ExpectedResult = Result.FromValue(42), TestName = "Min is first" };
            yield return new TestCaseData(0, new[] { 100, 42, 101 }, c) { ExpectedResult = Result.FromValue(42), TestName = "Min is in the middle" };
            yield return new TestCaseData(0, new[] { 110, 100, 42 }, c) { ExpectedResult = Result.FromValue(42), TestName = "Min is last" };

            // nan. For Enumerable.Min, nan are not ignored (while for max they are). See: https://codeblog.jonskeet.uk/2011/01/09/reimplementing-linq-to-objects-part-29-min-max/
            c = Comparer<double>.Default;
            yield return new TestCaseData(0d, new[] { double.NaN }, c) { ExpectedResult = Result.FromValue(double.NaN), TestName = "One nan" };
            yield return new TestCaseData(0d, new[] { double.NaN, 0 }, c) { ExpectedResult = Result.FromValue(double.NaN), TestName = "One nan at the beginning" };
            yield return new TestCaseData(0d, new[] { 0, double.NaN }, c) { ExpectedResult = Result.FromValue(double.NaN), TestName = "One nan at the end" };
            yield return new TestCaseData(0d, new[] { double.NaN, double.NaN }, c) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Two nan" };
            yield return new TestCaseData(0d, new[] { double.NaN, double.NaN, 0 }, c) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Two nan, value at the end" };
            yield return new TestCaseData(0d, new[] { double.NaN, 0, double.NaN }, c) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Two nan, value in the middle" };
            yield return new TestCaseData(0d, new[] { 0, double.NaN, double.NaN }, c) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Two nan, value at the beginning" };
            yield return new TestCaseData(0d, new[] { double.NaN, double.NaN, double.NaN }, c) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Three nan" };

            // reference type
            c = Comparer<string>.Default;
            yield return new TestCaseData("", null, c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null reference type source throw" };
            yield return new TestCaseData("", Enumerable.Empty<string>(), c) { ExpectedResult = Result.FromValue<string?>(null), TestName = "Empty reference type source return null" };
            yield return new TestCaseData("", new[] { "X" }, c) { ExpectedResult = Result.FromValue("X"), TestName = "One item source" };
            yield return new TestCaseData("", new string?[] { null, null }, c) { ExpectedResult = Result.FromValue<string?>(null), TestName = "Only nulls" };
            yield return new TestCaseData("", new[] { "X", "A", null, "B" }, c) { ExpectedResult = Result.FromValue("A"), TestName = "Min is first" };
            yield return new TestCaseData("", new[] { "A", "X", null, "B" }, c) { ExpectedResult = Result.FromValue("A"), TestName = "Min is in the middle" };
            yield return new TestCaseData("", new[] { "B", "A", null, "X" }, c) { ExpectedResult = Result.FromValue("A"), TestName = "Min is last" };

            // many Minima
            c = Comparer<EqualsMock>.Default;
            var _ = new EqualsMock("_");
            var a = new EqualsMock("A");
            var b = new EqualsMock("B");
            yield return new TestCaseData(_, new[] { a, b }, c) { ExpectedResult = Result.FromValue(a), TestName = "Many Minima" };

            // use provided comparer the good amount of time
            var mockComparer = new Mock<IComparer<int>>();
            mockComparer.Setup(e => e.Compare(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((x, y) => y - x);
            c = mockComparer.Object;
            yield return new TestCaseData(0, new[] { 42, 21, 0 }, c) { ExpectedResult = Result.FromValue(42), TestName = "Use provided comparer" };

            mockComparer = new Mock<IComparer<int>>();
            mockComparer.SetupSequence(e => e.Compare(It.IsAny<int>(), It.IsAny<int>())).Returns(1).Throws<Exception>();
            c = mockComparer.Object;
            yield return new TestCaseData(0, new[] { 42, 21, 0 }, c) { ExpectedResult = Result.FromException<Exception>(), TestName = "Use provided comparer at least as necessary" };
        }

        [TestCaseSource(nameof(MinWithSelectorTestCases))]
        public Result MinWithSelectorTest<TSource, TResult>(TSource _0, TResult _1, IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return Result.Evaluate(() => source.GetMin(selector).Deconstruct());
        }

        public static IEnumerable<object> MinWithSelectorTestCases()
        {
            yield return new TestCaseData(0, "", Enumerable.Range(0, 10), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };

            // int
            yield return new TestCaseData(0, "", null, Select) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null value type source throw" };
            yield return new TestCaseData(0, "", Enumerable.Empty<int>(), Select) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty value type source throw" };
            yield return new TestCaseData(0, "", new[] { 42 }, Select) { ExpectedResult = Result.FromValue("042"), TestName = "One item source" };
            yield return new TestCaseData(0, "", new[] { 42, 100, 101 }, Select) { ExpectedResult = Result.FromValue("042"), TestName = "Min is first" };
            yield return new TestCaseData(0, "", new[] { 100, 42, 101 }, Select) { ExpectedResult = Result.FromValue("042"), TestName = "Min is in the middle" };
            yield return new TestCaseData(0, "", new[] { 110, 100, 42 }, Select) { ExpectedResult = Result.FromValue("042"), TestName = "Min is last" };

            // use provided selector
            static string ThrowingSelect(int value) => value == 0 ? throw new Exception() : value.ToString("00");
            yield return new TestCaseData(0, "", new[] { 42, 21, 0 }, (Func<int, string>)ThrowingSelect) { ExpectedResult = Result.FromException<Exception>(), TestName = "Use provided comparer at least as necessary" };
        }

        private static Func<int, string> Select { get; } = value => value.ToString("000");

        private class EqualsMock : IComparable<EqualsMock>
        {
            private readonly string _name;

            public EqualsMock(string name)
            {
                _name = name;
            }

            public int CompareTo(EqualsMock? other) => other is null ? -1 : 0;

            public override string ToString() => $"Mock {_name}";
        }
    }
}