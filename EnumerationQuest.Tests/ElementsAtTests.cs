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
    public class ElementsAtTests
    {
        [TestCaseSource(nameof(ElementsAtTestCases))]
        public Result ElementsAtTest(IEnumerable<int> source, IEnumerable<int> indices)
        {
            return Result.Evaluate(() => Format(source.GetElementsAt(indices).Deconstruct()));
        }

        public static IEnumerable<object> ElementsAtTestCases()
        {
            yield return new TestCaseData(null, Enumerable.Empty<int>()) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null indices throw" };

            yield return new TestCaseData(Enumerable.Empty<int>(), Enumerable.Range(0, 10)) { ExpectedResult = Result.FromException<ArgumentException>(), TestName = "Empty source and positives indices throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), new[] { -1, 0 }) { ExpectedResult = Result.FromException<ArgumentException>(), TestName = "Empty source and negatives indices throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), new[] { 10, 5 }) { ExpectedResult = Result.FromException<ArgumentException>(), TestName = "Empty source and decreasing indices throw" };

            yield return new TestCaseData(Enumerable.Range(0, 10), new[] { -1, 0 }) { ExpectedResult = Result.FromException<ArgumentException>(), TestName = "Negatives indices throw" };
            yield return new TestCaseData(Enumerable.Range(0, 10), new[] { 7, 5 }) { ExpectedResult = Result.FromException<ArgumentException>(), TestName = "Decreasing indices throw" };
            yield return new TestCaseData(Enumerable.Range(0, 10), new[] { 10, 5 }) { ExpectedResult = Result.FromException<ArgumentException>(), TestName = "Decreasing indices after last element throw" };

            yield return new TestCaseData(Enumerable.Empty<int>(), Enumerable.Empty<int>()) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "Empty source and indices" };
            yield return new TestCaseData(Enumerable.Range(0, 10), Enumerable.Empty<int>()) { ExpectedResult = Result.FromValue(Format(Enumerable.Empty<int>())), TestName = "Empty indices" };
            yield return new TestCaseData(Enumerable.Range(0, 10), Enumerable.Range(5, 3)) { ExpectedResult = Result.FromValue(Format(Enumerable.Range(5, 3))), TestName = "Valid indices" };
            yield return new TestCaseData(Enumerable.Range(0, 10), new[] { 2, 4, 6 }) { ExpectedResult = Result.FromValue(Format(new[] { 2, 4, 6 })), TestName = "Valid not consecutive indices" };
            yield return new TestCaseData(Enumerable.Range(0, 10), new[] { 2, 4, 4, 7 }) { ExpectedResult = Result.FromValue(Format(new[] { 2, 4, 4, 7 })), TestName = "Valid and repeating indices" };
        }

        private static string Format(IEnumerable<int> e)
        {
            return string.Join('|', e);
        }
    }
}