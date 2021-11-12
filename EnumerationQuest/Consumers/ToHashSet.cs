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
        public static IEnumerableConsumer<TSource, HashSet<TSource>> ToHashSet<TSource>()
        {
            return new ToHashSetConsumer<TSource>(EqualityComparer<TSource>.Default);
        }

        public static IEnumerableConsumer<TSource, HashSet<TSource>> ToHashSet<TSource>(IEqualityComparer<TSource> comparer)
        {
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new ToHashSetConsumer<TSource>(comparer);
        }
    }

    internal class ToHashSetConsumer<TSource> : IEnumerableConsumer<TSource, HashSet<TSource>>
    {
        private readonly IEqualityComparer<TSource> _comparer;

        public ToHashSetConsumer(IEqualityComparer<TSource> comparer)
        {
            _comparer = comparer;
        }

        public IEnumerableSink<TSource, HashSet<TSource>> GetSink()
        {
            return new ToHashSetSink<TSource>(_comparer);
        }
    }

    internal class ToHashSetSink<TSource> : IEnumerableSink<TSource, HashSet<TSource>>
    {
        private readonly HashSet<TSource> _hashSet;

        public ToHashSetSink(IEqualityComparer<TSource> comparer)
        {
            _hashSet = new HashSet<TSource>(comparer);
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            _hashSet.Add(element);
            return true;
        }

        public void Dispose()
        {
            _hashSet.Clear();
        }

        public HashSet<TSource> GetResult()
        {
            return _hashSet;
        }
    }
}