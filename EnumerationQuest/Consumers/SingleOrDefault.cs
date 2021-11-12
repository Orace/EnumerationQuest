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
        public static IEnumerableConsumer<TSource, TSource?> SingleOrDefault<TSource>()
        {
            return new SingleOrDefaultConsumer<TSource>(default);
        }

        public static IEnumerableConsumer<TSource, TSource?> SingleOrDefault<TSource>(TSource? defaultValue)
        {
            return new SingleOrDefaultConsumer<TSource>(defaultValue);
        }

        public static IEnumerableConsumer<TSource, TSource?> SingleOrDefault<TSource>(Func<TSource, bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            
            return new SingleOrDefaultWithPredicateConsumer<TSource>(predicate, default);
        }

        public static IEnumerableConsumer<TSource, TSource?> SingleOrDefault<TSource>(Func<TSource, bool> predicate, TSource? defaultValue)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            
            return new SingleOrDefaultWithPredicateConsumer<TSource>(predicate, defaultValue);
        }
    }

    internal class SingleOrDefaultConsumer<TSource> : IEnumerableConsumer<TSource, TSource?>
    {
        private readonly TSource? _defaultValue;

        public SingleOrDefaultConsumer(TSource? defaultValue)
        {
            _defaultValue = defaultValue;
        }

        public IEnumerableSink<TSource, TSource?> GetSink()
        {
            return new SingleOrDefaultSink<TSource>(_defaultValue);
        }
    }

    internal class SingleOrDefaultSink<TSource> : IEnumerableSink<TSource, TSource?>
    {
        private bool _hasContent;
        private TSource? _result;
        
        public SingleOrDefaultSink(TSource? defaultValue)
        {
            _hasContent = true;
            _result = defaultValue;
        }

        public bool AcceptFirst(TSource element)
        {
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
            _result = default;
        }

        public TSource? GetResult()
        {
            return _hasContent ? _result : throw new InvalidOperationException("The sequence has more than one element");
        }
    }

    internal class SingleOrDefaultWithPredicateConsumer<TSource> : IEnumerableConsumer<TSource, TSource?>
    {
        private readonly Func<TSource, bool> _predicate;
        private readonly TSource? _defaultValue;

        public SingleOrDefaultWithPredicateConsumer(Func<TSource, bool> predicate, TSource? defaultValue)
        {
            _predicate = predicate;
            _defaultValue = defaultValue;
        }

        public IEnumerableSink<TSource, TSource?> GetSink()
        {
            return new SingleOrDefaultWithPredicateSink<TSource>(_predicate, _defaultValue);
        }
    }

    internal class SingleOrDefaultWithPredicateSink<TSource> : IEnumerableSink<TSource, TSource?>
    {
        private readonly Func<TSource, bool> _predicate;

        private int _matchCount;
        private TSource? _result;

        public SingleOrDefaultWithPredicateSink(Func<TSource, bool> predicate, TSource? defaultValue)
        {
            _predicate = predicate;
            _result = defaultValue;
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
            _result = default;
        }

        public TSource? GetResult()
        {
            return _matchCount <= 1 ? _result : throw new InvalidOperationException("The sequence has more than one element that match the predicate");
        }
    }
}