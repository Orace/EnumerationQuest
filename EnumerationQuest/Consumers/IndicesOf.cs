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
        public static IEnumerableConsumer<TSource, List<int>> IndicesOf<TSource>(TSource value)
        {
            return new IndicesOfConsumer<TSource>(value, EqualityComparer<TSource>.Default);
        }

        public static IEnumerableConsumer<TSource, List<int>> IndicesOf<TSource>(TSource value, IEqualityComparer<TSource> comparer)
        {
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new IndicesOfConsumer<TSource>(value, comparer);
        }
    }

    internal class IndicesOfConsumer<TSource> : IEnumerableConsumer<TSource, List<int>>
    {
        private readonly TSource _value;

        private readonly IEqualityComparer<TSource> _comparer;

        public IndicesOfConsumer(TSource value, IEqualityComparer<TSource> comparer)
        {
            _value = value;
            _comparer = comparer;
        }

        public IEnumerableSink<TSource, List<int>> GetSink()
        {
            return new Sink(_value, _comparer);
        }

        private class Sink : IEnumerableSink<TSource, List<int>>
        {
            private List<int> _result = new();

            private readonly TSource _value;
            private readonly IEqualityComparer<TSource> _comparer;

            private int _index;

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
                if (_comparer.Equals(element, _value))
                    _result.Add(_index);

                checked
                {
                    _index++;
                }

                return true;
            }

            public void Dispose()
            {
            }

            public List<int> GetResult()
            {
                return _result;
            }
        }
    }
}