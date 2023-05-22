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
        #region HasDuplicates 

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TSource}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests1<TSource, bool> GetHasDuplicates<TSource>(this IEnumerable<TSource> source) 
        {
            return new EnumerationRequests1<TSource, bool>(source, ConsumerFactory.HasDuplicates<TSource>());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TSource}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests2<TSource, TResult1, bool> AndHasDuplicates<TResult1, TSource>(this EnumerationRequests1<TSource, TResult1> source) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TSource}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests3<TSource, TResult1, TResult2, bool> AndHasDuplicates<TResult1, TResult2, TSource>(this EnumerationRequests2<TSource, TResult1, TResult2> source) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TSource}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests4<TSource, TResult1, TResult2, TResult3, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TSource>(this EnumerationRequests3<TSource, TResult1, TResult2, TResult3> source) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TSource}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TSource>(this EnumerationRequests4<TSource, TResult1, TResult2, TResult3, TResult4> source) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TSource}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TSource>(this EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, TResult5> source) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TSource}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TSource>(this EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> source) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TSource}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TSource>(this EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7> source) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TSource}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TSource>(this EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8> source) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TSource}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TSource>(this EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9> source) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TSource}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TSource>(this EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10> source) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TSource}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TSource>(this EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11> source) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TSource}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TSource>(this EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12> source) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TSource}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TSource>(this EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13> source) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TSource}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TSource>(this EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14> source) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TSource}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests16<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TSource>(this EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15> source) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>());
        }

        #endregion

        #region HasDuplicates with comparer

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests1<TSource, bool> GetHasDuplicates<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer) 
        {
            return new EnumerationRequests1<TSource, bool>(source, ConsumerFactory.HasDuplicates<TSource>(comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests2<TSource, TResult1, bool> AndHasDuplicates<TResult1, TSource>(this EnumerationRequests1<TSource, TResult1> source, IEqualityComparer<TSource> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>(comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests3<TSource, TResult1, TResult2, bool> AndHasDuplicates<TResult1, TResult2, TSource>(this EnumerationRequests2<TSource, TResult1, TResult2> source, IEqualityComparer<TSource> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>(comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests4<TSource, TResult1, TResult2, TResult3, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TSource>(this EnumerationRequests3<TSource, TResult1, TResult2, TResult3> source, IEqualityComparer<TSource> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>(comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TSource>(this EnumerationRequests4<TSource, TResult1, TResult2, TResult3, TResult4> source, IEqualityComparer<TSource> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>(comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TSource>(this EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, TResult5> source, IEqualityComparer<TSource> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>(comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TSource>(this EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> source, IEqualityComparer<TSource> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>(comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TSource>(this EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7> source, IEqualityComparer<TSource> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>(comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TSource>(this EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8> source, IEqualityComparer<TSource> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>(comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TSource>(this EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9> source, IEqualityComparer<TSource> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>(comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TSource>(this EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10> source, IEqualityComparer<TSource> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>(comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TSource>(this EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11> source, IEqualityComparer<TSource> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>(comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TSource>(this EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12> source, IEqualityComparer<TSource> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>(comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TSource>(this EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13> source, IEqualityComparer<TSource> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>(comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TSource>(this EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14> source, IEqualityComparer<TSource> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>(comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicate element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests16<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TSource>(this EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15> source, IEqualityComparer<TSource> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource>(comparer));
        }

        #endregion

        #region HasDuplicates with keySelector

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TKey}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests1<TSource, bool> GetHasDuplicates<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) 
        {
            return new EnumerationRequests1<TSource, bool>(source, ConsumerFactory.HasDuplicates<TSource, TKey>(keySelector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TKey}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests2<TSource, TResult1, bool> AndHasDuplicates<TResult1, TSource, TKey>(this EnumerationRequests1<TSource, TResult1> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource, TKey>(keySelector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TKey}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests3<TSource, TResult1, TResult2, bool> AndHasDuplicates<TResult1, TResult2, TSource, TKey>(this EnumerationRequests2<TSource, TResult1, TResult2> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource, TKey>(keySelector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TKey}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests4<TSource, TResult1, TResult2, TResult3, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TSource, TKey>(this EnumerationRequests3<TSource, TResult1, TResult2, TResult3> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource, TKey>(keySelector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TKey}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TSource, TKey>(this EnumerationRequests4<TSource, TResult1, TResult2, TResult3, TResult4> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource, TKey>(keySelector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TKey}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TSource, TKey>(this EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, TResult5> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource, TKey>(keySelector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TKey}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TSource, TKey>(this EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource, TKey>(keySelector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TKey}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TSource, TKey>(this EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource, TKey>(keySelector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TKey}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TSource, TKey>(this EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource, TKey>(keySelector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TKey}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TSource, TKey>(this EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource, TKey>(keySelector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TKey}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TSource, TKey>(this EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource, TKey>(keySelector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TKey}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TSource, TKey>(this EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource, TKey>(keySelector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TKey}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TSource, TKey>(this EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource, TKey>(keySelector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TKey}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TSource, TKey>(this EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource, TKey>(keySelector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TKey}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TSource, TKey>(this EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource, TKey>(keySelector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <remarks>
        ///   <para>
        ///     <see cref="EqualityComparer{TKey}.Default"/> is used to test elements equality.
        ///   </para>
        /// </remarks>
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
        public static EnumerationRequests16<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TSource, TKey>(this EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15> source, Func<TSource, TKey> keySelector) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource, TKey>(keySelector));
        }

        #endregion

        #region HasDuplicates with keySelector, comparer

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests1<TSource, bool> GetHasDuplicates<TSource ,TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
        {
            return new EnumerationRequests1<TSource, bool>(source, ConsumerFactory.HasDuplicates<TSource ,TKey>(keySelector, comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests2<TSource, TResult1, bool> AndHasDuplicates<TResult1, TSource ,TKey>(this EnumerationRequests1<TSource, TResult1> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource ,TKey>(keySelector, comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests3<TSource, TResult1, TResult2, bool> AndHasDuplicates<TResult1, TResult2, TSource ,TKey>(this EnumerationRequests2<TSource, TResult1, TResult2> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource ,TKey>(keySelector, comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests4<TSource, TResult1, TResult2, TResult3, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TSource ,TKey>(this EnumerationRequests3<TSource, TResult1, TResult2, TResult3> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource ,TKey>(keySelector, comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TSource ,TKey>(this EnumerationRequests4<TSource, TResult1, TResult2, TResult3, TResult4> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource ,TKey>(keySelector, comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TSource ,TKey>(this EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, TResult5> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource ,TKey>(keySelector, comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TSource ,TKey>(this EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource ,TKey>(keySelector, comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TSource ,TKey>(this EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource ,TKey>(keySelector, comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TSource ,TKey>(this EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource ,TKey>(keySelector, comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TSource ,TKey>(this EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource ,TKey>(keySelector, comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TSource ,TKey>(this EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource ,TKey>(keySelector, comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TSource ,TKey>(this EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource ,TKey>(keySelector, comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TSource ,TKey>(this EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource ,TKey>(keySelector, comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TSource ,TKey>(this EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource ,TKey>(keySelector, comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TSource ,TKey>(this EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource ,TKey>(keySelector, comparer));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a <see cref="Boolean"/> that represent whether a sequence contains a duplicate key from it's element by using a specified <see cref="IEqualityComparer{TSource}"/>.
        ///   </para>
        ///   <para>
        ///     The result of this request is <see langword="true"/> if the sequence contains a duplicates element; <see langword="false"/> otherwise.
        ///   </para>
        /// </summary>
        /// <param name="keySelector">A function to extract the keys from the elements.</param>
        /// <param name="comparer">An equality comparer to compare keys.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is <see langword="null"/>.</exception>
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
        public static EnumerationRequests16<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, bool> AndHasDuplicates<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TSource ,TKey>(this EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.HasDuplicates<TSource ,TKey>(keySelector, comparer));
        }

        #endregion

    }
}