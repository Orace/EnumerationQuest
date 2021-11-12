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
        public static IEnumerableConsumer<TSource, TSource> Single<TSource>()
        {
            return new SingleConsumer<TSource>();
        }

        public static IEnumerableConsumer<TSource, TSource> Single<TSource>(Func<TSource, bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            
            return new SingleWithPredicateConsumer<TSource>(predicate);
        }
    }

    internal class SingleConsumer<TSource> : IEnumerableConsumer<TSource, TSource>
    {
        public IEnumerableSink<TSource, TSource> GetSink()
        {
            return new SingleSink<TSource>();
        }
    }

    internal class SingleSink<TSource> : IEnumerableSink<TSource, TSource>
    {
        private bool _hasContent;
        private TSource? _result;

        public bool AcceptFirst(TSource element)
        {
            _hasContent = true;
            _result = element;
            return true;
        }

        public bool AcceptNext(TSource element)
        {
            _hasContent = false;
            _result = default;
            return false;
        }

        public void Dispose()
        {
            _hasContent = false;
            _result = default;
        }

        public TSource GetResult()
        {
            return _hasContent ? _result! : throw new InvalidOperationException("The sequence has not exactly one element");
        }
    }

    internal class SingleWithPredicateConsumer<TSource> : IEnumerableConsumer<TSource, TSource>
    {
        private readonly Func<TSource, bool> _predicate;

        public SingleWithPredicateConsumer(Func<TSource, bool> predicate)
        {
            _predicate = predicate;
        }

        public IEnumerableSink<TSource, TSource> GetSink()
        {
            return new SingleWithPredicateSink<TSource>(_predicate);
        }
    }

    internal class SingleWithPredicateSink<TSource> : IEnumerableSink<TSource, TSource>
    {
        private readonly Func<TSource, bool> _predicate;

        private int _matchCount;
        private TSource? _result;

        public SingleWithPredicateSink(Func<TSource, bool> predicate)
        {
            _predicate = predicate;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            if (_matchCount > 1)
                return false;

            if (!_predicate(element))
                return true;

            _matchCount++;

            if (_matchCount == 1)
            {
                _result = element;
                return true;
            }

            _result = default;
            return false;
        }

        public void Dispose()
        {
            _matchCount = 0;
            _result = default;
        }

        public TSource GetResult()
        {
            return _matchCount == 1 ? _result! : throw new InvalidOperationException("The sequence has not exactly one element that match the predicate");
        }
    }
}