#nullable enable

using Runtime.Abstractions.Models;
using UnityEngine;

namespace Runtime.Game.Components
{
    public class SpawnPositionComponent : MonoBehaviour, ISpawnPosition
    {
        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;
    }
}