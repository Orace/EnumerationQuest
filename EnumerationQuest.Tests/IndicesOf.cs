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
    public class IndicesOf
    {
        [TestCaseSource(nameof(IndicesOfTestCases))]
        public Result IndicesOfTest(IEnumerable<int> source, int value)
        {
            return Result.Evaluate(() => Format(source.GetIndicesOf(value).Deconstruct()));
        }

        public static IEnumerable<object> IndicesOfTestCases()
        {
            yield return new TestCaseData(null, 69) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), 69) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "Empty source" };
            yield return new TestCaseData(new[] { 0, 69, 0, 69 }, 69) { ExpectedResult = Result.FromValue(Format(new[] { 1, 3 })), TestName = "Valid result" };
        }

        [TestCaseSource(nameof(IndicesOfWithComparerTestCases))]
        public Result IndicesOfWithComparerTest(IEnumerable<int> source, int value, IEqualityComparer<int> comparer)
        {
            return Result.Evaluate(() => Format(source.GetIndicesOf(value, comparer).Deconstruct()));
        }

        public static IEnumerable<object> IndicesOfWithComparerTestCases()
        {
            var c = EqualityComparer<int>.Default;
            yield return new TestCaseData(null, 69, c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), 69, c) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "Empty source" };
            yield return new TestCaseData(new[] { 0, 69, 0, 69 }, 69, c) { ExpectedResult = Result.FromValue(Format(new[] { 1, 3 })), TestName = "Valid result" };

            var mockComparer = new Mock<EqualityComparer<int>>();
            mockComparer.SetupSequence(e => e.Equals(It.IsAny<int>(), It.IsAny<int>())).Returns(true).Returns(false).Returns(true);
            c = mockComparer.Object;
            yield return new TestCaseData(Enumerable.Range(0, 3), -1, c) { ExpectedResult = Result.FromValue(Format(new[] { 0, 2 })), TestName = "Use provided comparer" };
        }

        private static string Format(IEnumerable<int> e)
        {
            return string.Join('|', e);
        }
    }
}