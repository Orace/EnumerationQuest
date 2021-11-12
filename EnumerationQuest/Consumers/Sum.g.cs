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
        public static IEnumerableConsumer<decimal, decimal> SumOfDecimal()
        {
            return new SumOfDecimalConsumer();
        }

        public static IEnumerableConsumer<TSource, decimal> SumOfDecimal<TSource>(Func<TSource, decimal> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfDecimalConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<double, double> SumOfDouble()
        {
            return new SumOfDoubleConsumer();
        }

        public static IEnumerableConsumer<TSource, double> SumOfDouble<TSource>(Func<TSource, double> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfDoubleConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<float, float> SumOfSingle()
        {
            return new SumOfSingleConsumer();
        }

        public static IEnumerableConsumer<TSource, float> SumOfSingle<TSource>(Func<TSource, float> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfSingleConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<int, int> SumOfInt32()
        {
            return new SumOfInt32Consumer();
        }

        public static IEnumerableConsumer<TSource, int> SumOfInt32<TSource>(Func<TSource, int> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfInt32Consumer<TSource>(selector);
        }

        public static IEnumerableConsumer<long, long> SumOfInt64()
        {
            return new SumOfInt64Consumer();
        }

        public static IEnumerableConsumer<TSource, long> SumOfInt64<TSource>(Func<TSource, long> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfInt64Consumer<TSource>(selector);
        }

        public static IEnumerableConsumer<decimal?, decimal?> SumOfNullableDecimal()
        {
            return new SumOfNullableDecimalConsumer();
        }

        public static IEnumerableConsumer<TSource, decimal?> SumOfNullableDecimal<TSource>(Func<TSource, decimal?> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfNullableDecimalConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<double?, double?> SumOfNullableDouble()
        {
            return new SumOfNullableDoubleConsumer();
        }

        public static IEnumerableConsumer<TSource, double?> SumOfNullableDouble<TSource>(Func<TSource, double?> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfNullableDoubleConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<float?, float?> SumOfNullableSingle()
        {
            return new SumOfNullableSingleConsumer();
        }

        public static IEnumerableConsumer<TSource, float?> SumOfNullableSingle<TSource>(Func<TSource, float?> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfNullableSingleConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<int?, int?> SumOfNullableInt32()
        {
            return new SumOfNullableInt32Consumer();
        }

        public static IEnumerableConsumer<TSource, int?> SumOfNullableInt32<TSource>(Func<TSource, int?> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfNullableInt32Consumer<TSource>(selector);
        }

        public static IEnumerableConsumer<long?, long?> SumOfNullableInt64()
        {
            return new SumOfNullableInt64Consumer();
        }

        public static IEnumerableConsumer<TSource, long?> SumOfNullableInt64<TSource>(Func<TSource, long?> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfNullableInt64Consumer<TSource>(selector);
        }

    }

    internal class SumOfDecimalConsumer : IEnumerableConsumer<decimal, decimal>
    {
        public IEnumerableSink<decimal, decimal> GetSink()
        {
            return new SumOfDecimalSink();
        }
    }

    internal class SumOfDecimalConsumer<TSource> : IEnumerableConsumer<TSource, decimal>
    {
        private readonly Func<TSource, decimal> _selector;

        public SumOfDecimalConsumer(Func<TSource, decimal> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, decimal> GetSink()
        {
            return new SumOfDecimalSink<TSource>(_selector);
        }
    }

    internal class SumOfDoubleConsumer : IEnumerableConsumer<double, double>
    {
        public IEnumerableSink<double, double> GetSink()
        {
            return new SumOfDoubleSink();
        }
    }

    internal class SumOfDoubleConsumer<TSource> : IEnumerableConsumer<TSource, double>
    {
        private readonly Func<TSource, double> _selector;

        public SumOfDoubleConsumer(Func<TSource, double> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, double> GetSink()
        {
            return new SumOfDoubleSink<TSource>(_selector);
        }
    }

    internal class SumOfSingleConsumer : IEnumerableConsumer<float, float>
    {
        public IEnumerableSink<float, float> GetSink()
        {
            return new SumOfSingleSink();
        }
    }

    internal class SumOfSingleConsumer<TSource> : IEnumerableConsumer<TSource, float>
    {
        private readonly Func<TSource, float> _selector;

        public SumOfSingleConsumer(Func<TSource, float> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, float> GetSink()
        {
            return new SumOfSingleSink<TSource>(_selector);
        }
    }

    internal class SumOfInt32Consumer : IEnumerableConsumer<int, int>
    {
        public IEnumerableSink<int, int> GetSink()
        {
            return new SumOfInt32Sink();
        }
    }

    internal class SumOfInt32Consumer<TSource> : IEnumerableConsumer<TSource, int>
    {
        private readonly Func<TSource, int> _selector;

        public SumOfInt32Consumer(Func<TSource, int> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, int> GetSink()
        {
            return new SumOfInt32Sink<TSource>(_selector);
        }
    }

    internal class SumOfInt64Consumer : IEnumerableConsumer<long, long>
    {
        public IEnumerableSink<long, long> GetSink()
        {
            return new SumOfInt64Sink();
        }
    }

    internal class SumOfInt64Consumer<TSource> : IEnumerableConsumer<TSource, long>
    {
        private readonly Func<TSource, long> _selector;

        public SumOfInt64Consumer(Func<TSource, long> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, long> GetSink()
        {
            return new SumOfInt64Sink<TSource>(_selector);
        }
    }

    internal class SumOfNullableDecimalConsumer : IEnumerableConsumer<decimal?, decimal?>
    {
        public IEnumerableSink<decimal?, decimal?> GetSink()
        {
            return new SumOfNullableDecimalSink();
        }
    }

    internal class SumOfNullableDecimalConsumer<TSource> : IEnumerableConsumer<TSource, decimal?>
    {
        private readonly Func<TSource, decimal?> _selector;

        public SumOfNullableDecimalConsumer(Func<TSource, decimal?> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, decimal?> GetSink()
        {
            return new SumOfNullableDecimalSink<TSource>(_selector);
        }
    }

    internal class SumOfNullableDoubleConsumer : IEnumerableConsumer<double?, double?>
    {
        public IEnumerableSink<double?, double?> GetSink()
        {
            return new SumOfNullableDoubleSink();
        }
    }

    internal class SumOfNullableDoubleConsumer<TSource> : IEnumerableConsumer<TSource, double?>
    {
        private readonly Func<TSource, double?> _selector;

        public SumOfNullableDoubleConsumer(Func<TSource, double?> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, double?> GetSink()
        {
            return new SumOfNullableDoubleSink<TSource>(_selector);
        }
    }

    internal class SumOfNullableSingleConsumer : IEnumerableConsumer<float?, float?>
    {
        public IEnumerableSink<float?, float?> GetSink()
        {
            return new SumOfNullableSingleSink();
        }
    }

    internal class SumOfNullableSingleConsumer<TSource> : IEnumerableConsumer<TSource, float?>
    {
        private readonly Func<TSource, float?> _selector;

        public SumOfNullableSingleConsumer(Func<TSource, float?> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, float?> GetSink()
        {
            return new SumOfNullableSingleSink<TSource>(_selector);
        }
    }

    internal class SumOfNullableInt32Consumer : IEnumerableConsumer<int?, int?>
    {
        public IEnumerableSink<int?, int?> GetSink()
        {
            return new SumOfNullableInt32Sink();
        }
    }

    internal class SumOfNullableInt32Consumer<TSource> : IEnumerableConsumer<TSource, int?>
    {
        private readonly Func<TSource, int?> _selector;

        public SumOfNullableInt32Consumer(Func<TSource, int?> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, int?> GetSink()
        {
            return new SumOfNullableInt32Sink<TSource>(_selector);
        }
    }

    internal class SumOfNullableInt64Consumer : IEnumerableConsumer<long?, long?>
    {
        public IEnumerableSink<long?, long?> GetSink()
        {
            return new SumOfNullableInt64Sink();
        }
    }

    internal class SumOfNullableInt64Consumer<TSource> : IEnumerableConsumer<TSource, long?>
    {
        private readonly Func<TSource, long?> _selector;

        public SumOfNullableInt64Consumer(Func<TSource, long?> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, long?> GetSink()
        {
            return new SumOfNullableInt64Sink<TSource>(_selector);
        }
    }

    internal class SumOfDecimalSink : IEnumerableSink<decimal, decimal>
    {
        private decimal _sum;

        public bool AcceptFirst(decimal element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(decimal element)
        {
            _sum += element;
            return true;
        }

        public void Dispose()
        {
        }

        public decimal GetContent()
        {
            return _sum;
        }

        public decimal GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfDecimalSink<TSource> : IEnumerableSink<TSource, decimal>
    {
        private readonly Func<TSource, decimal> _selector;

        private decimal _sum;

        public SumOfDecimalSink(Func<TSource, decimal> selector)
        {
            _selector = selector;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            _sum += _selector(element);
            return true;
        }

        public void Dispose()
        {
        }

        public decimal GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfDoubleSink : IEnumerableSink<double, double>
    {
        private double _sum;

        public bool AcceptFirst(double element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(double element)
        {
            _sum += element;
            return true;
        }

        public void Dispose()
        {
        }

        public double GetContent()
        {
            return _sum;
        }

        public double GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfDoubleSink<TSource> : IEnumerableSink<TSource, double>
    {
        private readonly Func<TSource, double> _selector;

        private double _sum;

        public SumOfDoubleSink(Func<TSource, double> selector)
        {
            _selector = selector;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            _sum += _selector(element);
            return true;
        }

        public void Dispose()
        {
        }

        public double GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfSingleSink : IEnumerableSink<float, float>
    {
        private float _sum;

        public bool AcceptFirst(float element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(float element)
        {
            _sum += element;
            return true;
        }

        public void Dispose()
        {
        }

        public float GetContent()
        {
            return _sum;
        }

        public float GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfSingleSink<TSource> : IEnumerableSink<TSource, float>
    {
        private readonly Func<TSource, float> _selector;

        private float _sum;

        public SumOfSingleSink(Func<TSource, float> selector)
        {
            _selector = selector;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            _sum += _selector(element);
            return true;
        }

        public void Dispose()
        {
        }

        public float GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfInt32Sink : IEnumerableSink<int, int>
    {
        private int _sum;

        public bool AcceptFirst(int element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(int element)
        {
            _sum += element;
            return true;
        }

        public void Dispose()
        {
        }

        public int GetContent()
        {
            return _sum;
        }

        public int GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfInt32Sink<TSource> : IEnumerableSink<TSource, int>
    {
        private readonly Func<TSource, int> _selector;

        private int _sum;

        public SumOfInt32Sink(Func<TSource, int> selector)
        {
            _selector = selector;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            _sum += _selector(element);
            return true;
        }

        public void Dispose()
        {
        }

        public int GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfInt64Sink : IEnumerableSink<long, long>
    {
        private long _sum;

        public bool AcceptFirst(long element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(long element)
        {
            _sum += element;
            return true;
        }

        public void Dispose()
        {
        }

        public long GetContent()
        {
            return _sum;
        }

        public long GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfInt64Sink<TSource> : IEnumerableSink<TSource, long>
    {
        private readonly Func<TSource, long> _selector;

        private long _sum;

        public SumOfInt64Sink(Func<TSource, long> selector)
        {
            _selector = selector;
        }

        public bool AcceptFirst(TSource element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(TSource element)
        {
            _sum += _selector(element);
            return true;
        }

        public void Dispose()
        {
        }

        public long GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfNullableDecimalSink : IEnumerableSink<decimal?, decimal?>
    {
        private decimal _sum;

        public bool AcceptFirst(decimal? element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(decimal? element)
        {
            if (element.HasValue)
                _sum += element.Value;

            return true;
        }

        public void Dispose()
        {
        }

        public decimal? GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfNullableDecimalSink<TSource> : IEnumerableSink<TSource, decimal?>
    {
        private readonly Func<TSource, decimal?> _selector;

        private decimal _sum;

        public SumOfNullableDecimalSink(Func<TSource, decimal?> selector)
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
                _sum += nullable.Value;

            return true;
        }

        public void Dispose()
        {
        }

        public decimal? GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfNullableDoubleSink : IEnumerableSink<double?, double?>
    {
        private double _sum;

        public bool AcceptFirst(double? element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(double? element)
        {
            if (element.HasValue)
                _sum += element.Value;

            return true;
        }

        public void Dispose()
        {
        }

        public double? GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfNullableDoubleSink<TSource> : IEnumerableSink<TSource, double?>
    {
        private readonly Func<TSource, double?> _selector;

        private double _sum;

        public SumOfNullableDoubleSink(Func<TSource, double?> selector)
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
                _sum += nullable.Value;

            return true;
        }

        public void Dispose()
        {
        }

        public double? GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfNullableSingleSink : IEnumerableSink<float?, float?>
    {
        private float _sum;

        public bool AcceptFirst(float? element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(float? element)
        {
            if (element.HasValue)
                _sum += element.Value;

            return true;
        }

        public void Dispose()
        {
        }

        public float? GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfNullableSingleSink<TSource> : IEnumerableSink<TSource, float?>
    {
        private readonly Func<TSource, float?> _selector;

        private float _sum;

        public SumOfNullableSingleSink(Func<TSource, float?> selector)
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
                _sum += nullable.Value;

            return true;
        }

        public void Dispose()
        {
        }

        public float? GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfNullableInt32Sink : IEnumerableSink<int?, int?>
    {
        private int _sum;

        public bool AcceptFirst(int? element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(int? element)
        {
            if (element.HasValue)
                _sum += element.Value;

            return true;
        }

        public void Dispose()
        {
        }

        public int? GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfNullableInt32Sink<TSource> : IEnumerableSink<TSource, int?>
    {
        private readonly Func<TSource, int?> _selector;

        private int _sum;

        public SumOfNullableInt32Sink(Func<TSource, int?> selector)
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
                _sum += nullable.Value;

            return true;
        }

        public void Dispose()
        {
        }

        public int? GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfNullableInt64Sink : IEnumerableSink<long?, long?>
    {
        private long _sum;

        public bool AcceptFirst(long? element)
        {
            return AcceptNext(element);
        }

        public bool AcceptNext(long? element)
        {
            if (element.HasValue)
                _sum += element.Value;

            return true;
        }

        public void Dispose()
        {
        }

        public long? GetResult()
        {
            return _sum;
        }
    }

    internal class SumOfNullableInt64Sink<TSource> : IEnumerableSink<TSource, long?>
    {
        private readonly Func<TSource, long?> _selector;

        private long _sum;

        public SumOfNullableInt64Sink(Func<TSource, long?> selector)
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
                _sum += nullable.Value;

            return true;
        }

        public void Dispose()
        {
        }

        public long? GetResult()
        {
            return _sum;
        }
    }

}