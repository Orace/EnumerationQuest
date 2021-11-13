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

namespace EnumerationQuest.Tests
{
    public abstract class Result : IEquatable<Result>
    {
        public static Result Evaluate<TValue>(Func<TValue> value)
        {
            try
            {
                return new ValueResult<TValue>(value());
            }
            catch (Exception e)
            {
                return new ExceptionResult(e.GetType());
            }
        }

        public static Result FromValue<TValue>(TValue value) => new ValueResult<TValue>(value);
        public static Result FromException<TException>() where TException : Exception => new ExceptionResult(typeof(TException));

        public abstract override bool Equals(object? obj);

        public abstract bool Equals(Result? other);

        public abstract override int GetHashCode();

        private class ExceptionResult : Result, IEquatable<ExceptionResult>
        {
            private readonly Type _exceptionType;

            public ExceptionResult(Type exceptionType)
            {
                _exceptionType = exceptionType;
            }

            public bool Equals(ExceptionResult? other)
            {
                if (other is null) return false;
                if (ReferenceEquals(this, other)) return true;
                return _exceptionType == other._exceptionType;
            }

            public override bool Equals(object? obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((ExceptionResult)obj);
            }

            public override bool Equals(Result? obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj is not ExceptionResult other) return false;
                return Equals(other);
            }

            public override int GetHashCode()
            {
                return _exceptionType.GetHashCode();
            }

            public override string ToString()
            {
                return $"(E) {_exceptionType.Name}";
            }

            public static bool operator ==(ExceptionResult? left, ExceptionResult? right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(ExceptionResult? left, ExceptionResult? right)
            {
                return !Equals(left, right);
            }
        }

        private class ValueResult<TValue> : Result, IEquatable<ValueResult<TValue>>
        {
            private readonly TValue _value;

            public ValueResult(TValue value)
            {
                _value = value;
            }

            public bool Equals(ValueResult<TValue>? other)
            {
                if (other is null) return false;
                if (ReferenceEquals(this, other)) return true;
                return EqualityComparer<TValue>.Default.Equals(_value, other._value);
            }

            public override bool Equals(object? obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((ValueResult<TValue>)obj);
            }

            public override bool Equals(Result? obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj is not ValueResult<TValue> other) return false;
                return Equals(other);
            }

            public override int GetHashCode()
            {
                return _value is null ? 0 : EqualityComparer<TValue>.Default.GetHashCode(_value);
            }

            public override string ToString()
            {
                return $"(V) {_value?.ToString() ?? "null"}";
            }

            public static bool operator ==(ValueResult<TValue>? left, ValueResult<TValue>? right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(ValueResult<TValue>? left, ValueResult<TValue>? right)
            {
                return !Equals(left, right);
            }
        }
    }
}