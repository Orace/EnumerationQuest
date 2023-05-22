// EnumerableQuest - Avoids multiple enumeration
// 
// Copyright 2023 Pierre Lando
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
    public class HasDuplicatesTests
    {
        [Test]
        public void HasDuplicatesWithFullConsumerTest()
        {
            var (count, five) = Enumerable.Range(0, 10).GetCount().AndHasDuplicates();
            Assert.That(count, Is.EqualTo(10));
            Assert.That(five, Is.EqualTo(false));
        }

        [TestCaseSource(nameof(HasDuplicatesTestCases))]
        public Result HasDuplicatesTest(IEnumerable<int> source)
        {
            return Result.Evaluate(() => source.GetHasDuplicates().Deconstruct());
        }

        public static IEnumerable<object> HasDuplicatesTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>()) { ExpectedResult = Result.FromValue(false), TestName = "Empty source" };
            yield return new TestCaseData(new[] { 1, 2, 3, 4 }) { ExpectedResult = Result.FromValue(false), TestName = "Without duplicates" };
            yield return new TestCaseData(new[] { 1, 2, 2, 4 }) { ExpectedResult = Result.FromValue(true), TestName = "With duplicates" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(new[] { 2, 2 })) { ExpectedResult = Result.FromValue(true), TestName = "Doesn't enumerate uselessly" };
        }

        [Test]
        public void HasDuplicatesWithComparerAndFullConsumerTest()
        {
            var mockComparer = new Mock<EqualityComparer<int>>();
            mockComparer.SetupSequence(e => e.Equals(It.IsAny<int>(), It.IsAny<int>())).Returns(false).Returns(true);
            var c = mockComparer.Object;

            var (count, five) = Enumerable.Range(0, 10).GetCount().AndHasDuplicates(c);
            Assert.That(count, Is.EqualTo(10));
            Assert.That(five, Is.EqualTo(true));
        }

        [TestCaseSource(nameof(HasDuplicatesWithComparerTestCases))]
        public Result HasDuplicatesWithComparerTest(IEnumerable<int> source, IEqualityComparer<int> comparer)
        {
            return Result.Evaluate(() => source.GetHasDuplicates(comparer).Deconstruct());
        }

        public static IEnumerable<object> HasDuplicatesWithComparerTestCases()
        {
            var c = EqualityComparer<int>.Default;
            yield return new TestCaseData(null, c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), c) { ExpectedResult = Result.FromValue(false), TestName = "Empty source" };
            yield return new TestCaseData(new[] { 1, 2, 3, 4 }, c) { ExpectedResult = Result.FromValue(false), TestName = "Without duplicates" };
            yield return new TestCaseData(new[] { 1, 2, 2, 4 }, c) { ExpectedResult = Result.FromValue(true), TestName = "With duplicates" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(new[] { 2, 2 }), c) { ExpectedResult = Result.FromValue(true), TestName = "Doesn't enumerate uselessly" };

            var mockComparer = new Mock<EqualityComparer<int>>();
            mockComparer.SetupSequence(e => e.Equals(It.IsAny<int>(), It.IsAny<int>())).Returns(false).Returns(true).Throws<Exception>();
            c = mockComparer.Object;
            yield return new TestCaseData(Enumerable.Range(1, 10), c) { ExpectedResult = Result.FromValue(true), TestName = "Use provided comparer" };

            mockComparer = new Mock<EqualityComparer<int>>();
            mockComparer.SetupSequence(e => e.Equals(It.IsAny<int>(), It.IsAny<int>())).Returns(false).Returns(false).Throws<Exception>();
            c = mockComparer.Object;
            yield return new TestCaseData(Enumerable.Range(1, 10), c) { ExpectedResult = Result.FromException<Exception>(), TestName = "Use provided comparer twice" };

            c = null;
            yield return new TestCaseData(Enumerable.Range(1, 10), c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null comparer throw" };
        }

        [Test]
        public void HasDuplicatesWithKeySelectorAndFullConsumerTest()
        {
            var (count, five) = Enumerable.Range(0, 10).GetCount().AndHasDuplicates(KeySelector);
            Assert.That(count, Is.EqualTo(10));
            Assert.That(five, Is.EqualTo(false));
        }

        [TestCaseSource(nameof(HasDuplicatesWithKeySelectorTestCases))]
        public Result HasDuplicatesWithKeySelectorTest(IEnumerable<int> source, Func<int, string> keySelector)
        {
            return Result.Evaluate(() => source.GetHasDuplicates(keySelector).Deconstruct());
        }

        public static IEnumerable<object> HasDuplicatesWithKeySelectorTestCases()
        {
            var ks = new Func<int, string>(KeySelector);

            yield return new TestCaseData(null, ks) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(new[] { 1, 2, 3, 4 }, null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null key selector throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), ks) { ExpectedResult = Result.FromValue(false), TestName = "Empty source" };
            yield return new TestCaseData(new[] { 1, 2, 3, 4 }, ks) { ExpectedResult = Result.FromValue(false), TestName = "Without duplicates" };
            yield return new TestCaseData(new[] { 1, 2, 2, 4 }, ks) { ExpectedResult = Result.FromValue(true), TestName = "With duplicates" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(new[] { 2, 2 }), ks) { ExpectedResult = Result.FromValue(true), TestName = "Doesn't enumerate uselessly" };
        }

        [Test]
        public void HasDuplicatesWithKeySelectorAndComparerAndFullConsumerTest()
        {
            var mockComparer = new Mock<EqualityComparer<string>>();
            mockComparer.SetupSequence(e => e.Equals(It.IsAny<string>(), It.IsAny<string>())).Returns(false).Returns(true);
            var c = mockComparer.Object;

            var (count, five) = Enumerable.Range(0, 10).GetCount().AndHasDuplicates(KeySelector, c);
            Assert.That(count, Is.EqualTo(10));
            Assert.That(five, Is.EqualTo(true));
        }

        [TestCaseSource(nameof(HasDuplicatesWithKeySelectorAndComparerTestCases))]
        public Result HasDuplicatesWithKeySelectorAndComparerTest(IEnumerable<int> source, Func<int, string> keySelector, IEqualityComparer<string> comparer)
        {
            return Result.Evaluate(() => source.GetHasDuplicates(keySelector, comparer).Deconstruct());
        }

        public static IEnumerable<object> HasDuplicatesWithKeySelectorAndComparerTestCases()
        {
            var c = EqualityComparer<string>.Default;
            var ks = new Func<int, string>(KeySelector);

            yield return new TestCaseData(null, ks, c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), ks, c) { ExpectedResult = Result.FromValue(false), TestName = "Empty source" };
            yield return new TestCaseData(new[] { 1, 2, 3, 4 }, ks, c) { ExpectedResult = Result.FromValue(false), TestName = "Without duplicates" };
            yield return new TestCaseData(new[] { 1, 2, 2, 4 }, ks, c) { ExpectedResult = Result.FromValue(true), TestName = "With duplicates" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(new[] { 2, 2 }), ks, c) { ExpectedResult = Result.FromValue(true), TestName = "Doesn't enumerate uselessly" };

            var mockComparer = new Mock<EqualityComparer<string>>();
            mockComparer.SetupSequence(e => e.Equals(It.IsAny<string>(), It.IsAny<string>())).Returns(false).Returns(true).Throws<Exception>();
            c = mockComparer.Object;
            yield return new TestCaseData(Enumerable.Range(1, 10), ks, c) { ExpectedResult = Result.FromValue(true), TestName = "Use provided comparer" };

            mockComparer = new Mock<EqualityComparer<string>>();
            mockComparer.SetupSequence(e => e.Equals(It.IsAny<string>(), It.IsAny<string>())).Returns(false).Returns(false).Throws<Exception>();
            c = mockComparer.Object;
            yield return new TestCaseData(Enumerable.Range(1, 10), ks, c) { ExpectedResult = Result.FromException<Exception>(), TestName = "Use provided comparer twice" };

            c = null;
            yield return new TestCaseData(Enumerable.Range(1, 10), ks, c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null comparer throw" };

            c = EqualityComparer<string>.Default;
            ks = null;
            yield return new TestCaseData(Enumerable.Range(1, 10), ks, c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null key selector throw" };
        }

        private static IEnumerable<T> GetYieldThenThrowEnumerable<T>(IEnumerable<T> source)
        {
            foreach (var v in source)
                yield return v;

            throw new Exception();
        }

        private static string KeySelector(int i) => i.ToString();
    }
}