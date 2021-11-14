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
        public static IEnumerableConsumer<TSource, List<TSource>> MinimumsBy<TSource, TKey>(Func<TSource, TKey> keySelector)
        {
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            return new MinimumsByConsumer<TSource, TKey>(keySelector, Comparer<TKey>.Default);
        }

        public static IEnumerableConsumer<TSource, List<TSource>> MinimumsBy<TSource, TKey>(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new MinimumsByConsumer<TSource, TKey>(keySelector, comparer);
        }
    }

    internal class MinimumsByConsumer<TSource, TKey> : IEnumerableConsumer<TSource, List<TSource>>
    {
        private readonly Func<TSource, TKey> _keySelector;
        private readonly IComparer<TKey> _comparer;

        public MinimumsByConsumer(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _comparer = comparer;
        }

        public IEnumerableSink<TSource, List<TSource>> GetSink()
        {
            return new Sink(_keySelector, _comparer);
        }

        private class Sink : IEnumerableSink<TSource, List<TSource>>
        {
            private readonly List<TSource> _result = new();

            private readonly Func<TSource, TKey> _keySelector;
            private readonly IComparer<TKey> _comparer;

            private TKey? _bestKey;

            public Sink(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
            {
                _keySelector = keySelector;
                _comparer = comparer;
            }

            public bool AcceptFirst(TSource element)
            {
                _bestKey = _keySelector(element);
                _result.Add(element);
                return true;
            }

            public bool AcceptNext(TSource element)
            {
                var key = _keySelector(element);

                var comparison = (key, _bestKey) switch
                {
                    (null, null) => 0,
                    (null, _) => 1,
                    (_, null) => -1,
                    (_, _) => _comparer.Compare(key, _bestKey!),
                };

                switch (comparison )
                {
                    case > 0:
                        return true;
                    case < 0:
                        _result.Clear();
                        _bestKey = key;
                        break;
                }

                _result.Add(element);
                return true;
            }

            public void Dispose()
            {
            }

            public List<TSource> GetResult()
            {
                _result.TrimExcess();
                return _result;
            }
        }
    }
}