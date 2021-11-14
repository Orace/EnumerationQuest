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
        public static IEnumerableConsumer<TSource, TSource?> FirstOrDefault<TSource>()
        {
            return new FirstOrDefaultConsumer<TSource>(default);
        }

        public static IEnumerableConsumer<TSource, TSource?> FirstOrDefault<TSource>(TSource? defaultValue)
        {
            return new FirstOrDefaultConsumer<TSource>(defaultValue);
        }

        public static IEnumerableConsumer<TSource, TSource?> FirstOrDefault<TSource>(Func<TSource, bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            
            return new FirstOrDefaultWithPredicateConsumer<TSource>(predicate, default);
        }

        public static IEnumerableConsumer<TSource, TSource?> FirstOrDefault<TSource>(Func<TSource, bool> predicate, TSource? defaultValue)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            
            return new FirstOrDefaultWithPredicateConsumer<TSource>(predicate, defaultValue);
        }
    }

    internal class FirstOrDefaultConsumer<TSource> : IEnumerableConsumer<TSource, TSource?>
    {
        private readonly TSource? _defaultValue;

        public FirstOrDefaultConsumer(TSource? defaultValue)
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
                return false;
            }

            public bool AcceptNext(TSource element)
            {
                return false;
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

    internal class FirstOrDefaultWithPredicateConsumer<TSource> : IEnumerableConsumer<TSource, TSource?>
    {
        private readonly Func<TSource, bool> _predicate;

        private readonly TSource? _defaultValue;

        public FirstOrDefaultWithPredicateConsumer(Func<TSource, bool> predicate, TSource? defaultValue)
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

            private bool _hasResult;
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
                if (_hasResult)
                    return false;

                if (!_predicate(element))
                    return true;

                _result = element;
                _hasResult = true;

                return false;
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