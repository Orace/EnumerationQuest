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

namespace EnumerationQuest.Consumers
{
    internal static partial class ConsumerFactory
    {
        public static IEnumerableConsumer<TSource, TSource> Aggregate<TSource>(Func<TSource, TSource, TSource> func)
        {
            if (func is null)
                throw new ArgumentNullException(nameof(func));

            return new AggregateConsumer<TSource>(func);
        }

        public static IEnumerableConsumer<TSource, TAccumulate> Aggregate<TSource, TAccumulate>(TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (func is null)
                throw new ArgumentNullException(nameof(func));

            return new AggregateWithSeedConsumer<TSource, TAccumulate>(seed, func);
        }

        public static IEnumerableConsumer<TSource, TResult> Aggregate<TSource, TAccumulate, TResult>(TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            if (func is null)
                throw new ArgumentNullException(nameof(func));

            if (resultSelector is null)
                throw new ArgumentNullException(nameof(resultSelector));

            return new AggregateWithSeedAndResultSelectorConsumer<TSource, TAccumulate, TResult>(seed, func, resultSelector);
        }
    }

    internal class AggregateConsumer<TSource> : IEnumerableConsumer<TSource, TSource>
    {
        private readonly Func<TSource, TSource, TSource> _func;

        public AggregateConsumer(Func<TSource, TSource, TSource> func)
        {
            _func = func;
        }

        public IEnumerableSink<TSource, TSource> GetSink()
        {
            return new AggregateSink<TSource>(_func);
        }
    }

    internal class AggregateSink<TSource> : IEnumerableSink<TSource, TSource>
    {
        private readonly Func<TSource, TSource, TSource> _func;

        private bool _hasContent;
        private TSource? _state;

        public AggregateSink(Func<TSource, TSource, TSource> func)
        {
            _func = func;
        }

        public bool AcceptFirst(TSource element)
        {
            _state = element;
            _hasContent = true;

            return true;
        }

        public bool AcceptNext(TSource element)
        {
            _state = _func(_state!, element);

            return true;
        }

        public void Dispose()
        {
            _hasContent = false;
            _state = default;
        }

        public TSource GetResult()
        {
            return _hasContent ? _state! : throw new InvalidOperationException("Sequence was empty");
        }
    }

    internal class AggregateWithSeedConsumer<TSource, TAccumulate> : IEnumerableConsumer<TSource, TAccumulate>
    {
        private readonly TAccumulate _seed;
        private readonly Func<TAccumulate, TSource, TAccumulate> _func;

        public AggregateWithSeedConsumer(TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            _seed = seed;
            _func = func;
        }

        public IEnumerableSink<TSource, TAccumulate> GetSink()
        {
            return new AggregateWithSeedSink<TSource, TAccumulate>(_seed, _func);
        }
    }

    internal class AggregateWithSeedSink<TSource, TAccumulate> : IEnumerableSink<TSource, TAccumulate>
    {
        private readonly Func<TAccumulate, TSource, TAccumulate> _func;

        private TAccumulate _state;

        public AggregateWithSeedSink(TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            _state = seed;
            _func = func;
        }
        
        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            _state = _func(_state, element);
            return true;
        }

        public void Dispose()
        {
            _state = default!;
        }

        public TAccumulate GetResult()
        {
            return _state;
        }
    }

    internal class AggregateWithSeedAndResultSelectorConsumer<TSource, TAccumulate, TResult> : IEnumerableConsumer<TSource, TResult>
    {
        private readonly TAccumulate _seed;
        private readonly Func<TAccumulate, TSource, TAccumulate> _func;
        private readonly Func<TAccumulate, TResult> _resultSelector;

        public AggregateWithSeedAndResultSelectorConsumer(TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            _seed = seed;
            _func = func;
            _resultSelector = resultSelector;
        }

        public IEnumerableSink<TSource, TResult> GetSink()
        {
            return new AggregateWithSeedAndResultSelectorSink<TSource, TAccumulate, TResult>(_seed, _func, _resultSelector);
        }
    }

    internal class AggregateWithSeedAndResultSelectorSink<TSource, TAccumulate, TResult> : IEnumerableSink<TSource, TResult>
    {
        private readonly Func<TAccumulate, TSource, TAccumulate> _func;
        private readonly Func<TAccumulate, TResult> _resultSelector;

        private TAccumulate _state;

        public AggregateWithSeedAndResultSelectorSink(TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            _state = seed;
            _func = func;
            _resultSelector = resultSelector;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            _state = _func(_state, element);
            return true;
        }

        public void Dispose()
        {
            _state = default!;
        }

        public TResult GetResult()
        {
            return _resultSelector(_state);
        }
    }
}