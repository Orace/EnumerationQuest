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
    public class AllTests
    {
        [TestCaseSource(nameof(AllTestCases))]
        public Result AllTest<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return Result.Evaluate(() => source.GetAll(predicate).Deconstruct());
        }

        public static IEnumerable<object> AllTestCases()
        {
            yield return new TestCaseData(null, IsEven) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null predicate throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), IsEven) { ExpectedResult = Result.FromValue(true), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Range(1, 100).Select(v => 2 * v), IsEven) { ExpectedResult = Result.FromValue(true), TestName = "True expected" };
            yield return new TestCaseData(Enumerable.Range(1, 100), IsEven) { ExpectedResult = Result.FromValue(false), TestName = "False expected" };
            yield return new TestCaseData(GetZeroThenThrowEnumerable(), FalsePredicate) { ExpectedResult = Result.FromValue(false), TestName = "Do not call predicate uselessly" };
            yield return new TestCaseData(GetZeroThenThrowEnumerable(), TruePredicate) { ExpectedResult = Result.FromException<Exception>(), TestName = "Call predicate when necessary" };
        }

        private static Func<int, bool> FalsePredicate => _ => false;
        private static Func<int, bool> IsEven => a => a % 2 == 0;
        private static Func<int, bool> TruePredicate => _ => true;

        private static IEnumerable<int> GetZeroThenThrowEnumerable()
        {
            yield return 0;
            throw new Exception();
        }
    }
}