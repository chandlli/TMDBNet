using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMDBNet.Extensions
{
    public static class EnumerableExtension
    {
        public static bool SafeSequenceEquals<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            if (first is null && second is null)
                return true;

            if (first is null)
                return false;

            if (second is null)
                return false;

            return Enumerable.SequenceEqual(first, second);
        }
    }
}
