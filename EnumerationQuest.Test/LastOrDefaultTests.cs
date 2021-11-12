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
    public class LastOrDefaultTests
    {
        [TestCaseSource(nameof(LastOrDefaultTestCases))]
        public Result LastOrDefaultTest(IEnumerable<int> source)
        {
            return Result.Evaluate(() => source.GetLastOrDefault().Deconstruct());
        }

        public static IEnumerable<object> LastOrDefaultTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>()) { ExpectedResult = Result.FromValue(0), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Range(39, 4)) { ExpectedResult = Result.FromValue(42), TestName = "Valid result" };
        }

        [TestCaseSource(nameof(LastOrDefaultWithDefaultValueTestCases))]
        public Result LastOrDefaultWithDefaultValueTest(IEnumerable<int> source, int defaultValue)
        {
            return Result.Evaluate(() => source.GetLastOrDefault(defaultValue).Deconstruct());
        }

        public static IEnumerable<object> LastOrDefaultWithDefaultValueTestCases()
        {
            yield return new TestCaseData(null, 69) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), 69) { ExpectedResult = Result.FromValue(69), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Range(39, 4), 69) { ExpectedResult = Result.FromValue(42), TestName = "Valid result" };
        }

        [TestCaseSource(nameof(LastOrDefaultWithPredicateTestCases))]
        public Result LastOrDefaultWithPredicateTest(IEnumerable<int> source, Func<int, bool> predicate)
        {
            return Result.Evaluate(() => source.GetLastOrDefault(predicate).Deconstruct());
        }

        public static IEnumerable<object> LastOrDefaultWithPredicateTestCases()
        {
            yield return new TestCaseData(null, IsEven) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Range(0, 10), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null predicate throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), IsEven) { ExpectedResult = Result.FromValue(0), TestName = "Empty source" };
            yield return new TestCaseData(new[] { 1, 3 }, IsEven) { ExpectedResult = Result.FromValue(0), TestName = "No match" };
            yield return new TestCaseData(Enumerable.Range(39, 4), IsEven) { ExpectedResult = Result.FromValue(42), TestName = "Valid result" };
        }

        [TestCaseSource(nameof(LastOrDefaultWithPredicateAndDefaultValueTestCases))]
        public Result LastOrDefaultWithPredicateAndDefaultValueTest(IEnumerable<int> source, Func<int, bool> predicate, int defaultValue)
        {
            return Result.Evaluate(() => source.GetLastOrDefault(predicate, defaultValue).Deconstruct());
        }

        public static IEnumerable<object> LastOrDefaultWithPredicateAndDefaultValueTestCases()
        {
            yield return new TestCaseData(null, IsEven, 69) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Range(0, 10), null, 69) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null predicate throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), IsEven, 69) { ExpectedResult = Result.FromValue(69), TestName = "Empty source" };
            yield return new TestCaseData(new[] { 1, 3 }, IsEven, 69) { ExpectedResult = Result.FromValue(69), TestName = "No match" };
            yield return new TestCaseData(Enumerable.Range(39, 4), IsEven, 69) { ExpectedResult = Result.FromValue(42), TestName = "Valid result" };
        }

        private static Func<int, bool> IsEven => a => a % 2 == 0;
    }
}