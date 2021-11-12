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
        public static IEnumerableConsumer<TSource, Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(Func<TSource, TKey> keySelector)
            where TKey : notnull
        {
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            return new ToDictionaryConsumer<TSource, TKey>(keySelector, EqualityComparer<TKey>.Default);
        }

        public static IEnumerableConsumer<TSource, Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
            where TKey : notnull
        {
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new ToDictionaryConsumer<TSource, TKey>(keySelector, comparer);
        }

        public static IEnumerableConsumer<TSource, Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
            where TKey : notnull
        {
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            if (elementSelector is null)
                throw new ArgumentNullException(nameof(elementSelector));

            return new ToDictionaryWithElementSelectorConsumer<TSource, TKey, TElement>(keySelector, elementSelector, EqualityComparer<TKey>.Default);
        }

        public static IEnumerableConsumer<TSource, Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
            where TKey : notnull
        {
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));

            if (elementSelector is null)
                throw new ArgumentNullException(nameof(elementSelector));

            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));
            
            return new ToDictionaryWithElementSelectorConsumer<TSource, TKey, TElement>(keySelector, elementSelector, comparer);
        }
    }

    internal class ToDictionaryConsumer<TSource, TKey> : IEnumerableConsumer<TSource, Dictionary<TKey, TSource>>
        where TKey : notnull
    {
        private readonly Func<TSource, TKey> _keySelector;
        private readonly IEqualityComparer<TKey> _comparer;

        public ToDictionaryConsumer(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _comparer = comparer;
        }

        public IEnumerableSink<TSource, Dictionary<TKey, TSource>> GetSink()
        {
            return new ToDictionarySink<TSource, TKey>(_keySelector, _comparer);
        }
    }

    internal class ToDictionarySink<TSource, TKey> : IEnumerableSink<TSource, Dictionary<TKey, TSource>>
        where TKey : notnull
    {
        private readonly Dictionary<TKey, TSource> _dictionary;
        private readonly Func<TSource, TKey> _keySelector;

        public ToDictionarySink(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            _keySelector = keySelector;

            _dictionary = new Dictionary<TKey, TSource>(comparer);
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            _dictionary.Add(_keySelector(element), element);
            return true;
        }

        public void Dispose()
        {
            _dictionary.Clear();
        }

        public Dictionary<TKey, TSource> GetResult()
        {
            return _dictionary;
        }
    }

    internal class ToDictionaryWithElementSelectorConsumer<TSource, TKey, TElement> : IEnumerableConsumer<TSource, Dictionary<TKey, TElement>>
        where TKey : notnull
    {
        private readonly Func<TSource, TKey> _keySelector;
        private readonly Func<TSource, TElement> _elementSelector;
        private readonly IEqualityComparer<TKey> _comparer;

        public ToDictionaryWithElementSelectorConsumer(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _elementSelector = elementSelector;
            _comparer = comparer;
        }

        public IEnumerableSink<TSource, Dictionary<TKey, TElement>> GetSink()
        {
            return new ToDictionaryWithElementSelectorSink<TSource, TKey, TElement>(_keySelector, _elementSelector, _comparer);
        }
    }

    internal class ToDictionaryWithElementSelectorSink<TSource, TKey, TElement> : IEnumerableSink<TSource, Dictionary<TKey, TElement>>
        where TKey : notnull
    {
        private readonly Func<TSource, TElement> _elementSelector;
        private readonly Dictionary<TKey, TElement> _dictionary;
        private readonly Func<TSource, TKey> _keySelector;

        public ToDictionaryWithElementSelectorSink(Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _elementSelector = elementSelector;

            _dictionary = new Dictionary<TKey, TElement>(comparer);
        }
        
        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            _dictionary.Add(_keySelector(element), _elementSelector(element));
            return true;
        }

        public void Dispose()
        {
            _dictionary.Clear();
        }

        public Dictionary<TKey, TElement> GetResult()
        {
            return _dictionary;
        }
    }
}