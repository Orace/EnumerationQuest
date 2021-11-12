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
        public static IEnumerableConsumer<TSource, TSource?> ElementAtOrDefault<TSource>(Index index)
        {
            if (index.Equals(Index.End))
                return new ElementAtOrDefaultConsumer<TSource>(-1);

            return index.IsFromEnd
                       ? new ElementAtOrDefaultFromEndConsumer<TSource>(index.Value)
                       : new ElementAtOrDefaultConsumer<TSource>(index.Value);
        }

        public static IEnumerableConsumer<TSource, TSource?> ElementAtOrDefault<TSource>(int index)
        {
            if (index < 0)
                index = -1;

            return new ElementAtOrDefaultConsumer<TSource>(index);
        }
    }

    internal class ElementAtOrDefaultConsumer<TSource> : IEnumerableConsumer<TSource, TSource?>
    {
        private readonly int _index;

        public ElementAtOrDefaultConsumer(int index)
        {
            _index = index;
        }

        public IEnumerableSink<TSource, TSource?> GetSink()
        {
            return new ElementAtOrDefaultSink<TSource>(_index);
        }
    }

    internal class ElementAtOrDefaultSink<TSource> : IEnumerableSink<TSource, TSource?>
    {
        private int _index;
        private TSource? _result;

        public ElementAtOrDefaultSink(int index)
        {
            _index = index;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            if (_index == -1)
                return false;

            _index--;

            if (_index != -1)
                return true;

            _result = element;
            return false;
        }

        public void Dispose()
        {
            _result = default;
        }

        public TSource? GetResult()
        {
            return _index < 0 ? _result : default;
        }
    }

    internal class ElementAtOrDefaultFromEndConsumer<TSource> : IEnumerableConsumer<TSource, TSource?>
    {
        private readonly int _index;

        public ElementAtOrDefaultFromEndConsumer(int index)
        {
            _index = index;
        }

        public IEnumerableSink<TSource, TSource?> GetSink()
        {
            return new ElementAtOrDefaultFromEndSink<TSource>(_index);
        }
    }

    internal class ElementAtOrDefaultFromEndSink<TSource> : IEnumerableSink<TSource, TSource?>
    {
        private readonly int _count;
        private readonly Queue<TSource> _queue;

        public ElementAtOrDefaultFromEndSink(int count)
        {
            _count = count;
            _queue = new Queue<TSource>(count + 1);
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            _queue.Enqueue(element);
            if (_queue.Count > _count)
                _queue.Dequeue();

            return true;
        }

        public void Dispose()
        {
            _queue.Clear();
        }

        public TSource? GetResult()
        {
            return _queue.Count == _count ? _queue.Peek() : default;
        }
    }
}