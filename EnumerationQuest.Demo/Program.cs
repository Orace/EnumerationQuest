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
using System.Linq;

namespace EnumerationQuest.Demo
{
    internal static class Program
    {
        private static void Main()
        {
            var r = new Random();
            var e = Enumerable.Range(0, 1000).Select(_ => r.Next(256));

            e.GetLongCount();
            e.LongCount();

            var q = e.GetMin()
                     .AndMax()
                     .AndIndexOf(42)
                     .AndAverage()
                     .AndSlice(2..4)
                     .AndElementAt(50)
                     .AndFirst()
                     .AndLast()
                     .AndCount()
                     .AndAny(i => true)
                     .AndDelimitedString(", ", v => $"{v:000}");

            try
            {
                var (min, max, i42, avg, slice, at50, first, last, count, fCount, hs) = q;

                Console.WriteLine(min);
                Console.WriteLine(max);
                Console.WriteLine(i42);
                Console.WriteLine(avg);
                Console.WriteLine(string.Join(", ", slice));
                Console.WriteLine(at50);
                Console.WriteLine(first);
                Console.WriteLine(last);
                Console.WriteLine(count);
                Console.WriteLine(hs);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
