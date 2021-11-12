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
using System.Text;

namespace EnumerationQuest.Consumers
{
    internal static partial class ConsumerFactory
    {
        public static IEnumerableConsumer<TSource, string> DelimitedString<TSource>(string? delimiter)
        {
            return new DelimitedStringConsumer<TSource>(delimiter);
        }

        public static IEnumerableConsumer<TSource, string> DelimitedString<TSource>(string? delimiter, Func<TSource, string?> stringSelector)
        {
            if (stringSelector is null)
                throw new ArgumentNullException(nameof(stringSelector));

            return new DelimitedStringWithStringSelectorConsumer<TSource>(delimiter, stringSelector);
        }
    }

    internal class DelimitedStringConsumer<TSource> : IEnumerableConsumer<TSource, string>
    {
        private readonly string? _delimiter;

        public DelimitedStringConsumer(string? delimiter)
        {
            _delimiter = delimiter;
        }

        public IEnumerableSink<TSource, string> GetSink()
        {
            return new DelimitedStringSink<TSource>(_delimiter);
        }
    }

    internal class DelimitedStringSink<TSource> : IEnumerableSink<TSource, string>
    {
        private readonly string? _delimiter;
        
        private StringBuilder? _stringBuilder;

        public DelimitedStringSink(string? delimiter)
        {
            _delimiter = delimiter;
        }
        
        public bool AcceptFirst(TSource element)
        {
            _stringBuilder = new StringBuilder();
            _stringBuilder.Append(element);
            return true;
        }

        public bool AcceptNext(TSource element)
        {
            if (_stringBuilder is null)
                return false;

            _stringBuilder.Append(_delimiter);
            _stringBuilder.Append(element);

            return true;
        }

        public void Dispose()
        {
            _stringBuilder = null;
        }

        public string GetResult()
        {
            return _stringBuilder is null ? string.Empty : _stringBuilder.ToString();
        }
    }

    internal class DelimitedStringWithStringSelectorConsumer<TSource> : IEnumerableConsumer<TSource, string>
    {
        private readonly string? _delimiter;
        private readonly Func<TSource, string?> _stringSelector;

        public DelimitedStringWithStringSelectorConsumer(string? delimiter, Func<TSource, string?> stringSelector)
        {
            _delimiter = delimiter;
            _stringSelector = stringSelector;
        }

        public IEnumerableSink<TSource, string> GetSink()
        {
            return new DelimitedStringWithStringSelectorSink<TSource>(_delimiter, _stringSelector);
        }
    }

    internal class DelimitedStringWithStringSelectorSink<TSource> : IEnumerableSink<TSource, string>
    {
        private readonly string? _delimiter;
        private readonly Func<TSource, string?> _stringSelector;
        
        private StringBuilder? _stringBuilder;

        public DelimitedStringWithStringSelectorSink(string? delimiter, Func<TSource, string?> stringSelector)
        {
            _delimiter = delimiter;
            _stringSelector = stringSelector;
        }

        public bool AcceptFirst(TSource element)
        {
            _stringBuilder = new StringBuilder();
            _stringBuilder.Append(_stringSelector(element));
            return true;
        }

        public bool AcceptNext(TSource element)
        {
            if (_stringBuilder is null)
                return false;

            _stringBuilder.Append(_delimiter);
            _stringBuilder.Append(_stringSelector(element));

            return true;
        }

        public void Dispose()
        {
            _stringBuilder = null;
        }

        public string GetResult()
        {
            return _stringBuilder is null ? string.Empty : _stringBuilder.ToString();
        }
    }
}