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
    public class DelimitedStringTests
    {
        [TestCaseSource(nameof(DelimitedStringTestCases))]
        public Result DelimitedStringTest(IEnumerable<string?> source, string? delimiter)
        {
            return Result.Evaluate(() => source.GetDelimitedString(delimiter).Deconstruct());
        }

        public static IEnumerable<object> DelimitedStringTestCases()
        {
            yield return new TestCaseData(null, "|") { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<string>(), "|") { ExpectedResult = Result.FromValue(string.Empty), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Empty<string>(), null) { ExpectedResult = Result.FromValue(string.Empty), TestName = "Empty source with null delimiter" };
            yield return new TestCaseData(new[] { "1", null, "2" }, "|") { ExpectedResult = Result.FromValue("1||2"), TestName = "Null in source" };
            yield return new TestCaseData(new[] { "1", "2", "3" }, "|") { ExpectedResult = Result.FromValue("1|2|3"), TestName = "Valid result" };
            yield return new TestCaseData(new[] { "1", "2", "3" }, null) { ExpectedResult = Result.FromValue("123"), TestName = "Valid result with null delimiter" };
        }

        [TestCaseSource(nameof(DelimitedStringWithStringSelectorTestCases))]
        public Result DelimitedStringWithStringSelectorTest(IEnumerable<string?> source, string? delimiter, Func<string?, string?> stringSelector)
        {
            return Result.Evaluate(() => source.GetDelimitedString(delimiter, stringSelector).Deconstruct());
        }

        public static IEnumerable<object> DelimitedStringWithStringSelectorTestCases()
        {
            yield return new TestCaseData(null, "|", StringSelector) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null source throw" };
            yield return new TestCaseData(Enumerable.Empty<string>(), "|", null) { ExpectedResult = Result.FromException<ArgumentNullException>(), TestName = "Null string selector" };
            yield return new TestCaseData(Enumerable.Empty<string>(), "|", StringSelector) { ExpectedResult = Result.FromValue(string.Empty), TestName = "Empty source" };
            yield return new TestCaseData(Enumerable.Empty<string>(), null, StringSelector) { ExpectedResult = Result.FromValue(string.Empty), TestName = "Empty source with null delimiter" };
            yield return new TestCaseData(new[] { "a", null, "b" }, "|", StringSelector) { ExpectedResult = Result.FromValue("A|_|B"), TestName = "Null in source" };
            yield return new TestCaseData(new[] { "a", "b", "c" }, "|", StringSelector) { ExpectedResult = Result.FromValue("A|B|C"), TestName = "Valid result" };
            yield return new TestCaseData(new[] { "a", "b", "c" }, null, StringSelector) { ExpectedResult = Result.FromValue("ABC"), TestName = "Valid result with null delimiter" };
        }

        private static Func<string?, string?> StringSelector { get; } = s => s?.ToUpperInvariant() ?? "_";
    }
}