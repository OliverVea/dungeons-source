#nullable enable
using UnityEngine;

namespace Runtime.Abstractions.Controller
{
    public interface ITransformController
    {
        void SetPosition(Character character, Vector3 newPosition);
        void SetRotation(Character character, Quaternion newRotation);
    }
}