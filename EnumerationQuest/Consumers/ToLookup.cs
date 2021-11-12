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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EnumerationQuest.Consumers
{
    internal static partial class ConsumerFactory
    {
        public static IEnumerableConsumer<TSource, ILookup<TKey, TSource>> ToLookup<TSource, TKey>(Func<TSource, TKey> keySelector)
            where TKey : notnull
        {
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            return new ToLookupConsumer<TSource, TKey>(keySelector, EqualityComparer<TKey>.Default);
        }

        public static IEnumerableConsumer<TSource, ILookup<TKey, TSource>> ToLookup<TSource, TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
            where TKey : notnull
        {
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new ToLookupConsumer<TSource, TKey>(keySelector, comparer);
        }

        public static IEnumerableConsumer<TSource, ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
            where TKey : notnull
        {
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            if (elementSelector is null)
                throw new ArgumentNullException(nameof(elementSelector));

            return new ToLookupWithElementSelectorConsumer<TSource, TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
        }

        public static IEnumerableConsumer<TSource, ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
            where TKey : notnull
        {
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            if (elementSelector is null)
                throw new ArgumentNullException(nameof(elementSelector));

            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new ToLookupWithElementSelectorConsumer<TSource, TKey, TElement>(keySelector, elementSelector, comparer);
        }
    }

    internal class ToLookupConsumer<TSource, TKey> : IEnumerableConsumer<TSource, ILookup<TKey, TSource>>
        where TKey : notnull
    {
        private readonly Func<TSource, TKey> _keySelector;
        private readonly IEqualityComparer<TKey> _comparer;

        public ToLookupConsumer(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _comparer = comparer;
        }

        public IEnumerableSink<TSource, ILookup<TKey, TSource>> GetSink()
        {
            return new ToLookupSink<TSource, TKey>(_keySelector, _comparer);
        }
    }

    internal class ToLookupSink<TSource, TKey> : IEnumerableSink<TSource, ILookup<TKey, TSource>>
        where TKey : notnull
    {
        private readonly Func<TSource, TKey> _keySelector;
        private readonly IEqualityComparer<TKey> _comparer;

        private Dictionary<TKey, List<TSource>>? _result;

        public ToLookupSink(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _comparer = comparer;
        }

        public bool AcceptFirst(TSource element)
        {
            _result = new Dictionary<TKey, List<TSource>>(_comparer);
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            if (_result is null)
                return false;

            var key = _keySelector(element);
            if (_result.TryGetValue(key, out var list))
            {
                list.Add(element);
            }
            else
            {
                list = new List<TSource> { element };
                _result.Add(key, list);
            }

            return true;
        }

        public void Dispose()
        {
            _result?.Clear();
            _result?.TrimExcess();
            _result = null;
        }

        public ILookup<TKey, TSource> GetResult()
        {
            return new LookupWrapper<TKey, TSource>(_result ?? new Dictionary<TKey, List<TSource>>());
        }
    }

    internal class ToLookupWithElementSelectorConsumer<TSource, TKey, TElement> : IEnumerableConsumer<TSource, ILookup<TKey, TElement>>
        where TKey : notnull
    {
        private readonly Func<TSource, TKey> _keySelector;
        private readonly Func<TSource, TElement> _elementSelector;
        private readonly IEqualityComparer<TKey> _comparer;

        public ToLookupWithElementSelectorConsumer(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _elementSelector = elementSelector;
            _comparer = comparer;
        }

        public IEnumerableSink<TSource, ILookup<TKey, TElement>> GetSink()
        {
            return new ToLookupWithElementSelectorSink<TSource, TKey, TElement>(_keySelector, _elementSelector, _comparer);
        }
    }

    internal class ToLookupWithElementSelectorSink<TSource, TKey, TElement> : IEnumerableSink<TSource, ILookup<TKey, TElement>>
        where TKey : notnull
    {
        private readonly Func<TSource, TKey> _keySelector;
        private readonly Func<TSource, TElement> _elementSelector;
        private readonly IEqualityComparer<TKey> _comparer;

        private Dictionary<TKey, List<TElement>>? _result;

        public ToLookupWithElementSelectorSink(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _elementSelector = elementSelector;
            _comparer = comparer;
        }

        public bool AcceptFirst(TSource element)
        {
            _result = new Dictionary<TKey, List<TElement>>(_comparer);
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            if (_result is null)
                return false;

            var key = _keySelector(element);
            var value = _elementSelector(element);
            if (_result.TryGetValue(key, out var list))
            {
                list.Add(value);
            }
            else
            {
                list = new List<TElement> { value };
                _result.Add(key, list);
            }

            return true;
        }

        public void Dispose()
        {
            _result?.Clear();
            _result?.TrimExcess();
            _result = null;
        }

        public ILookup<TKey, TElement> GetResult()
        {
            return new LookupWrapper<TKey, TElement>(_result ?? new Dictionary<TKey, List<TElement>>());
        }
    }

    internal class LookupWrapper<TKey, TElement> : ILookup<TKey, TElement> where TKey : notnull
    {
        private readonly Dictionary<TKey, List<TElement>> _dictionary;

        public LookupWrapper(Dictionary<TKey, List<TElement>> dictionary)
        {
            _dictionary = dictionary;
        }

        public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
        {
            foreach (var (key, value) in _dictionary)
            {
                yield return new Grouping(key, value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public bool Contains(TKey key) => _dictionary.ContainsKey(key);

        public int Count => _dictionary.Count;

        public IEnumerable<TElement> this[TKey key] => _dictionary[key];

        private class Grouping : IGrouping<TKey, TElement>
        {
            private readonly IEnumerable<TElement> _elements;

            public Grouping(TKey key, IEnumerable<TElement> elements)
            {
                _elements = elements;
                Key = key;
            }

            public IEnumerator<TElement> GetEnumerator() => _elements.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public TKey Key { get; }
        }
    }
}