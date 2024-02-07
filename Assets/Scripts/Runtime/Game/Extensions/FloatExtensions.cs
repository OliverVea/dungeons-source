# nullable enable
using System;
using System.Collections.Generic;

namespace Runtime.Game.Extensions
{
    public static class FloatExtensions
    {
        public static float Product<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, float> selector)
        {
            var product = 1f;

            foreach (var val in source)
            {
                product *= selector(val);
            }

            return product;
        }
    }
}