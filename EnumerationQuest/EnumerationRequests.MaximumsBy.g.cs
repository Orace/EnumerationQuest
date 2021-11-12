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
using System.Linq;
using EnumerationQuest.Consumers;

#nullable enable

namespace EnumerationQuest
{
    public static partial class EnumerationRequests
    {
        #region MaximumsBy with keySelector

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<see cref="Comparer{TKey}.Default"/> is used to compare keys.
        /// 	</para>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="ArgumentException"/>
        /// 		if no key extracted from the sequence implements the <see cref="IComparable"/> or <see cref="IComparable{TResult}"/> interface.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The sequence for which the result is evaluated.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests1{TSource, TResult1}"/> whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see> evaluate this request.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the first position.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests1<TSource, List<TSource>> GetMaximumsBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) 
        {
            return new EnumerationRequests1<TSource, List<TSource>>(source, ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<see cref="Comparer{TKey}.Default"/> is used to compare keys.
        /// 	</para>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="ArgumentException"/>
        /// 		if no key extracted from the sequence implements the <see cref="IComparable"/> or <see cref="IComparable{TResult}"/> interface.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests2{TSource, TResult1, TResult2}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the second position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests2<TSource, TResult1, List<TSource>> AndMaximumsBy<TResult1, TSource, TKey>(this EnumerationRequests1<TSource, TResult1> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<see cref="Comparer{TKey}.Default"/> is used to compare keys.
        /// 	</para>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="ArgumentException"/>
        /// 		if no key extracted from the sequence implements the <see cref="IComparable"/> or <see cref="IComparable{TResult}"/> interface.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests3{TSource, TResult1, TResult2, TResult3}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the third position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests3<TSource, TResult1, TResult2, List<TSource>> AndMaximumsBy<TResult1, TResult2, TSource, TKey>(this EnumerationRequests2<TSource, TResult1, TResult2> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<see cref="Comparer{TKey}.Default"/> is used to compare keys.
        /// 	</para>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="ArgumentException"/>
        /// 		if no key extracted from the sequence implements the <see cref="IComparable"/> or <see cref="IComparable{TResult}"/> interface.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests4{TSource, TResult1, TResult2, TResult3, TResult4}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the fourth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests4<TSource, TResult1, TResult2, TResult3, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TSource, TKey>(this EnumerationRequests3<TSource, TResult1, TResult2, TResult3> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<see cref="Comparer{TKey}.Default"/> is used to compare keys.
        /// 	</para>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="ArgumentException"/>
        /// 		if no key extracted from the sequence implements the <see cref="IComparable"/> or <see cref="IComparable{TResult}"/> interface.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests5{TSource, TResult1, TResult2, TResult3, TResult4, TResult5}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the fifth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TSource, TKey>(this EnumerationRequests4<TSource, TResult1, TResult2, TResult3, TResult4> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<see cref="Comparer{TKey}.Default"/> is used to compare keys.
        /// 	</para>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="ArgumentException"/>
        /// 		if no key extracted from the sequence implements the <see cref="IComparable"/> or <see cref="IComparable{TResult}"/> interface.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests6{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the sixth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TSource, TKey>(this EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, TResult5> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<see cref="Comparer{TKey}.Default"/> is used to compare keys.
        /// 	</para>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="ArgumentException"/>
        /// 		if no key extracted from the sequence implements the <see cref="IComparable"/> or <see cref="IComparable{TResult}"/> interface.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests7{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the seventh position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TSource, TKey>(this EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<see cref="Comparer{TKey}.Default"/> is used to compare keys.
        /// 	</para>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="ArgumentException"/>
        /// 		if no key extracted from the sequence implements the <see cref="IComparable"/> or <see cref="IComparable{TResult}"/> interface.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests8{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the eighth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TSource, TKey>(this EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<see cref="Comparer{TKey}.Default"/> is used to compare keys.
        /// 	</para>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="ArgumentException"/>
        /// 		if no key extracted from the sequence implements the <see cref="IComparable"/> or <see cref="IComparable{TResult}"/> interface.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult8">The result type of the eighth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests9{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the ninth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TSource, TKey>(this EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<see cref="Comparer{TKey}.Default"/> is used to compare keys.
        /// 	</para>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="ArgumentException"/>
        /// 		if no key extracted from the sequence implements the <see cref="IComparable"/> or <see cref="IComparable{TResult}"/> interface.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult8">The result type of the eighth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult9">The result type of the ninth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests10{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the tenth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TSource, TKey>(this EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<see cref="Comparer{TKey}.Default"/> is used to compare keys.
        /// 	</para>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="ArgumentException"/>
        /// 		if no key extracted from the sequence implements the <see cref="IComparable"/> or <see cref="IComparable{TResult}"/> interface.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult8">The result type of the eighth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult9">The result type of the ninth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult10">The result type of the tenth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests11{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the eleventh position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TSource, TKey>(this EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<see cref="Comparer{TKey}.Default"/> is used to compare keys.
        /// 	</para>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="ArgumentException"/>
        /// 		if no key extracted from the sequence implements the <see cref="IComparable"/> or <see cref="IComparable{TResult}"/> interface.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult8">The result type of the eighth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult9">The result type of the ninth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult10">The result type of the tenth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult11">The result type of the eleventh request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests12{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the twelfth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TSource, TKey>(this EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<see cref="Comparer{TKey}.Default"/> is used to compare keys.
        /// 	</para>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="ArgumentException"/>
        /// 		if no key extracted from the sequence implements the <see cref="IComparable"/> or <see cref="IComparable{TResult}"/> interface.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult8">The result type of the eighth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult9">The result type of the ninth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult10">The result type of the tenth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult11">The result type of the eleventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult12">The result type of the twelfth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests13{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the thirteenth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TSource, TKey>(this EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<see cref="Comparer{TKey}.Default"/> is used to compare keys.
        /// 	</para>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="ArgumentException"/>
        /// 		if no key extracted from the sequence implements the <see cref="IComparable"/> or <see cref="IComparable{TResult}"/> interface.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult8">The result type of the eighth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult9">The result type of the ninth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult10">The result type of the tenth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult11">The result type of the eleventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult12">The result type of the twelfth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult13">The result type of the thirteenth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests14{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the fourteenth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TSource, TKey>(this EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<see cref="Comparer{TKey}.Default"/> is used to compare keys.
        /// 	</para>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="ArgumentException"/>
        /// 		if no key extracted from the sequence implements the <see cref="IComparable"/> or <see cref="IComparable{TResult}"/> interface.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult8">The result type of the eighth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult9">The result type of the ninth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult10">The result type of the tenth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult11">The result type of the eleventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult12">The result type of the twelfth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult13">The result type of the thirteenth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult14">The result type of the fourteenth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests15{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the fifteenth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TSource, TKey>(this EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		<see cref="Comparer{TKey}.Default"/> is used to compare keys.
        /// 	</para>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="ArgumentException"/>
        /// 		if no key extracted from the sequence implements the <see cref="IComparable"/> or <see cref="IComparable{TResult}"/> interface.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult8">The result type of the eighth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult9">The result type of the ninth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult10">The result type of the tenth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult11">The result type of the eleventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult12">The result type of the twelfth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult13">The result type of the thirteenth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult14">The result type of the fourteenth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult15">The result type of the fifteenth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests16{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TResult16}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the sixteenth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests16<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TSource, TKey>(this EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector));
        }

        #endregion

        #region MaximumsBy with keySelector, comparer

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function and key comparer.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="comparer">A comparer to compare keys.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey}, IComparer{TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The sequence for which the result is evaluated.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests1{TSource, TResult1}"/> whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see> evaluate this request.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the first position.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests1<TSource, List<TSource>> GetMaximumsBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) 
        {
            return new EnumerationRequests1<TSource, List<TSource>>(source, ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector, comparer));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function and key comparer.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="comparer">A comparer to compare keys.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey}, IComparer{TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests2{TSource, TResult1, TResult2}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the second position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests2<TSource, TResult1, List<TSource>> AndMaximumsBy<TResult1, TSource, TKey>(this EnumerationRequests1<TSource, TResult1> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector, comparer));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function and key comparer.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="comparer">A comparer to compare keys.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey}, IComparer{TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests3{TSource, TResult1, TResult2, TResult3}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the third position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests3<TSource, TResult1, TResult2, List<TSource>> AndMaximumsBy<TResult1, TResult2, TSource, TKey>(this EnumerationRequests2<TSource, TResult1, TResult2> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector, comparer));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function and key comparer.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="comparer">A comparer to compare keys.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey}, IComparer{TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests4{TSource, TResult1, TResult2, TResult3, TResult4}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the fourth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests4<TSource, TResult1, TResult2, TResult3, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TSource, TKey>(this EnumerationRequests3<TSource, TResult1, TResult2, TResult3> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector, comparer));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function and key comparer.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="comparer">A comparer to compare keys.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey}, IComparer{TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests5{TSource, TResult1, TResult2, TResult3, TResult4, TResult5}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the fifth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TSource, TKey>(this EnumerationRequests4<TSource, TResult1, TResult2, TResult3, TResult4> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector, comparer));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function and key comparer.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="comparer">A comparer to compare keys.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey}, IComparer{TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests6{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the sixth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TSource, TKey>(this EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, TResult5> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector, comparer));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function and key comparer.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="comparer">A comparer to compare keys.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey}, IComparer{TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests7{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the seventh position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TSource, TKey>(this EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector, comparer));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function and key comparer.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="comparer">A comparer to compare keys.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey}, IComparer{TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests8{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the eighth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TSource, TKey>(this EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector, comparer));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function and key comparer.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="comparer">A comparer to compare keys.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey}, IComparer{TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult8">The result type of the eighth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests9{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the ninth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TSource, TKey>(this EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector, comparer));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function and key comparer.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="comparer">A comparer to compare keys.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey}, IComparer{TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult8">The result type of the eighth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult9">The result type of the ninth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests10{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the tenth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TSource, TKey>(this EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector, comparer));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function and key comparer.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="comparer">A comparer to compare keys.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey}, IComparer{TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult8">The result type of the eighth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult9">The result type of the ninth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult10">The result type of the tenth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests11{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the eleventh position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TSource, TKey>(this EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector, comparer));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function and key comparer.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="comparer">A comparer to compare keys.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey}, IComparer{TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult8">The result type of the eighth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult9">The result type of the ninth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult10">The result type of the tenth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult11">The result type of the eleventh request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests12{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the twelfth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TSource, TKey>(this EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector, comparer));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function and key comparer.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="comparer">A comparer to compare keys.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey}, IComparer{TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult8">The result type of the eighth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult9">The result type of the ninth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult10">The result type of the tenth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult11">The result type of the eleventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult12">The result type of the twelfth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests13{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the thirteenth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TSource, TKey>(this EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector, comparer));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function and key comparer.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="comparer">A comparer to compare keys.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey}, IComparer{TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult8">The result type of the eighth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult9">The result type of the ninth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult10">The result type of the tenth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult11">The result type of the eleventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult12">The result type of the twelfth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult13">The result type of the thirteenth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests14{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the fourteenth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TSource, TKey>(this EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector, comparer));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function and key comparer.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="comparer">A comparer to compare keys.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey}, IComparer{TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult8">The result type of the eighth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult9">The result type of the ninth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult10">The result type of the tenth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult11">The result type of the eleventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult12">The result type of the twelfth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult13">The result type of the thirteenth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult14">The result type of the fourteenth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests15{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the fifteenth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TSource, TKey>(this EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector, comparer));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the values with the maximum key in a sequence; according to a specified key selector function and key comparer.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is a <see cref="List{TSource}"/> containing the values with the maximum key in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the source sequence is empty, the result of this request is an empty <see cref="List{TSource}"/>.
        /// 	</para>
        /// </remarks>
        /// <typeparam name="TKey">The type of key to compare elements by.</typeparam>
        /// <param name="comparer">A comparer to compare keys.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <seealso cref="Enumerable.MaxBy{TSource,TKey}(IEnumerable{TSource}, Func{TSource,TKey}, IComparer{TKey})"/>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
        /// <typeparam name="TSource">The type of the elements of the sequence for which the results are evaluated.</typeparam>
        /// <typeparam name="TResult1">The result type of the first request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult2">The result type of the second request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult3">The result type of the third request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult4">The result type of the fourth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult5">The result type of the fifth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult6">The result type of the sixth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult7">The result type of the seventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult8">The result type of the eighth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult9">The result type of the ninth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult10">The result type of the tenth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult11">The result type of the eleventh request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult12">The result type of the twelfth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult13">The result type of the thirteenth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult14">The result type of the fourteenth request stored in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult15">The result type of the fifteenth request stored in <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests16{TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TResult16}"/>
        ///         whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see>
        ///         evaluate this request and the requests stored in <paramref name="source"/>.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the sixteenth position;
        ///         and the results of the requests stored in <paramref name="source"/> are at their respective positions.
        ///     </para>
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static EnumerationRequests16<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, List<TSource>> AndMaximumsBy<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TSource, TKey>(this EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.MaximumsBy<TSource, TKey>(keySelector, comparer));
        }

        #endregion

    }
}