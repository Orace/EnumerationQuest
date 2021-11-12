using System;
using System.Collections.Generic;

#nullable enable

namespace EnumerationQuest
{
    /// <summary>
    ///     Stores enumeration requests on an unique sequence for deferred evaluation.
    /// </summary>
    /// <remarks>
    ///     <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is used to evaluate the requests.
    /// </remarks>
    /// <typeparam name="TSource">The type of the elements of the sequence to enumerate.</typeparam>
    /// <typeparam name="TResult1">The type of the result of the first request.</typeparam>
    public class EnumerationRequests1<TSource, TResult1> : EnumerationRequestsBase
    {
        private readonly IEnumerable<TSource> _enumerable;
        private readonly IEnumerableConsumer<TSource, TResult1> _consumer1;

        internal EnumerationRequests1(IEnumerable<TSource> enumerable, IEnumerableConsumer<TSource, TResult1> consumer1)
        {
            if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
            if (consumer1 is null) throw new ArgumentNullException(nameof(consumer1));

            _enumerable = enumerable;
            _consumer1 = consumer1;
        }

        internal EnumerationRequests2<TSource, TResult1, TResult> Add<TResult>(IEnumerableConsumer<TSource, TResult> consumer)
        {
            return new EnumerationRequests2<TSource, TResult1, TResult>(_enumerable, _consumer1, consumer);
        }

        /// <summary>
        ///     <para>
        ///         Evaluates the requests while enumerating the sequence once.<br/>
        ///         The requests results are returned as <see langword="out"/> arguments.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Each call to this method trigger a new evaluation of the requests and a new enumeration of the sequence.
        ///     </para>
        ///     <para>
        ///         This method is not intended to be used. Prefer the Linq equivalent of the unique request stored in this object.
        ///     </para>
        /// </remarks>
        /// <param name="result1">When this method returns, contains the result of the first request.</param>
        public void Deconstruct(out TResult1 result1)
        {
            using var sink1 = _consumer1.GetSink();

            Enumerate(_enumerable, sink1);

            var i = 1;
            try
            {
                result1 = sink1.GetResult(); i++;
            }
            catch(Exception e)
            {
                throw new EnumerationException($"The evaluation of Item{i} failed", e);
            }
        }
    }

    /// <summary>
    ///     Stores enumeration requests on an unique sequence for deferred evaluation.
    /// </summary>
    /// <remarks>
    ///     <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is used to evaluate the requests.
    /// </remarks>
    /// <typeparam name="TSource">The type of the elements of the sequence to enumerate.</typeparam>
    /// <typeparam name="TResult1">The type of the result of the first request.</typeparam>
    /// <typeparam name="TResult2">The type of the result of the second request.</typeparam>
    public class EnumerationRequests2<TSource, TResult1, TResult2> : EnumerationRequestsBase
    {
        private readonly IEnumerable<TSource> _enumerable;
        private readonly IEnumerableConsumer<TSource, TResult1> _consumer1;
        private readonly IEnumerableConsumer<TSource, TResult2> _consumer2;

        internal EnumerationRequests2(IEnumerable<TSource> enumerable, IEnumerableConsumer<TSource, TResult1> consumer1, IEnumerableConsumer<TSource, TResult2> consumer2)
        {
            if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
            if (consumer1 is null) throw new ArgumentNullException(nameof(consumer1));
            if (consumer2 is null) throw new ArgumentNullException(nameof(consumer2));

            _enumerable = enumerable;
            _consumer1 = consumer1;
            _consumer2 = consumer2;
        }

        internal EnumerationRequests3<TSource, TResult1, TResult2, TResult> Add<TResult>(IEnumerableConsumer<TSource, TResult> consumer)
        {
            return new EnumerationRequests3<TSource, TResult1, TResult2, TResult>(_enumerable, _consumer1, _consumer2, consumer);
        }

        /// <summary>
        ///     <para>
        ///         Evaluates the requests while enumerating the sequence once.<br/>
        ///         The requests results are returned as <see langword="out"/> arguments.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Each call to this method trigger a new evaluation of the requests and a new enumeration of the sequence.
        ///     </para>
        ///     <para>
        ///         This method is not intended to be directly called.
        ///         <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is the recommanded way to use this method.
        ///     </para>
        /// </remarks>
        /// <param name="result1">When this method returns, contains the result of the first request.</param>
        /// <param name="result2">When this method returns, contains the result of the second request.</param>
        public void Deconstruct(out TResult1 result1, out TResult2 result2)
        {
            using var sink1 = _consumer1.GetSink();
            using var sink2 = _consumer2.GetSink();

            Enumerate(_enumerable, sink1, sink2);

            var i = 1;
            try
            {
                result1 = sink1.GetResult(); i++;
                result2 = sink2.GetResult(); i++;
            }
            catch(Exception e)
            {
                throw new EnumerationException($"The evaluation of Item{i} failed", e);
            }
        }
    }

    /// <summary>
    ///     Stores enumeration requests on an unique sequence for deferred evaluation.
    /// </summary>
    /// <remarks>
    ///     <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is used to evaluate the requests.
    /// </remarks>
    /// <typeparam name="TSource">The type of the elements of the sequence to enumerate.</typeparam>
    /// <typeparam name="TResult1">The type of the result of the first request.</typeparam>
    /// <typeparam name="TResult2">The type of the result of the second request.</typeparam>
    /// <typeparam name="TResult3">The type of the result of the third request.</typeparam>
    public class EnumerationRequests3<TSource, TResult1, TResult2, TResult3> : EnumerationRequestsBase
    {
        private readonly IEnumerable<TSource> _enumerable;
        private readonly IEnumerableConsumer<TSource, TResult1> _consumer1;
        private readonly IEnumerableConsumer<TSource, TResult2> _consumer2;
        private readonly IEnumerableConsumer<TSource, TResult3> _consumer3;

        internal EnumerationRequests3(IEnumerable<TSource> enumerable, IEnumerableConsumer<TSource, TResult1> consumer1, IEnumerableConsumer<TSource, TResult2> consumer2, IEnumerableConsumer<TSource, TResult3> consumer3)
        {
            if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
            if (consumer1 is null) throw new ArgumentNullException(nameof(consumer1));
            if (consumer2 is null) throw new ArgumentNullException(nameof(consumer2));
            if (consumer3 is null) throw new ArgumentNullException(nameof(consumer3));

            _enumerable = enumerable;
            _consumer1 = consumer1;
            _consumer2 = consumer2;
            _consumer3 = consumer3;
        }

        internal EnumerationRequests4<TSource, TResult1, TResult2, TResult3, TResult> Add<TResult>(IEnumerableConsumer<TSource, TResult> consumer)
        {
            return new EnumerationRequests4<TSource, TResult1, TResult2, TResult3, TResult>(_enumerable, _consumer1, _consumer2, _consumer3, consumer);
        }

        /// <summary>
        ///     <para>
        ///         Evaluates the requests while enumerating the sequence once.<br/>
        ///         The requests results are returned as <see langword="out"/> arguments.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Each call to this method trigger a new evaluation of the requests and a new enumeration of the sequence.
        ///     </para>
        ///     <para>
        ///         This method is not intended to be directly called.
        ///         <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is the recommanded way to use this method.
        ///     </para>
        /// </remarks>
        /// <param name="result1">When this method returns, contains the result of the first request.</param>
        /// <param name="result2">When this method returns, contains the result of the second request.</param>
        /// <param name="result3">When this method returns, contains the result of the third request.</param>
        public void Deconstruct(out TResult1 result1, out TResult2 result2, out TResult3 result3)
        {
            using var sink1 = _consumer1.GetSink();
            using var sink2 = _consumer2.GetSink();
            using var sink3 = _consumer3.GetSink();

            Enumerate(_enumerable, sink1, sink2, sink3);

            var i = 1;
            try
            {
                result1 = sink1.GetResult(); i++;
                result2 = sink2.GetResult(); i++;
                result3 = sink3.GetResult(); i++;
            }
            catch(Exception e)
            {
                throw new EnumerationException($"The evaluation of Item{i} failed", e);
            }
        }
    }

    /// <summary>
    ///     Stores enumeration requests on an unique sequence for deferred evaluation.
    /// </summary>
    /// <remarks>
    ///     <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is used to evaluate the requests.
    /// </remarks>
    /// <typeparam name="TSource">The type of the elements of the sequence to enumerate.</typeparam>
    /// <typeparam name="TResult1">The type of the result of the first request.</typeparam>
    /// <typeparam name="TResult2">The type of the result of the second request.</typeparam>
    /// <typeparam name="TResult3">The type of the result of the third request.</typeparam>
    /// <typeparam name="TResult4">The type of the result of the fourth request.</typeparam>
    public class EnumerationRequests4<TSource, TResult1, TResult2, TResult3, TResult4> : EnumerationRequestsBase
    {
        private readonly IEnumerable<TSource> _enumerable;
        private readonly IEnumerableConsumer<TSource, TResult1> _consumer1;
        private readonly IEnumerableConsumer<TSource, TResult2> _consumer2;
        private readonly IEnumerableConsumer<TSource, TResult3> _consumer3;
        private readonly IEnumerableConsumer<TSource, TResult4> _consumer4;

        internal EnumerationRequests4(IEnumerable<TSource> enumerable, IEnumerableConsumer<TSource, TResult1> consumer1, IEnumerableConsumer<TSource, TResult2> consumer2, IEnumerableConsumer<TSource, TResult3> consumer3, IEnumerableConsumer<TSource, TResult4> consumer4)
        {
            if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
            if (consumer1 is null) throw new ArgumentNullException(nameof(consumer1));
            if (consumer2 is null) throw new ArgumentNullException(nameof(consumer2));
            if (consumer3 is null) throw new ArgumentNullException(nameof(consumer3));
            if (consumer4 is null) throw new ArgumentNullException(nameof(consumer4));

            _enumerable = enumerable;
            _consumer1 = consumer1;
            _consumer2 = consumer2;
            _consumer3 = consumer3;
            _consumer4 = consumer4;
        }

        internal EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, TResult> Add<TResult>(IEnumerableConsumer<TSource, TResult> consumer)
        {
            return new EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, TResult>(_enumerable, _consumer1, _consumer2, _consumer3, _consumer4, consumer);
        }

        /// <summary>
        ///     <para>
        ///         Evaluates the requests while enumerating the sequence once.<br/>
        ///         The requests results are returned as <see langword="out"/> arguments.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Each call to this method trigger a new evaluation of the requests and a new enumeration of the sequence.
        ///     </para>
        ///     <para>
        ///         This method is not intended to be directly called.
        ///         <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is the recommanded way to use this method.
        ///     </para>
        /// </remarks>
        /// <param name="result1">When this method returns, contains the result of the first request.</param>
        /// <param name="result2">When this method returns, contains the result of the second request.</param>
        /// <param name="result3">When this method returns, contains the result of the third request.</param>
        /// <param name="result4">When this method returns, contains the result of the fourth request.</param>
        public void Deconstruct(out TResult1 result1, out TResult2 result2, out TResult3 result3, out TResult4 result4)
        {
            using var sink1 = _consumer1.GetSink();
            using var sink2 = _consumer2.GetSink();
            using var sink3 = _consumer3.GetSink();
            using var sink4 = _consumer4.GetSink();

            Enumerate(_enumerable, sink1, sink2, sink3, sink4);

            var i = 1;
            try
            {
                result1 = sink1.GetResult(); i++;
                result2 = sink2.GetResult(); i++;
                result3 = sink3.GetResult(); i++;
                result4 = sink4.GetResult(); i++;
            }
            catch(Exception e)
            {
                throw new EnumerationException($"The evaluation of Item{i} failed", e);
            }
        }
    }

    /// <summary>
    ///     Stores enumeration requests on an unique sequence for deferred evaluation.
    /// </summary>
    /// <remarks>
    ///     <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is used to evaluate the requests.
    /// </remarks>
    /// <typeparam name="TSource">The type of the elements of the sequence to enumerate.</typeparam>
    /// <typeparam name="TResult1">The type of the result of the first request.</typeparam>
    /// <typeparam name="TResult2">The type of the result of the second request.</typeparam>
    /// <typeparam name="TResult3">The type of the result of the third request.</typeparam>
    /// <typeparam name="TResult4">The type of the result of the fourth request.</typeparam>
    /// <typeparam name="TResult5">The type of the result of the fifth request.</typeparam>
    public class EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, TResult5> : EnumerationRequestsBase
    {
        private readonly IEnumerable<TSource> _enumerable;
        private readonly IEnumerableConsumer<TSource, TResult1> _consumer1;
        private readonly IEnumerableConsumer<TSource, TResult2> _consumer2;
        private readonly IEnumerableConsumer<TSource, TResult3> _consumer3;
        private readonly IEnumerableConsumer<TSource, TResult4> _consumer4;
        private readonly IEnumerableConsumer<TSource, TResult5> _consumer5;

        internal EnumerationRequests5(IEnumerable<TSource> enumerable, IEnumerableConsumer<TSource, TResult1> consumer1, IEnumerableConsumer<TSource, TResult2> consumer2, IEnumerableConsumer<TSource, TResult3> consumer3, IEnumerableConsumer<TSource, TResult4> consumer4, IEnumerableConsumer<TSource, TResult5> consumer5)
        {
            if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
            if (consumer1 is null) throw new ArgumentNullException(nameof(consumer1));
            if (consumer2 is null) throw new ArgumentNullException(nameof(consumer2));
            if (consumer3 is null) throw new ArgumentNullException(nameof(consumer3));
            if (consumer4 is null) throw new ArgumentNullException(nameof(consumer4));
            if (consumer5 is null) throw new ArgumentNullException(nameof(consumer5));

            _enumerable = enumerable;
            _consumer1 = consumer1;
            _consumer2 = consumer2;
            _consumer3 = consumer3;
            _consumer4 = consumer4;
            _consumer5 = consumer5;
        }

        internal EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult> Add<TResult>(IEnumerableConsumer<TSource, TResult> consumer)
        {
            return new EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult>(_enumerable, _consumer1, _consumer2, _consumer3, _consumer4, _consumer5, consumer);
        }

        /// <summary>
        ///     <para>
        ///         Evaluates the requests while enumerating the sequence once.<br/>
        ///         The requests results are returned as <see langword="out"/> arguments.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Each call to this method trigger a new evaluation of the requests and a new enumeration of the sequence.
        ///     </para>
        ///     <para>
        ///         This method is not intended to be directly called.
        ///         <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is the recommanded way to use this method.
        ///     </para>
        /// </remarks>
        /// <param name="result1">When this method returns, contains the result of the first request.</param>
        /// <param name="result2">When this method returns, contains the result of the second request.</param>
        /// <param name="result3">When this method returns, contains the result of the third request.</param>
        /// <param name="result4">When this method returns, contains the result of the fourth request.</param>
        /// <param name="result5">When this method returns, contains the result of the fifth request.</param>
        public void Deconstruct(out TResult1 result1, out TResult2 result2, out TResult3 result3, out TResult4 result4, out TResult5 result5)
        {
            using var sink1 = _consumer1.GetSink();
            using var sink2 = _consumer2.GetSink();
            using var sink3 = _consumer3.GetSink();
            using var sink4 = _consumer4.GetSink();
            using var sink5 = _consumer5.GetSink();

            Enumerate(_enumerable, sink1, sink2, sink3, sink4, sink5);

            var i = 1;
            try
            {
                result1 = sink1.GetResult(); i++;
                result2 = sink2.GetResult(); i++;
                result3 = sink3.GetResult(); i++;
                result4 = sink4.GetResult(); i++;
                result5 = sink5.GetResult(); i++;
            }
            catch(Exception e)
            {
                throw new EnumerationException($"The evaluation of Item{i} failed", e);
            }
        }
    }

    /// <summary>
    ///     Stores enumeration requests on an unique sequence for deferred evaluation.
    /// </summary>
    /// <remarks>
    ///     <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is used to evaluate the requests.
    /// </remarks>
    /// <typeparam name="TSource">The type of the elements of the sequence to enumerate.</typeparam>
    /// <typeparam name="TResult1">The type of the result of the first request.</typeparam>
    /// <typeparam name="TResult2">The type of the result of the second request.</typeparam>
    /// <typeparam name="TResult3">The type of the result of the third request.</typeparam>
    /// <typeparam name="TResult4">The type of the result of the fourth request.</typeparam>
    /// <typeparam name="TResult5">The type of the result of the fifth request.</typeparam>
    /// <typeparam name="TResult6">The type of the result of the sixth request.</typeparam>
    public class EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> : EnumerationRequestsBase
    {
        private readonly IEnumerable<TSource> _enumerable;
        private readonly IEnumerableConsumer<TSource, TResult1> _consumer1;
        private readonly IEnumerableConsumer<TSource, TResult2> _consumer2;
        private readonly IEnumerableConsumer<TSource, TResult3> _consumer3;
        private readonly IEnumerableConsumer<TSource, TResult4> _consumer4;
        private readonly IEnumerableConsumer<TSource, TResult5> _consumer5;
        private readonly IEnumerableConsumer<TSource, TResult6> _consumer6;

        internal EnumerationRequests6(IEnumerable<TSource> enumerable, IEnumerableConsumer<TSource, TResult1> consumer1, IEnumerableConsumer<TSource, TResult2> consumer2, IEnumerableConsumer<TSource, TResult3> consumer3, IEnumerableConsumer<TSource, TResult4> consumer4, IEnumerableConsumer<TSource, TResult5> consumer5, IEnumerableConsumer<TSource, TResult6> consumer6)
        {
            if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
            if (consumer1 is null) throw new ArgumentNullException(nameof(consumer1));
            if (consumer2 is null) throw new ArgumentNullException(nameof(consumer2));
            if (consumer3 is null) throw new ArgumentNullException(nameof(consumer3));
            if (consumer4 is null) throw new ArgumentNullException(nameof(consumer4));
            if (consumer5 is null) throw new ArgumentNullException(nameof(consumer5));
            if (consumer6 is null) throw new ArgumentNullException(nameof(consumer6));

            _enumerable = enumerable;
            _consumer1 = consumer1;
            _consumer2 = consumer2;
            _consumer3 = consumer3;
            _consumer4 = consumer4;
            _consumer5 = consumer5;
            _consumer6 = consumer6;
        }

        internal EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult> Add<TResult>(IEnumerableConsumer<TSource, TResult> consumer)
        {
            return new EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult>(_enumerable, _consumer1, _consumer2, _consumer3, _consumer4, _consumer5, _consumer6, consumer);
        }

        /// <summary>
        ///     <para>
        ///         Evaluates the requests while enumerating the sequence once.<br/>
        ///         The requests results are returned as <see langword="out"/> arguments.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Each call to this method trigger a new evaluation of the requests and a new enumeration of the sequence.
        ///     </para>
        ///     <para>
        ///         This method is not intended to be directly called.
        ///         <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is the recommanded way to use this method.
        ///     </para>
        /// </remarks>
        /// <param name="result1">When this method returns, contains the result of the first request.</param>
        /// <param name="result2">When this method returns, contains the result of the second request.</param>
        /// <param name="result3">When this method returns, contains the result of the third request.</param>
        /// <param name="result4">When this method returns, contains the result of the fourth request.</param>
        /// <param name="result5">When this method returns, contains the result of the fifth request.</param>
        /// <param name="result6">When this method returns, contains the result of the sixth request.</param>
        public void Deconstruct(out TResult1 result1, out TResult2 result2, out TResult3 result3, out TResult4 result4, out TResult5 result5, out TResult6 result6)
        {
            using var sink1 = _consumer1.GetSink();
            using var sink2 = _consumer2.GetSink();
            using var sink3 = _consumer3.GetSink();
            using var sink4 = _consumer4.GetSink();
            using var sink5 = _consumer5.GetSink();
            using var sink6 = _consumer6.GetSink();

            Enumerate(_enumerable, sink1, sink2, sink3, sink4, sink5, sink6);

            var i = 1;
            try
            {
                result1 = sink1.GetResult(); i++;
                result2 = sink2.GetResult(); i++;
                result3 = sink3.GetResult(); i++;
                result4 = sink4.GetResult(); i++;
                result5 = sink5.GetResult(); i++;
                result6 = sink6.GetResult(); i++;
            }
            catch(Exception e)
            {
                throw new EnumerationException($"The evaluation of Item{i} failed", e);
            }
        }
    }

    /// <summary>
    ///     Stores enumeration requests on an unique sequence for deferred evaluation.
    /// </summary>
    /// <remarks>
    ///     <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is used to evaluate the requests.
    /// </remarks>
    /// <typeparam name="TSource">The type of the elements of the sequence to enumerate.</typeparam>
    /// <typeparam name="TResult1">The type of the result of the first request.</typeparam>
    /// <typeparam name="TResult2">The type of the result of the second request.</typeparam>
    /// <typeparam name="TResult3">The type of the result of the third request.</typeparam>
    /// <typeparam name="TResult4">The type of the result of the fourth request.</typeparam>
    /// <typeparam name="TResult5">The type of the result of the fifth request.</typeparam>
    /// <typeparam name="TResult6">The type of the result of the sixth request.</typeparam>
    /// <typeparam name="TResult7">The type of the result of the seventh request.</typeparam>
    public class EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7> : EnumerationRequestsBase
    {
        private readonly IEnumerable<TSource> _enumerable;
        private readonly IEnumerableConsumer<TSource, TResult1> _consumer1;
        private readonly IEnumerableConsumer<TSource, TResult2> _consumer2;
        private readonly IEnumerableConsumer<TSource, TResult3> _consumer3;
        private readonly IEnumerableConsumer<TSource, TResult4> _consumer4;
        private readonly IEnumerableConsumer<TSource, TResult5> _consumer5;
        private readonly IEnumerableConsumer<TSource, TResult6> _consumer6;
        private readonly IEnumerableConsumer<TSource, TResult7> _consumer7;

        internal EnumerationRequests7(IEnumerable<TSource> enumerable, IEnumerableConsumer<TSource, TResult1> consumer1, IEnumerableConsumer<TSource, TResult2> consumer2, IEnumerableConsumer<TSource, TResult3> consumer3, IEnumerableConsumer<TSource, TResult4> consumer4, IEnumerableConsumer<TSource, TResult5> consumer5, IEnumerableConsumer<TSource, TResult6> consumer6, IEnumerableConsumer<TSource, TResult7> consumer7)
        {
            if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
            if (consumer1 is null) throw new ArgumentNullException(nameof(consumer1));
            if (consumer2 is null) throw new ArgumentNullException(nameof(consumer2));
            if (consumer3 is null) throw new ArgumentNullException(nameof(consumer3));
            if (consumer4 is null) throw new ArgumentNullException(nameof(consumer4));
            if (consumer5 is null) throw new ArgumentNullException(nameof(consumer5));
            if (consumer6 is null) throw new ArgumentNullException(nameof(consumer6));
            if (consumer7 is null) throw new ArgumentNullException(nameof(consumer7));

            _enumerable = enumerable;
            _consumer1 = consumer1;
            _consumer2 = consumer2;
            _consumer3 = consumer3;
            _consumer4 = consumer4;
            _consumer5 = consumer5;
            _consumer6 = consumer6;
            _consumer7 = consumer7;
        }

        internal EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult> Add<TResult>(IEnumerableConsumer<TSource, TResult> consumer)
        {
            return new EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult>(_enumerable, _consumer1, _consumer2, _consumer3, _consumer4, _consumer5, _consumer6, _consumer7, consumer);
        }

        /// <summary>
        ///     <para>
        ///         Evaluates the requests while enumerating the sequence once.<br/>
        ///         The requests results are returned as <see langword="out"/> arguments.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Each call to this method trigger a new evaluation of the requests and a new enumeration of the sequence.
        ///     </para>
        ///     <para>
        ///         This method is not intended to be directly called.
        ///         <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is the recommanded way to use this method.
        ///     </para>
        /// </remarks>
        /// <param name="result1">When this method returns, contains the result of the first request.</param>
        /// <param name="result2">When this method returns, contains the result of the second request.</param>
        /// <param name="result3">When this method returns, contains the result of the third request.</param>
        /// <param name="result4">When this method returns, contains the result of the fourth request.</param>
        /// <param name="result5">When this method returns, contains the result of the fifth request.</param>
        /// <param name="result6">When this method returns, contains the result of the sixth request.</param>
        /// <param name="result7">When this method returns, contains the result of the seventh request.</param>
        public void Deconstruct(out TResult1 result1, out TResult2 result2, out TResult3 result3, out TResult4 result4, out TResult5 result5, out TResult6 result6, out TResult7 result7)
        {
            using var sink1 = _consumer1.GetSink();
            using var sink2 = _consumer2.GetSink();
            using var sink3 = _consumer3.GetSink();
            using var sink4 = _consumer4.GetSink();
            using var sink5 = _consumer5.GetSink();
            using var sink6 = _consumer6.GetSink();
            using var sink7 = _consumer7.GetSink();

            Enumerate(_enumerable, sink1, sink2, sink3, sink4, sink5, sink6, sink7);

            var i = 1;
            try
            {
                result1 = sink1.GetResult(); i++;
                result2 = sink2.GetResult(); i++;
                result3 = sink3.GetResult(); i++;
                result4 = sink4.GetResult(); i++;
                result5 = sink5.GetResult(); i++;
                result6 = sink6.GetResult(); i++;
                result7 = sink7.GetResult(); i++;
            }
            catch(Exception e)
            {
                throw new EnumerationException($"The evaluation of Item{i} failed", e);
            }
        }
    }

    /// <summary>
    ///     Stores enumeration requests on an unique sequence for deferred evaluation.
    /// </summary>
    /// <remarks>
    ///     <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is used to evaluate the requests.
    /// </remarks>
    /// <typeparam name="TSource">The type of the elements of the sequence to enumerate.</typeparam>
    /// <typeparam name="TResult1">The type of the result of the first request.</typeparam>
    /// <typeparam name="TResult2">The type of the result of the second request.</typeparam>
    /// <typeparam name="TResult3">The type of the result of the third request.</typeparam>
    /// <typeparam name="TResult4">The type of the result of the fourth request.</typeparam>
    /// <typeparam name="TResult5">The type of the result of the fifth request.</typeparam>
    /// <typeparam name="TResult6">The type of the result of the sixth request.</typeparam>
    /// <typeparam name="TResult7">The type of the result of the seventh request.</typeparam>
    /// <typeparam name="TResult8">The type of the result of the eighth request.</typeparam>
    public class EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8> : EnumerationRequestsBase
    {
        private readonly IEnumerable<TSource> _enumerable;
        private readonly IEnumerableConsumer<TSource, TResult1> _consumer1;
        private readonly IEnumerableConsumer<TSource, TResult2> _consumer2;
        private readonly IEnumerableConsumer<TSource, TResult3> _consumer3;
        private readonly IEnumerableConsumer<TSource, TResult4> _consumer4;
        private readonly IEnumerableConsumer<TSource, TResult5> _consumer5;
        private readonly IEnumerableConsumer<TSource, TResult6> _consumer6;
        private readonly IEnumerableConsumer<TSource, TResult7> _consumer7;
        private readonly IEnumerableConsumer<TSource, TResult8> _consumer8;

        internal EnumerationRequests8(IEnumerable<TSource> enumerable, IEnumerableConsumer<TSource, TResult1> consumer1, IEnumerableConsumer<TSource, TResult2> consumer2, IEnumerableConsumer<TSource, TResult3> consumer3, IEnumerableConsumer<TSource, TResult4> consumer4, IEnumerableConsumer<TSource, TResult5> consumer5, IEnumerableConsumer<TSource, TResult6> consumer6, IEnumerableConsumer<TSource, TResult7> consumer7, IEnumerableConsumer<TSource, TResult8> consumer8)
        {
            if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
            if (consumer1 is null) throw new ArgumentNullException(nameof(consumer1));
            if (consumer2 is null) throw new ArgumentNullException(nameof(consumer2));
            if (consumer3 is null) throw new ArgumentNullException(nameof(consumer3));
            if (consumer4 is null) throw new ArgumentNullException(nameof(consumer4));
            if (consumer5 is null) throw new ArgumentNullException(nameof(consumer5));
            if (consumer6 is null) throw new ArgumentNullException(nameof(consumer6));
            if (consumer7 is null) throw new ArgumentNullException(nameof(consumer7));
            if (consumer8 is null) throw new ArgumentNullException(nameof(consumer8));

            _enumerable = enumerable;
            _consumer1 = consumer1;
            _consumer2 = consumer2;
            _consumer3 = consumer3;
            _consumer4 = consumer4;
            _consumer5 = consumer5;
            _consumer6 = consumer6;
            _consumer7 = consumer7;
            _consumer8 = consumer8;
        }

        internal EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult> Add<TResult>(IEnumerableConsumer<TSource, TResult> consumer)
        {
            return new EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult>(_enumerable, _consumer1, _consumer2, _consumer3, _consumer4, _consumer5, _consumer6, _consumer7, _consumer8, consumer);
        }

        /// <summary>
        ///     <para>
        ///         Evaluates the requests while enumerating the sequence once.<br/>
        ///         The requests results are returned as <see langword="out"/> arguments.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Each call to this method trigger a new evaluation of the requests and a new enumeration of the sequence.
        ///     </para>
        ///     <para>
        ///         This method is not intended to be directly called.
        ///         <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is the recommanded way to use this method.
        ///     </para>
        /// </remarks>
        /// <param name="result1">When this method returns, contains the result of the first request.</param>
        /// <param name="result2">When this method returns, contains the result of the second request.</param>
        /// <param name="result3">When this method returns, contains the result of the third request.</param>
        /// <param name="result4">When this method returns, contains the result of the fourth request.</param>
        /// <param name="result5">When this method returns, contains the result of the fifth request.</param>
        /// <param name="result6">When this method returns, contains the result of the sixth request.</param>
        /// <param name="result7">When this method returns, contains the result of the seventh request.</param>
        /// <param name="result8">When this method returns, contains the result of the eighth request.</param>
        public void Deconstruct(out TResult1 result1, out TResult2 result2, out TResult3 result3, out TResult4 result4, out TResult5 result5, out TResult6 result6, out TResult7 result7, out TResult8 result8)
        {
            using var sink1 = _consumer1.GetSink();
            using var sink2 = _consumer2.GetSink();
            using var sink3 = _consumer3.GetSink();
            using var sink4 = _consumer4.GetSink();
            using var sink5 = _consumer5.GetSink();
            using var sink6 = _consumer6.GetSink();
            using var sink7 = _consumer7.GetSink();
            using var sink8 = _consumer8.GetSink();

            Enumerate(_enumerable, sink1, sink2, sink3, sink4, sink5, sink6, sink7, sink8);

            var i = 1;
            try
            {
                result1 = sink1.GetResult(); i++;
                result2 = sink2.GetResult(); i++;
                result3 = sink3.GetResult(); i++;
                result4 = sink4.GetResult(); i++;
                result5 = sink5.GetResult(); i++;
                result6 = sink6.GetResult(); i++;
                result7 = sink7.GetResult(); i++;
                result8 = sink8.GetResult(); i++;
            }
            catch(Exception e)
            {
                throw new EnumerationException($"The evaluation of Item{i} failed", e);
            }
        }
    }

    /// <summary>
    ///     Stores enumeration requests on an unique sequence for deferred evaluation.
    /// </summary>
    /// <remarks>
    ///     <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is used to evaluate the requests.
    /// </remarks>
    /// <typeparam name="TSource">The type of the elements of the sequence to enumerate.</typeparam>
    /// <typeparam name="TResult1">The type of the result of the first request.</typeparam>
    /// <typeparam name="TResult2">The type of the result of the second request.</typeparam>
    /// <typeparam name="TResult3">The type of the result of the third request.</typeparam>
    /// <typeparam name="TResult4">The type of the result of the fourth request.</typeparam>
    /// <typeparam name="TResult5">The type of the result of the fifth request.</typeparam>
    /// <typeparam name="TResult6">The type of the result of the sixth request.</typeparam>
    /// <typeparam name="TResult7">The type of the result of the seventh request.</typeparam>
    /// <typeparam name="TResult8">The type of the result of the eighth request.</typeparam>
    /// <typeparam name="TResult9">The type of the result of the ninth request.</typeparam>
    public class EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9> : EnumerationRequestsBase
    {
        private readonly IEnumerable<TSource> _enumerable;
        private readonly IEnumerableConsumer<TSource, TResult1> _consumer1;
        private readonly IEnumerableConsumer<TSource, TResult2> _consumer2;
        private readonly IEnumerableConsumer<TSource, TResult3> _consumer3;
        private readonly IEnumerableConsumer<TSource, TResult4> _consumer4;
        private readonly IEnumerableConsumer<TSource, TResult5> _consumer5;
        private readonly IEnumerableConsumer<TSource, TResult6> _consumer6;
        private readonly IEnumerableConsumer<TSource, TResult7> _consumer7;
        private readonly IEnumerableConsumer<TSource, TResult8> _consumer8;
        private readonly IEnumerableConsumer<TSource, TResult9> _consumer9;

        internal EnumerationRequests9(IEnumerable<TSource> enumerable, IEnumerableConsumer<TSource, TResult1> consumer1, IEnumerableConsumer<TSource, TResult2> consumer2, IEnumerableConsumer<TSource, TResult3> consumer3, IEnumerableConsumer<TSource, TResult4> consumer4, IEnumerableConsumer<TSource, TResult5> consumer5, IEnumerableConsumer<TSource, TResult6> consumer6, IEnumerableConsumer<TSource, TResult7> consumer7, IEnumerableConsumer<TSource, TResult8> consumer8, IEnumerableConsumer<TSource, TResult9> consumer9)
        {
            if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
            if (consumer1 is null) throw new ArgumentNullException(nameof(consumer1));
            if (consumer2 is null) throw new ArgumentNullException(nameof(consumer2));
            if (consumer3 is null) throw new ArgumentNullException(nameof(consumer3));
            if (consumer4 is null) throw new ArgumentNullException(nameof(consumer4));
            if (consumer5 is null) throw new ArgumentNullException(nameof(consumer5));
            if (consumer6 is null) throw new ArgumentNullException(nameof(consumer6));
            if (consumer7 is null) throw new ArgumentNullException(nameof(consumer7));
            if (consumer8 is null) throw new ArgumentNullException(nameof(consumer8));
            if (consumer9 is null) throw new ArgumentNullException(nameof(consumer9));

            _enumerable = enumerable;
            _consumer1 = consumer1;
            _consumer2 = consumer2;
            _consumer3 = consumer3;
            _consumer4 = consumer4;
            _consumer5 = consumer5;
            _consumer6 = consumer6;
            _consumer7 = consumer7;
            _consumer8 = consumer8;
            _consumer9 = consumer9;
        }

        internal EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult> Add<TResult>(IEnumerableConsumer<TSource, TResult> consumer)
        {
            return new EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult>(_enumerable, _consumer1, _consumer2, _consumer3, _consumer4, _consumer5, _consumer6, _consumer7, _consumer8, _consumer9, consumer);
        }

        /// <summary>
        ///     <para>
        ///         Evaluates the requests while enumerating the sequence once.<br/>
        ///         The requests results are returned as <see langword="out"/> arguments.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Each call to this method trigger a new evaluation of the requests and a new enumeration of the sequence.
        ///     </para>
        ///     <para>
        ///         This method is not intended to be directly called.
        ///         <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is the recommanded way to use this method.
        ///     </para>
        /// </remarks>
        /// <param name="result1">When this method returns, contains the result of the first request.</param>
        /// <param name="result2">When this method returns, contains the result of the second request.</param>
        /// <param name="result3">When this method returns, contains the result of the third request.</param>
        /// <param name="result4">When this method returns, contains the result of the fourth request.</param>
        /// <param name="result5">When this method returns, contains the result of the fifth request.</param>
        /// <param name="result6">When this method returns, contains the result of the sixth request.</param>
        /// <param name="result7">When this method returns, contains the result of the seventh request.</param>
        /// <param name="result8">When this method returns, contains the result of the eighth request.</param>
        /// <param name="result9">When this method returns, contains the result of the ninth request.</param>
        public void Deconstruct(out TResult1 result1, out TResult2 result2, out TResult3 result3, out TResult4 result4, out TResult5 result5, out TResult6 result6, out TResult7 result7, out TResult8 result8, out TResult9 result9)
        {
            using var sink1 = _consumer1.GetSink();
            using var sink2 = _consumer2.GetSink();
            using var sink3 = _consumer3.GetSink();
            using var sink4 = _consumer4.GetSink();
            using var sink5 = _consumer5.GetSink();
            using var sink6 = _consumer6.GetSink();
            using var sink7 = _consumer7.GetSink();
            using var sink8 = _consumer8.GetSink();
            using var sink9 = _consumer9.GetSink();

            Enumerate(_enumerable, sink1, sink2, sink3, sink4, sink5, sink6, sink7, sink8, sink9);

            var i = 1;
            try
            {
                result1 = sink1.GetResult(); i++;
                result2 = sink2.GetResult(); i++;
                result3 = sink3.GetResult(); i++;
                result4 = sink4.GetResult(); i++;
                result5 = sink5.GetResult(); i++;
                result6 = sink6.GetResult(); i++;
                result7 = sink7.GetResult(); i++;
                result8 = sink8.GetResult(); i++;
                result9 = sink9.GetResult(); i++;
            }
            catch(Exception e)
            {
                throw new EnumerationException($"The evaluation of Item{i} failed", e);
            }
        }
    }

    /// <summary>
    ///     Stores enumeration requests on an unique sequence for deferred evaluation.
    /// </summary>
    /// <remarks>
    ///     <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is used to evaluate the requests.
    /// </remarks>
    /// <typeparam name="TSource">The type of the elements of the sequence to enumerate.</typeparam>
    /// <typeparam name="TResult1">The type of the result of the first request.</typeparam>
    /// <typeparam name="TResult2">The type of the result of the second request.</typeparam>
    /// <typeparam name="TResult3">The type of the result of the third request.</typeparam>
    /// <typeparam name="TResult4">The type of the result of the fourth request.</typeparam>
    /// <typeparam name="TResult5">The type of the result of the fifth request.</typeparam>
    /// <typeparam name="TResult6">The type of the result of the sixth request.</typeparam>
    /// <typeparam name="TResult7">The type of the result of the seventh request.</typeparam>
    /// <typeparam name="TResult8">The type of the result of the eighth request.</typeparam>
    /// <typeparam name="TResult9">The type of the result of the ninth request.</typeparam>
    /// <typeparam name="TResult10">The type of the result of the tenth request.</typeparam>
    public class EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10> : EnumerationRequestsBase
    {
        private readonly IEnumerable<TSource> _enumerable;
        private readonly IEnumerableConsumer<TSource, TResult1> _consumer1;
        private readonly IEnumerableConsumer<TSource, TResult2> _consumer2;
        private readonly IEnumerableConsumer<TSource, TResult3> _consumer3;
        private readonly IEnumerableConsumer<TSource, TResult4> _consumer4;
        private readonly IEnumerableConsumer<TSource, TResult5> _consumer5;
        private readonly IEnumerableConsumer<TSource, TResult6> _consumer6;
        private readonly IEnumerableConsumer<TSource, TResult7> _consumer7;
        private readonly IEnumerableConsumer<TSource, TResult8> _consumer8;
        private readonly IEnumerableConsumer<TSource, TResult9> _consumer9;
        private readonly IEnumerableConsumer<TSource, TResult10> _consumer10;

        internal EnumerationRequests10(IEnumerable<TSource> enumerable, IEnumerableConsumer<TSource, TResult1> consumer1, IEnumerableConsumer<TSource, TResult2> consumer2, IEnumerableConsumer<TSource, TResult3> consumer3, IEnumerableConsumer<TSource, TResult4> consumer4, IEnumerableConsumer<TSource, TResult5> consumer5, IEnumerableConsumer<TSource, TResult6> consumer6, IEnumerableConsumer<TSource, TResult7> consumer7, IEnumerableConsumer<TSource, TResult8> consumer8, IEnumerableConsumer<TSource, TResult9> consumer9, IEnumerableConsumer<TSource, TResult10> consumer10)
        {
            if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
            if (consumer1 is null) throw new ArgumentNullException(nameof(consumer1));
            if (consumer2 is null) throw new ArgumentNullException(nameof(consumer2));
            if (consumer3 is null) throw new ArgumentNullException(nameof(consumer3));
            if (consumer4 is null) throw new ArgumentNullException(nameof(consumer4));
            if (consumer5 is null) throw new ArgumentNullException(nameof(consumer5));
            if (consumer6 is null) throw new ArgumentNullException(nameof(consumer6));
            if (consumer7 is null) throw new ArgumentNullException(nameof(consumer7));
            if (consumer8 is null) throw new ArgumentNullException(nameof(consumer8));
            if (consumer9 is null) throw new ArgumentNullException(nameof(consumer9));
            if (consumer10 is null) throw new ArgumentNullException(nameof(consumer10));

            _enumerable = enumerable;
            _consumer1 = consumer1;
            _consumer2 = consumer2;
            _consumer3 = consumer3;
            _consumer4 = consumer4;
            _consumer5 = consumer5;
            _consumer6 = consumer6;
            _consumer7 = consumer7;
            _consumer8 = consumer8;
            _consumer9 = consumer9;
            _consumer10 = consumer10;
        }

        internal EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult> Add<TResult>(IEnumerableConsumer<TSource, TResult> consumer)
        {
            return new EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult>(_enumerable, _consumer1, _consumer2, _consumer3, _consumer4, _consumer5, _consumer6, _consumer7, _consumer8, _consumer9, _consumer10, consumer);
        }

        /// <summary>
        ///     <para>
        ///         Evaluates the requests while enumerating the sequence once.<br/>
        ///         The requests results are returned as <see langword="out"/> arguments.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Each call to this method trigger a new evaluation of the requests and a new enumeration of the sequence.
        ///     </para>
        ///     <para>
        ///         This method is not intended to be directly called.
        ///         <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is the recommanded way to use this method.
        ///     </para>
        /// </remarks>
        /// <param name="result1">When this method returns, contains the result of the first request.</param>
        /// <param name="result2">When this method returns, contains the result of the second request.</param>
        /// <param name="result3">When this method returns, contains the result of the third request.</param>
        /// <param name="result4">When this method returns, contains the result of the fourth request.</param>
        /// <param name="result5">When this method returns, contains the result of the fifth request.</param>
        /// <param name="result6">When this method returns, contains the result of the sixth request.</param>
        /// <param name="result7">When this method returns, contains the result of the seventh request.</param>
        /// <param name="result8">When this method returns, contains the result of the eighth request.</param>
        /// <param name="result9">When this method returns, contains the result of the ninth request.</param>
        /// <param name="result10">When this method returns, contains the result of the tenth request.</param>
        public void Deconstruct(out TResult1 result1, out TResult2 result2, out TResult3 result3, out TResult4 result4, out TResult5 result5, out TResult6 result6, out TResult7 result7, out TResult8 result8, out TResult9 result9, out TResult10 result10)
        {
            using var sink1 = _consumer1.GetSink();
            using var sink2 = _consumer2.GetSink();
            using var sink3 = _consumer3.GetSink();
            using var sink4 = _consumer4.GetSink();
            using var sink5 = _consumer5.GetSink();
            using var sink6 = _consumer6.GetSink();
            using var sink7 = _consumer7.GetSink();
            using var sink8 = _consumer8.GetSink();
            using var sink9 = _consumer9.GetSink();
            using var sink10 = _consumer10.GetSink();

            Enumerate(_enumerable, sink1, sink2, sink3, sink4, sink5, sink6, sink7, sink8, sink9, sink10);

            var i = 1;
            try
            {
                result1 = sink1.GetResult(); i++;
                result2 = sink2.GetResult(); i++;
                result3 = sink3.GetResult(); i++;
                result4 = sink4.GetResult(); i++;
                result5 = sink5.GetResult(); i++;
                result6 = sink6.GetResult(); i++;
                result7 = sink7.GetResult(); i++;
                result8 = sink8.GetResult(); i++;
                result9 = sink9.GetResult(); i++;
                result10 = sink10.GetResult(); i++;
            }
            catch(Exception e)
            {
                throw new EnumerationException($"The evaluation of Item{i} failed", e);
            }
        }
    }

    /// <summary>
    ///     Stores enumeration requests on an unique sequence for deferred evaluation.
    /// </summary>
    /// <remarks>
    ///     <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is used to evaluate the requests.
    /// </remarks>
    /// <typeparam name="TSource">The type of the elements of the sequence to enumerate.</typeparam>
    /// <typeparam name="TResult1">The type of the result of the first request.</typeparam>
    /// <typeparam name="TResult2">The type of the result of the second request.</typeparam>
    /// <typeparam name="TResult3">The type of the result of the third request.</typeparam>
    /// <typeparam name="TResult4">The type of the result of the fourth request.</typeparam>
    /// <typeparam name="TResult5">The type of the result of the fifth request.</typeparam>
    /// <typeparam name="TResult6">The type of the result of the sixth request.</typeparam>
    /// <typeparam name="TResult7">The type of the result of the seventh request.</typeparam>
    /// <typeparam name="TResult8">The type of the result of the eighth request.</typeparam>
    /// <typeparam name="TResult9">The type of the result of the ninth request.</typeparam>
    /// <typeparam name="TResult10">The type of the result of the tenth request.</typeparam>
    /// <typeparam name="TResult11">The type of the result of the eleventh request.</typeparam>
    public class EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11> : EnumerationRequestsBase
    {
        private readonly IEnumerable<TSource> _enumerable;
        private readonly IEnumerableConsumer<TSource, TResult1> _consumer1;
        private readonly IEnumerableConsumer<TSource, TResult2> _consumer2;
        private readonly IEnumerableConsumer<TSource, TResult3> _consumer3;
        private readonly IEnumerableConsumer<TSource, TResult4> _consumer4;
        private readonly IEnumerableConsumer<TSource, TResult5> _consumer5;
        private readonly IEnumerableConsumer<TSource, TResult6> _consumer6;
        private readonly IEnumerableConsumer<TSource, TResult7> _consumer7;
        private readonly IEnumerableConsumer<TSource, TResult8> _consumer8;
        private readonly IEnumerableConsumer<TSource, TResult9> _consumer9;
        private readonly IEnumerableConsumer<TSource, TResult10> _consumer10;
        private readonly IEnumerableConsumer<TSource, TResult11> _consumer11;

        internal EnumerationRequests11(IEnumerable<TSource> enumerable, IEnumerableConsumer<TSource, TResult1> consumer1, IEnumerableConsumer<TSource, TResult2> consumer2, IEnumerableConsumer<TSource, TResult3> consumer3, IEnumerableConsumer<TSource, TResult4> consumer4, IEnumerableConsumer<TSource, TResult5> consumer5, IEnumerableConsumer<TSource, TResult6> consumer6, IEnumerableConsumer<TSource, TResult7> consumer7, IEnumerableConsumer<TSource, TResult8> consumer8, IEnumerableConsumer<TSource, TResult9> consumer9, IEnumerableConsumer<TSource, TResult10> consumer10, IEnumerableConsumer<TSource, TResult11> consumer11)
        {
            if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
            if (consumer1 is null) throw new ArgumentNullException(nameof(consumer1));
            if (consumer2 is null) throw new ArgumentNullException(nameof(consumer2));
            if (consumer3 is null) throw new ArgumentNullException(nameof(consumer3));
            if (consumer4 is null) throw new ArgumentNullException(nameof(consumer4));
            if (consumer5 is null) throw new ArgumentNullException(nameof(consumer5));
            if (consumer6 is null) throw new ArgumentNullException(nameof(consumer6));
            if (consumer7 is null) throw new ArgumentNullException(nameof(consumer7));
            if (consumer8 is null) throw new ArgumentNullException(nameof(consumer8));
            if (consumer9 is null) throw new ArgumentNullException(nameof(consumer9));
            if (consumer10 is null) throw new ArgumentNullException(nameof(consumer10));
            if (consumer11 is null) throw new ArgumentNullException(nameof(consumer11));

            _enumerable = enumerable;
            _consumer1 = consumer1;
            _consumer2 = consumer2;
            _consumer3 = consumer3;
            _consumer4 = consumer4;
            _consumer5 = consumer5;
            _consumer6 = consumer6;
            _consumer7 = consumer7;
            _consumer8 = consumer8;
            _consumer9 = consumer9;
            _consumer10 = consumer10;
            _consumer11 = consumer11;
        }

        internal EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult> Add<TResult>(IEnumerableConsumer<TSource, TResult> consumer)
        {
            return new EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult>(_enumerable, _consumer1, _consumer2, _consumer3, _consumer4, _consumer5, _consumer6, _consumer7, _consumer8, _consumer9, _consumer10, _consumer11, consumer);
        }

        /// <summary>
        ///     <para>
        ///         Evaluates the requests while enumerating the sequence once.<br/>
        ///         The requests results are returned as <see langword="out"/> arguments.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Each call to this method trigger a new evaluation of the requests and a new enumeration of the sequence.
        ///     </para>
        ///     <para>
        ///         This method is not intended to be directly called.
        ///         <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is the recommanded way to use this method.
        ///     </para>
        /// </remarks>
        /// <param name="result1">When this method returns, contains the result of the first request.</param>
        /// <param name="result2">When this method returns, contains the result of the second request.</param>
        /// <param name="result3">When this method returns, contains the result of the third request.</param>
        /// <param name="result4">When this method returns, contains the result of the fourth request.</param>
        /// <param name="result5">When this method returns, contains the result of the fifth request.</param>
        /// <param name="result6">When this method returns, contains the result of the sixth request.</param>
        /// <param name="result7">When this method returns, contains the result of the seventh request.</param>
        /// <param name="result8">When this method returns, contains the result of the eighth request.</param>
        /// <param name="result9">When this method returns, contains the result of the ninth request.</param>
        /// <param name="result10">When this method returns, contains the result of the tenth request.</param>
        /// <param name="result11">When this method returns, contains the result of the eleventh request.</param>
        public void Deconstruct(out TResult1 result1, out TResult2 result2, out TResult3 result3, out TResult4 result4, out TResult5 result5, out TResult6 result6, out TResult7 result7, out TResult8 result8, out TResult9 result9, out TResult10 result10, out TResult11 result11)
        {
            using var sink1 = _consumer1.GetSink();
            using var sink2 = _consumer2.GetSink();
            using var sink3 = _consumer3.GetSink();
            using var sink4 = _consumer4.GetSink();
            using var sink5 = _consumer5.GetSink();
            using var sink6 = _consumer6.GetSink();
            using var sink7 = _consumer7.GetSink();
            using var sink8 = _consumer8.GetSink();
            using var sink9 = _consumer9.GetSink();
            using var sink10 = _consumer10.GetSink();
            using var sink11 = _consumer11.GetSink();

            Enumerate(_enumerable, sink1, sink2, sink3, sink4, sink5, sink6, sink7, sink8, sink9, sink10, sink11);

            var i = 1;
            try
            {
                result1 = sink1.GetResult(); i++;
                result2 = sink2.GetResult(); i++;
                result3 = sink3.GetResult(); i++;
                result4 = sink4.GetResult(); i++;
                result5 = sink5.GetResult(); i++;
                result6 = sink6.GetResult(); i++;
                result7 = sink7.GetResult(); i++;
                result8 = sink8.GetResult(); i++;
                result9 = sink9.GetResult(); i++;
                result10 = sink10.GetResult(); i++;
                result11 = sink11.GetResult(); i++;
            }
            catch(Exception e)
            {
                throw new EnumerationException($"The evaluation of Item{i} failed", e);
            }
        }
    }

    /// <summary>
    ///     Stores enumeration requests on an unique sequence for deferred evaluation.
    /// </summary>
    /// <remarks>
    ///     <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is used to evaluate the requests.
    /// </remarks>
    /// <typeparam name="TSource">The type of the elements of the sequence to enumerate.</typeparam>
    /// <typeparam name="TResult1">The type of the result of the first request.</typeparam>
    /// <typeparam name="TResult2">The type of the result of the second request.</typeparam>
    /// <typeparam name="TResult3">The type of the result of the third request.</typeparam>
    /// <typeparam name="TResult4">The type of the result of the fourth request.</typeparam>
    /// <typeparam name="TResult5">The type of the result of the fifth request.</typeparam>
    /// <typeparam name="TResult6">The type of the result of the sixth request.</typeparam>
    /// <typeparam name="TResult7">The type of the result of the seventh request.</typeparam>
    /// <typeparam name="TResult8">The type of the result of the eighth request.</typeparam>
    /// <typeparam name="TResult9">The type of the result of the ninth request.</typeparam>
    /// <typeparam name="TResult10">The type of the result of the tenth request.</typeparam>
    /// <typeparam name="TResult11">The type of the result of the eleventh request.</typeparam>
    /// <typeparam name="TResult12">The type of the result of the twelfth request.</typeparam>
    public class EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12> : EnumerationRequestsBase
    {
        private readonly IEnumerable<TSource> _enumerable;
        private readonly IEnumerableConsumer<TSource, TResult1> _consumer1;
        private readonly IEnumerableConsumer<TSource, TResult2> _consumer2;
        private readonly IEnumerableConsumer<TSource, TResult3> _consumer3;
        private readonly IEnumerableConsumer<TSource, TResult4> _consumer4;
        private readonly IEnumerableConsumer<TSource, TResult5> _consumer5;
        private readonly IEnumerableConsumer<TSource, TResult6> _consumer6;
        private readonly IEnumerableConsumer<TSource, TResult7> _consumer7;
        private readonly IEnumerableConsumer<TSource, TResult8> _consumer8;
        private readonly IEnumerableConsumer<TSource, TResult9> _consumer9;
        private readonly IEnumerableConsumer<TSource, TResult10> _consumer10;
        private readonly IEnumerableConsumer<TSource, TResult11> _consumer11;
        private readonly IEnumerableConsumer<TSource, TResult12> _consumer12;

        internal EnumerationRequests12(IEnumerable<TSource> enumerable, IEnumerableConsumer<TSource, TResult1> consumer1, IEnumerableConsumer<TSource, TResult2> consumer2, IEnumerableConsumer<TSource, TResult3> consumer3, IEnumerableConsumer<TSource, TResult4> consumer4, IEnumerableConsumer<TSource, TResult5> consumer5, IEnumerableConsumer<TSource, TResult6> consumer6, IEnumerableConsumer<TSource, TResult7> consumer7, IEnumerableConsumer<TSource, TResult8> consumer8, IEnumerableConsumer<TSource, TResult9> consumer9, IEnumerableConsumer<TSource, TResult10> consumer10, IEnumerableConsumer<TSource, TResult11> consumer11, IEnumerableConsumer<TSource, TResult12> consumer12)
        {
            if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
            if (consumer1 is null) throw new ArgumentNullException(nameof(consumer1));
            if (consumer2 is null) throw new ArgumentNullException(nameof(consumer2));
            if (consumer3 is null) throw new ArgumentNullException(nameof(consumer3));
            if (consumer4 is null) throw new ArgumentNullException(nameof(consumer4));
            if (consumer5 is null) throw new ArgumentNullException(nameof(consumer5));
            if (consumer6 is null) throw new ArgumentNullException(nameof(consumer6));
            if (consumer7 is null) throw new ArgumentNullException(nameof(consumer7));
            if (consumer8 is null) throw new ArgumentNullException(nameof(consumer8));
            if (consumer9 is null) throw new ArgumentNullException(nameof(consumer9));
            if (consumer10 is null) throw new ArgumentNullException(nameof(consumer10));
            if (consumer11 is null) throw new ArgumentNullException(nameof(consumer11));
            if (consumer12 is null) throw new ArgumentNullException(nameof(consumer12));

            _enumerable = enumerable;
            _consumer1 = consumer1;
            _consumer2 = consumer2;
            _consumer3 = consumer3;
            _consumer4 = consumer4;
            _consumer5 = consumer5;
            _consumer6 = consumer6;
            _consumer7 = consumer7;
            _consumer8 = consumer8;
            _consumer9 = consumer9;
            _consumer10 = consumer10;
            _consumer11 = consumer11;
            _consumer12 = consumer12;
        }

        internal EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult> Add<TResult>(IEnumerableConsumer<TSource, TResult> consumer)
        {
            return new EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult>(_enumerable, _consumer1, _consumer2, _consumer3, _consumer4, _consumer5, _consumer6, _consumer7, _consumer8, _consumer9, _consumer10, _consumer11, _consumer12, consumer);
        }

        /// <summary>
        ///     <para>
        ///         Evaluates the requests while enumerating the sequence once.<br/>
        ///         The requests results are returned as <see langword="out"/> arguments.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Each call to this method trigger a new evaluation of the requests and a new enumeration of the sequence.
        ///     </para>
        ///     <para>
        ///         This method is not intended to be directly called.
        ///         <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is the recommanded way to use this method.
        ///     </para>
        /// </remarks>
        /// <param name="result1">When this method returns, contains the result of the first request.</param>
        /// <param name="result2">When this method returns, contains the result of the second request.</param>
        /// <param name="result3">When this method returns, contains the result of the third request.</param>
        /// <param name="result4">When this method returns, contains the result of the fourth request.</param>
        /// <param name="result5">When this method returns, contains the result of the fifth request.</param>
        /// <param name="result6">When this method returns, contains the result of the sixth request.</param>
        /// <param name="result7">When this method returns, contains the result of the seventh request.</param>
        /// <param name="result8">When this method returns, contains the result of the eighth request.</param>
        /// <param name="result9">When this method returns, contains the result of the ninth request.</param>
        /// <param name="result10">When this method returns, contains the result of the tenth request.</param>
        /// <param name="result11">When this method returns, contains the result of the eleventh request.</param>
        /// <param name="result12">When this method returns, contains the result of the twelfth request.</param>
        public void Deconstruct(out TResult1 result1, out TResult2 result2, out TResult3 result3, out TResult4 result4, out TResult5 result5, out TResult6 result6, out TResult7 result7, out TResult8 result8, out TResult9 result9, out TResult10 result10, out TResult11 result11, out TResult12 result12)
        {
            using var sink1 = _consumer1.GetSink();
            using var sink2 = _consumer2.GetSink();
            using var sink3 = _consumer3.GetSink();
            using var sink4 = _consumer4.GetSink();
            using var sink5 = _consumer5.GetSink();
            using var sink6 = _consumer6.GetSink();
            using var sink7 = _consumer7.GetSink();
            using var sink8 = _consumer8.GetSink();
            using var sink9 = _consumer9.GetSink();
            using var sink10 = _consumer10.GetSink();
            using var sink11 = _consumer11.GetSink();
            using var sink12 = _consumer12.GetSink();

            Enumerate(_enumerable, sink1, sink2, sink3, sink4, sink5, sink6, sink7, sink8, sink9, sink10, sink11, sink12);

            var i = 1;
            try
            {
                result1 = sink1.GetResult(); i++;
                result2 = sink2.GetResult(); i++;
                result3 = sink3.GetResult(); i++;
                result4 = sink4.GetResult(); i++;
                result5 = sink5.GetResult(); i++;
                result6 = sink6.GetResult(); i++;
                result7 = sink7.GetResult(); i++;
                result8 = sink8.GetResult(); i++;
                result9 = sink9.GetResult(); i++;
                result10 = sink10.GetResult(); i++;
                result11 = sink11.GetResult(); i++;
                result12 = sink12.GetResult(); i++;
            }
            catch(Exception e)
            {
                throw new EnumerationException($"The evaluation of Item{i} failed", e);
            }
        }
    }

    /// <summary>
    ///     Stores enumeration requests on an unique sequence for deferred evaluation.
    /// </summary>
    /// <remarks>
    ///     <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is used to evaluate the requests.
    /// </remarks>
    /// <typeparam name="TSource">The type of the elements of the sequence to enumerate.</typeparam>
    /// <typeparam name="TResult1">The type of the result of the first request.</typeparam>
    /// <typeparam name="TResult2">The type of the result of the second request.</typeparam>
    /// <typeparam name="TResult3">The type of the result of the third request.</typeparam>
    /// <typeparam name="TResult4">The type of the result of the fourth request.</typeparam>
    /// <typeparam name="TResult5">The type of the result of the fifth request.</typeparam>
    /// <typeparam name="TResult6">The type of the result of the sixth request.</typeparam>
    /// <typeparam name="TResult7">The type of the result of the seventh request.</typeparam>
    /// <typeparam name="TResult8">The type of the result of the eighth request.</typeparam>
    /// <typeparam name="TResult9">The type of the result of the ninth request.</typeparam>
    /// <typeparam name="TResult10">The type of the result of the tenth request.</typeparam>
    /// <typeparam name="TResult11">The type of the result of the eleventh request.</typeparam>
    /// <typeparam name="TResult12">The type of the result of the twelfth request.</typeparam>
    /// <typeparam name="TResult13">The type of the result of the thirteenth request.</typeparam>
    public class EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13> : EnumerationRequestsBase
    {
        private readonly IEnumerable<TSource> _enumerable;
        private readonly IEnumerableConsumer<TSource, TResult1> _consumer1;
        private readonly IEnumerableConsumer<TSource, TResult2> _consumer2;
        private readonly IEnumerableConsumer<TSource, TResult3> _consumer3;
        private readonly IEnumerableConsumer<TSource, TResult4> _consumer4;
        private readonly IEnumerableConsumer<TSource, TResult5> _consumer5;
        private readonly IEnumerableConsumer<TSource, TResult6> _consumer6;
        private readonly IEnumerableConsumer<TSource, TResult7> _consumer7;
        private readonly IEnumerableConsumer<TSource, TResult8> _consumer8;
        private readonly IEnumerableConsumer<TSource, TResult9> _consumer9;
        private readonly IEnumerableConsumer<TSource, TResult10> _consumer10;
        private readonly IEnumerableConsumer<TSource, TResult11> _consumer11;
        private readonly IEnumerableConsumer<TSource, TResult12> _consumer12;
        private readonly IEnumerableConsumer<TSource, TResult13> _consumer13;

        internal EnumerationRequests13(IEnumerable<TSource> enumerable, IEnumerableConsumer<TSource, TResult1> consumer1, IEnumerableConsumer<TSource, TResult2> consumer2, IEnumerableConsumer<TSource, TResult3> consumer3, IEnumerableConsumer<TSource, TResult4> consumer4, IEnumerableConsumer<TSource, TResult5> consumer5, IEnumerableConsumer<TSource, TResult6> consumer6, IEnumerableConsumer<TSource, TResult7> consumer7, IEnumerableConsumer<TSource, TResult8> consumer8, IEnumerableConsumer<TSource, TResult9> consumer9, IEnumerableConsumer<TSource, TResult10> consumer10, IEnumerableConsumer<TSource, TResult11> consumer11, IEnumerableConsumer<TSource, TResult12> consumer12, IEnumerableConsumer<TSource, TResult13> consumer13)
        {
            if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
            if (consumer1 is null) throw new ArgumentNullException(nameof(consumer1));
            if (consumer2 is null) throw new ArgumentNullException(nameof(consumer2));
            if (consumer3 is null) throw new ArgumentNullException(nameof(consumer3));
            if (consumer4 is null) throw new ArgumentNullException(nameof(consumer4));
            if (consumer5 is null) throw new ArgumentNullException(nameof(consumer5));
            if (consumer6 is null) throw new ArgumentNullException(nameof(consumer6));
            if (consumer7 is null) throw new ArgumentNullException(nameof(consumer7));
            if (consumer8 is null) throw new ArgumentNullException(nameof(consumer8));
            if (consumer9 is null) throw new ArgumentNullException(nameof(consumer9));
            if (consumer10 is null) throw new ArgumentNullException(nameof(consumer10));
            if (consumer11 is null) throw new ArgumentNullException(nameof(consumer11));
            if (consumer12 is null) throw new ArgumentNullException(nameof(consumer12));
            if (consumer13 is null) throw new ArgumentNullException(nameof(consumer13));

            _enumerable = enumerable;
            _consumer1 = consumer1;
            _consumer2 = consumer2;
            _consumer3 = consumer3;
            _consumer4 = consumer4;
            _consumer5 = consumer5;
            _consumer6 = consumer6;
            _consumer7 = consumer7;
            _consumer8 = consumer8;
            _consumer9 = consumer9;
            _consumer10 = consumer10;
            _consumer11 = consumer11;
            _consumer12 = consumer12;
            _consumer13 = consumer13;
        }

        internal EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult> Add<TResult>(IEnumerableConsumer<TSource, TResult> consumer)
        {
            return new EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult>(_enumerable, _consumer1, _consumer2, _consumer3, _consumer4, _consumer5, _consumer6, _consumer7, _consumer8, _consumer9, _consumer10, _consumer11, _consumer12, _consumer13, consumer);
        }

        /// <summary>
        ///     <para>
        ///         Evaluates the requests while enumerating the sequence once.<br/>
        ///         The requests results are returned as <see langword="out"/> arguments.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Each call to this method trigger a new evaluation of the requests and a new enumeration of the sequence.
        ///     </para>
        ///     <para>
        ///         This method is not intended to be directly called.
        ///         <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is the recommanded way to use this method.
        ///     </para>
        /// </remarks>
        /// <param name="result1">When this method returns, contains the result of the first request.</param>
        /// <param name="result2">When this method returns, contains the result of the second request.</param>
        /// <param name="result3">When this method returns, contains the result of the third request.</param>
        /// <param name="result4">When this method returns, contains the result of the fourth request.</param>
        /// <param name="result5">When this method returns, contains the result of the fifth request.</param>
        /// <param name="result6">When this method returns, contains the result of the sixth request.</param>
        /// <param name="result7">When this method returns, contains the result of the seventh request.</param>
        /// <param name="result8">When this method returns, contains the result of the eighth request.</param>
        /// <param name="result9">When this method returns, contains the result of the ninth request.</param>
        /// <param name="result10">When this method returns, contains the result of the tenth request.</param>
        /// <param name="result11">When this method returns, contains the result of the eleventh request.</param>
        /// <param name="result12">When this method returns, contains the result of the twelfth request.</param>
        /// <param name="result13">When this method returns, contains the result of the thirteenth request.</param>
        public void Deconstruct(out TResult1 result1, out TResult2 result2, out TResult3 result3, out TResult4 result4, out TResult5 result5, out TResult6 result6, out TResult7 result7, out TResult8 result8, out TResult9 result9, out TResult10 result10, out TResult11 result11, out TResult12 result12, out TResult13 result13)
        {
            using var sink1 = _consumer1.GetSink();
            using var sink2 = _consumer2.GetSink();
            using var sink3 = _consumer3.GetSink();
            using var sink4 = _consumer4.GetSink();
            using var sink5 = _consumer5.GetSink();
            using var sink6 = _consumer6.GetSink();
            using var sink7 = _consumer7.GetSink();
            using var sink8 = _consumer8.GetSink();
            using var sink9 = _consumer9.GetSink();
            using var sink10 = _consumer10.GetSink();
            using var sink11 = _consumer11.GetSink();
            using var sink12 = _consumer12.GetSink();
            using var sink13 = _consumer13.GetSink();

            Enumerate(_enumerable, sink1, sink2, sink3, sink4, sink5, sink6, sink7, sink8, sink9, sink10, sink11, sink12, sink13);

            var i = 1;
            try
            {
                result1 = sink1.GetResult(); i++;
                result2 = sink2.GetResult(); i++;
                result3 = sink3.GetResult(); i++;
                result4 = sink4.GetResult(); i++;
                result5 = sink5.GetResult(); i++;
                result6 = sink6.GetResult(); i++;
                result7 = sink7.GetResult(); i++;
                result8 = sink8.GetResult(); i++;
                result9 = sink9.GetResult(); i++;
                result10 = sink10.GetResult(); i++;
                result11 = sink11.GetResult(); i++;
                result12 = sink12.GetResult(); i++;
                result13 = sink13.GetResult(); i++;
            }
            catch(Exception e)
            {
                throw new EnumerationException($"The evaluation of Item{i} failed", e);
            }
        }
    }

    /// <summary>
    ///     Stores enumeration requests on an unique sequence for deferred evaluation.
    /// </summary>
    /// <remarks>
    ///     <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is used to evaluate the requests.
    /// </remarks>
    /// <typeparam name="TSource">The type of the elements of the sequence to enumerate.</typeparam>
    /// <typeparam name="TResult1">The type of the result of the first request.</typeparam>
    /// <typeparam name="TResult2">The type of the result of the second request.</typeparam>
    /// <typeparam name="TResult3">The type of the result of the third request.</typeparam>
    /// <typeparam name="TResult4">The type of the result of the fourth request.</typeparam>
    /// <typeparam name="TResult5">The type of the result of the fifth request.</typeparam>
    /// <typeparam name="TResult6">The type of the result of the sixth request.</typeparam>
    /// <typeparam name="TResult7">The type of the result of the seventh request.</typeparam>
    /// <typeparam name="TResult8">The type of the result of the eighth request.</typeparam>
    /// <typeparam name="TResult9">The type of the result of the ninth request.</typeparam>
    /// <typeparam name="TResult10">The type of the result of the tenth request.</typeparam>
    /// <typeparam name="TResult11">The type of the result of the eleventh request.</typeparam>
    /// <typeparam name="TResult12">The type of the result of the twelfth request.</typeparam>
    /// <typeparam name="TResult13">The type of the result of the thirteenth request.</typeparam>
    /// <typeparam name="TResult14">The type of the result of the fourteenth request.</typeparam>
    public class EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14> : EnumerationRequestsBase
    {
        private readonly IEnumerable<TSource> _enumerable;
        private readonly IEnumerableConsumer<TSource, TResult1> _consumer1;
        private readonly IEnumerableConsumer<TSource, TResult2> _consumer2;
        private readonly IEnumerableConsumer<TSource, TResult3> _consumer3;
        private readonly IEnumerableConsumer<TSource, TResult4> _consumer4;
        private readonly IEnumerableConsumer<TSource, TResult5> _consumer5;
        private readonly IEnumerableConsumer<TSource, TResult6> _consumer6;
        private readonly IEnumerableConsumer<TSource, TResult7> _consumer7;
        private readonly IEnumerableConsumer<TSource, TResult8> _consumer8;
        private readonly IEnumerableConsumer<TSource, TResult9> _consumer9;
        private readonly IEnumerableConsumer<TSource, TResult10> _consumer10;
        private readonly IEnumerableConsumer<TSource, TResult11> _consumer11;
        private readonly IEnumerableConsumer<TSource, TResult12> _consumer12;
        private readonly IEnumerableConsumer<TSource, TResult13> _consumer13;
        private readonly IEnumerableConsumer<TSource, TResult14> _consumer14;

        internal EnumerationRequests14(IEnumerable<TSource> enumerable, IEnumerableConsumer<TSource, TResult1> consumer1, IEnumerableConsumer<TSource, TResult2> consumer2, IEnumerableConsumer<TSource, TResult3> consumer3, IEnumerableConsumer<TSource, TResult4> consumer4, IEnumerableConsumer<TSource, TResult5> consumer5, IEnumerableConsumer<TSource, TResult6> consumer6, IEnumerableConsumer<TSource, TResult7> consumer7, IEnumerableConsumer<TSource, TResult8> consumer8, IEnumerableConsumer<TSource, TResult9> consumer9, IEnumerableConsumer<TSource, TResult10> consumer10, IEnumerableConsumer<TSource, TResult11> consumer11, IEnumerableConsumer<TSource, TResult12> consumer12, IEnumerableConsumer<TSource, TResult13> consumer13, IEnumerableConsumer<TSource, TResult14> consumer14)
        {
            if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
            if (consumer1 is null) throw new ArgumentNullException(nameof(consumer1));
            if (consumer2 is null) throw new ArgumentNullException(nameof(consumer2));
            if (consumer3 is null) throw new ArgumentNullException(nameof(consumer3));
            if (consumer4 is null) throw new ArgumentNullException(nameof(consumer4));
            if (consumer5 is null) throw new ArgumentNullException(nameof(consumer5));
            if (consumer6 is null) throw new ArgumentNullException(nameof(consumer6));
            if (consumer7 is null) throw new ArgumentNullException(nameof(consumer7));
            if (consumer8 is null) throw new ArgumentNullException(nameof(consumer8));
            if (consumer9 is null) throw new ArgumentNullException(nameof(consumer9));
            if (consumer10 is null) throw new ArgumentNullException(nameof(consumer10));
            if (consumer11 is null) throw new ArgumentNullException(nameof(consumer11));
            if (consumer12 is null) throw new ArgumentNullException(nameof(consumer12));
            if (consumer13 is null) throw new ArgumentNullException(nameof(consumer13));
            if (consumer14 is null) throw new ArgumentNullException(nameof(consumer14));

            _enumerable = enumerable;
            _consumer1 = consumer1;
            _consumer2 = consumer2;
            _consumer3 = consumer3;
            _consumer4 = consumer4;
            _consumer5 = consumer5;
            _consumer6 = consumer6;
            _consumer7 = consumer7;
            _consumer8 = consumer8;
            _consumer9 = consumer9;
            _consumer10 = consumer10;
            _consumer11 = consumer11;
            _consumer12 = consumer12;
            _consumer13 = consumer13;
            _consumer14 = consumer14;
        }

        internal EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult> Add<TResult>(IEnumerableConsumer<TSource, TResult> consumer)
        {
            return new EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult>(_enumerable, _consumer1, _consumer2, _consumer3, _consumer4, _consumer5, _consumer6, _consumer7, _consumer8, _consumer9, _consumer10, _consumer11, _consumer12, _consumer13, _consumer14, consumer);
        }

        /// <summary>
        ///     <para>
        ///         Evaluates the requests while enumerating the sequence once.<br/>
        ///         The requests results are returned as <see langword="out"/> arguments.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Each call to this method trigger a new evaluation of the requests and a new enumeration of the sequence.
        ///     </para>
        ///     <para>
        ///         This method is not intended to be directly called.
        ///         <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is the recommanded way to use this method.
        ///     </para>
        /// </remarks>
        /// <param name="result1">When this method returns, contains the result of the first request.</param>
        /// <param name="result2">When this method returns, contains the result of the second request.</param>
        /// <param name="result3">When this method returns, contains the result of the third request.</param>
        /// <param name="result4">When this method returns, contains the result of the fourth request.</param>
        /// <param name="result5">When this method returns, contains the result of the fifth request.</param>
        /// <param name="result6">When this method returns, contains the result of the sixth request.</param>
        /// <param name="result7">When this method returns, contains the result of the seventh request.</param>
        /// <param name="result8">When this method returns, contains the result of the eighth request.</param>
        /// <param name="result9">When this method returns, contains the result of the ninth request.</param>
        /// <param name="result10">When this method returns, contains the result of the tenth request.</param>
        /// <param name="result11">When this method returns, contains the result of the eleventh request.</param>
        /// <param name="result12">When this method returns, contains the result of the twelfth request.</param>
        /// <param name="result13">When this method returns, contains the result of the thirteenth request.</param>
        /// <param name="result14">When this method returns, contains the result of the fourteenth request.</param>
        public void Deconstruct(out TResult1 result1, out TResult2 result2, out TResult3 result3, out TResult4 result4, out TResult5 result5, out TResult6 result6, out TResult7 result7, out TResult8 result8, out TResult9 result9, out TResult10 result10, out TResult11 result11, out TResult12 result12, out TResult13 result13, out TResult14 result14)
        {
            using var sink1 = _consumer1.GetSink();
            using var sink2 = _consumer2.GetSink();
            using var sink3 = _consumer3.GetSink();
            using var sink4 = _consumer4.GetSink();
            using var sink5 = _consumer5.GetSink();
            using var sink6 = _consumer6.GetSink();
            using var sink7 = _consumer7.GetSink();
            using var sink8 = _consumer8.GetSink();
            using var sink9 = _consumer9.GetSink();
            using var sink10 = _consumer10.GetSink();
            using var sink11 = _consumer11.GetSink();
            using var sink12 = _consumer12.GetSink();
            using var sink13 = _consumer13.GetSink();
            using var sink14 = _consumer14.GetSink();

            Enumerate(_enumerable, sink1, sink2, sink3, sink4, sink5, sink6, sink7, sink8, sink9, sink10, sink11, sink12, sink13, sink14);

            var i = 1;
            try
            {
                result1 = sink1.GetResult(); i++;
                result2 = sink2.GetResult(); i++;
                result3 = sink3.GetResult(); i++;
                result4 = sink4.GetResult(); i++;
                result5 = sink5.GetResult(); i++;
                result6 = sink6.GetResult(); i++;
                result7 = sink7.GetResult(); i++;
                result8 = sink8.GetResult(); i++;
                result9 = sink9.GetResult(); i++;
                result10 = sink10.GetResult(); i++;
                result11 = sink11.GetResult(); i++;
                result12 = sink12.GetResult(); i++;
                result13 = sink13.GetResult(); i++;
                result14 = sink14.GetResult(); i++;
            }
            catch(Exception e)
            {
                throw new EnumerationException($"The evaluation of Item{i} failed", e);
            }
        }
    }

    /// <summary>
    ///     Stores enumeration requests on an unique sequence for deferred evaluation.
    /// </summary>
    /// <remarks>
    ///     <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is used to evaluate the requests.
    /// </remarks>
    /// <typeparam name="TSource">The type of the elements of the sequence to enumerate.</typeparam>
    /// <typeparam name="TResult1">The type of the result of the first request.</typeparam>
    /// <typeparam name="TResult2">The type of the result of the second request.</typeparam>
    /// <typeparam name="TResult3">The type of the result of the third request.</typeparam>
    /// <typeparam name="TResult4">The type of the result of the fourth request.</typeparam>
    /// <typeparam name="TResult5">The type of the result of the fifth request.</typeparam>
    /// <typeparam name="TResult6">The type of the result of the sixth request.</typeparam>
    /// <typeparam name="TResult7">The type of the result of the seventh request.</typeparam>
    /// <typeparam name="TResult8">The type of the result of the eighth request.</typeparam>
    /// <typeparam name="TResult9">The type of the result of the ninth request.</typeparam>
    /// <typeparam name="TResult10">The type of the result of the tenth request.</typeparam>
    /// <typeparam name="TResult11">The type of the result of the eleventh request.</typeparam>
    /// <typeparam name="TResult12">The type of the result of the twelfth request.</typeparam>
    /// <typeparam name="TResult13">The type of the result of the thirteenth request.</typeparam>
    /// <typeparam name="TResult14">The type of the result of the fourteenth request.</typeparam>
    /// <typeparam name="TResult15">The type of the result of the fifteenth request.</typeparam>
    public class EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15> : EnumerationRequestsBase
    {
        private readonly IEnumerable<TSource> _enumerable;
        private readonly IEnumerableConsumer<TSource, TResult1> _consumer1;
        private readonly IEnumerableConsumer<TSource, TResult2> _consumer2;
        private readonly IEnumerableConsumer<TSource, TResult3> _consumer3;
        private readonly IEnumerableConsumer<TSource, TResult4> _consumer4;
        private readonly IEnumerableConsumer<TSource, TResult5> _consumer5;
        private readonly IEnumerableConsumer<TSource, TResult6> _consumer6;
        private readonly IEnumerableConsumer<TSource, TResult7> _consumer7;
        private readonly IEnumerableConsumer<TSource, TResult8> _consumer8;
        private readonly IEnumerableConsumer<TSource, TResult9> _consumer9;
        private readonly IEnumerableConsumer<TSource, TResult10> _consumer10;
        private readonly IEnumerableConsumer<TSource, TResult11> _consumer11;
        private readonly IEnumerableConsumer<TSource, TResult12> _consumer12;
        private readonly IEnumerableConsumer<TSource, TResult13> _consumer13;
        private readonly IEnumerableConsumer<TSource, TResult14> _consumer14;
        private readonly IEnumerableConsumer<TSource, TResult15> _consumer15;

        internal EnumerationRequests15(IEnumerable<TSource> enumerable, IEnumerableConsumer<TSource, TResult1> consumer1, IEnumerableConsumer<TSource, TResult2> consumer2, IEnumerableConsumer<TSource, TResult3> consumer3, IEnumerableConsumer<TSource, TResult4> consumer4, IEnumerableConsumer<TSource, TResult5> consumer5, IEnumerableConsumer<TSource, TResult6> consumer6, IEnumerableConsumer<TSource, TResult7> consumer7, IEnumerableConsumer<TSource, TResult8> consumer8, IEnumerableConsumer<TSource, TResult9> consumer9, IEnumerableConsumer<TSource, TResult10> consumer10, IEnumerableConsumer<TSource, TResult11> consumer11, IEnumerableConsumer<TSource, TResult12> consumer12, IEnumerableConsumer<TSource, TResult13> consumer13, IEnumerableConsumer<TSource, TResult14> consumer14, IEnumerableConsumer<TSource, TResult15> consumer15)
        {
            if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
            if (consumer1 is null) throw new ArgumentNullException(nameof(consumer1));
            if (consumer2 is null) throw new ArgumentNullException(nameof(consumer2));
            if (consumer3 is null) throw new ArgumentNullException(nameof(consumer3));
            if (consumer4 is null) throw new ArgumentNullException(nameof(consumer4));
            if (consumer5 is null) throw new ArgumentNullException(nameof(consumer5));
            if (consumer6 is null) throw new ArgumentNullException(nameof(consumer6));
            if (consumer7 is null) throw new ArgumentNullException(nameof(consumer7));
            if (consumer8 is null) throw new ArgumentNullException(nameof(consumer8));
            if (consumer9 is null) throw new ArgumentNullException(nameof(consumer9));
            if (consumer10 is null) throw new ArgumentNullException(nameof(consumer10));
            if (consumer11 is null) throw new ArgumentNullException(nameof(consumer11));
            if (consumer12 is null) throw new ArgumentNullException(nameof(consumer12));
            if (consumer13 is null) throw new ArgumentNullException(nameof(consumer13));
            if (consumer14 is null) throw new ArgumentNullException(nameof(consumer14));
            if (consumer15 is null) throw new ArgumentNullException(nameof(consumer15));

            _enumerable = enumerable;
            _consumer1 = consumer1;
            _consumer2 = consumer2;
            _consumer3 = consumer3;
            _consumer4 = consumer4;
            _consumer5 = consumer5;
            _consumer6 = consumer6;
            _consumer7 = consumer7;
            _consumer8 = consumer8;
            _consumer9 = consumer9;
            _consumer10 = consumer10;
            _consumer11 = consumer11;
            _consumer12 = consumer12;
            _consumer13 = consumer13;
            _consumer14 = consumer14;
            _consumer15 = consumer15;
        }

        internal EnumerationRequests16<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TResult> Add<TResult>(IEnumerableConsumer<TSource, TResult> consumer)
        {
            return new EnumerationRequests16<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TResult>(_enumerable, _consumer1, _consumer2, _consumer3, _consumer4, _consumer5, _consumer6, _consumer7, _consumer8, _consumer9, _consumer10, _consumer11, _consumer12, _consumer13, _consumer14, _consumer15, consumer);
        }

        /// <summary>
        ///     <para>
        ///         Evaluates the requests while enumerating the sequence once.<br/>
        ///         The requests results are returned as <see langword="out"/> arguments.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Each call to this method trigger a new evaluation of the requests and a new enumeration of the sequence.
        ///     </para>
        ///     <para>
        ///         This method is not intended to be directly called.
        ///         <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is the recommanded way to use this method.
        ///     </para>
        /// </remarks>
        /// <param name="result1">When this method returns, contains the result of the first request.</param>
        /// <param name="result2">When this method returns, contains the result of the second request.</param>
        /// <param name="result3">When this method returns, contains the result of the third request.</param>
        /// <param name="result4">When this method returns, contains the result of the fourth request.</param>
        /// <param name="result5">When this method returns, contains the result of the fifth request.</param>
        /// <param name="result6">When this method returns, contains the result of the sixth request.</param>
        /// <param name="result7">When this method returns, contains the result of the seventh request.</param>
        /// <param name="result8">When this method returns, contains the result of the eighth request.</param>
        /// <param name="result9">When this method returns, contains the result of the ninth request.</param>
        /// <param name="result10">When this method returns, contains the result of the tenth request.</param>
        /// <param name="result11">When this method returns, contains the result of the eleventh request.</param>
        /// <param name="result12">When this method returns, contains the result of the twelfth request.</param>
        /// <param name="result13">When this method returns, contains the result of the thirteenth request.</param>
        /// <param name="result14">When this method returns, contains the result of the fourteenth request.</param>
        /// <param name="result15">When this method returns, contains the result of the fifteenth request.</param>
        public void Deconstruct(out TResult1 result1, out TResult2 result2, out TResult3 result3, out TResult4 result4, out TResult5 result5, out TResult6 result6, out TResult7 result7, out TResult8 result8, out TResult9 result9, out TResult10 result10, out TResult11 result11, out TResult12 result12, out TResult13 result13, out TResult14 result14, out TResult15 result15)
        {
            using var sink1 = _consumer1.GetSink();
            using var sink2 = _consumer2.GetSink();
            using var sink3 = _consumer3.GetSink();
            using var sink4 = _consumer4.GetSink();
            using var sink5 = _consumer5.GetSink();
            using var sink6 = _consumer6.GetSink();
            using var sink7 = _consumer7.GetSink();
            using var sink8 = _consumer8.GetSink();
            using var sink9 = _consumer9.GetSink();
            using var sink10 = _consumer10.GetSink();
            using var sink11 = _consumer11.GetSink();
            using var sink12 = _consumer12.GetSink();
            using var sink13 = _consumer13.GetSink();
            using var sink14 = _consumer14.GetSink();
            using var sink15 = _consumer15.GetSink();

            Enumerate(_enumerable, sink1, sink2, sink3, sink4, sink5, sink6, sink7, sink8, sink9, sink10, sink11, sink12, sink13, sink14, sink15);

            var i = 1;
            try
            {
                result1 = sink1.GetResult(); i++;
                result2 = sink2.GetResult(); i++;
                result3 = sink3.GetResult(); i++;
                result4 = sink4.GetResult(); i++;
                result5 = sink5.GetResult(); i++;
                result6 = sink6.GetResult(); i++;
                result7 = sink7.GetResult(); i++;
                result8 = sink8.GetResult(); i++;
                result9 = sink9.GetResult(); i++;
                result10 = sink10.GetResult(); i++;
                result11 = sink11.GetResult(); i++;
                result12 = sink12.GetResult(); i++;
                result13 = sink13.GetResult(); i++;
                result14 = sink14.GetResult(); i++;
                result15 = sink15.GetResult(); i++;
            }
            catch(Exception e)
            {
                throw new EnumerationException($"The evaluation of Item{i} failed", e);
            }
        }
    }

    /// <summary>
    ///     Stores enumeration requests on an unique sequence for deferred evaluation.
    /// </summary>
    /// <remarks>
    ///     <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is used to evaluate the requests.
    /// </remarks>
    /// <typeparam name="TSource">The type of the elements of the sequence to enumerate.</typeparam>
    /// <typeparam name="TResult1">The type of the result of the first request.</typeparam>
    /// <typeparam name="TResult2">The type of the result of the second request.</typeparam>
    /// <typeparam name="TResult3">The type of the result of the third request.</typeparam>
    /// <typeparam name="TResult4">The type of the result of the fourth request.</typeparam>
    /// <typeparam name="TResult5">The type of the result of the fifth request.</typeparam>
    /// <typeparam name="TResult6">The type of the result of the sixth request.</typeparam>
    /// <typeparam name="TResult7">The type of the result of the seventh request.</typeparam>
    /// <typeparam name="TResult8">The type of the result of the eighth request.</typeparam>
    /// <typeparam name="TResult9">The type of the result of the ninth request.</typeparam>
    /// <typeparam name="TResult10">The type of the result of the tenth request.</typeparam>
    /// <typeparam name="TResult11">The type of the result of the eleventh request.</typeparam>
    /// <typeparam name="TResult12">The type of the result of the twelfth request.</typeparam>
    /// <typeparam name="TResult13">The type of the result of the thirteenth request.</typeparam>
    /// <typeparam name="TResult14">The type of the result of the fourteenth request.</typeparam>
    /// <typeparam name="TResult15">The type of the result of the fifteenth request.</typeparam>
    /// <typeparam name="TResult16">The type of the result of the sixteenth request.</typeparam>
    public class EnumerationRequests16<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TResult16> : EnumerationRequestsBase
    {
        private readonly IEnumerable<TSource> _enumerable;
        private readonly IEnumerableConsumer<TSource, TResult1> _consumer1;
        private readonly IEnumerableConsumer<TSource, TResult2> _consumer2;
        private readonly IEnumerableConsumer<TSource, TResult3> _consumer3;
        private readonly IEnumerableConsumer<TSource, TResult4> _consumer4;
        private readonly IEnumerableConsumer<TSource, TResult5> _consumer5;
        private readonly IEnumerableConsumer<TSource, TResult6> _consumer6;
        private readonly IEnumerableConsumer<TSource, TResult7> _consumer7;
        private readonly IEnumerableConsumer<TSource, TResult8> _consumer8;
        private readonly IEnumerableConsumer<TSource, TResult9> _consumer9;
        private readonly IEnumerableConsumer<TSource, TResult10> _consumer10;
        private readonly IEnumerableConsumer<TSource, TResult11> _consumer11;
        private readonly IEnumerableConsumer<TSource, TResult12> _consumer12;
        private readonly IEnumerableConsumer<TSource, TResult13> _consumer13;
        private readonly IEnumerableConsumer<TSource, TResult14> _consumer14;
        private readonly IEnumerableConsumer<TSource, TResult15> _consumer15;
        private readonly IEnumerableConsumer<TSource, TResult16> _consumer16;

        internal EnumerationRequests16(IEnumerable<TSource> enumerable, IEnumerableConsumer<TSource, TResult1> consumer1, IEnumerableConsumer<TSource, TResult2> consumer2, IEnumerableConsumer<TSource, TResult3> consumer3, IEnumerableConsumer<TSource, TResult4> consumer4, IEnumerableConsumer<TSource, TResult5> consumer5, IEnumerableConsumer<TSource, TResult6> consumer6, IEnumerableConsumer<TSource, TResult7> consumer7, IEnumerableConsumer<TSource, TResult8> consumer8, IEnumerableConsumer<TSource, TResult9> consumer9, IEnumerableConsumer<TSource, TResult10> consumer10, IEnumerableConsumer<TSource, TResult11> consumer11, IEnumerableConsumer<TSource, TResult12> consumer12, IEnumerableConsumer<TSource, TResult13> consumer13, IEnumerableConsumer<TSource, TResult14> consumer14, IEnumerableConsumer<TSource, TResult15> consumer15, IEnumerableConsumer<TSource, TResult16> consumer16)
        {
            if (enumerable is null) throw new ArgumentNullException(nameof(enumerable));
            if (consumer1 is null) throw new ArgumentNullException(nameof(consumer1));
            if (consumer2 is null) throw new ArgumentNullException(nameof(consumer2));
            if (consumer3 is null) throw new ArgumentNullException(nameof(consumer3));
            if (consumer4 is null) throw new ArgumentNullException(nameof(consumer4));
            if (consumer5 is null) throw new ArgumentNullException(nameof(consumer5));
            if (consumer6 is null) throw new ArgumentNullException(nameof(consumer6));
            if (consumer7 is null) throw new ArgumentNullException(nameof(consumer7));
            if (consumer8 is null) throw new ArgumentNullException(nameof(consumer8));
            if (consumer9 is null) throw new ArgumentNullException(nameof(consumer9));
            if (consumer10 is null) throw new ArgumentNullException(nameof(consumer10));
            if (consumer11 is null) throw new ArgumentNullException(nameof(consumer11));
            if (consumer12 is null) throw new ArgumentNullException(nameof(consumer12));
            if (consumer13 is null) throw new ArgumentNullException(nameof(consumer13));
            if (consumer14 is null) throw new ArgumentNullException(nameof(consumer14));
            if (consumer15 is null) throw new ArgumentNullException(nameof(consumer15));
            if (consumer16 is null) throw new ArgumentNullException(nameof(consumer16));

            _enumerable = enumerable;
            _consumer1 = consumer1;
            _consumer2 = consumer2;
            _consumer3 = consumer3;
            _consumer4 = consumer4;
            _consumer5 = consumer5;
            _consumer6 = consumer6;
            _consumer7 = consumer7;
            _consumer8 = consumer8;
            _consumer9 = consumer9;
            _consumer10 = consumer10;
            _consumer11 = consumer11;
            _consumer12 = consumer12;
            _consumer13 = consumer13;
            _consumer14 = consumer14;
            _consumer15 = consumer15;
            _consumer16 = consumer16;
        }

        /// <summary>
        ///     <para>
        ///         Evaluates the requests while enumerating the sequence once.<br/>
        ///         The requests results are returned as <see langword="out"/> arguments.
        ///     </para>
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Each call to this method trigger a new evaluation of the requests and a new enumeration of the sequence.
        ///     </para>
        ///     <para>
        ///         This method is not intended to be directly called.
        ///         <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">Deconstruction</see> is the recommanded way to use this method.
        ///     </para>
        /// </remarks>
        /// <param name="result1">When this method returns, contains the result of the first request.</param>
        /// <param name="result2">When this method returns, contains the result of the second request.</param>
        /// <param name="result3">When this method returns, contains the result of the third request.</param>
        /// <param name="result4">When this method returns, contains the result of the fourth request.</param>
        /// <param name="result5">When this method returns, contains the result of the fifth request.</param>
        /// <param name="result6">When this method returns, contains the result of the sixth request.</param>
        /// <param name="result7">When this method returns, contains the result of the seventh request.</param>
        /// <param name="result8">When this method returns, contains the result of the eighth request.</param>
        /// <param name="result9">When this method returns, contains the result of the ninth request.</param>
        /// <param name="result10">When this method returns, contains the result of the tenth request.</param>
        /// <param name="result11">When this method returns, contains the result of the eleventh request.</param>
        /// <param name="result12">When this method returns, contains the result of the twelfth request.</param>
        /// <param name="result13">When this method returns, contains the result of the thirteenth request.</param>
        /// <param name="result14">When this method returns, contains the result of the fourteenth request.</param>
        /// <param name="result15">When this method returns, contains the result of the fifteenth request.</param>
        /// <param name="result16">When this method returns, contains the result of the sixteenth request.</param>
        public void Deconstruct(out TResult1 result1, out TResult2 result2, out TResult3 result3, out TResult4 result4, out TResult5 result5, out TResult6 result6, out TResult7 result7, out TResult8 result8, out TResult9 result9, out TResult10 result10, out TResult11 result11, out TResult12 result12, out TResult13 result13, out TResult14 result14, out TResult15 result15, out TResult16 result16)
        {
            using var sink1 = _consumer1.GetSink();
            using var sink2 = _consumer2.GetSink();
            using var sink3 = _consumer3.GetSink();
            using var sink4 = _consumer4.GetSink();
            using var sink5 = _consumer5.GetSink();
            using var sink6 = _consumer6.GetSink();
            using var sink7 = _consumer7.GetSink();
            using var sink8 = _consumer8.GetSink();
            using var sink9 = _consumer9.GetSink();
            using var sink10 = _consumer10.GetSink();
            using var sink11 = _consumer11.GetSink();
            using var sink12 = _consumer12.GetSink();
            using var sink13 = _consumer13.GetSink();
            using var sink14 = _consumer14.GetSink();
            using var sink15 = _consumer15.GetSink();
            using var sink16 = _consumer16.GetSink();

            Enumerate(_enumerable, sink1, sink2, sink3, sink4, sink5, sink6, sink7, sink8, sink9, sink10, sink11, sink12, sink13, sink14, sink15, sink16);

            var i = 1;
            try
            {
                result1 = sink1.GetResult(); i++;
                result2 = sink2.GetResult(); i++;
                result3 = sink3.GetResult(); i++;
                result4 = sink4.GetResult(); i++;
                result5 = sink5.GetResult(); i++;
                result6 = sink6.GetResult(); i++;
                result7 = sink7.GetResult(); i++;
                result8 = sink8.GetResult(); i++;
                result9 = sink9.GetResult(); i++;
                result10 = sink10.GetResult(); i++;
                result11 = sink11.GetResult(); i++;
                result12 = sink12.GetResult(); i++;
                result13 = sink13.GetResult(); i++;
                result14 = sink14.GetResult(); i++;
                result15 = sink15.GetResult(); i++;
                result16 = sink16.GetResult(); i++;
            }
            catch(Exception e)
            {
                throw new EnumerationException($"The evaluation of Item{i} failed", e);
            }
        }
    }

}