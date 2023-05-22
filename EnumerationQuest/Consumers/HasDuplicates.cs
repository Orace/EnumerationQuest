// EnumerableQuest - Avoids multiple enumeration
// 
// Copyright 2023 Pierre Lando
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
        public static IEnumerableConsumer<TSource, bool> HasDuplicates<TSource>()
        {
            return new HasDuplicatesConsumer<TSource>(EqualityComparer<TSource>.Default);
        }

        public static IEnumerableConsumer<TSource, bool> HasDuplicates<TSource>(IEqualityComparer<TSource> comparer)
        {
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new HasDuplicatesConsumer<TSource>(comparer);
        }

        public static IEnumerableConsumer<TSource, bool> HasDuplicates<TSource, TKey>(Func<TSource, TKey> keySelector)
        {
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));
            
            return new HasDuplicatesConsumer<TSource, TKey>(keySelector, EqualityComparer<TKey>.Default);
        }

        public static IEnumerableConsumer<TSource, bool> HasDuplicates<TSource, TKey>(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));
            
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new HasDuplicatesConsumer<TSource, TKey>(keySelector, comparer);
        }
    }

    internal class HasDuplicatesConsumer<TSource> : IEnumerableConsumer<TSource, bool>
    {
        private readonly IEqualityComparer<TSource> _comparer;

        public HasDuplicatesConsumer(IEqualityComparer<TSource> comparer)
        {
            _comparer = comparer;
        }

        public IEnumerableSink<TSource, bool> GetSink()
        {
            return new Sink(_comparer);
        }

        private class Sink : IEnumerableSink<TSource, bool>
        {
            private bool _result;
            private ISet<TSource>? _set;

            public Sink(IEqualityComparer<TSource> comparer)
            {
                _set = new HashSet<TSource>(comparer);
            }

            public bool AcceptFirst(TSource element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(TSource element)
            {
                if (_set is null)
                    return false;

                if (_set.Add(element))
                    return true;

                _result = true;
                _set = null;

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

    internal class HasDuplicatesConsumer<TSource, TKey> : IEnumerableConsumer<TSource, bool>
    {
        private readonly IEqualityComparer<TKey> _comparer;
        private readonly Func<TSource, TKey> _keySelector;

        public HasDuplicatesConsumer(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            _keySelector = keySelector;
            _comparer = comparer;
        }

        public IEnumerableSink<TSource, bool> GetSink()
        {
            return new Sink(_keySelector, _comparer);
        }

        private class Sink : IEnumerableSink<TSource, bool>
        {
            private readonly Func<TSource, TKey> _keySelector;

            private bool _result;
            private ISet<TKey>? _set;

            public Sink(Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
            {
                _keySelector = keySelector;
                _set = new HashSet<TKey>(comparer);
            }

            public bool AcceptFirst(TSource element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(TSource element)
            {
                if (_set is null)
                    return false;

                var key = _keySelector(element);
                if (_set.Add(key))
                    return true;

                _result = true;
                _set = null;

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