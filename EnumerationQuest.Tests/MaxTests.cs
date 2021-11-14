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

namespace EnumerationQuest.Tests
{
    public class MaxTests
    {
        [TestCaseSource(nameof(MaxTestCases))]
        public Result MaxTest<TSource>(TSource _, IEnumerable<TSource> source)
        {
            return Result.Evaluate(() => source.GetMax().Deconstruct());
        }

        public static IEnumerable<object> MaxTestCases()
        {
            // int
            yield return new TestCaseData(0, null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null value type source throw" };
            yield return new TestCaseData(0, Enumerable.Empty<int>()) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty value type source throw" };
            yield return new TestCaseData(0, new[] { 42 }) { ExpectedResult = Result.FromValue(42), TestName = "One item source" };
            yield return new TestCaseData(0, new[] { 42, 0, 1 }) { ExpectedResult = Result.FromValue(42), TestName = "Max is first" };
            yield return new TestCaseData(0, new[] { 0, 42, 1 }) { ExpectedResult = Result.FromValue(42), TestName = "Max is in the middle" };
            yield return new TestCaseData(0, new[] { 10, 0, 42 }) { ExpectedResult = Result.FromValue(42), TestName = "Max is last" };

            // nan. For Enumerable.Max, nan are ignored (while for min they aren't). See: https://codeblog.jonskeet.uk/2011/01/09/reimplementing-linq-to-objects-part-29-min-max/
            yield return new TestCaseData(0d, new[] { double.NaN }) { ExpectedResult = Result.FromValue(double.NaN), TestName = "One nan" };
            yield return new TestCaseData(0d, new[] { double.NaN, 0 }) { ExpectedResult = Result.FromValue(0d), TestName = "One nan at the beginning" };
            yield return new TestCaseData(0d, new[] { 0, double.NaN }) { ExpectedResult = Result.FromValue(0d), TestName = "One nan at the end" };
            yield return new TestCaseData(0d, new[] { double.NaN, double.NaN }) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Two nan" };
            yield return new TestCaseData(0d, new[] { double.NaN, double.NaN, 0 }) { ExpectedResult = Result.FromValue(0d), TestName = "Two nan, value at the end" };
            yield return new TestCaseData(0d, new[] { double.NaN, 0, double.NaN }) { ExpectedResult = Result.FromValue(0d), TestName = "Two nan, value in the middle" };
            yield return new TestCaseData(0d, new[] { 0, double.NaN, double.NaN }) { ExpectedResult = Result.FromValue(0d), TestName = "Two nan, value at the beginning" };
            yield return new TestCaseData(0d, new[] { double.NaN, double.NaN, double.NaN }) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Three nan" };

            // reference type
            yield return new TestCaseData("", null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null reference type source throw" };
            yield return new TestCaseData("", Enumerable.Empty<string>()) { ExpectedResult = Result.FromValue<string?>(null), TestName = "Empty reference type source return null" };
            yield return new TestCaseData("", new[] { "X" }) { ExpectedResult = Result.FromValue("X"), TestName = "One item source" };
            yield return new TestCaseData("", new string?[] { null, null }) { ExpectedResult = Result.FromValue<string?>(null), TestName = "Only nulls" };
            yield return new TestCaseData("", new[] { "X", "A", null, "B" }) { ExpectedResult = Result.FromValue("X"), TestName = "Max is first" };
            yield return new TestCaseData("", new[] { "A", "X", null, "B" }) { ExpectedResult = Result.FromValue("X"), TestName = "Max is in the middle" };
            yield return new TestCaseData("", new[] { "B", "A", null, "X" }) { ExpectedResult = Result.FromValue("X"), TestName = "Max is last" };

            // many maxima
            var _ = new EqualsMock("_");
            var a = new EqualsMock("A");
            var b = new EqualsMock("B");
            yield return new TestCaseData(_, new[] { a, b }) { ExpectedResult = Result.FromValue(a), TestName = "Many maxima" };
        }

        [TestCaseSource(nameof(MaxWithComparerTestCases))]
        public Result MaxWithComparerTest<TSource>(TSource _, IEnumerable<TSource> source, IComparer<TSource> comparer)
        {
            return Result.Evaluate(() => source.GetMax(comparer).Deconstruct());
        }

        public static IEnumerable<object> MaxWithComparerTestCases()
        {
            yield return new TestCaseData(0, Enumerable.Range(0, 10), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null comparer throw" };

            // int
            object c = Comparer<int>.Default;
            yield return new TestCaseData(0, null, c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null value type source throw" };
            yield return new TestCaseData(0, Enumerable.Empty<int>(), c) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty value type source throw" };
            yield return new TestCaseData(0, new[] { 42 }, c) { ExpectedResult = Result.FromValue(42), TestName = "One item source" };
            yield return new TestCaseData(0, new[] { 42, 0, 1 }, c) { ExpectedResult = Result.FromValue(42), TestName = "Max is first" };
            yield return new TestCaseData(0, new[] { 0, 42, 1 }, c) { ExpectedResult = Result.FromValue(42), TestName = "Max is in the middle" };
            yield return new TestCaseData(0, new[] { 10, 0, 42 }, c) { ExpectedResult = Result.FromValue(42), TestName = "Max is last" };


            // nan. For Enumerable.Max, nan are ignored (while for min they aren't). See: https://codeblog.jonskeet.uk/2011/01/09/reimplementing-linq-to-objects-part-29-min-max/
            c = Comparer<double>.Default;
            yield return new TestCaseData(0d, new[] { double.NaN }, c) { ExpectedResult = Result.FromValue(double.NaN), TestName = "One nan" };
            yield return new TestCaseData(0d, new[] { double.NaN, 0 }, c) { ExpectedResult = Result.FromValue(0d), TestName = "One nan at the beginning" };
            yield return new TestCaseData(0d, new[] { 0, double.NaN }, c) { ExpectedResult = Result.FromValue(0d), TestName = "One nan at the end" };
            yield return new TestCaseData(0d, new[] { double.NaN, double.NaN }, c) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Two nan" };
            yield return new TestCaseData(0d, new[] { double.NaN, double.NaN, 0 }, c) { ExpectedResult = Result.FromValue(0d), TestName = "Two nan, value at the end" };
            yield return new TestCaseData(0d, new[] { double.NaN, 0, double.NaN }, c) { ExpectedResult = Result.FromValue(0d), TestName = "Two nan, value in the middle" };
            yield return new TestCaseData(0d, new[] { 0, double.NaN, double.NaN }, c) { ExpectedResult = Result.FromValue(0d), TestName = "Two nan, value at the beginning" };
            yield return new TestCaseData(0d, new[] { double.NaN, double.NaN, double.NaN }, c) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Three nan" };

            // reference type
            c = Comparer<string>.Default;
            yield return new TestCaseData("", null, c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null reference type source throw" };
            yield return new TestCaseData("", Enumerable.Empty<string>(), c) { ExpectedResult = Result.FromValue<string?>(null), TestName = "Empty reference type source return null" };
            yield return new TestCaseData("", new[] { "X" }, c) { ExpectedResult = Result.FromValue("X"), TestName = "One item source" };
            yield return new TestCaseData("", new string?[] { null, null }, c) { ExpectedResult = Result.FromValue<string?>(null), TestName = "Only nulls" };
            yield return new TestCaseData("", new[] { "X", "A", null, "B" }, c) { ExpectedResult = Result.FromValue("X"), TestName = "Max is first" };
            yield return new TestCaseData("", new[] { "A", "X", null, "B" }, c) { ExpectedResult = Result.FromValue("X"), TestName = "Max is in the middle" };
            yield return new TestCaseData("", new[] { "B", "A", null, "X" }, c) { ExpectedResult = Result.FromValue("X"), TestName = "Max is last" };

            // many maxima
            c = Comparer<EqualsMock>.Default;
            var _ = new EqualsMock("_");
            var a = new EqualsMock("A");
            var b = new EqualsMock("B");
            yield return new TestCaseData(_, new[] { a, b }, c) { ExpectedResult = Result.FromValue(a), TestName = "Many maxima" };

            // use provided comparer the good amount of time
            var mockComparer = new Mock<IComparer<int>>();
            mockComparer.Setup(e => e.Compare(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((x, y) => y - x);
            c = mockComparer.Object;
            yield return new TestCaseData(0, new[]{42, 21, 0}, c) { ExpectedResult = Result.FromValue(0), TestName = "Use provided comparer" };

            mockComparer = new Mock<IComparer<int>>();
            mockComparer.SetupSequence(e => e.Compare(It.IsAny<int>(), It.IsAny<int>())).Returns(1).Throws<Exception>();
            c = mockComparer.Object;
            yield return new TestCaseData(0, new[] { 42, 21, 0 }, c) { ExpectedResult = Result.FromException<Exception>(), TestName = "Use provided comparer at least as necessary" };
        }

        [TestCaseSource(nameof(MaxWithSelectorTestCases))]
        public Result MaxTest<TSource, TResult>(TSource _0, TResult _1, IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return Result.Evaluate(() => source.GetMax(selector).Deconstruct());
        }

        public static IEnumerable<object> MaxWithSelectorTestCases()
        {
            yield return new TestCaseData(0, 0, Enumerable.Empty<int>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(0, 0, new[] { 42 }, ThrowSelector<int>()) { ExpectedResult = Result.FromException<Exception>(), TestName = "Actually use the selector" };

            // int
            yield return new TestCaseData(0, 0, null, IdOf<int>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null value type source throw" };
            yield return new TestCaseData(0, 0, Enumerable.Empty<int>(), IdOf<int>()) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty value type source throw" };
            yield return new TestCaseData(0, 0, new[] { 42 }, IdOf<int>()) { ExpectedResult = Result.FromValue(42), TestName = "One item source" };
            yield return new TestCaseData(0, 0, new[] { 42, 0, 1 }, IdOf<int>()) { ExpectedResult = Result.FromValue(42), TestName = "Max is first" };
            yield return new TestCaseData(0, 0, new[] { 0, 42, 1 }, IdOf<int>()) { ExpectedResult = Result.FromValue(42), TestName = "Max is in the middle" };
            yield return new TestCaseData(0, 0, new[] { 10, 0, 42 }, IdOf<int>()) { ExpectedResult = Result.FromValue(42), TestName = "Max is last" };

            // nan. For Enumerable.Max, nan are ignored (while for min they aren't). See: https://codeblog.jonskeet.uk/2011/01/09/reimplementing-linq-to-objects-part-29-min-max/
            yield return new TestCaseData(0d, 0d, new[] { double.NaN }, IdOf<double>()) { ExpectedResult = Result.FromValue(double.NaN), TestName = "One nan" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, 0 }, IdOf<double>()) { ExpectedResult = Result.FromValue(0d), TestName = "One nan at the beginning" };
            yield return new TestCaseData(0d, 0d, new[] { 0, double.NaN }, IdOf<double>()) { ExpectedResult = Result.FromValue(0d), TestName = "One nan at the end" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, double.NaN }, IdOf<double>()) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Two nan" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, double.NaN, 0 }, IdOf<double>()) { ExpectedResult = Result.FromValue(0d), TestName = "Two nan, value at the end" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, 0, double.NaN }, IdOf<double>()) { ExpectedResult = Result.FromValue(0d), TestName = "Two nan, value in the middle" };
            yield return new TestCaseData(0d, 0d, new[] { 0, double.NaN, double.NaN }, IdOf<double>()) { ExpectedResult = Result.FromValue(0d), TestName = "Two nan, value at the beginning" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, double.NaN, double.NaN }, IdOf<double>()) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Three nan" };

            // reference type
            yield return new TestCaseData("", "", null, IdOf<string>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null reference type source throw" };
            yield return new TestCaseData("", "", Enumerable.Empty<string>(), IdOf<string>()) { ExpectedResult = Result.FromValue<string?>(null), TestName = "Empty reference type source return null" };
            yield return new TestCaseData("", "", new[] { "X" }, IdOf<string>()) { ExpectedResult = Result.FromValue("X"), TestName = "One item source" };
            yield return new TestCaseData("", "", new[] { "A" }, ToNull<string>()) { ExpectedResult = Result.FromValue<string?>(null), TestName = "One item to null" };
            yield return new TestCaseData("", "", new[] { null, "A" }, IdOf<string>()) { ExpectedResult = Result.FromValue<string?>("A"), TestName = "Null then value" };
            yield return new TestCaseData("", "", new string?[] { null, null }, IdOf<string>()) { ExpectedResult = Result.FromValue<string?>(null), TestName = "Only nulls" };
            yield return new TestCaseData("", "", new[] { "X", "A", null, "B" }, IdOf<string>()) { ExpectedResult = Result.FromValue("X"), TestName = "Max is first" };
            yield return new TestCaseData("", "", new[] { "A", "X", null, "B" }, IdOf<string>()) { ExpectedResult = Result.FromValue("X"), TestName = "Max is in the middle" };
            yield return new TestCaseData("", "", new[] { "B", "A", null, "X" }, IdOf<string>()) { ExpectedResult = Result.FromValue("X"), TestName = "Max is last" };

            // many maxima
            var _ = new EqualsMock("_");
            var a = new EqualsMock("A");
            var b = new EqualsMock("B");
            yield return new TestCaseData(_, _, new[] { a, b }, IdOf<EqualsMock>()) { ExpectedResult = Result.FromValue(a), TestName = "Many maxima" };
        }

        [TestCaseSource(nameof(MaxWithSelectorAndComparerTestCases))]
        public Result MaxWithComparerTest<TSource, TResult>(TSource _0, TResult _1, IEnumerable<TSource> source, Func<TSource, TResult> selector, IComparer<TResult> comparer)
        {
            return Result.Evaluate(() => source.GetMax(selector, comparer).Deconstruct());
        }

        public static IEnumerable<object> MaxWithSelectorAndComparerTestCases()
        {
            object c = Comparer<int>.Default;

            yield return new TestCaseData(0, 0, Enumerable.Range(0, 10), null, c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null selector throw" };
            yield return new TestCaseData(0, 0, Enumerable.Range(0, 10), IdOf<int>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null comparer throw" };
            yield return new TestCaseData(0, 0, new[] { 42 }, ThrowSelector<int>(), c) { ExpectedResult = Result.FromException<Exception>(), TestName = "Actually use the selector" };

            // int
            yield return new TestCaseData(0, 0, null, IdOf<int>(), c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null value type source throw" };
            yield return new TestCaseData(0, 0, Enumerable.Empty<int>(), IdOf<int>(), c) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty value type source throw" };
            yield return new TestCaseData(0, 0, new[] { 42 }, IdOf<int>(), c) { ExpectedResult = Result.FromValue(42), TestName = "One item source" };
            yield return new TestCaseData(0, 0, new[] { 42, 0, 1 }, IdOf<int>(), c) { ExpectedResult = Result.FromValue(42), TestName = "Max is first" };
            yield return new TestCaseData(0, 0, new[] { 0, 42, 1 }, IdOf<int>(), c) { ExpectedResult = Result.FromValue(42), TestName = "Max is in the middle" };
            yield return new TestCaseData(0, 0, new[] { 10, 0, 42 }, IdOf<int>(), c) { ExpectedResult = Result.FromValue(42), TestName = "Max is last" };


            // nan. For Enumerable.Max, nan are ignored (while for min they aren't). See: https://codeblog.jonskeet.uk/2011/01/09/reimplementing-linq-to-objects-part-29-min-max/
            c = Comparer<double>.Default;
            yield return new TestCaseData(0d, 0d, new[] { double.NaN }, IdOf<double>(), c) { ExpectedResult = Result.FromValue(double.NaN), TestName = "One nan" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, 0 }, IdOf<double>(), c) { ExpectedResult = Result.FromValue(0d), TestName = "One nan at the beginning" };
            yield return new TestCaseData(0d, 0d, new[] { 0, double.NaN }, IdOf<double>(), c) { ExpectedResult = Result.FromValue(0d), TestName = "One nan at the end" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, double.NaN }, IdOf<double>(), c) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Two nan" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, double.NaN, 0 }, IdOf<double>(), c) { ExpectedResult = Result.FromValue(0d), TestName = "Two nan, value at the end" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, 0, double.NaN }, IdOf<double>(), c) { ExpectedResult = Result.FromValue(0d), TestName = "Two nan, value in the middle" };
            yield return new TestCaseData(0d, 0d, new[] { 0, double.NaN, double.NaN }, IdOf<double>(), c) { ExpectedResult = Result.FromValue(0d), TestName = "Two nan, value at the beginning" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, double.NaN, double.NaN }, IdOf<double>(), c) { ExpectedResult = Result.FromValue(double.NaN), TestName = "Three nan" };

            // reference type
            c = Comparer<string>.Default;
            yield return new TestCaseData("", "", null, IdOf<string>(), c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null reference type source throw" };
            yield return new TestCaseData("", "", Enumerable.Empty<string>(), IdOf<string>(), c) { ExpectedResult = Result.FromValue<string?>(null), TestName = "Empty reference type source return null" };
            yield return new TestCaseData("", "", new[] { "X" }, IdOf<string>(), c) { ExpectedResult = Result.FromValue("X"), TestName = "One item source" };
            yield return new TestCaseData("", "", new[] { "A" }, ToNull<string>(), c) { ExpectedResult = Result.FromValue<string?>(null), TestName = "One item to null" };
            yield return new TestCaseData("", "", new[] { null, "A" }, IdOf<string>(), c) { ExpectedResult = Result.FromValue<string?>("A"), TestName = "Null then value" };
            yield return new TestCaseData("", "", new string?[] { null, null }, IdOf<string>(), c) { ExpectedResult = Result.FromValue<string?>(null), TestName = "Only nulls" };
            yield return new TestCaseData("", "", new[] { "X", "A", null, "B" }, IdOf<string>(), c) { ExpectedResult = Result.FromValue("X"), TestName = "Max is first" };
            yield return new TestCaseData("", "", new[] { "A", "X", null, "B" }, IdOf<string>(), c) { ExpectedResult = Result.FromValue("X"), TestName = "Max is in the middle" };
            yield return new TestCaseData("", "", new[] { "B", "A", null, "X" }, IdOf<string>(), c) { ExpectedResult = Result.FromValue("X"), TestName = "Max is last" };

            // many maxima
            c = Comparer<EqualsMock>.Default;
            var _ = new EqualsMock("_");
            var a = new EqualsMock("A");
            var b = new EqualsMock("B");
            yield return new TestCaseData(_, _, new[] { a, b }, IdOf<EqualsMock>(), c) { ExpectedResult = Result.FromValue(a), TestName = "Many maxima" };

            // use provided comparer the good amount of time
            var mockComparer = new Mock<IComparer<int>>();
            mockComparer.Setup(e => e.Compare(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((x, y) => y - x);
            c = mockComparer.Object;
            yield return new TestCaseData(0, 0, new[] { 42, 21, 0 }, IdOf<int>(), c) { ExpectedResult = Result.FromValue(0), TestName = "Use provided comparer" };

            mockComparer = new Mock<IComparer<int>>();
            mockComparer.SetupSequence(e => e.Compare(It.IsAny<int>(), It.IsAny<int>())).Returns(1).Throws<Exception>();
            c = mockComparer.Object;
            yield return new TestCaseData(0, 0, new[] { 42, 21, 0 }, IdOf<int>(), c) { ExpectedResult = Result.FromException<Exception>(), TestName = "Use provided comparer at least as necessary" };
        }

        private static Func<T, T> IdOf<T>() => t => t;
        private static Func<T, T> ThrowSelector<T>() => _ => throw new Exception();
        private static Func<T, T?> ToNull<T>() where T : class => _ => null;

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