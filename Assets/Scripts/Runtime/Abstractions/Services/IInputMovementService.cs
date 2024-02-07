#nullable enable

using UnityEngine;

namespace Runtime.Abstractions
{
    public interface IInputMovementService
    {
        Vector3 RelativeDirection { get; }
        
        void SetDirection(float x, float z);
        void SetMovementRotation(Quaternion movementRotation);
        void Jump();
    }
}