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
    public class IndexOfTests
    {
        [TestCaseSource(nameof(IndexOfTestCases))]
        public Result IndexOfTest(IEnumerable<int> source, int value)
        {
            return Result.Evaluate(() => source.GetIndexOf(value).Deconstruct());
        }

        public static IEnumerable<object> IndexOfTestCases()
        {
            yield return new TestCaseData(null, 69) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), 69) { ExpectedResult = Result.FromValue(-1), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Range(27, 100), 69) { ExpectedResult = Result.FromValue(42), TestName = "Valid result" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(0, 70), 69) { ExpectedResult = Result.FromValue(69), TestName = "Doesn't enumerate uselessly" };
        }

        [TestCaseSource(nameof(IndexOfWithComparerTestCases))]
        public Result IndexOfWithComparerTest(IEnumerable<int> source, int value, IEqualityComparer<int> comparer)
        {
            return Result.Evaluate(() => source.GetIndexOf(value, comparer).Deconstruct());
        }

        public static IEnumerable<object> IndexOfWithComparerTestCases()
        {
            var c = EqualityComparer<int>.Default;
            yield return new TestCaseData(null, 69, c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), 69, c) { ExpectedResult = Result.FromValue(-1), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Range(27, 100), 69, c) { ExpectedResult = Result.FromValue(42), TestName = "Valid result" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(0, 70), 69, c) { ExpectedResult = Result.FromValue(69), TestName = "Doesn't enumerate uselessly" };

            var mockComparer = new Mock<EqualityComparer<int>>();
            mockComparer.SetupSequence(e => e.Equals(It.IsAny<int>(), It.IsAny<int>())).Returns(false).Returns(true).Throws<Exception>();
            c = mockComparer.Object;
            yield return new TestCaseData(Enumerable.Range(1, 10), 0, c) { ExpectedResult = Result.FromValue(1), TestName = "Use provided comparer" };

            mockComparer = new Mock<EqualityComparer<int>>();
            mockComparer.SetupSequence(e => e.Equals(It.IsAny<int>(), It.IsAny<int>())).Returns(false).Returns(false).Throws<Exception>();
            c = mockComparer.Object;
            yield return new TestCaseData(Enumerable.Range(1, 10), 0, c) { ExpectedResult = Result.FromException<Exception>(), TestName = "Use provided comparer twice" };
        }

        private static IEnumerable<int> GetYieldThenThrowEnumerable(int start, int count)
        {
            foreach (var v in Enumerable.Range(start, count))
                yield return v;

            throw new Exception();
        }
    }
}