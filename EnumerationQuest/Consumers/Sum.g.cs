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

        public static IEnumerableConsumer<double, double> SumOfDouble()
        {
            return new SumOfDoubleConsumer();
        }

        public static IEnumerableConsumer<float, float> SumOfSingle()
        {
            return new SumOfSingleConsumer();
        }

        public static IEnumerableConsumer<int, int> SumOfInt32()
        {
            return new SumOfInt32Consumer();
        }

        public static IEnumerableConsumer<long, long> SumOfInt64()
        {
            return new SumOfInt64Consumer();
        }

        public static IEnumerableConsumer<decimal?, decimal?> SumOfNullableDecimal()
        {
            return new SumOfNullableDecimalConsumer();
        }

        public static IEnumerableConsumer<double?, double?> SumOfNullableDouble()
        {
            return new SumOfNullableDoubleConsumer();
        }

        public static IEnumerableConsumer<float?, float?> SumOfNullableSingle()
        {
            return new SumOfNullableSingleConsumer();
        }

        public static IEnumerableConsumer<int?, int?> SumOfNullableInt32()
        {
            return new SumOfNullableInt32Consumer();
        }

        public static IEnumerableConsumer<long?, long?> SumOfNullableInt64()
        {
            return new SumOfNullableInt64Consumer();
        }

        public static IEnumerableConsumer<TSource, decimal> SumOfDecimal<TSource>(Func<TSource, decimal> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfDecimalWithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, double> SumOfDouble<TSource>(Func<TSource, double> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfDoubleWithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, float> SumOfSingle<TSource>(Func<TSource, float> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfSingleWithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, int> SumOfInt32<TSource>(Func<TSource, int> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfInt32WithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, long> SumOfInt64<TSource>(Func<TSource, long> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfInt64WithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, decimal?> SumOfNullableDecimal<TSource>(Func<TSource, decimal?> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfNullableDecimalWithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, double?> SumOfNullableDouble<TSource>(Func<TSource, double?> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfNullableDoubleWithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, float?> SumOfNullableSingle<TSource>(Func<TSource, float?> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfNullableSingleWithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, int?> SumOfNullableInt32<TSource>(Func<TSource, int?> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfNullableInt32WithSelectorConsumer<TSource>(selector);
        }

        public static IEnumerableConsumer<TSource, long?> SumOfNullableInt64<TSource>(Func<TSource, long?> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));

            return new SumOfNullableInt64WithSelectorConsumer<TSource>(selector);
        }

    }

    internal class SumOfDecimalConsumer : IEnumerableConsumer<decimal, decimal>
    {
        public IEnumerableSink<decimal, decimal> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<decimal, decimal>
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

            public decimal GetResult()
            {
                return _sum;
            }
        }
    }

    internal class SumOfDecimalWithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, decimal>
    {
        private readonly Func<TSource, decimal> _selector;

        public SumOfDecimalWithSelectorConsumer(Func<TSource, decimal> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, decimal> GetSink()
        {
            return new Sink(_selector);
        }

        private class Sink : IEnumerableSink<TSource, decimal>
        {
            private readonly Func<TSource, decimal> _selector;

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
    }

    internal class SumOfDoubleConsumer : IEnumerableConsumer<double, double>
    {
        public IEnumerableSink<double, double> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<double, double>
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

            public double GetResult()
            {
                return _sum;
            }
        }
    }

    internal class SumOfDoubleWithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, double>
    {
        private readonly Func<TSource, double> _selector;

        public SumOfDoubleWithSelectorConsumer(Func<TSource, double> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, double> GetSink()
        {
            return new Sink(_selector);
        }

        private class Sink : IEnumerableSink<TSource, double>
        {
            private readonly Func<TSource, double> _selector;

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
    }

    internal class SumOfSingleConsumer : IEnumerableConsumer<float, float>
    {
        public IEnumerableSink<float, float> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<float, float>
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

            public float GetResult()
            {
                return _sum;
            }
        }
    }

    internal class SumOfSingleWithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, float>
    {
        private readonly Func<TSource, float> _selector;

        public SumOfSingleWithSelectorConsumer(Func<TSource, float> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, float> GetSink()
        {
            return new Sink(_selector);
        }

        private class Sink : IEnumerableSink<TSource, float>
        {
            private readonly Func<TSource, float> _selector;

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
    }

    internal class SumOfInt32Consumer : IEnumerableConsumer<int, int>
    {
        public IEnumerableSink<int, int> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<int, int>
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

            public int GetResult()
            {
                return _sum;
            }
        }
    }

    internal class SumOfInt32WithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, int>
    {
        private readonly Func<TSource, int> _selector;

        public SumOfInt32WithSelectorConsumer(Func<TSource, int> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, int> GetSink()
        {
            return new Sink(_selector);
        }

        private class Sink : IEnumerableSink<TSource, int>
        {
            private readonly Func<TSource, int> _selector;

            private int _sum;

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
    }

    internal class SumOfInt64Consumer : IEnumerableConsumer<long, long>
    {
        public IEnumerableSink<long, long> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<long, long>
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

            public long GetResult()
            {
                return _sum;
            }
        }
    }

    internal class SumOfInt64WithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, long>
    {
        private readonly Func<TSource, long> _selector;

        public SumOfInt64WithSelectorConsumer(Func<TSource, long> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, long> GetSink()
        {
            return new Sink(_selector);
        }

        private class Sink : IEnumerableSink<TSource, long>
        {
            private readonly Func<TSource, long> _selector;

            private long _sum;

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
    }

    internal class SumOfNullableDecimalConsumer : IEnumerableConsumer<decimal?, decimal?>
    {
        public IEnumerableSink<decimal?, decimal?> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<decimal?, decimal?>
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
    }

    internal class SumOfNullableDecimalWithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, decimal?>
    {
        private readonly Func<TSource, decimal?> _selector;

        public SumOfNullableDecimalWithSelectorConsumer(Func<TSource, decimal?> selector)
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
    }

    internal class SumOfNullableDoubleConsumer : IEnumerableConsumer<double?, double?>
    {
        public IEnumerableSink<double?, double?> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<double?, double?>
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
    }

    internal class SumOfNullableDoubleWithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, double?>
    {
        private readonly Func<TSource, double?> _selector;

        public SumOfNullableDoubleWithSelectorConsumer(Func<TSource, double?> selector)
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
    }

    internal class SumOfNullableSingleConsumer : IEnumerableConsumer<float?, float?>
    {
        public IEnumerableSink<float?, float?> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<float?, float?>
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
    }

    internal class SumOfNullableSingleWithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, float?>
    {
        private readonly Func<TSource, float?> _selector;

        public SumOfNullableSingleWithSelectorConsumer(Func<TSource, float?> selector)
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
    }

    internal class SumOfNullableInt32Consumer : IEnumerableConsumer<int?, int?>
    {
        public IEnumerableSink<int?, int?> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<int?, int?>
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
    }

    internal class SumOfNullableInt32WithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, int?>
    {
        private readonly Func<TSource, int?> _selector;

        public SumOfNullableInt32WithSelectorConsumer(Func<TSource, int?> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, int?> GetSink()
        {
            return new Sink(_selector);
        }

        private class Sink : IEnumerableSink<TSource, int?>
        {
            private readonly Func<TSource, int?> _selector;

            private int _sum;

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
    }

    internal class SumOfNullableInt64Consumer : IEnumerableConsumer<long?, long?>
    {
        public IEnumerableSink<long?, long?> GetSink()
        {
            return new Sink();
        }

        private class Sink : IEnumerableSink<long?, long?>
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
    }

    internal class SumOfNullableInt64WithSelectorConsumer<TSource> : IEnumerableConsumer<TSource, long?>
    {
        private readonly Func<TSource, long?> _selector;

        public SumOfNullableInt64WithSelectorConsumer(Func<TSource, long?> selector)
        {
            _selector = selector;
        }

        public IEnumerableSink<TSource, long?> GetSink()
        {
            return new Sink(_selector);
        }

        private class Sink : IEnumerableSink<TSource, long?>
        {
            private readonly Func<TSource, long?> _selector;

            private long _sum;

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

}