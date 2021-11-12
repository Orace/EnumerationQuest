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
    public class SingleOrDefaultTests
    {
        [TestCaseSource(nameof(SingleOrDefaultTestCases))]
        public Result SingleOrDefaultTest(IEnumerable<int> source)
        {
            return Result.Evaluate(() => source.GetSingleOrDefault().Deconstruct());
        }

        public static IEnumerable<object> SingleOrDefaultTestCases()
        {
            yield return new TestCaseData(null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>()) { ExpectedResult = Result.FromValue(0), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Range(42, 3)) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "More than one element throw" };
            yield return new TestCaseData(Enumerable.Range(42, 1)) { ExpectedResult = Result.FromValue(42), TestName = "Valid result" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(0, 2)) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Doesn't enumerate uselessly" };
        }

        [TestCaseSource(nameof(SingleOrDefaultWithDefaultValueTestCases))]
        public Result SingleOrDefaultWithDefaultValueTest(IEnumerable<int> source, int defaultValue)
        {
            return Result.Evaluate(() => source.GetSingleOrDefault(defaultValue).Deconstruct());
        }

        public static IEnumerable<object> SingleOrDefaultWithDefaultValueTestCases()
        {
            yield return new TestCaseData(null, 69) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), 69) { ExpectedResult = Result.FromValue(69), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Range(42, 3), 69) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "More than one element throw" };
            yield return new TestCaseData(Enumerable.Range(42, 1), 69) { ExpectedResult = Result.FromValue(42), TestName = "Valid result" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(0, 2), 69) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "Doesn't enumerate uselessly" };
        }

        [TestCaseSource(nameof(SingleOrDefaultWithPredicateTestCases))]
        public Result SingleOrDefaultWithPredicateTest(IEnumerable<int> source, Func<int, bool> predicate)
        {
            return Result.Evaluate(() => source.GetSingleOrDefault(predicate).Deconstruct());
        }

        public static IEnumerable<object> SingleOrDefaultWithPredicateTestCases()
        {
            yield return new TestCaseData(null, IsEven) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Range(0, 10), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null predicate throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), IsEven) { ExpectedResult = Result.FromValue(0), TestName = "Empty source" };
            yield return new TestCaseData(new[] { 1, 3 }, IsEven) { ExpectedResult = Result.FromValue(0), TestName = "No match" };
            yield return new TestCaseData(Enumerable.Range(0, 10), IsEven) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "More than one match throw" };
            yield return new TestCaseData(Enumerable.Range(41, 3), IsEven) { ExpectedResult = Result.FromValue(42), TestName = "Valid result" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(1, 2), IsEven) { ExpectedResult = Result.FromException<Exception>(), TestName = "Enumerate to the end" };
        }

        [TestCaseSource(nameof(SingleOrDefaultWithPredicateAndDefaultValueTestCases))]
        public Result SingleOrDefaultWithPredicateAndDefaultValueTest(IEnumerable<int> source, Func<int, bool> predicate, int defaultValue)
        {
            return Result.Evaluate(() => source.GetSingleOrDefault(predicate, defaultValue).Deconstruct());
        }

        public static IEnumerable<object> SingleOrDefaultWithPredicateAndDefaultValueTestCases()
        {
            yield return new TestCaseData(null, IsEven, 69) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Range(0, 10), null, 69) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null predicate throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), IsEven, 69) { ExpectedResult = Result.FromValue(69), TestName = "Empty source" };
            yield return new TestCaseData(new[] { 1, 3 }, IsEven, 69) { ExpectedResult = Result.FromValue(69), TestName = "No match" };
            yield return new TestCaseData(Enumerable.Range(0, 10), IsEven, 69) { ExpectedResult = Result.FromException<InvalidOperationException>(), TestName = "More than one match throw" };
            yield return new TestCaseData(Enumerable.Range(41, 3), IsEven, 69) { ExpectedResult = Result.FromValue(42), TestName = "Valid result" };
            yield return new TestCaseData(GetYieldThenThrowEnumerable(1, 2), IsEven, 69) { ExpectedResult = Result.FromException<Exception>(), TestName = "Enumerate to the end" };
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