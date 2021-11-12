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

using System.Collections.Generic;
using NUnit.Framework;

namespace EnumerationQuest.Test
{
    public class EnumerationRequestsTests
    {
        [Test]
        public void EnumerationRequestsTest()
        {
            var i = 0;
            var j = 0;

            IEnumerable<int> Enumerable()
            {
                for (;;)
                    yield return i++;
            }

            var requests1 = Enumerable().GetElementAt(0);
            requests1.Deconstruct(out var result1);
            Assert.That(result1, Is.EqualTo(j++));

            var requests2 = requests1.AndElementAt(1);
            var (result2Item1, result2Item2) = requests2;
            Assert.That(result2Item1, Is.EqualTo(j++));
            Assert.That(result2Item2, Is.EqualTo(j++));

            var requests3 = requests2.AndElementAt(2);
            var (result3Item1, result3Item2, result3Item3) = requests3;
            Assert.That(result3Item1, Is.EqualTo(j++));
            Assert.That(result3Item2, Is.EqualTo(j++));
            Assert.That(result3Item3, Is.EqualTo(j++));

            var requests4 = requests3.AndElementAt(3);
            var (result4Item1, result4Item2, result4Item3, result4Item4) = requests4;
            Assert.That(result4Item1, Is.EqualTo(j++));
            Assert.That(result4Item2, Is.EqualTo(j++));
            Assert.That(result4Item3, Is.EqualTo(j++));
            Assert.That(result4Item4, Is.EqualTo(j++));

            var requests5 = requests4.AndElementAt(4);
            var (result5Item1, result5Item2, result5Item3, result5Item4, result5Item5) = requests5;
            Assert.That(result5Item1, Is.EqualTo(j++));
            Assert.That(result5Item2, Is.EqualTo(j++));
            Assert.That(result5Item3, Is.EqualTo(j++));
            Assert.That(result5Item4, Is.EqualTo(j++));
            Assert.That(result5Item5, Is.EqualTo(j++));

            var requests6 = requests5.AndElementAt(5);
            var (result6Item1, result6Item2, result6Item3, result6Item4, result6Item5, result6Item6) = requests6;
            Assert.That(result6Item1, Is.EqualTo(j++));
            Assert.That(result6Item2, Is.EqualTo(j++));
            Assert.That(result6Item3, Is.EqualTo(j++));
            Assert.That(result6Item4, Is.EqualTo(j++));
            Assert.That(result6Item5, Is.EqualTo(j++));
            Assert.That(result6Item6, Is.EqualTo(j++));

            var requests7 = requests6.AndElementAt(6);
            var (result7Item1, result7Item2, result7Item3, result7Item4, result7Item5, result7Item6, result7Item7) = requests7;
            Assert.That(result7Item1, Is.EqualTo(j++));
            Assert.That(result7Item2, Is.EqualTo(j++));
            Assert.That(result7Item3, Is.EqualTo(j++));
            Assert.That(result7Item4, Is.EqualTo(j++));
            Assert.That(result7Item5, Is.EqualTo(j++));
            Assert.That(result7Item6, Is.EqualTo(j++));
            Assert.That(result7Item7, Is.EqualTo(j++));

            var requests8 = requests7.AndElementAt(7);
            var (result8Item1, result8Item2, result8Item3, result8Item4, result8Item5, result8Item6, result8Item7, result8Item8) = requests8;
            Assert.That(result8Item1, Is.EqualTo(j++));
            Assert.That(result8Item2, Is.EqualTo(j++));
            Assert.That(result8Item3, Is.EqualTo(j++));
            Assert.That(result8Item4, Is.EqualTo(j++));
            Assert.That(result8Item5, Is.EqualTo(j++));
            Assert.That(result8Item6, Is.EqualTo(j++));
            Assert.That(result8Item7, Is.EqualTo(j++));
            Assert.That(result8Item8, Is.EqualTo(j++));

            var requests9 = requests8.AndElementAt(8);
            var (result9Item1, result9Item2, result9Item3, result9Item4, result9Item5, result9Item6, result9Item7, result9Item8, result9Item9) = requests9;
            Assert.That(result9Item1, Is.EqualTo(j++));
            Assert.That(result9Item2, Is.EqualTo(j++));
            Assert.That(result9Item3, Is.EqualTo(j++));
            Assert.That(result9Item4, Is.EqualTo(j++));
            Assert.That(result9Item5, Is.EqualTo(j++));
            Assert.That(result9Item6, Is.EqualTo(j++));
            Assert.That(result9Item7, Is.EqualTo(j++));
            Assert.That(result9Item8, Is.EqualTo(j++));
            Assert.That(result9Item9, Is.EqualTo(j++));

            var requests10 = requests9.AndElementAt(9);
            var (result10Item1, result10Item2, result10Item3, result10Item4, result10Item5, result10Item6, result10Item7, result10Item8, result10Item9, result10Item10) = requests10;
            Assert.That(result10Item1, Is.EqualTo(j++));
            Assert.That(result10Item2, Is.EqualTo(j++));
            Assert.That(result10Item3, Is.EqualTo(j++));
            Assert.That(result10Item4, Is.EqualTo(j++));
            Assert.That(result10Item5, Is.EqualTo(j++));
            Assert.That(result10Item6, Is.EqualTo(j++));
            Assert.That(result10Item7, Is.EqualTo(j++));
            Assert.That(result10Item8, Is.EqualTo(j++));
            Assert.That(result10Item9, Is.EqualTo(j++));
            Assert.That(result10Item10, Is.EqualTo(j++));

            var requests11 = requests10.AndElementAt(10);
            var (result11Item1, result11Item2, result11Item3, result11Item4, result11Item5, result11Item6, result11Item7, result11Item8, result11Item9, result11Item10, result11Item11) = requests11;
            Assert.That(result11Item1, Is.EqualTo(j++));
            Assert.That(result11Item2, Is.EqualTo(j++));
            Assert.That(result11Item3, Is.EqualTo(j++));
            Assert.That(result11Item4, Is.EqualTo(j++));
            Assert.That(result11Item5, Is.EqualTo(j++));
            Assert.That(result11Item6, Is.EqualTo(j++));
            Assert.That(result11Item7, Is.EqualTo(j++));
            Assert.That(result11Item8, Is.EqualTo(j++));
            Assert.That(result11Item9, Is.EqualTo(j++));
            Assert.That(result11Item10, Is.EqualTo(j++));
            Assert.That(result11Item11, Is.EqualTo(j++));

            var requests12 = requests11.AndElementAt(11);
            var (result12Item1, result12Item2, result12Item3, result12Item4, result12Item5, result12Item6, result12Item7, result12Item8, result12Item9, result12Item10, result12Item11, result12Item12) = requests12;
            Assert.That(result12Item1, Is.EqualTo(j++));
            Assert.That(result12Item2, Is.EqualTo(j++));
            Assert.That(result12Item3, Is.EqualTo(j++));
            Assert.That(result12Item4, Is.EqualTo(j++));
            Assert.That(result12Item5, Is.EqualTo(j++));
            Assert.That(result12Item6, Is.EqualTo(j++));
            Assert.That(result12Item7, Is.EqualTo(j++));
            Assert.That(result12Item8, Is.EqualTo(j++));
            Assert.That(result12Item9, Is.EqualTo(j++));
            Assert.That(result12Item10, Is.EqualTo(j++));
            Assert.That(result12Item11, Is.EqualTo(j++));
            Assert.That(result12Item12, Is.EqualTo(j++));

            var requests13 = requests12.AndElementAt(12);
            var (result13Item1, result13Item2, result13Item3, result13Item4, result13Item5, result13Item6, result13Item7, result13Item8, result13Item9, result13Item10, result13Item11, result13Item12, result13Item13) = requests13;
            Assert.That(result13Item1, Is.EqualTo(j++));
            Assert.That(result13Item2, Is.EqualTo(j++));
            Assert.That(result13Item3, Is.EqualTo(j++));
            Assert.That(result13Item4, Is.EqualTo(j++));
            Assert.That(result13Item5, Is.EqualTo(j++));
            Assert.That(result13Item6, Is.EqualTo(j++));
            Assert.That(result13Item7, Is.EqualTo(j++));
            Assert.That(result13Item8, Is.EqualTo(j++));
            Assert.That(result13Item9, Is.EqualTo(j++));
            Assert.That(result13Item10, Is.EqualTo(j++));
            Assert.That(result13Item11, Is.EqualTo(j++));
            Assert.That(result13Item12, Is.EqualTo(j++));
            Assert.That(result13Item13, Is.EqualTo(j++));

            var requests14 = requests13.AndElementAt(13);
            var (result14Item1, result14Item2, result14Item3, result14Item4, result14Item5, result14Item6, result14Item7, result14Item8, result14Item9, result14Item10, result14Item11, result14Item12, result14Item13, result14Item14) = requests14;
            Assert.That(result14Item1, Is.EqualTo(j++));
            Assert.That(result14Item2, Is.EqualTo(j++));
            Assert.That(result14Item3, Is.EqualTo(j++));
            Assert.That(result14Item4, Is.EqualTo(j++));
            Assert.That(result14Item5, Is.EqualTo(j++));
            Assert.That(result14Item6, Is.EqualTo(j++));
            Assert.That(result14Item7, Is.EqualTo(j++));
            Assert.That(result14Item8, Is.EqualTo(j++));
            Assert.That(result14Item9, Is.EqualTo(j++));
            Assert.That(result14Item10, Is.EqualTo(j++));
            Assert.That(result14Item11, Is.EqualTo(j++));
            Assert.That(result14Item12, Is.EqualTo(j++));
            Assert.That(result14Item13, Is.EqualTo(j++));
            Assert.That(result14Item14, Is.EqualTo(j++));

            var requests15 = requests14.AndElementAt(14);
            var (result15Item1, result15Item2, result15Item3, result15Item4, result15Item5, result15Item6, result15Item7, result15Item8, result15Item9, result15Item10, result15Item11, result15Item12, result15Item13, result15Item14, result15Item15) = requests15;
            Assert.That(result15Item1, Is.EqualTo(j++));
            Assert.That(result15Item2, Is.EqualTo(j++));
            Assert.That(result15Item3, Is.EqualTo(j++));
            Assert.That(result15Item4, Is.EqualTo(j++));
            Assert.That(result15Item5, Is.EqualTo(j++));
            Assert.That(result15Item6, Is.EqualTo(j++));
            Assert.That(result15Item7, Is.EqualTo(j++));
            Assert.That(result15Item8, Is.EqualTo(j++));
            Assert.That(result15Item9, Is.EqualTo(j++));
            Assert.That(result15Item10, Is.EqualTo(j++));
            Assert.That(result15Item11, Is.EqualTo(j++));
            Assert.That(result15Item12, Is.EqualTo(j++));
            Assert.That(result15Item13, Is.EqualTo(j++));
            Assert.That(result15Item14, Is.EqualTo(j++));
            Assert.That(result15Item15, Is.EqualTo(j++));

            var requests16 = requests15.AndElementAt(15);
            var (result16Item1, result16Item2, result16Item3, result16Item4, result16Item5, result16Item6, result16Item7, result16Item8, result16Item9, result16Item10, result16Item11, result16Item12, result16Item13, result16Item14, result16Item15, result16Item16) = requests16;
            Assert.That(result16Item1, Is.EqualTo(j++));
            Assert.That(result16Item2, Is.EqualTo(j++));
            Assert.That(result16Item3, Is.EqualTo(j++));
            Assert.That(result16Item4, Is.EqualTo(j++));
            Assert.That(result16Item5, Is.EqualTo(j++));
            Assert.That(result16Item6, Is.EqualTo(j++));
            Assert.That(result16Item7, Is.EqualTo(j++));
            Assert.That(result16Item8, Is.EqualTo(j++));
            Assert.That(result16Item9, Is.EqualTo(j++));
            Assert.That(result16Item10, Is.EqualTo(j++));
            Assert.That(result16Item11, Is.EqualTo(j++));
            Assert.That(result16Item12, Is.EqualTo(j++));
            Assert.That(result16Item13, Is.EqualTo(j++));
            Assert.That(result16Item14, Is.EqualTo(j++));
            Assert.That(result16Item15, Is.EqualTo(j++));
            Assert.That(result16Item16, Is.EqualTo(j++));
        }
    }
}