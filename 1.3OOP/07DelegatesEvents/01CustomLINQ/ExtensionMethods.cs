using System;
using System.Collections.Generic;
using System.Linq;

namespace _01CustomLINQ
{
    public static class ExtensionMethods
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();

            foreach (var element in collection)
            {
                if (!predicate(element))
                {
                    result.Add(element);
                }
            }
            return result;
        }

        public static TSelector CustomMax<TSource, TSelector>(this IEnumerable<TSource> collection, Func<TSource, TSelector> selector) where TSelector : IComparable
        {
            if (collection == null)
            {
                throw new InvalidOperationException("Collection is empty!");
            }

            TSelector result = selector(collection.First());

            foreach (var element in collection)
            {
                if (result.CompareTo(selector(element)) < 0)
                {
                    result = selector(element);
                }
            }
            return result;
        }
    }
}