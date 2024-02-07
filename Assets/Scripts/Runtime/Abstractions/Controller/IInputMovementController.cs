#nullable enable

using UnityEngine;

namespace Runtime.Abstractions.Controller
{
    public interface IInputMovementController
    {
        bool ShouldEvaluate();
        void SetDirection(Vector3 direction);
        void Jump();
        bool IsGrounded(Character character);
    }
}