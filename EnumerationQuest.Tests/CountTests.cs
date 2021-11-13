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
    public class CountTests
    {
        [TestCaseSource(nameof(CountTestCases))]
        public Result CountTest(IEnumerable<int> source)
        {
            return Result.Evaluate(() => source.GetCount().Deconstruct());
        }

        public static IEnumerable<object> CountTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            // yield return new TestCaseData(GetLongEnumerable()) { ExpectedResult = Result.FromException<OverflowException>(), TestName = "Overflowing source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>()) { ExpectedResult = Result.FromValue(0), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Range(1, 5)) { ExpectedResult = Result.FromValue(5), TestName = "Valid result" };
        }


        [TestCaseSource(nameof(CountWithPredicateTestCases))]
        public Result CountWithPredicateTest(IEnumerable<int> source, Func<int, bool> predicate)
        {
            return Result.Evaluate(() => source.GetCount(predicate).Deconstruct());
        }

        public static IEnumerable<object> CountWithPredicateTestCases()
        {
            yield return new TestCaseData(null, EvenPredicate) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null predicate throw" };
            // yield return new TestCaseData(GetLongEnumerable()) { ExpectedResult = Result.FromException<OverflowException>(), TestName = "Overflowing source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), EvenPredicate) { ExpectedResult = Result.FromValue(0), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Range(1, 5), EvenPredicate) { ExpectedResult = Result.FromValue(2), TestName = "Valid result" };
        }

        private static Func<int, bool> EvenPredicate { get; } = value => value % 2 == 0;

        private static IEnumerable<int> GetLongEnumerable()
        {
            for (var i = -1; i < int.MaxValue; i++)
                yield return i;
        }
    }
}