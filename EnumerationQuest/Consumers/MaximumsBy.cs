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
        public static IEnumerableConsumer<TSource, List<TSource>> MaximumsBy<TSource, TKey>(Func<TSource, TKey> keySelector)
        {
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            return new MaximumsByConsumer<TSource, TKey>(keySelector, Comparer<TKey>.Default);
        }

        public static IEnumerableConsumer<TSource, List<TSource>> MaximumsBy<TSource, TKey>(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new MaximumsByConsumer<TSource, TKey>(keySelector, comparer);
        }
    }

    internal class MaximumsByConsumer<TSource, TKey> : IEnumerableConsumer<TSource, List<TSource>>
    {
        private readonly Func<TSource, TKey> _keySelector;
        private readonly IComparer<TKey> _comparer;

        public MaximumsByConsumer(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _comparer = comparer;
        }

        public IEnumerableSink<TSource, List<TSource>> GetSink()
        {
            return new MaximumsBySink<TSource, TKey>(_keySelector, _comparer);
        }
    }

    internal class MaximumsBySink<TSource, TKey> : IEnumerableSink<TSource, List<TSource>>
    {
        private readonly Func<TSource, TKey> _keySelector;
        private readonly IComparer<TKey> _comparer;

        private TKey? _bestKey;
        private bool _isBestKeyDefined;
        private List<TSource>? _result;

        public MaximumsBySink(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _comparer = comparer;
        }

        public bool AcceptFirst(TSource element)
        {
            _result = new List<TSource> { element };
            return true;
        }

        public bool AcceptNext(TSource element)
        {
            if (_result is null || _result.Count == 0)
                return false;

            if (!_isBestKeyDefined)
            {
                _bestKey = _keySelector(_result[0]);
                _isBestKeyDefined = true;
            }

            var key = _keySelector(element);
            switch (_comparer.Compare(key, _bestKey!))
            {
                case < 0:
                    return true;
                case > 0:
                    _result.Clear();
                    _bestKey = key;
                    break;
            }

            _result.Add(element);
            return true;
        }

        public void Dispose()
        {
            _bestKey = default;
            _result = default;
        }

        public List<TSource> GetResult()
        {
            if (_result is null)
                return new List<TSource>();

            _result.TrimExcess();
            return _result;
        }
    }
}