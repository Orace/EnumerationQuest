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
        public static IEnumerableConsumer<TSource, TSource> ElementAt<TSource>(Index index)
        {
            if (index.Equals(Index.End))
                throw new ArgumentOutOfRangeException(nameof(index), index, "after end index is not a valid value");

            return index.IsFromEnd
                       ? new ElementAtFromEndConsumer<TSource>(index.Value)
                       : new ElementAtConsumer<TSource>(index.Value);
        }

        public static IEnumerableConsumer<TSource, TSource> ElementAt<TSource>(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), index, "value must not be negative");

            return new ElementAtConsumer<TSource>(index);
        }
    }

    internal class ElementAtConsumer<TSource> : IEnumerableConsumer<TSource, TSource>
    {
        private readonly int _index;

        public ElementAtConsumer(int index)
        {
            _index = index;
        }

        public IEnumerableSink<TSource, TSource> GetSink()
        {
            return new Sink(_index);
        }

        private class Sink : IEnumerableSink<TSource, TSource>
        {
            private int _index;
            private TSource? _result;

            public Sink(int index)
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
            }

            public TSource GetResult()
            {
                return _index == -1 ? _result! : throw new ArgumentOutOfRangeException();
            }
        }
    }

    internal class ElementAtFromEndConsumer<TSource> : IEnumerableConsumer<TSource, TSource>
    {
        private readonly int _index;

        public ElementAtFromEndConsumer(int index)
        {
            _index = index;
        }

        public IEnumerableSink<TSource, TSource> GetSink()
        {
            return new Sink(_index);
        }

        private class Sink : IEnumerableSink<TSource, TSource>
        {
            private readonly int _count;
            private readonly Queue<TSource> _queue;

            public Sink(int count)
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
            }

            public TSource GetResult()
            {
                return _queue.Count == _count ? _queue.Peek() : throw new ArgumentOutOfRangeException();
            }
        }
    }
}