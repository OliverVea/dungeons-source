#nullable enable

using UnityEngine;

namespace Runtime.Game.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 WithY(this Vector3 vector, float y)
        {
            vector.y = y;
            return vector;
        }
    }
}