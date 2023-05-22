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
using System.Reactive.Linq;

namespace EnumerationQuest.Demo
{
    internal static class Program
    {
        private static void Main()
        {
            var peoples = new[]
            {
                new { Age = 40, Gender = Gender.Male, Name = "Bob" },
                new { Age = 38, Gender = Gender.Female, Name = "Helen" },
                new { Age = 14, Gender = Gender.Female, Name = "Violet" },
                new { Age = 10, Gender = Gender.Male, Name = "Dash" },
                new { Age = 1, Gender = Gender.Male, Name = "Jack-Jack" }
            };

            var (infants, kids, teenagers, adults, female, male) =
                peoples.Get(o => o.Where(p => p.Age <= 2).Select(p => p.Name).ToList())
                       .And(o => o.Where(p => p.Age is > 2 and <= 12).Select(p => p.Name).ToList())
                       .And(o => o.Where(p => p.Age is > 12 and <= 19).Select(p => p.Name).ToList())
                       .And(o => o.Where(p => p.Age > 19).Select(p => p.Name).ToList())
                       .And(o => o.Where(p => p.Gender is Gender.Female).Select(p => p.Name).ToList())
                       .And(o => o.Where(p => p.Gender is Gender.Male).Select(p => p.Name).ToList());

            Console.WriteLine($"  infants: {string.Join(", ", infants)}");
            Console.WriteLine($"     kids: {string.Join(", ", kids)}");
            Console.WriteLine($"teenagers: {string.Join(", ", teenagers)}");
            Console.WriteLine($"   adults: {string.Join(", ", adults)}");
            Console.WriteLine($"   female: {string.Join(", ", female)}");
            Console.WriteLine($"    male : {string.Join(", ", male)}");

            var r = new Random();
            var e = Enumerable.Range(0, 1000).Select(_ => r.Next(256));

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
                     .AndDelimitedString(", ", v => $"{v:000}")
                     .AndHasDuplicates();

            try
            {
                var (min, max, i42, avg, slice, at50, first, last, count, any, delimitedString, hasDuplicate) = q;

                Console.WriteLine(min);
                Console.WriteLine(max);
                Console.WriteLine(i42);
                Console.WriteLine(avg);
                Console.WriteLine(string.Join(", ", slice));
                Console.WriteLine(at50);
                Console.WriteLine(first);
                Console.WriteLine(last);
                Console.WriteLine(count);
                Console.WriteLine(any);
                Console.WriteLine(delimitedString);
                Console.WriteLine(hasDuplicate);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private enum Gender
        {
            Female,
            Male
        }
    }
}
