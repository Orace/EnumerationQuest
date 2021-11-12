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
    public class ContainsTests
    {
        [TestCaseSource(nameof(ContainsTestCases))]
        public Result ContainsTest<TSource>(IEnumerable<TSource> source, TSource value)
        {
            return Result.Evaluate(() => source.GetContains(value).Deconstruct());
        }

        public static IEnumerable<object> ContainsTestCases()
        {
            yield return new TestCaseData(null, 0) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), 0) { ExpectedResult = Result.FromValue(false), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Range(1, 10), 5) { ExpectedResult = Result.FromValue(true), TestName = "True result" };
            yield return new TestCaseData(Enumerable.Range(1, 10), 0) { ExpectedResult = Result.FromValue(false), TestName = "False result" };
        }

        [TestCaseSource(nameof(ContainsWithComparerTestCases))]
        public Result ContainsWithComparerTest<TSource>(IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
        {
            return Result.Evaluate(() => source.GetContains(value, comparer).Deconstruct());
        }

        public static IEnumerable<object> ContainsWithComparerTestCases()
        {
            var c = EqualityComparer<int>.Default;

            yield return new TestCaseData(null, 0, c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), 0, null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null comparer throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), 0, c) { ExpectedResult = Result.FromValue(false), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Range(1, 10), 5, c) { ExpectedResult = Result.FromValue(true), TestName = "True result" };
            yield return new TestCaseData(Enumerable.Range(1, 10), 0, c) { ExpectedResult = Result.FromValue(false), TestName = "False result" };
            yield return new TestCaseData(GetZeroThenThrowEnumerable(), 0, c) { ExpectedResult = Result.FromValue(true), TestName = "Do not enumerate uselessly" };

            var mockComparer = new Mock<EqualityComparer<int>>();
            mockComparer.SetupSequence(e => e.Equals(It.IsAny<int>(), It.IsAny<int>())).Returns(true).Throws<Exception>();
            c = mockComparer.Object;
            yield return new TestCaseData(Enumerable.Range(1, 10), 0, c) { ExpectedResult = Result.FromValue(true), TestName = "Use provided comparer" };

            mockComparer = new Mock<EqualityComparer<int>>();
            mockComparer.SetupSequence(e => e.Equals(It.IsAny<int>(), It.IsAny<int>())).Returns(false).Throws<Exception>();
            c = mockComparer.Object;
            yield return new TestCaseData(Enumerable.Range(1, 10), 0, c) { ExpectedResult = Result.FromException<Exception>(), TestName = "Use provided comparer twice" };
        }

        private static IEnumerable<int> GetZeroThenThrowEnumerable()
        {
            yield return 0;
            throw new Exception();
        }
    }
}