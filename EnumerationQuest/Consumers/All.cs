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
        public static IEnumerableConsumer<TSource, bool> All<TSource>(Func<TSource, bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            
            return new AllConsumer<TSource>(predicate);
        }
    }

    internal class AllConsumer<TSource> : IEnumerableConsumer<TSource, bool>
    {
        private readonly Func<TSource, bool> _predicate;

        public AllConsumer(Func<TSource, bool> predicate)
        {
            _predicate = predicate;
        }

        public IEnumerableSink<TSource, bool> GetSink()
        {
            return new Sink(_predicate);
        }

        private class Sink : IEnumerableSink<TSource, bool>
        {
            private readonly Func<TSource, bool> _predicate;

            private bool _result = true;

            public Sink(Func<TSource, bool> predicate)
            {
                _predicate = predicate;
            }

            public bool AcceptFirst(TSource element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(TSource element)
            {
                if (_result is false)
                    return false;

                if (_predicate(element))
                    return true;

                _result = false;
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