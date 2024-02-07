#nullable enable

using Runtime.Abstractions;
using UnityEngine;

namespace Runtime.Game.Components
{
    public class HeadPositionComponent : MonoBehaviour, IHeadPositionComponent
    {
        public Vector3 Position => transform.position;
    }
}