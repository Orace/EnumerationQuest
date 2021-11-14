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
        public static IEnumerableConsumer<TSource, TSource> First<TSource>()
        {
            return new FirstConsumer<TSource>();
        }

        public static IEnumerableConsumer<TSource, TSource> First<TSource>(Func<TSource, bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            
            return new FirstWithPredicateConsumer<TSource>(predicate);
        }
    }

    internal class FirstConsumer<TSource> : IEnumerableConsumer<TSource, TSource>
    {
        public IEnumerableSink<TSource, TSource> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<TSource, TSource>
        {
            private bool _hasContent;
            private TSource? _result;

            public bool AcceptFirst(TSource element)
            {
                _hasContent = true;
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

            public TSource GetResult()
            {
                return _hasContent ? _result! : throw new InvalidOperationException("Sequence was empty");
            }
        }
    }

    internal class FirstWithPredicateConsumer<TSource> : IEnumerableConsumer<TSource, TSource>
    {
        private readonly Func<TSource, bool> _predicate;

        public FirstWithPredicateConsumer(Func<TSource, bool> predicate)
        {
            _predicate = predicate;
        }

        public IEnumerableSink<TSource, TSource> GetSink()
        {
            return new Sink(_predicate);
        }

        private class Sink : IEnumerableSink<TSource, TSource>
        {
            private readonly Func<TSource, bool> _predicate;

            private bool _hasContent;
            private TSource? _result;

            public Sink(Func<TSource, bool> predicate)
            {
                _predicate = predicate;
            }

            public bool AcceptFirst(TSource element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(TSource element)
            {
                if (_hasContent)
                    return false;

                if (!_predicate(element))
                    return true;

                _hasContent = true;
                _result = element;

                return false;
            }

            public void Dispose()
            {
            }

            public TSource GetResult()
            {
                return _hasContent ? _result! : throw new InvalidOperationException("The sequence contains no elements that match the predicate");
            }
        }
    }
}