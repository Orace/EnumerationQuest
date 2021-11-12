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
        public static IEnumerableConsumer<TSource, TSource?> MaxBy<TSource, TKey>(Func<TSource, TKey> keySelector)
        {
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));
            
            return new MaxByConsumer<TSource, TKey>(keySelector, Comparer<TKey>.Default);
        }

        public static IEnumerableConsumer<TSource, TSource?> MaxBy<TSource, TKey>(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new MaxByConsumer<TSource, TKey>(keySelector, comparer);
        }
    }

    internal class MaxByConsumer<TSource, TKey> : IEnumerableConsumer<TSource, TSource?>
    {
        private readonly Func<TSource, TKey> _keySelector;
        private readonly IComparer<TKey> _comparer;

        public MaxByConsumer(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _comparer = comparer;
        }

        public IEnumerableSink<TSource, TSource?> GetSink()
        {
            return new MaxBySink<TSource, TKey>(_keySelector, _comparer);
        }
    }

    internal class MaxBySink<TSource, TKey> : IEnumerableSink<TSource, TSource?>
    {
        private readonly Func<TSource, TKey> _keySelector;
        private readonly IComparer<TKey> _comparer;

        private TKey? _bestKey;
        private TSource? _result;
        private int _state;

        public MaxBySink(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _comparer = comparer;
        }

        public bool AcceptFirst(TSource element)
        {
            _state = 1;
            _result = element;

            return true;
        }

        public bool AcceptNext(TSource element)
        {
            switch (_state)
            {
                case 0:
                    return false;
                case 1:
                    _bestKey = _keySelector(_result!);
                    _state = 2;
                    break;
            }

            var key = _keySelector(element);

            if (_comparer.Compare(key, _bestKey!) > 0)
            {
                _bestKey = key;
                _result = element;
            }

            return true;
        }

        public void Dispose()
        {
            _bestKey = default;
            _result = default;
            _state = 0;
        }

        public TSource? GetResult()
        {
            if (_state > 0)
                return _result;

            if (default(TSource) is null)
                return default;

            throw new InvalidOperationException("Sequence was empty");
        }
    }
}