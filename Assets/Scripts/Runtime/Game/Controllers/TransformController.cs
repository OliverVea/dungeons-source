#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using UnityEngine;

namespace Runtime.Game.Controllers
{
    public class TransformController : ITransformController
    {
        public void SetPosition(Character character, Vector3 newPosition)
        {
            character.Transform.position = newPosition;
        }

        public void SetRotation(Character character, Quaternion newRotation)
        {
            character.Transform.rotation = newRotation;
        }
    }
}