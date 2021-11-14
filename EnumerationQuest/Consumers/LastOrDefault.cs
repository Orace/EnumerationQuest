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
        public static IEnumerableConsumer<TSource, TSource?> LastOrDefault<TSource>()
        {
            return new LastOrDefaultConsumer<TSource>(default);
        }

        public static IEnumerableConsumer<TSource, TSource?> LastOrDefault<TSource>(TSource? defaultValue)
        {
            return new LastOrDefaultConsumer<TSource>(defaultValue);
        }

        public static IEnumerableConsumer<TSource, TSource?> LastOrDefault<TSource>(Func<TSource, bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            
            return new LastOrDefaultWithPredicateConsumer<TSource>(predicate, default);
        }

        public static IEnumerableConsumer<TSource, TSource?> LastOrDefault<TSource>(Func<TSource, bool> predicate, TSource? defaultValue)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            
            return new LastOrDefaultWithPredicateConsumer<TSource>(predicate, defaultValue);
        }
    }

    internal class LastOrDefaultConsumer<TSource> : IEnumerableConsumer<TSource, TSource?>
    {
        private readonly TSource? _defaultValue;

        public LastOrDefaultConsumer(TSource? defaultValue)
        {
            _defaultValue = defaultValue;
        }

        public IEnumerableSink<TSource, TSource?> GetSink()
        {
            return new Sink(_defaultValue);
        }

        private class Sink : IEnumerableSink<TSource, TSource?>
        {
            private TSource? _result;

            public Sink(TSource? defaultValue)
            {
                _result = defaultValue;
            }

            public bool AcceptFirst(TSource element)
            {
                _result = element;
                return true;
            }

            public bool AcceptNext(TSource element)
            {
                _result = element;
                return true;
            }

            public void Dispose()
            {
            }

            public TSource? GetResult()
            {
                return _result;
            }
        }
    }

    internal class LastOrDefaultWithPredicateConsumer<TSource> : IEnumerableConsumer<TSource, TSource?>
    {
        private readonly Func<TSource, bool> _predicate;

        private readonly TSource? _defaultValue;

        public LastOrDefaultWithPredicateConsumer(Func<TSource, bool> predicate, TSource? defaultValue)
        {
            _predicate = predicate;
            _defaultValue = defaultValue;
        }

        public IEnumerableSink<TSource, TSource?> GetSink()
        {
            return new Sink(_predicate, _defaultValue);
        }

        private class Sink : IEnumerableSink<TSource, TSource?>
        {
            private readonly Func<TSource, bool> _predicate;

            private TSource? _result;

            public Sink(Func<TSource, bool> predicate, TSource? defaultValue)
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
                if (_predicate(element))
                    _result = element;

                return true;
            }

            public void Dispose()
            {
            }

            public TSource? GetResult()
            {
                return _result;
            }
        }
    }
}