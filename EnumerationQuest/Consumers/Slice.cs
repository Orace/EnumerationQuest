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
        public static IEnumerableConsumer<TSource, List<TSource>> Slice<TSource>(Range range)
        {
            return new SliceConsumer<TSource>(range);
        }
    }

    internal class SliceConsumer<TSource> : IEnumerableConsumer<TSource, List<TSource>>
    {
        private readonly Range _range;

        public SliceConsumer(Range range)
        {
            _range = range;
        }

        public IEnumerableSink<TSource, List<TSource>> GetSink()
        {
            return (_range.Start.IsFromEnd, _range.End.IsFromEnd) switch
            {
                (false, false) when _range.Start.Value >= _range.End.Value => SinkForEmpty.Instance,
                (true, true) when _range.Start.Value <= _range.End.Value => SinkForEmpty.Instance,
                (false, false) => new SinkForFromStartFromStart(_range.Start.Value, _range.End.Value),
                (false, true) => new SinkForFromStartFromEnd(_range.Start.Value, _range.End.Value),
                (true, false) => new SinkForFromEndFromStart(_range.Start.Value, _range.End.Value),
                (true, true) => new SinkForFromEndFromEnd(_range.Start.Value, _range.End.Value)
            };
        }

        private class SinkForEmpty : IEnumerableSink<TSource, List<TSource>>
        {
            public static SinkForEmpty Instance { get; } = new();

            private SinkForEmpty()
            {
            }

            public bool AcceptFirst(TSource element)
            {
                return false;
            }

            public bool AcceptNext(TSource element)
            {
                return false;
            }

            public void Dispose()
            {
            }

            public List<TSource> GetResult()
            {
                return new List<TSource>();
            }
        }

        private class SinkForFromStartFromStart : IEnumerableSink<TSource, List<TSource>>
        {
            private readonly List<TSource> _result;

            private readonly int _startIndex;
            private readonly int _endIndex;

            private int _index;

            public SinkForFromStartFromStart(int startIndex, int endIndex)
            {
                _result = new List<TSource>(endIndex - startIndex);

                _startIndex = startIndex;
                _endIndex = endIndex;
            }

            public bool AcceptFirst(TSource element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(TSource element)
            {
                if (_index >= _endIndex)
                    return false;

                if (_index >= _startIndex)
                    _result.Add(element);

                _index++;

                return _index < _endIndex;
            }

            public void Dispose()
            {
            }

            public List<TSource> GetResult()
            {
                _result.TrimExcess();
                return _result;
            }
        }

        private class SinkForFromStartFromEnd : IEnumerableSink<TSource, List<TSource>>
        {
            private readonly List<TSource> _result = new();

            private readonly int _startIndex;
            private readonly int _endOffset;

            private int _index;

            public SinkForFromStartFromEnd(int startIndex, int endOffset)
            {
                _startIndex = startIndex;
                _endOffset = endOffset;
            }

            public bool AcceptFirst(TSource element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(TSource element)
            {
                if (_index >= _startIndex)
                    _result.Add(element);

                _index++;

                return true;
            }

            public void Dispose()
            {
            }

            public List<TSource> GetResult()
            {
                var count = _result.Count - _endOffset;
                if (count <= 0)
                {
                    _result.Clear();
                }
                else
                {
                    _result.RemoveRange(count, _result.Count - count);
                }

                _result.TrimExcess();
                return _result;
            }
        }

        private class SinkForFromEndFromStart : IEnumerableSink<TSource, List<TSource>>
        {
            private readonly List<TSource> _result;

            private readonly int _startOffset;
            private readonly int _endIndex;

            private int _index;

            public SinkForFromEndFromStart(int startOffset, int endIndex)
            {
                _result = new List<TSource>(endIndex);

                _startOffset = startOffset;
                _endIndex = endIndex;
            }

            public bool AcceptFirst(TSource element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(TSource element)
            {
                if (_index < _endIndex)
                    _result.Add(element);

                _index++;

                var startIndex = _index - _startOffset;
                return startIndex < _endIndex;
            }

            public void Dispose()
            {
            }

            public List<TSource> GetResult()
            {
                var startIndex = Math.Max(0, _index - _startOffset);
                var endIndex = Math.Min(_endIndex, _index);

                var count = Math.Max(0, endIndex - startIndex);

                if (count <= 0)
                {
                    _result.Clear();
                }
                else
                {
                    _result.RemoveRange(0, startIndex);
                    _result.RemoveRange(count, _result.Count - count);
                }

                _result.TrimExcess();
                return _result;
            }
        }

        private class SinkForFromEndFromEnd : IEnumerableSink<TSource, List<TSource>>
        {
            private readonly List<TSource> _circularBuffer;

            private readonly int _startOffset;
            private readonly int _endOffset;

            private int _index;

            public SinkForFromEndFromEnd(int startOffset, int endOffset)
            {
                _circularBuffer = new List<TSource>(startOffset);

                _startOffset = startOffset;
                _endOffset = endOffset;
            }

            public bool AcceptFirst(TSource element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(TSource element)
            {
                if (_index >= _startOffset)
                {
                    _circularBuffer[_index % _startOffset] = element;
                }
                else
                {
                    _circularBuffer.Add(element);
                }

                _index++;
                return true;
            }

            public void Dispose()
            {
            }

            public List<TSource> GetResult()
            {
                var startIndex = Math.Max(0, _index - _startOffset);
                var endIndex = Math.Max(0, _index - _endOffset);
                var count = endIndex - startIndex;

                var start1 = _index % _startOffset;
                var length1 = Math.Min(count, _circularBuffer.Count - start1);
                if (length1 == count)
                {
                    _circularBuffer.RemoveRange(0, start1);
                    _circularBuffer.RemoveRange(count, _circularBuffer.Count - count);
                    _circularBuffer.TrimExcess();
                    return _circularBuffer;
                }

                var length2 = count - length1;
                var tmp = new TSource[length2];
                _circularBuffer.CopyTo(0, tmp, 0, length2);
                _circularBuffer.RemoveRange(0, start1);
                _circularBuffer.AddRange(tmp);
                _circularBuffer.TrimExcess();
                return _circularBuffer;
            }
        }
    }
}