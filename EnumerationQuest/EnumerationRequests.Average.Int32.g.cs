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
        #region Average of int

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/>
        /// 		if the source sequence is empty.
        /// 	</para>
        /// </remarks>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests1{TSource, double}"/> whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see> evaluate this request.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the first position.
        ///     </para>
        /// </returns>
        /// <param name="source">The sequence for which the average is requested.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests1<int, double> GetAverage(this IEnumerable<int> source)
        {
            return new EnumerationRequests1<int, double>(source, ConsumerFactory.AverageOfInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests2<int, TResult1, double> AndAverage<TResult1>(this EnumerationRequests1<int, TResult1> source)
        {
            return source.Add(ConsumerFactory.AverageOfInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests3<int, TResult1, TResult2, double> AndAverage<TResult1, TResult2>(this EnumerationRequests2<int, TResult1, TResult2> source)
        {
            return source.Add(ConsumerFactory.AverageOfInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests4<int, TResult1, TResult2, TResult3, double> AndAverage<TResult1, TResult2, TResult3>(this EnumerationRequests3<int, TResult1, TResult2, TResult3> source)
        {
            return source.Add(ConsumerFactory.AverageOfInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests5<int, TResult1, TResult2, TResult3, TResult4, double> AndAverage<TResult1, TResult2, TResult3, TResult4>(this EnumerationRequests4<int, TResult1, TResult2, TResult3, TResult4> source)
        {
            return source.Add(ConsumerFactory.AverageOfInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests6<int, TResult1, TResult2, TResult3, TResult4, TResult5, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5>(this EnumerationRequests5<int, TResult1, TResult2, TResult3, TResult4, TResult5> source)
        {
            return source.Add(ConsumerFactory.AverageOfInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests7<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(this EnumerationRequests6<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> source)
        {
            return source.Add(ConsumerFactory.AverageOfInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests8<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(this EnumerationRequests7<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7> source)
        {
            return source.Add(ConsumerFactory.AverageOfInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests9<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>(this EnumerationRequests8<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8> source)
        {
            return source.Add(ConsumerFactory.AverageOfInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests10<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9>(this EnumerationRequests9<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9> source)
        {
            return source.Add(ConsumerFactory.AverageOfInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests11<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10>(this EnumerationRequests10<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10> source)
        {
            return source.Add(ConsumerFactory.AverageOfInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests12<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11>(this EnumerationRequests11<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11> source)
        {
            return source.Add(ConsumerFactory.AverageOfInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests13<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12>(this EnumerationRequests12<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12> source)
        {
            return source.Add(ConsumerFactory.AverageOfInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests14<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13>(this EnumerationRequests13<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13> source)
        {
            return source.Add(ConsumerFactory.AverageOfInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests15<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14>(this EnumerationRequests14<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14> source)
        {
            return source.Add(ConsumerFactory.AverageOfInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests16<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15>(this EnumerationRequests15<int, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15> source)
        {
            return source.Add(ConsumerFactory.AverageOfInt32());
        }

        #endregion

        #region Average of int?

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests1{TSource, double?}"/> whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see> evaluate this request.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the first position.
        ///     </para>
        /// </returns>
        /// <param name="source">The sequence for which the average is requested.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests1<int?, double?> GetAverage(this IEnumerable<int?> source)
        {
            return new EnumerationRequests1<int?, double?>(source, ConsumerFactory.AverageOfNullableInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests2<int?, TResult1, double?> AndAverage<TResult1>(this EnumerationRequests1<int?, TResult1> source)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests3<int?, TResult1, TResult2, double?> AndAverage<TResult1, TResult2>(this EnumerationRequests2<int?, TResult1, TResult2> source)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests4<int?, TResult1, TResult2, TResult3, double?> AndAverage<TResult1, TResult2, TResult3>(this EnumerationRequests3<int?, TResult1, TResult2, TResult3> source)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests5<int?, TResult1, TResult2, TResult3, TResult4, double?> AndAverage<TResult1, TResult2, TResult3, TResult4>(this EnumerationRequests4<int?, TResult1, TResult2, TResult3, TResult4> source)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests6<int?, TResult1, TResult2, TResult3, TResult4, TResult5, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5>(this EnumerationRequests5<int?, TResult1, TResult2, TResult3, TResult4, TResult5> source)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests7<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(this EnumerationRequests6<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> source)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests8<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(this EnumerationRequests7<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7> source)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests9<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>(this EnumerationRequests8<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8> source)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests10<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9>(this EnumerationRequests9<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9> source)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests11<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10>(this EnumerationRequests10<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10> source)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests12<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11>(this EnumerationRequests11<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11> source)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests13<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12>(this EnumerationRequests12<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12> source)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests14<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13>(this EnumerationRequests13<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13> source)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests15<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14>(this EnumerationRequests14<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14> source)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32());
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of the values in a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of the values in the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <param name="source">The request holder to which this request is added.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests16<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15>(this EnumerationRequests15<int?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15> source)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32());
        }

        #endregion

        #region Average of int with selector

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/>
        /// 		if the source sequence is empty.
        /// 	</para>
        /// </remarks>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests1{TSource, double}"/> whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see> evaluate this request.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the first position.
        ///     </para>
        /// </returns>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The sequence for which the average is requested.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests1<TSource, double> GetAverage<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            return new EnumerationRequests1<TSource, double>(source, ConsumerFactory.AverageOfInt32(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests2<TSource, TResult1, double> AndAverage<TResult1, TSource>(this EnumerationRequests1<TSource, TResult1> source, Func<TSource, int> selector)
        {
            return source.Add(ConsumerFactory.AverageOfInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests3<TSource, TResult1, TResult2, double> AndAverage<TResult1, TResult2, TSource>(this EnumerationRequests2<TSource, TResult1, TResult2> source, Func<TSource, int> selector)
        {
            return source.Add(ConsumerFactory.AverageOfInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests4<TSource, TResult1, TResult2, TResult3, double> AndAverage<TResult1, TResult2, TResult3, TSource>(this EnumerationRequests3<TSource, TResult1, TResult2, TResult3> source, Func<TSource, int> selector)
        {
            return source.Add(ConsumerFactory.AverageOfInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TSource>(this EnumerationRequests4<TSource, TResult1, TResult2, TResult3, TResult4> source, Func<TSource, int> selector)
        {
            return source.Add(ConsumerFactory.AverageOfInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TSource>(this EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, TResult5> source, Func<TSource, int> selector)
        {
            return source.Add(ConsumerFactory.AverageOfInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TSource>(this EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> source, Func<TSource, int> selector)
        {
            return source.Add(ConsumerFactory.AverageOfInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TSource>(this EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7> source, Func<TSource, int> selector)
        {
            return source.Add(ConsumerFactory.AverageOfInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TSource>(this EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8> source, Func<TSource, int> selector)
        {
            return source.Add(ConsumerFactory.AverageOfInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TSource>(this EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9> source, Func<TSource, int> selector)
        {
            return source.Add(ConsumerFactory.AverageOfInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TSource>(this EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10> source, Func<TSource, int> selector)
        {
            return source.Add(ConsumerFactory.AverageOfInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TSource>(this EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11> source, Func<TSource, int> selector)
        {
            return source.Add(ConsumerFactory.AverageOfInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TSource>(this EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12> source, Func<TSource, int> selector)
        {
            return source.Add(ConsumerFactory.AverageOfInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TSource>(this EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13> source, Func<TSource, int> selector)
        {
            return source.Add(ConsumerFactory.AverageOfInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TSource>(this EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14> source, Func<TSource, int> selector)
        {
            return source.Add(ConsumerFactory.AverageOfInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		The returned object deconstruction throw <see cref="InvalidOperationException"/> if the source sequence is empty.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int})"/>
        public static EnumerationRequests16<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, double> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TSource>(this EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15> source, Func<TSource, int> selector)
        {
            return source.Add(ConsumerFactory.AverageOfInt32<TSource>(selector));
        }

        #endregion

        #region Average of int? with selector

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests1{TSource, double?}"/> whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see> evaluate this request.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the first position.
        ///     </para>
        /// </returns>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The sequence for which the average is requested.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests1<TSource, double?> GetAverage<TSource>(this IEnumerable<TSource> source, Func<TSource, int?> selector)
        {
            return new EnumerationRequests1<TSource, double?>(source, ConsumerFactory.AverageOfNullableInt32(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests2<TSource, TResult1, double?> AndAverage<TResult1, TSource>(this EnumerationRequests1<TSource, TResult1> source, Func<TSource, int?> selector)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests3<TSource, TResult1, TResult2, double?> AndAverage<TResult1, TResult2, TSource>(this EnumerationRequests2<TSource, TResult1, TResult2> source, Func<TSource, int?> selector)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests4<TSource, TResult1, TResult2, TResult3, double?> AndAverage<TResult1, TResult2, TResult3, TSource>(this EnumerationRequests3<TSource, TResult1, TResult2, TResult3> source, Func<TSource, int?> selector)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TSource>(this EnumerationRequests4<TSource, TResult1, TResult2, TResult3, TResult4> source, Func<TSource, int?> selector)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TSource>(this EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, TResult5> source, Func<TSource, int?> selector)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TSource>(this EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> source, Func<TSource, int?> selector)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TSource>(this EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7> source, Func<TSource, int?> selector)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TSource>(this EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8> source, Func<TSource, int?> selector)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TSource>(this EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9> source, Func<TSource, int?> selector)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TSource>(this EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10> source, Func<TSource, int?> selector)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TSource>(this EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11> source, Func<TSource, int?> selector)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TSource>(this EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12> source, Func<TSource, int?> selector)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TSource>(this EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13> source, Func<TSource, int?> selector)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TSource>(this EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14> source, Func<TSource, int?> selector)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32<TSource>(selector));
        }

        /// <summary>
        /// 	<para>
        /// 		Requests the evaluation of the average of tranformed objects from a sequence.
        /// 	</para>
        /// 	<para>
        /// 		The result of this request is the average of transformed objects from the sequence.
        /// 	</para>
        /// </summary>
        /// <remarks>
        /// 	<para>
        /// 		If the sequence is empty or contains only object that are transformed to <see langword="null"/>, the result of this request is <see langword="null"/>.
        /// 	</para>
        /// </remarks>
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
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The request holder to which this request is added.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Average(IEnumerable{int?})"/>
        public static EnumerationRequests16<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, double?> AndAverage<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TSource>(this EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15> source, Func<TSource, int?> selector)
        {
            return source.Add(ConsumerFactory.AverageOfNullableInt32<TSource>(selector));
        }

        #endregion

    }
}