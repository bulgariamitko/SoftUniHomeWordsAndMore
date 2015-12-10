using System;
using System.Collections.Generic;
using System.Linq;

namespace Exers02Func
{
    public static class Func
    {
        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return Enumerable.TakeWhile(collection, element => predicate(element)).ToList();
        }
    }
}