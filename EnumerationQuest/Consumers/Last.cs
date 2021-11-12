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
        public static IEnumerableConsumer<TSource, TSource> Last<TSource>()
        {
            return new LastConsumer<TSource>();
        }

        public static IEnumerableConsumer<TSource, TSource> Last<TSource>(Func<TSource, bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            
            return new LastWithPredicateConsumer<TSource>(predicate);
        }
    }

    internal class LastConsumer<TSource> : IEnumerableConsumer<TSource, TSource>
    {
        public IEnumerableSink<TSource, TSource> GetSink()
        {
            return new LastSink<TSource>();
        }
    }

    internal class LastSink<TSource> : IEnumerableSink<TSource, TSource>
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
            _result = element;
            return true;
        }

        public void Dispose()
        {
            _hasContent = false;
            _result = default;
        }

        public TSource GetResult()
        {
            return _hasContent ? _result! : throw new InvalidOperationException("Sequence was empty");
        }
    }

    internal class LastWithPredicateConsumer<TSource> : IEnumerableConsumer<TSource, TSource>
    {
        private readonly Func<TSource, bool> _predicate;

        public LastWithPredicateConsumer(Func<TSource, bool> predicate)
        {
            _predicate = predicate;
        }

        public IEnumerableSink<TSource, TSource> GetSink()
        {
            return new LastWithPredicateSink<TSource>(_predicate);
        }
    }

    internal class LastWithPredicateSink<TSource> : IEnumerableSink<TSource, TSource>
    {
        private readonly Func<TSource, bool> _predicate;

        private bool _hasContent;
        private TSource? _result;
        
        public LastWithPredicateSink(Func<TSource, bool> predicate)
        {
            _predicate = predicate;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            if (!_predicate(element))
                return true;
            
            _hasContent = true;
            _result = element;
            return true;
        }

        public void Dispose()
        {
            _hasContent = false;
            _result = default;
        }

        public TSource GetResult()
        {
            return _hasContent ? _result! : throw new InvalidOperationException("The sequence contains no elements that match the predicate");
        }
    }
}