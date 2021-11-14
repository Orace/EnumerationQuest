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
    public class FirstOrDefaultTests
    {
        [Test]
        public void FirstOrDefaultWithFullConsumerTest()
        {
            var (count, first) = Enumerable.Range(0, 10).GetCount().AndFirstOrDefault();
            Assert.That(count, Is.EqualTo(10));
            Assert.That(first, Is.EqualTo(0));
        }

        [TestCaseSource(nameof(FirstOrDefaultTestCases))]
        public Result FirstOrDefaultTest(IEnumerable<int> source)
        {
            return Result.Evaluate(() => source.GetFirstOrDefault().Deconstruct());
        }

        public static IEnumerable<object> FirstOrDefaultTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>()) { ExpectedResult = Result.FromValue(0), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Range(42, 3)) { ExpectedResult = Result.FromValue(42), TestName = "Valid result" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(0, 1)) { ExpectedResult = Result.FromValue(0), TestName = "Doesn't enumerate uselessly" };
        }

        [TestCaseSource(nameof(FirstOrDefaultWithDefaultValueTestCases))]
        public Result FirstOrDefaultWithDefaultValueTest(IEnumerable<int> source, int defaultValue)
        {
            return Result.Evaluate(() => source.GetFirstOrDefault(defaultValue).Deconstruct());
        }

        public static IEnumerable<object> FirstOrDefaultWithDefaultValueTestCases()
        {
            yield return new TestCaseData(null, 69) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), 69) { ExpectedResult = Result.FromValue(69), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Range(42, 3), 69) { ExpectedResult = Result.FromValue(42), TestName = "Valid result" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(0, 1), 69) { ExpectedResult = Result.FromValue(0), TestName = "Doesn't enumerate uselessly" };
        }

        [Test]
        public void FirstOrDefaultWithPredicateAndFullConsumerTest()
        {
            var (count, five) = Enumerable.Range(0, 10).GetCount().AndFirstOrDefault(v => v is 5);
            Assert.That(count, Is.EqualTo(10));
            Assert.That(five, Is.EqualTo(5));
        }

        [TestCaseSource(nameof(FirstOrDefaultWithPredicateTestCases))]
        public Result FirstOrDefaultWithPredicateTest(IEnumerable<int> source, Func<int, bool> predicate)
        {
            return Result.Evaluate(() => source.GetFirstOrDefault(predicate).Deconstruct());
        }

        public static IEnumerable<object> FirstOrDefaultWithPredicateTestCases()
        {
            yield return new TestCaseData(null, IsEven) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Range(0, 10), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null predicate throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), IsEven) { ExpectedResult = Result.FromValue(0), TestName = "Empty source" };
            yield return new TestCaseData(new[] { 1, 3 }, IsEven) { ExpectedResult = Result.FromValue(0), TestName = "No match" };
            yield return new TestCaseData(Enumerable.Range(41, 3), IsEven) { ExpectedResult = Result.FromValue(42), TestName = "Valid result" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(1, 2), IsEven) { ExpectedResult = Result.FromValue(2), TestName = "Doesn't enumerate uselessly" };
        }

        [TestCaseSource(nameof(FirstOrDefaultWithPredicateAndDefaultValueTestCases))]
        public Result FirstOrDefaultWithPredicateAndDefaultValueTest(IEnumerable<int> source, Func<int, bool> predicate, int defaultValue)
        {
            return Result.Evaluate(() => source.GetFirstOrDefault(predicate, defaultValue).Deconstruct());
        }

        public static IEnumerable<object> FirstOrDefaultWithPredicateAndDefaultValueTestCases()
        {
            yield return new TestCaseData(null, IsEven, 69) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Range(0, 10), null, 69) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null predicate throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), IsEven, 69) { ExpectedResult = Result.FromValue(69), TestName = "Empty source" };
            yield return new TestCaseData(new[] { 1, 3 }, IsEven, 69) { ExpectedResult = Result.FromValue(69), TestName = "No match" };
            yield return new TestCaseData(Enumerable.Range(41, 3), IsEven, 69) { ExpectedResult = Result.FromValue(42), TestName = "Valid result" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(1, 2), IsEven, 69) { ExpectedResult = Result.FromValue(2), TestName = "Doesn't enumerate uselessly" };
        }

        private static Func<int, bool> IsEven => a => a % 2 == 0;

        private static IEnumerable<int> GetYieldThenThrowEnumerable(int start, int count)
        {
            foreach (var v in Enumerable.Range(start, count))
                yield return v;

            throw new Exception();
        }
    }
}