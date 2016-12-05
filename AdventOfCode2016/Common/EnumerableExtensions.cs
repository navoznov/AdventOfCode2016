using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class EnumerableExtensions
    {
        public static int GetIndexOf<T>(this IEnumerable<T> source, Func<T, bool> condition)
        {
            var enumerator = source.GetEnumerator();
            var index = -1;
            while (enumerator.MoveNext())
            {
                index++;
                if (condition(enumerator.Current))
                {
                    return index;
                }
            }

            return -1;
        }
    }
}