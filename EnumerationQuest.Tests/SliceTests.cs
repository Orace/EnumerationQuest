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
    public class SliceTests
    {
        [TestCaseSource(nameof(SliceWithFullConsumerTestCases))]
        public void SliceWithFullConsumerTest(Range range)
        {
            var (count, yingYang) = Enumerable.Range(0, 20).GetCount().AndSlice(range);
            Assert.That(count, Is.EqualTo(20));
            CollectionAssert.AreEqual(yingYang, new[] { 6, 7, 8, 9 });
        }

        public static IEnumerable<object> SliceWithFullConsumerTestCases()
        {
            yield return new TestCaseData(6..10) { TestName = "(From start, From start) with full consumer" };
            yield return new TestCaseData(6..^10) { TestName = "(From start, From end) with full consumer" };
            yield return new TestCaseData(^14..10) { TestName = "(From end, From start) with full consumer" };
            yield return new TestCaseData(^14..^10) { TestName = "(From end, From end) with full consumer" };
        }

        [TestCaseSource(nameof(SliceTestCases))]
        public Result SliceTest(IEnumerable<int> source, Range range)
        {
            return Result.Evaluate(() => Format(source.GetSlice(range).Deconstruct()));
        }

        public static IEnumerable<object> SliceTestCases()
        {
            yield return new TestCaseData(null, ..) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };

            // Empty range
            yield return new TestCaseData(Enumerable.Range(0, 10), 5..5) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "Empty range from start" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^5..^5) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "Empty range from end" };

            // (From start, From start)
            yield return new TestCaseData(Enumerable.Empty<int>(), ..10) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "(From start, From start) Empty source" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ..10) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(0, 10))), TestName = "(From start, From start) Full range" };
            yield return new TestCaseData(Enumerable.Range(0, 10), 4..6) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(4, 2))), TestName = "(From start, From start) Partial range" };
            yield return new TestCaseData(Enumerable.Range(0, 10), 4..16) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(4, 6))), TestName = "(From start, From start) Cross range" };
            yield return new TestCaseData(Enumerable.Range(0, 10), 16..20) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "(From start, From start) Overflow range" };
            yield return new TestCaseData(Enumerable.Range(0, 10), 10..11) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "(From start, From start) After last" };
            yield return new TestCaseData(Enumerable.Range(0, 10), 9..10) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(9, 1))), TestName = "(From start, From start) Last" };
            yield return new TestCaseData(Enumerable.Range(0, 10), 6..4) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "(From start, From start) Switched range" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(2), 1..2) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(1, 1))), TestName = "(From start, From start) Do not enumerate uselessly" };

            // (From start, From end)
            yield return new TestCaseData(Enumerable.Empty<int>(), ..) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "(From start, From end) Empty source" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ..) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(0, 10))), TestName = "(From start, From end) Full range" };
            yield return new TestCaseData(Enumerable.Range(0, 10), 4..^4) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(4, 2))), TestName = "(From start, From end) Partial range" };
            yield return new TestCaseData(Enumerable.Range(0, 100), 75..^10) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(75, 15))), TestName = "(From end, From end) Partial range in long enumerable" };
            yield return new TestCaseData(Enumerable.Range(0, 10), 6..^6) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "(From start, From end) Switched range" };
            yield return new TestCaseData(Enumerable.Range(0, 10), 16..^6) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "(From start, From end) Switched range overflow left" };
            yield return new TestCaseData(Enumerable.Range(0, 10), 6..^16) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "(From start, From end) Switched range overflow right" };

            // (From end, From start)
            yield return new TestCaseData(Enumerable.Empty<int>(), ^10..10) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "(From end, From start) Empty source" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^10..10) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(0, 10))), TestName = "(From end, From start) Full range" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^6..0) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "(From end, From start) Overflow and empty" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^6..6) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(4, 2))), TestName = "(From end, From start) Partial range" };
            yield return new TestCaseData(Enumerable.Range(0, 100), ^25..90) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(75, 15))), TestName = "(From end, From start) Partial range in long enumerable" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^6..16) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(4, 6))), TestName = "(From end, From start) Cross range" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^16..20) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(0, 10))), TestName = "(From end, From start) Overflow full range" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^4..4) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "(From end, From start) Switched range" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(2), 1..2) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(1, 1))), TestName = "(From start, From start) Do not enumerate uselessly" };

            // (From end, From end)
            yield return new TestCaseData(Enumerable.Empty<int>(), ^10..) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "(From end, From end) Empty source" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^10..) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(0, 10))), TestName = "(From end, From end) Full range" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^6..^4) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(4, 2))), TestName = "(From end, From end) Partial range" };
            yield return new TestCaseData(Enumerable.Range(0, 100), ^25..^10) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(75, 15))), TestName = "(From end, From end) Partial range in long enumerable" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^26..^6) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(0, 4))), TestName = "(From end, From end) Cross range" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^30..^20) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "(From end, From end) Overflow range" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^10..^9) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(0, 1))), TestName = "(From end, From end) first" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^1..) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(9, 1))), TestName = "(From end, From end) last" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^0..) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "(From end, From end) after last" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^11..^10) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "(From end, From end) Before first" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^4..^6) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "(From end, From end) Switched range" };
        }

        private static string Format(IEnumerable<int> e)
        {
            return string.Join('|', e);
        }

        private static IEnumerable<int> GetYieldThenThrowEnumerable(int count)
        {
            foreach (var v in Enumerable.Range(0, count))
                yield return v;

            throw new Exception();
        }
    }
}