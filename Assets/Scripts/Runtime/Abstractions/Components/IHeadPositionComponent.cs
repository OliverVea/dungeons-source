#nullable enable

using UnityEngine;

namespace Runtime.Abstractions
{
    public interface IHeadPositionComponent
    {
        Vector3 Position { get; }
    }
}