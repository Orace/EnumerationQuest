// EnumerableQuest - Avoids multiple enumeration
// 
// Copyright 2022 Pierre Lando
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
using System.Reactive.Subjects;

namespace EnumerationQuest.Consumers
{
    internal static partial class ConsumerFactory
    {
        public static IEnumerableConsumer<TSource, TResult> Get<TSource, TResult>(Func<IObservable<TSource>, IObservable<TResult>> func)
        {
            return new GetConsumer<TSource, TResult>(func);
        }
    }

    internal class GetConsumer<TSource, TResult> : IEnumerableConsumer<TSource, TResult>
    {
        private readonly Func<IObservable<TSource>, IObservable<TResult>> _func;

        public GetConsumer(Func<IObservable<TSource>, IObservable<TResult>> func)
        {
            _func = func;
        }

        public IEnumerableSink<TSource, TResult> GetSink()
        {
            return new Sink(_func);
        }

        private class Sink : IEnumerableSink<TSource, TResult>
        {
            private readonly Subject<TSource> _subject;
            private readonly IDisposable _subscription;

            private TResult? _lastValue;

            public Sink(Func<IObservable<TSource>, IObservable<TResult>> func)
            {
                _subject = new Subject<TSource>();
                _subscription = func(_subject).Subscribe(v => _lastValue = v);
            }

            public bool AcceptFirst(TSource element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(TSource element)
            {
                _subject.OnNext(element);
                return true;
            }

            public void Dispose()
            {
                _subscription.Dispose();
            }

            public TResult GetResult()
            {
                _subject.OnCompleted();
                return _lastValue ?? throw new InvalidOperationException("Sequence was empty");
            }
        }
    }
}