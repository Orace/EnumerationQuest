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
        public static IEnumerableConsumer<TSource, List<TSource>> ElementsAt<TSource>(IEnumerable<int> indices)
        {
            if (indices is null)
                throw new ArgumentNullException(nameof(indices));
            
            return new ElementsAtConsumer<TSource>(indices);
        }
    }

    internal class ElementsAtConsumer<TSource> : IEnumerableConsumer<TSource, List<TSource>>
    {
        private readonly IEnumerable<int> _indices;

        public ElementsAtConsumer(IEnumerable<int> indices)
        {
            _indices = indices;
        }

        public IEnumerableSink<TSource, List<TSource>> GetSink()
        {
            return new Sink(_indices);
        }

        private class Sink : IEnumerableSink<TSource, List<TSource>>
        {
            private readonly List<TSource> _result = new();

            private IEnumerator<int>? _enumerator;
            private int _index;
            private int _nextIndex;

            public Sink(IEnumerable<int> indices)
            {
                _enumerator = indices.GetEnumerator();

                if (_enumerator.MoveNext())
                {
                    _nextIndex = _enumerator.Current;
                    if (_nextIndex < 0)
                        throw new ArgumentException("The index sequence contains a negative value");
                }
                else
                {
                    _enumerator.Dispose();
                    _enumerator = null;
                }
            }

            public bool AcceptFirst(TSource element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(TSource element)
            {
                if (_enumerator is null)
                    return false;

                while (_nextIndex == _index)
                {
                    _result.Add(element);
                    if (_enumerator.MoveNext())
                    {
                        _nextIndex = _enumerator.Current;
                        if (_nextIndex < _index)
                            throw new ArgumentException("The index sequence is not in increasing order");
                    }
                    else
                    {
                        _enumerator.Dispose();
                        _enumerator = null;
                        return false;
                    }
                }

                _index++;
                return true;
            }

            public void Dispose()
            {
                _enumerator?.Dispose();
                _enumerator = default;
            }

            public List<TSource> GetResult()
            {
                if (_enumerator is not null)
                    throw new ArgumentException("The index sequence contains a value greater or equal than the source sequence length");

                return _result;
            }
        }
    }
}