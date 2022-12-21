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
        #region  with func

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a IObservable that emit the original sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the last element emited by the IObservable.
        ///   </para>
        /// </summary>
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
        public static EnumerationRequests1<TSource, TResult> Get<TSource, TResult>(this IEnumerable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> func) 
        {
            return new EnumerationRequests1<TSource, TResult>(source, ConsumerFactory.Get<TSource, TResult>(func));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a IObservable that emit the original sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the last element emited by the IObservable.
        ///   </para>
        /// </summary>
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
        public static EnumerationRequests2<TSource, TResult1, TResult> And<TResult1, TSource, TResult>(this EnumerationRequests1<TSource, TResult1> source, Func<IObservable<TSource>, IObservable<TResult>> func) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.Get<TSource, TResult>(func));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a IObservable that emit the original sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the last element emited by the IObservable.
        ///   </para>
        /// </summary>
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
        public static EnumerationRequests3<TSource, TResult1, TResult2, TResult> And<TResult1, TResult2, TSource, TResult>(this EnumerationRequests2<TSource, TResult1, TResult2> source, Func<IObservable<TSource>, IObservable<TResult>> func) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.Get<TSource, TResult>(func));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a IObservable that emit the original sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the last element emited by the IObservable.
        ///   </para>
        /// </summary>
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
        public static EnumerationRequests4<TSource, TResult1, TResult2, TResult3, TResult> And<TResult1, TResult2, TResult3, TSource, TResult>(this EnumerationRequests3<TSource, TResult1, TResult2, TResult3> source, Func<IObservable<TSource>, IObservable<TResult>> func) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.Get<TSource, TResult>(func));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a IObservable that emit the original sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the last element emited by the IObservable.
        ///   </para>
        /// </summary>
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
        public static EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, TResult> And<TResult1, TResult2, TResult3, TResult4, TSource, TResult>(this EnumerationRequests4<TSource, TResult1, TResult2, TResult3, TResult4> source, Func<IObservable<TSource>, IObservable<TResult>> func) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.Get<TSource, TResult>(func));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a IObservable that emit the original sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the last element emited by the IObservable.
        ///   </para>
        /// </summary>
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
        public static EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult> And<TResult1, TResult2, TResult3, TResult4, TResult5, TSource, TResult>(this EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, TResult5> source, Func<IObservable<TSource>, IObservable<TResult>> func) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.Get<TSource, TResult>(func));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a IObservable that emit the original sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the last element emited by the IObservable.
        ///   </para>
        /// </summary>
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
        public static EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult> And<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TSource, TResult>(this EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> source, Func<IObservable<TSource>, IObservable<TResult>> func) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.Get<TSource, TResult>(func));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a IObservable that emit the original sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the last element emited by the IObservable.
        ///   </para>
        /// </summary>
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
        public static EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult> And<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TSource, TResult>(this EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7> source, Func<IObservable<TSource>, IObservable<TResult>> func) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.Get<TSource, TResult>(func));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a IObservable that emit the original sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the last element emited by the IObservable.
        ///   </para>
        /// </summary>
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
        public static EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult> And<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TSource, TResult>(this EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8> source, Func<IObservable<TSource>, IObservable<TResult>> func) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.Get<TSource, TResult>(func));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a IObservable that emit the original sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the last element emited by the IObservable.
        ///   </para>
        /// </summary>
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
        public static EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult> And<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TSource, TResult>(this EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9> source, Func<IObservable<TSource>, IObservable<TResult>> func) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.Get<TSource, TResult>(func));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a IObservable that emit the original sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the last element emited by the IObservable.
        ///   </para>
        /// </summary>
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
        public static EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult> And<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TSource, TResult>(this EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10> source, Func<IObservable<TSource>, IObservable<TResult>> func) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.Get<TSource, TResult>(func));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a IObservable that emit the original sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the last element emited by the IObservable.
        ///   </para>
        /// </summary>
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
        public static EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult> And<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TSource, TResult>(this EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11> source, Func<IObservable<TSource>, IObservable<TResult>> func) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.Get<TSource, TResult>(func));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a IObservable that emit the original sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the last element emited by the IObservable.
        ///   </para>
        /// </summary>
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
        public static EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult> And<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TSource, TResult>(this EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12> source, Func<IObservable<TSource>, IObservable<TResult>> func) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.Get<TSource, TResult>(func));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a IObservable that emit the original sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the last element emited by the IObservable.
        ///   </para>
        /// </summary>
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
        public static EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult> And<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TSource, TResult>(this EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13> source, Func<IObservable<TSource>, IObservable<TResult>> func) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.Get<TSource, TResult>(func));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a IObservable that emit the original sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the last element emited by the IObservable.
        ///   </para>
        /// </summary>
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
        public static EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult> And<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TSource, TResult>(this EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14> source, Func<IObservable<TSource>, IObservable<TResult>> func) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.Get<TSource, TResult>(func));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of a IObservable that emit the original sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the last element emited by the IObservable.
        ///   </para>
        /// </summary>
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
        public static EnumerationRequests16<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TResult> And<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TSource, TResult>(this EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15> source, Func<IObservable<TSource>, IObservable<TResult>> func) 
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            return source.Add(ConsumerFactory.Get<TSource, TResult>(func));
        }

        #endregion

    }
}