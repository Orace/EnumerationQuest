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
        public static IEnumerableConsumer<TSource, TSource?> Max<TSource>()
        {
            return new MaxConsumer<TSource>(Comparer<TSource>.Default);
        }

        public static IEnumerableConsumer<TSource, TSource?> Max<TSource>(IComparer<TSource> comparer)
        {
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new MaxConsumer<TSource>(comparer);
        }

        public static IEnumerableConsumer<TSource, TResult?> Max<TSource, TResult>(Func<TSource, TResult> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new MaxWithSelectorConsumer<TSource, TResult>(selector, Comparer<TResult>.Default);
        }

        public static IEnumerableConsumer<TSource, TResult?> Max<TSource, TResult>(Func<TSource, TResult> selector, IComparer<TResult> comparer)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new MaxWithSelectorConsumer<TSource, TResult>(selector, comparer);
        }
    }

    internal class MaxConsumer<TSource> : IEnumerableConsumer<TSource, TSource?>
    {
        private readonly IComparer<TSource> _comparer;

        public MaxConsumer(IComparer<TSource> comparer)
        {
            _comparer = comparer;
        }

        public IEnumerableSink<TSource, TSource?> GetSink()
        {
            return new Sink(_comparer);
        }

        private class Sink : IEnumerableSink<TSource, TSource?>
        {
            private readonly IComparer<TSource> _comparer;

            private bool _hasContent;
            private TSource? _result;

            public Sink(IComparer<TSource> comparer)
            {
                _comparer = comparer;
            }

            public bool AcceptFirst(TSource element)
            {
                _hasContent = true;
                _result = element;
                return true;
            }

            public bool AcceptNext(TSource element)
            {
                if (element is null)
                    return true;

                if (_result is null)
                {
                    _result = element;
                    return true;
                }

                _result = _comparer.Compare(element, _result) > 0 ? element : _result;
                return true;
            }

            public void Dispose()
            {
            }

            public TSource? GetResult()
            {
                if (_hasContent)
                    return _result;

                if (default(TSource) is null)
                    return default;

                throw new InvalidOperationException("Sequence was empty");
            }
        }
    }

    internal class MaxWithSelectorConsumer<TSource, TResult> : IEnumerableConsumer<TSource, TResult?>
    {
        private readonly Func<TSource, TResult> _selector;

        private readonly IComparer<TResult> _comparer;

        public MaxWithSelectorConsumer(Func<TSource, TResult> selector, IComparer<TResult> comparer)
        {
            _selector = selector;
            _comparer = comparer;
        }

        public IEnumerableSink<TSource, TResult?> GetSink()
        {
            return new Sink(_selector, _comparer);
        }

        private class Sink : IEnumerableSink<TSource, TResult?>
        {
            private readonly Func<TSource, TResult> _selector;
            private readonly IComparer<TResult> _comparer;

            private bool _hasContent;
            private TResult? _result;

            public Sink(Func<TSource, TResult> selector, IComparer<TResult> comparer)
            {
                _selector = selector;
                _comparer = comparer;
            }

            public bool AcceptFirst(TSource element)
            {
                _hasContent = true;
                _result = _selector(element);
                return true;
            }

            public bool AcceptNext(TSource element)
            {
                var value = _selector(element);
                if (value is null)
                    return true;

                if (_result is null)
                {
                    _result = value;
                    return true;
                }

                _result = _comparer.Compare(value, _result) > 0 ? value : _result;
                return true;
            }

            public void Dispose()
            {
            }

            public TResult? GetResult()
            {
                if (_hasContent)
                    return _result;

                if (default(TSource) is null)
                    return default;

                throw new InvalidOperationException("Sequence was empty");
            }
        }
    }
}