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
using EnumerationQuest.Consumers;

#nullable enable

namespace EnumerationQuest
{
    public static partial class EnumerationRequests
    {
        #region Sum of float

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        /// </remarks>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests1{TSource, float}"/> whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see> evaluate this request.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the first position.
        ///     </para>
        /// </returns>
        /// <param name="source">The sequence for which the sum is requested.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests1<float, float> GetSum(this IEnumerable<float> source)
        {
            return new EnumerationRequests1<float, float>(source, ConsumerFactory.SumOfSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests2<float, TResult1, float> AndSum<TResult1>(this EnumerationRequests1<float, TResult1> source)
        {
            return source.Add(ConsumerFactory.SumOfSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests3<float, TResult1, TResult2, float> AndSum<TResult1, TResult2>(this EnumerationRequests2<float, TResult1, TResult2> source)
        {
            return source.Add(ConsumerFactory.SumOfSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests4<float, TResult1, TResult2, TResult3, float> AndSum<TResult1, TResult2, TResult3>(this EnumerationRequests3<float, TResult1, TResult2, TResult3> source)
        {
            return source.Add(ConsumerFactory.SumOfSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests5<float, TResult1, TResult2, TResult3, TResult4, float> AndSum<TResult1, TResult2, TResult3, TResult4>(this EnumerationRequests4<float, TResult1, TResult2, TResult3, TResult4> source)
        {
            return source.Add(ConsumerFactory.SumOfSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests6<float, TResult1, TResult2, TResult3, TResult4, TResult5, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5>(this EnumerationRequests5<float, TResult1, TResult2, TResult3, TResult4, TResult5> source)
        {
            return source.Add(ConsumerFactory.SumOfSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests7<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(this EnumerationRequests6<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> source)
        {
            return source.Add(ConsumerFactory.SumOfSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests8<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(this EnumerationRequests7<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7> source)
        {
            return source.Add(ConsumerFactory.SumOfSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests9<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>(this EnumerationRequests8<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8> source)
        {
            return source.Add(ConsumerFactory.SumOfSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests10<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9>(this EnumerationRequests9<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9> source)
        {
            return source.Add(ConsumerFactory.SumOfSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests11<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10>(this EnumerationRequests10<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10> source)
        {
            return source.Add(ConsumerFactory.SumOfSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests12<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11>(this EnumerationRequests11<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11> source)
        {
            return source.Add(ConsumerFactory.SumOfSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests13<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12>(this EnumerationRequests12<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12> source)
        {
            return source.Add(ConsumerFactory.SumOfSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests14<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13>(this EnumerationRequests13<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13> source)
        {
            return source.Add(ConsumerFactory.SumOfSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests15<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14>(this EnumerationRequests14<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14> source)
        {
            return source.Add(ConsumerFactory.SumOfSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests16<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15>(this EnumerationRequests15<float, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15> source)
        {
            return source.Add(ConsumerFactory.SumOfSingle());
        }

        #endregion

        #region Sum of float?

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are <see langword="null"/> are ignored, hence if the sequence contains only
        ///         <see langword="null"/> values, the result of this request is <c>0</c>.
        ///   </para>
        /// </remarks>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests1{TSource, float?}"/> whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see> evaluate this request.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the first position.
        ///     </para>
        /// </returns>
        /// <param name="source">The sequence for which the sum is requested.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests1<float?, float?> GetSum(this IEnumerable<float?> source)
        {
            return new EnumerationRequests1<float?, float?>(source, ConsumerFactory.SumOfNullableSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are <see langword="null"/> are ignored, hence if the sequence contains only
        ///         <see langword="null"/> values, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests2<float?, TResult1, float?> AndSum<TResult1>(this EnumerationRequests1<float?, TResult1> source)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are <see langword="null"/> are ignored, hence if the sequence contains only
        ///         <see langword="null"/> values, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests3<float?, TResult1, TResult2, float?> AndSum<TResult1, TResult2>(this EnumerationRequests2<float?, TResult1, TResult2> source)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are <see langword="null"/> are ignored, hence if the sequence contains only
        ///         <see langword="null"/> values, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests4<float?, TResult1, TResult2, TResult3, float?> AndSum<TResult1, TResult2, TResult3>(this EnumerationRequests3<float?, TResult1, TResult2, TResult3> source)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are <see langword="null"/> are ignored, hence if the sequence contains only
        ///         <see langword="null"/> values, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests5<float?, TResult1, TResult2, TResult3, TResult4, float?> AndSum<TResult1, TResult2, TResult3, TResult4>(this EnumerationRequests4<float?, TResult1, TResult2, TResult3, TResult4> source)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are <see langword="null"/> are ignored, hence if the sequence contains only
        ///         <see langword="null"/> values, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests6<float?, TResult1, TResult2, TResult3, TResult4, TResult5, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5>(this EnumerationRequests5<float?, TResult1, TResult2, TResult3, TResult4, TResult5> source)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are <see langword="null"/> are ignored, hence if the sequence contains only
        ///         <see langword="null"/> values, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests7<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6>(this EnumerationRequests6<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> source)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are <see langword="null"/> are ignored, hence if the sequence contains only
        ///         <see langword="null"/> values, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests8<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7>(this EnumerationRequests7<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7> source)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are <see langword="null"/> are ignored, hence if the sequence contains only
        ///         <see langword="null"/> values, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests9<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8>(this EnumerationRequests8<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8> source)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are <see langword="null"/> are ignored, hence if the sequence contains only
        ///         <see langword="null"/> values, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests10<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9>(this EnumerationRequests9<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9> source)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are <see langword="null"/> are ignored, hence if the sequence contains only
        ///         <see langword="null"/> values, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests11<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10>(this EnumerationRequests10<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10> source)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are <see langword="null"/> are ignored, hence if the sequence contains only
        ///         <see langword="null"/> values, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests12<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11>(this EnumerationRequests11<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11> source)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are <see langword="null"/> are ignored, hence if the sequence contains only
        ///         <see langword="null"/> values, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests13<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12>(this EnumerationRequests12<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12> source)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are <see langword="null"/> are ignored, hence if the sequence contains only
        ///         <see langword="null"/> values, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests14<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13>(this EnumerationRequests13<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13> source)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are <see langword="null"/> are ignored, hence if the sequence contains only
        ///         <see langword="null"/> values, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests15<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14>(this EnumerationRequests14<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14> source)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle());
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of the values in a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of the values in the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are <see langword="null"/> are ignored, hence if the sequence contains only
        ///         <see langword="null"/> values, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests16<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15>(this EnumerationRequests15<float?, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15> source)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle());
        }

        #endregion

        #region Sum of float with selector

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        /// </remarks>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests1{TSource, float}"/> whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see> evaluate this request.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the first position.
        ///     </para>
        /// </returns>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The sequence for which the sum is requested.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests1<TSource, float> GetSum<TSource>(this IEnumerable<TSource> source, Func<TSource, float> selector)
        {
            return new EnumerationRequests1<TSource, float>(source, ConsumerFactory.SumOfSingle(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests2<TSource, TResult1, float> AndSum<TResult1, TSource>(this EnumerationRequests1<TSource, TResult1> source, Func<TSource, float> selector)
        {
            return source.Add(ConsumerFactory.SumOfSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests3<TSource, TResult1, TResult2, float> AndSum<TResult1, TResult2, TSource>(this EnumerationRequests2<TSource, TResult1, TResult2> source, Func<TSource, float> selector)
        {
            return source.Add(ConsumerFactory.SumOfSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests4<TSource, TResult1, TResult2, TResult3, float> AndSum<TResult1, TResult2, TResult3, TSource>(this EnumerationRequests3<TSource, TResult1, TResult2, TResult3> source, Func<TSource, float> selector)
        {
            return source.Add(ConsumerFactory.SumOfSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, float> AndSum<TResult1, TResult2, TResult3, TResult4, TSource>(this EnumerationRequests4<TSource, TResult1, TResult2, TResult3, TResult4> source, Func<TSource, float> selector)
        {
            return source.Add(ConsumerFactory.SumOfSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TSource>(this EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, TResult5> source, Func<TSource, float> selector)
        {
            return source.Add(ConsumerFactory.SumOfSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TSource>(this EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> source, Func<TSource, float> selector)
        {
            return source.Add(ConsumerFactory.SumOfSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TSource>(this EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7> source, Func<TSource, float> selector)
        {
            return source.Add(ConsumerFactory.SumOfSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TSource>(this EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8> source, Func<TSource, float> selector)
        {
            return source.Add(ConsumerFactory.SumOfSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TSource>(this EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9> source, Func<TSource, float> selector)
        {
            return source.Add(ConsumerFactory.SumOfSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TSource>(this EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10> source, Func<TSource, float> selector)
        {
            return source.Add(ConsumerFactory.SumOfSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TSource>(this EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11> source, Func<TSource, float> selector)
        {
            return source.Add(ConsumerFactory.SumOfSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TSource>(this EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12> source, Func<TSource, float> selector)
        {
            return source.Add(ConsumerFactory.SumOfSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TSource>(this EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13> source, Func<TSource, float> selector)
        {
            return source.Add(ConsumerFactory.SumOfSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TSource>(this EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14> source, Func<TSource, float> selector)
        {
            return source.Add(ConsumerFactory.SumOfSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float})"/>
        public static EnumerationRequests16<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, float> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TSource>(this EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15> source, Func<TSource, float> selector)
        {
            return source.Add(ConsumerFactory.SumOfSingle<TSource>(selector));
        }

        #endregion

        #region Sum of float? with selector

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are transformed to <see langword="null"/> are ignored, hence if the sequence contains only
        ///         values that are transformed to <see langword="null"/>, the result of this request is <c>0</c>.
        ///   </para>
        /// </remarks>
        /// <returns>
        ///     <para>
        ///         An <see cref="EnumerationRequests1{TSource, float?}"/> whose <see href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">deconstruction</see> evaluate this request.
        ///     </para>
        ///     <para>
        ///         After deconstruction, the result of this request is at the first position.
        ///     </para>
        /// </returns>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The sequence for which the sum is requested.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests1<TSource, float?> GetSum<TSource>(this IEnumerable<TSource> source, Func<TSource, float?> selector)
        {
            return new EnumerationRequests1<TSource, float?>(source, ConsumerFactory.SumOfNullableSingle(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are transformed to <see langword="null"/> are ignored, hence if the sequence contains only
        ///         values that are transformed to <see langword="null"/>, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests2<TSource, TResult1, float?> AndSum<TResult1, TSource>(this EnumerationRequests1<TSource, TResult1> source, Func<TSource, float?> selector)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are transformed to <see langword="null"/> are ignored, hence if the sequence contains only
        ///         values that are transformed to <see langword="null"/>, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests3<TSource, TResult1, TResult2, float?> AndSum<TResult1, TResult2, TSource>(this EnumerationRequests2<TSource, TResult1, TResult2> source, Func<TSource, float?> selector)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are transformed to <see langword="null"/> are ignored, hence if the sequence contains only
        ///         values that are transformed to <see langword="null"/>, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests4<TSource, TResult1, TResult2, TResult3, float?> AndSum<TResult1, TResult2, TResult3, TSource>(this EnumerationRequests3<TSource, TResult1, TResult2, TResult3> source, Func<TSource, float?> selector)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are transformed to <see langword="null"/> are ignored, hence if the sequence contains only
        ///         values that are transformed to <see langword="null"/>, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TSource>(this EnumerationRequests4<TSource, TResult1, TResult2, TResult3, TResult4> source, Func<TSource, float?> selector)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are transformed to <see langword="null"/> are ignored, hence if the sequence contains only
        ///         values that are transformed to <see langword="null"/>, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TSource>(this EnumerationRequests5<TSource, TResult1, TResult2, TResult3, TResult4, TResult5> source, Func<TSource, float?> selector)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are transformed to <see langword="null"/> are ignored, hence if the sequence contains only
        ///         values that are transformed to <see langword="null"/>, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TSource>(this EnumerationRequests6<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6> source, Func<TSource, float?> selector)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are transformed to <see langword="null"/> are ignored, hence if the sequence contains only
        ///         values that are transformed to <see langword="null"/>, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TSource>(this EnumerationRequests7<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7> source, Func<TSource, float?> selector)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are transformed to <see langword="null"/> are ignored, hence if the sequence contains only
        ///         values that are transformed to <see langword="null"/>, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TSource>(this EnumerationRequests8<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8> source, Func<TSource, float?> selector)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are transformed to <see langword="null"/> are ignored, hence if the sequence contains only
        ///         values that are transformed to <see langword="null"/>, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TSource>(this EnumerationRequests9<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9> source, Func<TSource, float?> selector)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are transformed to <see langword="null"/> are ignored, hence if the sequence contains only
        ///         values that are transformed to <see langword="null"/>, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TSource>(this EnumerationRequests10<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10> source, Func<TSource, float?> selector)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are transformed to <see langword="null"/> are ignored, hence if the sequence contains only
        ///         values that are transformed to <see langword="null"/>, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TSource>(this EnumerationRequests11<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11> source, Func<TSource, float?> selector)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are transformed to <see langword="null"/> are ignored, hence if the sequence contains only
        ///         values that are transformed to <see langword="null"/>, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TSource>(this EnumerationRequests12<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12> source, Func<TSource, float?> selector)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are transformed to <see langword="null"/> are ignored, hence if the sequence contains only
        ///         values that are transformed to <see langword="null"/>, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TSource>(this EnumerationRequests13<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13> source, Func<TSource, float?> selector)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are transformed to <see langword="null"/> are ignored, hence if the sequence contains only
        ///         values that are transformed to <see langword="null"/>, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TSource>(this EnumerationRequests14<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14> source, Func<TSource, float?> selector)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle<TSource>(selector));
        }

        /// <summary>
        ///   <para>
        ///     Requests the evaluation of the sum of tranformed objects from a sequence.
        ///   </para>
        ///   <para>
        ///     The result of this request is the sum of transformed objects from the sequence.
        ///   </para>
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     If the sequence is empty the result of this request is <c>0</c>.
        ///   </para>
        ///   <para>
        ///     Values that are transformed to <see langword="null"/> are ignored, hence if the sequence contains only
        ///         values that are transformed to <see langword="null"/>, the result of this request is <c>0</c>.
        ///   </para>
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
        /// <seealso cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static EnumerationRequests16<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, float?> AndSum<TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15, TSource>(this EnumerationRequests15<TSource, TResult1, TResult2, TResult3, TResult4, TResult5, TResult6, TResult7, TResult8, TResult9, TResult10, TResult11, TResult12, TResult13, TResult14, TResult15> source, Func<TSource, float?> selector)
        {
            return source.Add(ConsumerFactory.SumOfNullableSingle<TSource>(selector));
        }

        #endregion

    }
}