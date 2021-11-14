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
    public class MaximumsByTests
    {
        [TestCaseSource(nameof(MaximumsByTestCases))]
        public Result MaximumsByTest<TSource, TKey>(TSource _0, TKey _1, IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return Result.Evaluate(() => Format(source.GetMaximumsBy(keySelector).Deconstruct()));
        }

        public static IEnumerable<object> MaximumsByTestCases()
        {
            yield return new TestCaseData("", "", Enumerable.Empty<string>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null keySelector throw" };
            yield return new TestCaseData("", "", new[] { "42" }, ThrowSelector<string>()) { ExpectedResult = Result.FromValue("42"), TestName = "Don't use the key selector for one value" };
            yield return new TestCaseData("", "", new[] { "42", "69" }, ThrowSelector<string>()) { ExpectedResult = Result.FromException<Exception>(), TestName = "Actually use the key selector" };

            // int
            yield return new TestCaseData(0, 0, null, IdOf<int>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null value type source throw" };
            yield return new TestCaseData(0, 0, Enumerable.Empty<int>(), IdOf<int>()) { ExpectedResult = Result.FromValue(""), TestName = "Empty value type source" };
            yield return new TestCaseData(0, 0, new[] { 42 }, IdOf<int>()) { ExpectedResult = Result.FromValue("42"), TestName = "One item source" };
            yield return new TestCaseData(0, 0, new[] { 42, 0, 1 }, IdOf<int>()) { ExpectedResult = Result.FromValue("42"), TestName = "Maximums is first" };
            yield return new TestCaseData(0, 0, new[] { 0, 42, 1 }, IdOf<int>()) { ExpectedResult = Result.FromValue("42"), TestName = "Maximums is in the middle" };
            yield return new TestCaseData(0, 0, new[] { 10, 0, 42 }, IdOf<int>()) { ExpectedResult = Result.FromValue("42"), TestName = "Maximums is last" };

            // nan. For Enumerable.Maximums, nan are ignored (while for min they aren't). See: https://codeblog.jonskeet.uk/2011/01/09/reimplementing-linq-to-objects-part-29-min-maximums/
            yield return new TestCaseData(0d, 0d, new[] { double.NaN }, IdOf<double>()) { ExpectedResult = Result.FromValue("NaN"), TestName = "One nan" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, 0 }, IdOf<double>()) { ExpectedResult = Result.FromValue("0"), TestName = "One nan at the beginning" };
            yield return new TestCaseData(0d, 0d, new[] { 0, double.NaN }, IdOf<double>()) { ExpectedResult = Result.FromValue("0"), TestName = "One nan at the end" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, double.NaN }, IdOf<double>()) { ExpectedResult = Result.FromValue("NaN|NaN"), TestName = "Two nan" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, double.NaN, 0 }, IdOf<double>()) { ExpectedResult = Result.FromValue("0"), TestName = "Two nan, value at the end" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, 0, double.NaN }, IdOf<double>()) { ExpectedResult = Result.FromValue("0"), TestName = "Two nan, value in the middle" };
            yield return new TestCaseData(0d, 0d, new[] { 0, double.NaN, double.NaN }, IdOf<double>()) { ExpectedResult = Result.FromValue("0"), TestName = "Two nan, value at the beginning" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, double.NaN, double.NaN }, IdOf<double>()) { ExpectedResult = Result.FromValue("NaN|NaN|NaN"), TestName = "Three nan" };

            // reference type
            yield return new TestCaseData("", "", null, IdOf<string>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null reference type source throw" };
            yield return new TestCaseData("", "", Enumerable.Empty<string>(), IdOf<string>()) { ExpectedResult = Result.FromValue<string?>(""), TestName = "Empty reference type source" };
            yield return new TestCaseData("", "", new[] { "X" }, IdOf<string>()) { ExpectedResult = Result.FromValue("X"), TestName = "One item source" };
            yield return new TestCaseData("", "", new[] { "A" }, ToNull<string>()) { ExpectedResult = Result.FromValue<string?>("A"), TestName = "One item to null" };
            yield return new TestCaseData("", "", new[] { null, "A" }, IdOf<string>()) { ExpectedResult = Result.FromValue<string?>("A"), TestName = "Null then value" };
            yield return new TestCaseData("", "", new string?[] { null, null }, IdOf<string>()) { ExpectedResult = Result.FromValue("|"), TestName = "Only nulls" };
            yield return new TestCaseData("", "", new[] { "X", "A", null, "B" }, IdOf<string>()) { ExpectedResult = Result.FromValue("X"), TestName = "Maximums is first" };
            yield return new TestCaseData("", "", new[] { "A", "X", null, "B" }, IdOf<string>()) { ExpectedResult = Result.FromValue("X"), TestName = "Maximums is in the middle" };
            yield return new TestCaseData("", "", new[] { "B", "A", null, "X" }, IdOf<string>()) { ExpectedResult = Result.FromValue("X"), TestName = "Maximums is last" };

            // many maximums
            var _ = new EqualsMock("_");
            var a = new EqualsMock("A");
            var b = new EqualsMock("B");
            yield return new TestCaseData(_, _, new[] { a, b }, IdOf<EqualsMock>()) { ExpectedResult = Result.FromValue("Mock A|Mock B"), TestName = "Many maximums" };
        }

        [TestCaseSource(nameof(MaximumsByWithComparerTestCases))]
        public Result MaximumsByWithComparerTest<TSource, TKey>(TSource _0, TKey _1, IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            return Result.Evaluate(() => Format(source.GetMaximumsBy(keySelector, comparer).Deconstruct()));
        }

        public static IEnumerable<object> MaximumsByWithComparerTestCases()
        {
            object c = Comparer<int>.Default;

            yield return new TestCaseData(0, 0, Enumerable.Empty<int>(), null, c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null keySelector throw" };
            yield return new TestCaseData(0, 0, Enumerable.Empty<int>(), IdOf<int>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null comparer throw" };
            yield return new TestCaseData(0, 0, new[] { 42 }, ThrowSelector<int>(), c) { ExpectedResult = Result.FromValue("42"), TestName = "Don't use the key selector for one value" };
            yield return new TestCaseData(0, 0, new[] { 42, 69 }, ThrowSelector<int>(), c) { ExpectedResult = Result.FromException<Exception>(), TestName = "Actually use the key selector" };

            // int
            yield return new TestCaseData(0, 0, null, IdOf<int>(), c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null value type source throw" };
            yield return new TestCaseData(0, 0, Enumerable.Empty<int>(), IdOf<int>(), c) { ExpectedResult = Result.FromValue(""), TestName = "Empty value type source" };
            yield return new TestCaseData(0, 0, new[] { 42 }, IdOf<int>(), c) { ExpectedResult = Result.FromValue("42"), TestName = "One item source" };
            yield return new TestCaseData(0, 0, new[] { 42, 0, 1 }, IdOf<int>(), c) { ExpectedResult = Result.FromValue("42"), TestName = "Maximums is first" };
            yield return new TestCaseData(0, 0, new[] { 0, 42, 1 }, IdOf<int>(), c) { ExpectedResult = Result.FromValue("42"), TestName = "Maximums is in the middle" };
            yield return new TestCaseData(0, 0, new[] { 10, 0, 42 }, IdOf<int>(), c) { ExpectedResult = Result.FromValue("42"), TestName = "Maximums is last" };


            // nan. For Enumerable.Maximums, nan are ignored (while for min they aren't). See: https://codeblog.jonskeet.uk/2011/01/09/reimplementing-linq-to-objects-part-29-min-maximums/
            c = Comparer<double>.Default;
            yield return new TestCaseData(0d, 0d, new[] { double.NaN }, IdOf<double>(), c) { ExpectedResult = Result.FromValue("NaN"), TestName = "One nan" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, 0 }, IdOf<double>(), c) { ExpectedResult = Result.FromValue("0"), TestName = "One nan at the beginning" };
            yield return new TestCaseData(0d, 0d, new[] { 0, double.NaN }, IdOf<double>(), c) { ExpectedResult = Result.FromValue("0"), TestName = "One nan at the end" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, double.NaN }, IdOf<double>(), c) { ExpectedResult = Result.FromValue("NaN|NaN"), TestName = "Two nan" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, double.NaN, 0 }, IdOf<double>(), c) { ExpectedResult = Result.FromValue("0"), TestName = "Two nan, value at the end" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, 0, double.NaN }, IdOf<double>(), c) { ExpectedResult = Result.FromValue("0"), TestName = "Two nan, value in the middle" };
            yield return new TestCaseData(0d, 0d, new[] { 0, double.NaN, double.NaN }, IdOf<double>(), c) { ExpectedResult = Result.FromValue("0"), TestName = "Two nan, value at the beginning" };
            yield return new TestCaseData(0d, 0d, new[] { double.NaN, double.NaN, double.NaN }, IdOf<double>(), c) { ExpectedResult = Result.FromValue("NaN|NaN|NaN"), TestName = "Three nan" };

            // reference type
            c = Comparer<string>.Default;
            yield return new TestCaseData("", "", null, IdOf<string>(), c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null reference type source throw" };
            yield return new TestCaseData("", "", Enumerable.Empty<string>(), IdOf<string>(), c) { ExpectedResult = Result.FromValue<string?>(""), TestName = "Empty reference type source" };
            yield return new TestCaseData("", "", new[] { "X" }, IdOf<string>(), c) { ExpectedResult = Result.FromValue("X"), TestName = "One item source" };
            yield return new TestCaseData("", "", new[] { "A" }, ToNull<string>(), c) { ExpectedResult = Result.FromValue<string?>("A"), TestName = "One item to null" };
            yield return new TestCaseData("", "", new[] { null, "A" }, IdOf<string>(), c) { ExpectedResult = Result.FromValue<string?>("A"), TestName = "Null then value" };
            yield return new TestCaseData("", "", new string?[] { null, null }, IdOf<string>(), c) { ExpectedResult = Result.FromValue("|"), TestName = "Only nulls" };
            yield return new TestCaseData("", "", new[] { "X", "A", null, "B" }, IdOf<string>(), c) { ExpectedResult = Result.FromValue("X"), TestName = "Maximums is first" };
            yield return new TestCaseData("", "", new[] { "A", "X", null, "B" }, IdOf<string>(), c) { ExpectedResult = Result.FromValue("X"), TestName = "Maximums is in the middle" };
            yield return new TestCaseData("", "", new[] { "B", "A", null, "X" }, IdOf<string>(), c) { ExpectedResult = Result.FromValue("X"), TestName = "Maximums is last" };

            // many maximums
            c = Comparer<EqualsMock>.Default;
            var _ = new EqualsMock("_");
            var a = new EqualsMock("A");
            var b = new EqualsMock("B");
            yield return new TestCaseData(_, _, new[] { a, b }, IdOf<EqualsMock>(), c) { ExpectedResult = Result.FromValue("Mock A|Mock B"), TestName = "Many maximums" };

            // use provided comparer the good amount of time
            var mockComparer = new Mock<IComparer<int>>();
            mockComparer.Setup(e => e.Compare(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((x, y) => y - x);
            c = mockComparer.Object;
            yield return new TestCaseData(0, 0, new[] { 42, 21, 0 }, IdOf<int>(), c) { ExpectedResult = Result.FromValue("0"), TestName = "Use provided comparer" };

            mockComparer = new Mock<IComparer<int>>();
            mockComparer.SetupSequence(e => e.Compare(It.IsAny<int>(), It.IsAny<int>())).Returns(1).Throws<Exception>();
            c = mockComparer.Object;
            yield return new TestCaseData(0, 0, new[] { 42, 21, 0 }, IdOf<int>(), c) { ExpectedResult = Result.FromException<Exception>(), TestName = "Use provided comparer at least as necessary" };
        }

        private static string Format<T>(IEnumerable<T> e) => string.Join('|', e);
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