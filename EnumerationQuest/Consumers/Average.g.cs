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

#nullable enable

namespace EnumerationQuest.Consumers
{
    internal static partial class ConsumerFactory
    {
        public static IEnumerableConsumer<decimal, decimal> AverageOfDecimal()
        {
            return new AverageOfDecimalConsumer();
        }

        public static IEnumerableConsumer<double, double> AverageOfDouble()
        {
            return new AverageOfDoubleConsumer();
        }

        public static IEnumerableConsumer<float, float> AverageOfSingle()
        {
            return new AverageOfSingleConsumer();
        }

        public static IEnumerableConsumer<int, double> AverageOfInt32()
        {
            return new AverageOfInt32Consumer();
        }

        public static IEnumerableConsumer<long, double> AverageOfInt64()
        {
            return new AverageOfInt64Consumer();
        }

        public static IEnumerableConsumer<decimal?, decimal?> AverageOfNullableDecimal()
        {
            return new AverageOfNullableDecimalConsumer();
        }

        public static IEnumerableConsumer<double?, double?> AverageOfNullableDouble()
        {
            return new AverageOfNullableDoubleConsumer();
        }

        public static IEnumerableConsumer<float?, float?> AverageOfNullableSingle()
        {
            return new AverageOfNullableSingleConsumer();
        }

        public static IEnumerableConsumer<int?, double?> AverageOfNullableInt32()
        {
            return new AverageOfNullableInt32Consumer();
        }

        public static IEnumerableConsumer<long?, double?> AverageOfNullableInt64()
        {
            return new AverageOfNullableInt64Consumer();
        }

        public static IEnumerableConsumer<TSource, decimal> AverageOfDecimal<TSource>(Func<TSource, decimal> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new AverageOfDecimalWithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, double> AverageOfDouble<TSource>(Func<TSource, double> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new AverageOfDoubleWithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, float> AverageOfSingle<TSource>(Func<TSource, float> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new AverageOfSingleWithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, double> AverageOfInt32<TSource>(Func<TSource, int> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new AverageOfInt32WithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, double> AverageOfInt64<TSource>(Func<TSource, long> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new AverageOfInt64WithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, decimal?> AverageOfNullableDecimal<TSource>(Func<TSource, decimal?> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new AverageOfNullableDecimalWithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, double?> AverageOfNullableDouble<TSource>(Func<TSource, double?> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new AverageOfNullableDoubleWithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, float?> AverageOfNullableSingle<TSource>(Func<TSource, float?> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new AverageOfNullableSingleWithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, double?> AverageOfNullableInt32<TSource>(Func<TSource, int?> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new AverageOfNullableInt32WithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, double?> AverageOfNullableInt64<TSource>(Func<TSource, long?> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new AverageOfNullableInt64WithSelectorConsumer<TSource>(selector);
        }

    }

    internal class AverageOfDecimalConsumer : IEnumerableConsumer<decimal, decimal>
    {
        public IEnumerableSink<decimal, decimal> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<decimal, decimal>
        {
            private int _count;
            private decimal _sum;

            public bool AcceptFirst(decimal element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(decimal element)
            {
                _count++;
                _sum += element;

                return true;
            }

            public void Dispose()
            {
            }

            public decimal GetResult()
            {
                return _count > 0 ? _sum / _count : throw new InvalidOperationException("Sequence was empty");
            }
        }
    }

    internal class AverageOfDoubleConsumer : IEnumerableConsumer<double, double>
    {
        public IEnumerableSink<double, double> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<double, double>
        {
            private int _count;
            private double _sum;

            public bool AcceptFirst(double element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(double element)
            {
                _count++;
                _sum += element;

                return true;
            }

            public void Dispose()
            {
            }

            public double GetResult()
            {
                return _count > 0 ? _sum / _count : throw new InvalidOperationException("Sequence was empty");
            }
        }
    }

    internal class AverageOfSingleConsumer : IEnumerableConsumer<float, float>
    {
        public IEnumerableSink<float, float> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<float, float>
        {
            private int _count;
            private float _sum;

            public bool AcceptFirst(float element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(float element)
            {
                _count++;
                _sum += element;

                return true;
            }

            public void Dispose()
            {
            }

            public float GetResult()
            {
                return _count > 0 ? _sum / _count : throw new InvalidOperationException("Sequence was empty");
            }
        }
    }

    internal class AverageOfInt32Consumer : IEnumerableConsumer<int, double>
    {
        public IEnumerableSink<int, double> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<int, double>
        {
            private int _count;
            private double _sum;

            public bool AcceptFirst(int element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(int element)
            {
                _count++;
                _sum += element;

                return true;
            }

            public void Dispose()
            {
            }

            public double GetResult()
            {
                return _count > 0 ? _sum / _count : throw new InvalidOperationException("Sequence was empty");
            }
        }
    }

    internal class AverageOfInt64Consumer : IEnumerableConsumer<long, double>
    {
        public IEnumerableSink<long, double> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<long, double>
        {
            private int _count;
            private double _sum;

            public bool AcceptFirst(long element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(long element)
            {
                _count++;
                _sum += element;

                return true;
            }

            public void Dispose()
            {
            }

            public double GetResult()
            {
                return _count > 0 ? _sum / _count : throw new InvalidOperationException("Sequence was empty");
            }
        }
    }

    internal class AverageOfNullableDecimalConsumer : IEnumerableConsumer<decimal?, decimal?>
    {
        public IEnumerableSink<decimal?, decimal?> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<decimal?, decimal?>
        {
            private int _count;
            private decimal _sum;

            public bool AcceptFirst(decimal? element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(decimal? element)
            {
                if (element.HasValue)
                {
                    _count++;
                    _sum += element.Value;
                }

                return true;
            }

            public void Dispose()
            {
            }

            public decimal? GetResult()
            {
                return _count > 0 ? _sum / _count : null;
            }
        }
    }

    internal class AverageOfNullableDoubleConsumer : IEnumerableConsumer<double?, double?>
    {
        public IEnumerableSink<double?, double?> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<double?, double?>
        {
            private int _count;
            private double _sum;

            public bool AcceptFirst(double? element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(double? element)
            {
                if (element.HasValue)
                {
                    _count++;
                    _sum += element.Value;
                }

                return true;
            }

            public void Dispose()
            {
            }

            public double? GetResult()
            {
                return _count > 0 ? _sum / _count : null;
            }
        }
    }

    internal class AverageOfNullableSingleConsumer : IEnumerableConsumer<float?, float?>
    {
        public IEnumerableSink<float?, float?> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<float?, float?>
        {
            private int _count;
            private float _sum;

            public bool AcceptFirst(float? element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(float? element)
            {
                if (element.HasValue)
                {
                    _count++;
                    _sum += element.Value;
                }

                return true;
            }

            public void Dispose()
            {
            }

            public float? GetResult()
            {
                return _count > 0 ? _sum / _count : null;
            }
        }
    }

    internal class AverageOfNullableInt32Consumer : IEnumerableConsumer<int?, double?>
    {
        public IEnumerableSink<int?, double?> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<int?, double?>
        {
            private int _count;
            private double _sum;

            public bool AcceptFirst(int? element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(int? element)
            {
                if (element.HasValue)
                {
                    _count++;
                    _sum += element.Value;
                }

                return true;
            }

            public void Dispose()
            {
            }

            public double? GetResult()
            {
                return _count > 0 ? _sum / _count : null;
            }
        }
    }

    internal class AverageOfNullableInt64Consumer : IEnumerableConsumer<long?, double?>
    {
        public IEnumerableSink<long?, double?> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<long?, double?>
        {
            private int _count;
            private double _sum;

            public bool AcceptFirst(long? element)
            {
                return AcceptNext(element);
            }

            public bool AcceptNext(long? element)
            {
                if (element.HasValue)
                {
                    _count++;
                    _sum += element.Value;
                }

                return true;
            }

            public void Dispose()
            {
            }

            public double? GetResult()
            {
                return _count > 0 ? _sum / _count : null;
            }
        }
    }

    internal class AverageOfDecimalWithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, decimal>
    {
        private readonly Func<TSource, decimal> _selector;

        public AverageOfDecimalWithSelectorConsumer(Func<TSource, decimal> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, decimal> GetSink()
        {
            return new Sink(_selector);
        }

    internal class Sink : IEnumerableSink<TSource, decimal>
    {
        private readonly Func<TSource, decimal> _selector;

        private int _count;
        private decimal _sum;

        public Sink(Func<TSource, decimal> selector)
        {
            _selector = selector;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            _count++;
            _sum += _selector(element);

            return true;
        }

        public void Dispose()
        {
        }

        public decimal GetResult()
        {
            return _count > 0 ? _sum / _count : throw new InvalidOperationException("Sequence was empty");
        }
    }
    }
    internal class AverageOfDoubleWithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, double>
    {
        private readonly Func<TSource, double> _selector;

        public AverageOfDoubleWithSelectorConsumer(Func<TSource, double> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, double> GetSink()
        {
            return new Sink(_selector);
        }

    internal class Sink : IEnumerableSink<TSource, double>
    {
        private readonly Func<TSource, double> _selector;

        private int _count;
        private double _sum;

        public Sink(Func<TSource, double> selector)
        {
            _selector = selector;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            _count++;
            _sum += _selector(element);

            return true;
        }

        public void Dispose()
        {
        }

        public double GetResult()
        {
            return _count > 0 ? _sum / _count : throw new InvalidOperationException("Sequence was empty");
        }
    }
    }
    internal class AverageOfSingleWithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, float>
    {
        private readonly Func<TSource, float> _selector;

        public AverageOfSingleWithSelectorConsumer(Func<TSource, float> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, float> GetSink()
        {
            return new Sink(_selector);
        }

    internal class Sink : IEnumerableSink<TSource, float>
    {
        private readonly Func<TSource, float> _selector;

        private int _count;
        private float _sum;

        public Sink(Func<TSource, float> selector)
        {
            _selector = selector;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            _count++;
            _sum += _selector(element);

            return true;
        }

        public void Dispose()
        {
        }

        public float GetResult()
        {
            return _count > 0 ? _sum / _count : throw new InvalidOperationException("Sequence was empty");
        }
    }
    }
    internal class AverageOfInt32WithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, double>
    {
        private readonly Func<TSource, int> _selector;

        public AverageOfInt32WithSelectorConsumer(Func<TSource, int> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, double> GetSink()
        {
            return new Sink(_selector);
        }

    internal class Sink : IEnumerableSink<TSource, double>
    {
        private readonly Func<TSource, int> _selector;

        private int _count;
        private double _sum;

        public Sink(Func<TSource, int> selector)
        {
            _selector = selector;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            _count++;
            _sum += _selector(element);

            return true;
        }

        public void Dispose()
        {
        }

        public double GetResult()
        {
            return _count > 0 ? _sum / _count : throw new InvalidOperationException("Sequence was empty");
        }
    }
    }
    internal class AverageOfInt64WithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, double>
    {
        private readonly Func<TSource, long> _selector;

        public AverageOfInt64WithSelectorConsumer(Func<TSource, long> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, double> GetSink()
        {
            return new Sink(_selector);
        }

    internal class Sink : IEnumerableSink<TSource, double>
    {
        private readonly Func<TSource, long> _selector;

        private int _count;
        private double _sum;

        public Sink(Func<TSource, long> selector)
        {
            _selector = selector;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            _count++;
            _sum += _selector(element);

            return true;
        }

        public void Dispose()
        {
        }

        public double GetResult()
        {
            return _count > 0 ? _sum / _count : throw new InvalidOperationException("Sequence was empty");
        }
    }
    }
    internal class AverageOfNullableDecimalWithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, decimal?>
    {
        private readonly Func<TSource, decimal?> _selector;

        public AverageOfNullableDecimalWithSelectorConsumer(Func<TSource, decimal?> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, decimal?> GetSink()
        {
            return new Sink(_selector);
        }

    private class Sink : IEnumerableSink<TSource, decimal?>
    {
        private readonly Func<TSource, decimal?> _selector;

        private int _count;
        private decimal _sum;

        public Sink(Func<TSource, decimal?> selector)
        {
            _selector = selector;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            var nullable = _selector(element);
            if (nullable.HasValue)
            {
                _count++;
                _sum += nullable.Value;
            }

            return true;
        }

        public void Dispose()
        {
        }

        public decimal? GetResult()
        {
            return _count > 0 ? _sum / _count : null;
        }
    }
    }
    internal class AverageOfNullableDoubleWithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, double?>
    {
        private readonly Func<TSource, double?> _selector;

        public AverageOfNullableDoubleWithSelectorConsumer(Func<TSource, double?> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, double?> GetSink()
        {
            return new Sink(_selector);
        }

    private class Sink : IEnumerableSink<TSource, double?>
    {
        private readonly Func<TSource, double?> _selector;

        private int _count;
        private double _sum;

        public Sink(Func<TSource, double?> selector)
        {
            _selector = selector;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            var nullable = _selector(element);
            if (nullable.HasValue)
            {
                _count++;
                _sum += nullable.Value;
            }

            return true;
        }

        public void Dispose()
        {
        }

        public double? GetResult()
        {
            return _count > 0 ? _sum / _count : null;
        }
    }
    }
    internal class AverageOfNullableSingleWithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, float?>
    {
        private readonly Func<TSource, float?> _selector;

        public AverageOfNullableSingleWithSelectorConsumer(Func<TSource, float?> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, float?> GetSink()
        {
            return new Sink(_selector);
        }

    private class Sink : IEnumerableSink<TSource, float?>
    {
        private readonly Func<TSource, float?> _selector;

        private int _count;
        private float _sum;

        public Sink(Func<TSource, float?> selector)
        {
            _selector = selector;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            var nullable = _selector(element);
            if (nullable.HasValue)
            {
                _count++;
                _sum += nullable.Value;
            }

            return true;
        }

        public void Dispose()
        {
        }

        public float? GetResult()
        {
            return _count > 0 ? _sum / _count : null;
        }
    }
    }
    internal class AverageOfNullableInt32WithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, double?>
    {
        private readonly Func<TSource, int?> _selector;

        public AverageOfNullableInt32WithSelectorConsumer(Func<TSource, int?> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, double?> GetSink()
        {
            return new Sink(_selector);
        }

    private class Sink : IEnumerableSink<TSource, double?>
    {
        private readonly Func<TSource, int?> _selector;

        private int _count;
        private double _sum;

        public Sink(Func<TSource, int?> selector)
        {
            _selector = selector;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            var nullable = _selector(element);
            if (nullable.HasValue)
            {
                _count++;
                _sum += nullable.Value;
            }

            return true;
        }

        public void Dispose()
        {
        }

        public double? GetResult()
        {
            return _count > 0 ? _sum / _count : null;
        }
    }
    }
    internal class AverageOfNullableInt64WithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, double?>
    {
        private readonly Func<TSource, long?> _selector;

        public AverageOfNullableInt64WithSelectorConsumer(Func<TSource, long?> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, double?> GetSink()
        {
            return new Sink(_selector);
        }

    private class Sink : IEnumerableSink<TSource, double?>
    {
        private readonly Func<TSource, long?> _selector;

        private int _count;
        private double _sum;

        public Sink(Func<TSource, long?> selector)
        {
            _selector = selector;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            var nullable = _selector(element);
            if (nullable.HasValue)
            {
                _count++;
                _sum += nullable.Value;
            }

            return true;
        }

        public void Dispose()
        {
        }

        public double? GetResult()
        {
            return _count > 0 ? _sum / _count : null;
        }
    }
    }
}