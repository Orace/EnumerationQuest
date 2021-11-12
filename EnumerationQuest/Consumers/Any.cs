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
        public static IEnumerableConsumer<TSource, bool> Any<TSource>()
        {
            return new AnyConsumer<TSource>();
        }

        public static IEnumerableConsumer<TSource, bool> Any<TSource>(Func<TSource, bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            return new AnyWithPredicateConsumer<TSource>(predicate);
        }
    }

    internal class AnyConsumer<TSource> : IEnumerableConsumer<TSource, bool>
    {
        public IEnumerableSink<TSource, bool> GetSink()
        {
            return new AnySink<TSource>();
        }
    }

    internal class AnySink<TSource> : IEnumerableSink<TSource, bool>
    {
        private bool _result;

        public bool AcceptFirst(TSource element)
        {
            _result = true;
            return false;
        }

        public bool AcceptNext(TSource element)
        {
            return false;
        }

        public void Dispose()
        {
        }

        public bool GetResult()
        {
            return _result;
        }
    }

    internal class AnyWithPredicateConsumer<TSource> : IEnumerableConsumer<TSource, bool>
    {
        private readonly Func<TSource, bool> _predicate;

        public AnyWithPredicateConsumer(Func<TSource, bool> predicate)
        {
            _predicate = predicate;
        }

        public IEnumerableSink<TSource, bool> GetSink()
        {
            return new AnyWithPredicateSink<TSource>(_predicate);
        }
    }

    internal class AnyWithPredicateSink<TSource> : IEnumerableSink<TSource, bool>
    {
        private readonly Func<TSource, bool> _predicate;

        private bool _result;

        public AnyWithPredicateSink(Func<TSource, bool> predicate)
        {
            _predicate = predicate;
        }
        
        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            if (_result)
                return false;

            if (!_predicate(element))
                return true;

            _result = true;
            return false;
        }

        public void Dispose()
        {
        }

        public bool GetResult()
        {
            return _result;
        }
    }
}