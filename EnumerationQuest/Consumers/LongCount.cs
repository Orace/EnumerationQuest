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

namespace EnumerationQuest.Consumers
{
    internal static partial class ConsumerFactory
    {
        public static IEnumerableConsumer<TSource, long> LongCount<TSource>()
        {
            return new LongCountConsumer<TSource>();
        }

        public static IEnumerableConsumer<TSource, long> LongCount<TSource>(Func<TSource, bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            return new LongCountWithPredicateConsumer<TSource>(predicate);
        }
    }

    internal class LongCountConsumer<TSource> : IEnumerableConsumer<TSource, long>
    {
        public IEnumerableSink<TSource, long> GetSink()
        {
            return new LongCountSink<TSource>();
        }
    }

    internal class LongCountSink<TSource> : IEnumerableSink<TSource, long>
    {
        private long _count;

        public bool AcceptFirst(TSource element)
        {
            _count = 1;
            return true;
        }

        public bool AcceptNext(TSource element)
        {
            checked
            {
                _count++;
            }

            return true;
        }

        public void Dispose()
        {
        }

        public long GetResult()
        {
            return _count;
        }
    }

    internal class LongCountWithPredicateConsumer<TSource> : IEnumerableConsumer<TSource, long>
    {
        private readonly Func<TSource, bool> _predicate;

        public LongCountWithPredicateConsumer(Func<TSource, bool> predicate)
        {
            _predicate = predicate;
        }

        public IEnumerableSink<TSource, long> GetSink()
        {
            return new LongCountWithPredicateSink<TSource>(_predicate);
        }
    }

    internal class LongCountWithPredicateSink<TSource> : IEnumerableSink<TSource, long>
    {
        private readonly Func<TSource, bool> _predicate;

        private long _count;

        public LongCountWithPredicateSink(Func<TSource, bool> predicate)
        {
            _predicate = predicate;
        }

        public bool AcceptFirst(TSource element)
        {
            if (_predicate(element))
                _count = 1;

            return true;
        }

        public bool AcceptNext(TSource element)
        {
            if (_predicate(element))
            {
                checked
                {
                    _count++;
                }
            }

            return true;
        }

        public void Dispose()
        {
        }

        public long GetResult()
        {
            return _count;
        }
    }
}