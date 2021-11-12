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
    public class SequenceEqualTests
    {
        [TestCaseSource(nameof(SequenceEqualTestCases))]
        public Result SequenceEqualTest(IEnumerable<int> source, IEnumerable<int> other)
        {
            return Result.Evaluate(() => source.GetSequenceEqual(other).Deconstruct());
        }

        public static IEnumerable<object> SequenceEqualTestCases()
        {
            yield return new TestCaseData(null, Enumerable.Empty<int>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null other throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), Enumerable.Empty<int>()) { ExpectedResult = Result.FromValue(true), TestName = "Both empty" };
            yield return new TestCaseData(Enumerable.Range(0, 10), Enumerable.Range(0, 10)) { ExpectedResult = Result.FromValue(true), TestName = "Both 0..10" };
            yield return new TestCaseData(new[] { 0, 1, 2, 3, 4}, new[] { 0, 1, 2, 2, 4 }) { ExpectedResult = Result.FromValue(false), TestName = "Differ after 3 elements" };
            yield return new TestCaseData(Enumerable.Range(0, 10), Enumerable.Range(0, 20)) { ExpectedResult = Result.FromValue(false), TestName = "First shorter" };
            yield return new TestCaseData(Enumerable.Range(0, 20), Enumerable.Range(0, 10)) { ExpectedResult = Result.FromValue(false), TestName = "Second shorter" };
            yield return new TestCaseData(GetYieldThenThrow(0, 1, 2, 2), new[] { 0, 1, 2, 3}) { ExpectedResult = Result.FromValue(false), TestName = "Doesn't enumerate first uselessly after differ after 3 elements" };
            yield return new TestCaseData(new[] { 0, 1, 2, 3}, GetYieldThenThrow(0, 1, 2, 2)) { ExpectedResult = Result.FromValue(false), TestName = "Doesn't enumerate second uselessly after differ after 3 elements" };
            yield return new TestCaseData(Enumerable.Range(0, 10), GetYieldThenThrowEnumerable(11)) { ExpectedResult = Result.FromValue(false), TestName = "Doesn't enumerate first uselessly after first ends" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(11), Enumerable.Range(0, 10)) { ExpectedResult = Result.FromValue(false), TestName = "Doesn't enumerate first uselessly after second ends" };
        }

        [TestCaseSource(nameof(SequenceEqualWithComparerTestCases))]
        public Result SequenceEqualWithComparerTest(IEnumerable<int> source, IEnumerable<int> other, IEqualityComparer<int> comparer)
        {
            return Result.Evaluate(() => source.GetSequenceEqual(other, comparer).Deconstruct());
        }

        public static IEnumerable<object> SequenceEqualWithComparerTestCases()
        {
            var c = EqualityComparer<int>.Default;
            yield return new TestCaseData(null, Enumerable.Empty<int>(), c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), null, c) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null other throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), Enumerable.Empty<int>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null comparer" };
            yield return new TestCaseData(Enumerable.Empty<int>(), Enumerable.Empty<int>(), c) { ExpectedResult = Result.FromValue(true), TestName = "Both empty" };
            yield return new TestCaseData(Enumerable.Range(0, 10), Enumerable.Range(0, 10), c) { ExpectedResult = Result.FromValue(true), TestName = "Both 0..10" };
            yield return new TestCaseData(new[] { 0, 1, 2, 3, 4 }, new[] { 0, 1, 2, 2, 4 }, c) { ExpectedResult = Result.FromValue(false), TestName = "Differ after 3 elements" };
            yield return new TestCaseData(Enumerable.Range(0, 10), Enumerable.Range(0, 20), c) { ExpectedResult = Result.FromValue(false), TestName = "First shorter" };
            yield return new TestCaseData(Enumerable.Range(0, 20), Enumerable.Range(0, 10), c) { ExpectedResult = Result.FromValue(false), TestName = "Second shorter" };
            yield return new TestCaseData(GetYieldThenThrow(0, 1, 2, 2), new[] { 0, 1, 2, 3 }, c) { ExpectedResult = Result.FromValue(false), TestName = "Doesn't enumerate first uselessly after differ after 3 elements" };
            yield return new TestCaseData(new[] { 0, 1, 2, 3 }, GetYieldThenThrow(0, 1, 2, 2), c) { ExpectedResult = Result.FromValue(false), TestName = "Doesn't enumerate second uselessly after differ after 3 elements" };
            yield return new TestCaseData(Enumerable.Range(0, 10), GetYieldThenThrowEnumerable(11), c) { ExpectedResult = Result.FromValue(false), TestName = "Doesn't enumerate first uselessly after first ends" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(11), Enumerable.Range(0, 10), c) { ExpectedResult = Result.FromValue(false), TestName = "Doesn't enumerate first uselessly after second ends" };

            var mockComparer = new Mock<EqualityComparer<int>>();
            mockComparer.SetupSequence(e => e.Equals(It.IsAny<int>(), It.IsAny<int>())).Returns(false).Throws<Exception>();
            c = mockComparer.Object;
            yield return new TestCaseData(Enumerable.Range(1, 10), Enumerable.Range(1, 10), c) { ExpectedResult = Result.FromValue(false), TestName = "Use provided comparer" };

            mockComparer = new Mock<EqualityComparer<int>>();
            mockComparer.SetupSequence(e => e.Equals(It.IsAny<int>(), It.IsAny<int>())).Returns(true).Throws<Exception>();
            c = mockComparer.Object;
            yield return new TestCaseData(Enumerable.Range(1, 10), Enumerable.Range(1, 10), c) { ExpectedResult = Result.FromException<Exception>(), TestName = "Use provided comparer twice" };
        }

        private static IEnumerable<int> GetYieldThenThrow(params int[] values)
        {
            foreach (var v in values)
                yield return v;

            throw new Exception();
        }

        private static IEnumerable<int> GetYieldThenThrowEnumerable(int count)
        {
            foreach (var v in Enumerable.Range(0, count))
                yield return v;

            throw new Exception();
        }
    }
}