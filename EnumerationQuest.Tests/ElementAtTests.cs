﻿// EnumerableQuest - Avoids multiple enumeration
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
    public class ElementAtTests
    {
        [Test]
        public void ElementAtWithFullConsumerTest()
        {
            var (count, five) = Enumerable.Range(0, 10).GetCount().AndElementAt(5);
            Assert.That(count, Is.EqualTo(10));
            Assert.That(five, Is.EqualTo(5));
        }

        [TestCaseSource(nameof(ElementAtTestCases))]
        public Result ElementAtTest(IEnumerable<int> source, int index)
        {
            return Result.Evaluate(() => source.GetElementAt(index).Deconstruct());
        }

        public static IEnumerable<object> ElementAtTestCases()
        {
            yield return new TestCaseData(null, 0) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), 0) { ExpectedResult = Result.FromException<ArgumentOutOfRangeException>(), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), -1) { ExpectedResult = Result.FromException<ArgumentOutOfRangeException>(), TestName = "Negative index throw" };
            yield return new TestCaseData(Enumerable.Range(0, 10), 10) { ExpectedResult = Result.FromException<ArgumentOutOfRangeException>(), TestName = "Overflow index throw" };
            yield return new TestCaseData(Enumerable.Range(0, 10), 0) { ExpectedResult = Result.FromValue(0), TestName = "With first index returns good value" };
            yield return new TestCaseData(Enumerable.Range(0, 10), 5) { ExpectedResult = Result.FromValue(5), TestName = "With valid index returns good value" };
            yield return new TestCaseData(Enumerable.Range(0, 10), 9) { ExpectedResult = Result.FromValue(9), TestName = "With last index returns good value" };
        }

        [TestCaseSource(nameof(ElementAtWithIndexTestCases))]
        public Result ElementAtWithIndexTest(IEnumerable<int> source, Index index)
        {
            return Result.Evaluate(() => source.GetElementAt(index).Deconstruct());
        }

        public static IEnumerable<object> ElementAtWithIndexTestCases()
        {
            yield return new TestCaseData(null, new Index(0)) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<int>(), new Index(0)) { ExpectedResult = Result.FromException<ArgumentOutOfRangeException>(), TestName = "Empty source throw" };
            yield return new TestCaseData(Enumerable.Range(0, 10), new Index(10)) { ExpectedResult = Result.FromException<ArgumentOutOfRangeException>(), TestName = "Overflow index throw" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^0) { ExpectedResult = Result.FromException<ArgumentOutOfRangeException>(), TestName = "End index throw" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^11) { ExpectedResult = Result.FromException<ArgumentOutOfRangeException>(), TestName = "Negative index from end throw" };
            yield return new TestCaseData(Enumerable.Range(0, 10), new Index(0)) { ExpectedResult = Result.FromValue(0), TestName = "With first index returns good value" };
            yield return new TestCaseData(Enumerable.Range(0, 10), new Index(5)) { ExpectedResult = Result.FromValue(5), TestName = "With valid index returns good value" };
            yield return new TestCaseData(Enumerable.Range(0, 10), new Index(9)) { ExpectedResult = Result.FromValue(9), TestName = "With last index returns good value" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^10) { ExpectedResult = Result.FromValue(0), TestName = "With first index from end returns good value" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^5) { ExpectedResult = Result.FromValue(5), TestName = "With valid index from end returns good value" };
            yield return new TestCaseData(Enumerable.Range(0, 10), ^1) { ExpectedResult = Result.FromValue(9), TestName = "With last index from end returns good value" };
        }
    }
}