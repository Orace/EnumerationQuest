﻿// EnumerableQuest - Avoids multiple enumeration
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
        public static IEnumerableConsumer<TSource, bool> SequenceEqual<TSource>(IEnumerable<TSource> other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            return new SequenceEqualConsumer<TSource>(other, EqualityComparer<TSource>.Default);
        }

        public static IEnumerableConsumer<TSource, bool> SequenceEqual<TSource>(IEnumerable<TSource> other, IEqualityComparer<TSource> comparer)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other));

            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new SequenceEqualConsumer<TSource>(other, comparer);
        }
    }

    internal class SequenceEqualConsumer<TSource> : IEnumerableConsumer<TSource, bool>
    {
        private readonly IEnumerable<TSource> _other;
        private readonly IEqualityComparer<TSource> _comparer;

        public SequenceEqualConsumer(IEnumerable<TSource> other, IEqualityComparer<TSource> comparer)
        {
            _other = other;
            _comparer = comparer;
        }

        public IEnumerableSink<TSource, bool> GetSink()
        {
            return new SequenceEqualSink<TSource>(_other, _comparer);
        }
    }

    internal class SequenceEqualSink<TSource> : IEnumerableSink<TSource, bool>
    {
        private readonly IEnumerable<TSource> _other;
        private readonly IEqualityComparer<TSource> _comparer;

        private bool _areSequenceEqual = true;
        private IEnumerator<TSource>? _enumerator;

        public SequenceEqualSink(IEnumerable<TSource> other, IEqualityComparer<TSource> comparer)
        {
            _other = other;
            _comparer = comparer;
        }

        public bool AcceptFirst(TSource element)
        {
            _enumerator?.Dispose();
            _enumerator = _other.GetEnumerator();
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            if (!_areSequenceEqual || _enumerator is null)
                return false;
            
            _areSequenceEqual = _enumerator.MoveNext() && _comparer.Equals(_enumerator.Current, element);
            return _areSequenceEqual;
        }

        public void Dispose()
        {
            GetResult();
        }

        public bool GetResult()
        {
            if (_enumerator is null)
                return _areSequenceEqual;

            if (_areSequenceEqual)
                _areSequenceEqual = !_enumerator.MoveNext();

            _enumerator?.Dispose();
            _enumerator = null;

            return _areSequenceEqual;
        }
    }
}