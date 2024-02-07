#nullable enable

using UnityEngine;

namespace Runtime.Abstractions.Models
{
    public interface ISpawnPosition
    {
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }
    }
}