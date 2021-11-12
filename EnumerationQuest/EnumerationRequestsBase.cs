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

namespace EnumerationQuest
{
    public abstract class EnumerationRequestsBase
    {
        internal EnumerationRequestsBase()
        {
        }

        internal static void Enumerate<TSource>(IEnumerable<TSource> source, params IEnumerableSink<TSource>[] sinks)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            if (sinks is null)
                throw new ArgumentNullException(nameof(sinks));

            if (sinks.Length is 0)
                return;

            using var enumerator = source.GetEnumerator();

            if (!enumerator.MoveNext())
                return;

            var shouldContinue = false;
            foreach (var sink in sinks)
            {
                shouldContinue |= sink.AcceptFirst(enumerator.Current);
            }

            while (shouldContinue && enumerator.MoveNext())
            {
                shouldContinue = false;
                foreach (var sink in sinks)
                {
                    shouldContinue |= sink.AcceptNext(enumerator.Current);
                }
            }
        }
    }
}