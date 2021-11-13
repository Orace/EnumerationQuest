﻿// EnumerableQuest - Avoids multiple enumeration
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

namespace EnumerationQuest.Tests
{
    public static class DeconstructionHelper
    {
        internal static TResult Deconstruct<TSource, TResult>(this EnumerationRequests1<TSource, TResult> consumers)
        {
            try
            {
                consumers.Deconstruct(out var result);
                return result;
            }
            catch (EnumerationException e)
            {
                throw e.InnerException ?? e;
            }
        }
    }
}