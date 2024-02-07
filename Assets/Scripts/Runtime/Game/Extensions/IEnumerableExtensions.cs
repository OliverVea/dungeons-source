#nullable enable

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runtime.Game.Extensions
{
    public static class IEnumerableExtensions
    {
        [HideInCallstack]
        public static T GetRandom<T>(this IEnumerable<T> collection)
        {
            var index = (int)(Random.value * collection.Count());
            return collection.ElementAt(index);
        }
    }
}