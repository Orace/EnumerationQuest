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

namespace EnumerationQuest.Consumers
{
    internal static partial class ConsumerFactory
    {
        public static IEnumerableConsumer<TSource, bool> Contains<TSource>(TSource value)
        {
            return new ContainsConsumer<TSource>(value, EqualityComparer<TSource>.Default);
        }

        public static IEnumerableConsumer<TSource, bool> Contains<TSource>(
            TSource value, IEqualityComparer<TSource> comparer)
        {
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new ContainsConsumer<TSource>(value, comparer);
        }
    }

    internal class ContainsConsumer<TSource> : IEnumerableConsumer<TSource, bool>
    {
        private readonly TSource _value;

        private readonly IEqualityComparer<TSource> _comparer;

        public ContainsConsumer(TSource value, IEqualityComparer<TSource> comparer)
        {
            _value = value;
            _comparer = comparer;
        }

        public IEnumerableSink<TSource, bool> GetSink()
        {
            return new Sink(_value, _comparer);
        }

        private class Sink : IEnumerableSink<TSource, bool>
        {
            private readonly TSource _value;
            private readonly IEqualityComparer<TSource> _comparer;

            private bool _result;

            public Sink(TSource value, IEqualityComparer<TSource> comparer)
            {
                _value = value;
                _comparer = comparer;
            }

            public bool AcceptFirst(TSource element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(TSource element)
            {
                if (_result)
                    return false;

                if (!_comparer.Equals(_value, element))
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
}