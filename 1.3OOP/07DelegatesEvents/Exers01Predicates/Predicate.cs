using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Exers01Predicates
{
    public static class Predicate
    {
        public static T FirstOrDefault<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            foreach (var element in collection.Where(element => condition(element)))
            {
                return element;
            }
            return default(T);
        }
    }
}