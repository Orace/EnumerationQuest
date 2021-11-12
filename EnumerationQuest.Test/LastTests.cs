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

namespace EnumerationQuest.Test
{
    public class LastTests
    {
        [TestCaseSource(nameof(LastTestCases))]
        public Result LastTest(IEnumerable<int> source)
        {
            return Result.Evaluate(() => source.GetLast().Deconstruct());
        }

        public static IEnumerable<object> LastTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>()) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(39, 4)) { ExpectedResult = Result.FromValue(42), TestName = "Valid result" };
        }

        [TestCaseSource(nameof(LastWithPredicateTestCases))]
        public Result LastWithPredicateTest(IEnumerable<int> source, Func<int, bool> predicate)
        {
            return Result.Evaluate(() => source.GetLast(predicate).Deconstruct());
        }

        public static IEnumerable<object> LastWithPredicateTestCases()
        {
            yield return new TestCaseData(null, IsEven) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Range(0, 10), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null predicate throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), IsEven) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Empty source throw" };
            yield return new TestCaseData(new[] { 1, 3 }, IsEven) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "No match throw" };
            yield return new TestCaseData(Enumerable.Range(39, 4), IsEven) { ExpectedResult = Result.FromValue(42), TestName = "Valid result" };
        }

        private static Func<int, bool> IsEven => a => a % 2 == 0;
    }
}