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
        public static IEnumerableConsumer<TSource, TSource?> Min<TSource>()
        {
            return new MinConsumer<TSource>(Comparer<TSource>.Default);
        }

        public static IEnumerableConsumer<TSource, TSource?> Min<TSource>(IComparer<TSource> comparer)
        {
            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new MinConsumer<TSource>(comparer);
        }

        public static IEnumerableConsumer<TSource, TResult?> Min<TSource, TResult>(Func<TSource, TResult> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new MinWithSelectorConsumer<TSource, TResult>(selector, Comparer<TResult>.Default);
        }

        public static IEnumerableConsumer<TSource, TResult?> Min<TSource, TResult>(Func<TSource, TResult> selector, IComparer<TResult> comparer)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            if (comparer is null)
                throw new ArgumentNullException(nameof(comparer));

            return new MinWithSelectorConsumer<TSource, TResult>(selector, comparer);
        }
    }

    internal class MinConsumer<TSource> : IEnumerableConsumer<TSource, TSource?>
    {
        private readonly IComparer<TSource> _comparer;

        public MinConsumer(IComparer<TSource> comparer)
        {
            _comparer = comparer;
        }

        public IEnumerableSink<TSource, TSource?> GetSink()
        {
            return new MinSink<TSource>(_comparer);
        }
    }

    internal class MinSink<TSource> : IEnumerableSink<TSource, TSource?>
    {
        private readonly IComparer<TSource> _comparer;

        private bool _hasContent;
        private TSource? _result;

        public MinSink(IComparer<TSource> comparer)
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

            _result = _comparer.Compare(element, _result) < 0 ? element : _result;
            return true;
        }

        public void Dispose()
        {
            _hasContent = false;
            _result = default;
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

    internal class MinWithSelectorConsumer<TSource, TResult> : IEnumerableConsumer<TSource, TResult?>
    {
        private readonly Func<TSource, TResult> _selector;
        private readonly IComparer<TResult> _comparer;

        public MinWithSelectorConsumer(Func<TSource, TResult> selector, IComparer<TResult> comparer)
        {
            _selector = selector;
            _comparer = comparer;
        }

        public IEnumerableSink<TSource, TResult?> GetSink()
        {
            return new MinWithSelectorSink<TSource, TResult>(_selector, _comparer);
        }
    }

    internal class MinWithSelectorSink<TSource, TResult> : IEnumerableSink<TSource, TResult?>
    {
        private readonly Func<TSource, TResult> _selector;
        private readonly IComparer<TResult> _comparer;

        private bool _hasContent;
        private TResult? _result;

        public MinWithSelectorSink(Func<TSource, TResult> selector, IComparer<TResult> comparer)
        {
            _comparer = comparer;
            _selector = selector;
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

            _result = _comparer.Compare(value, _result) < 0 ? value : _result;
            return true;
        }

        public void Dispose()
        {
            _hasContent = false;
            _result = default;
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