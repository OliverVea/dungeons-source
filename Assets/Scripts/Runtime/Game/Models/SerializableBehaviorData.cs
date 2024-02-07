#nullable enable

using System;
using BehaviorDesigner.Runtime;
using Runtime.Abstractions.Models;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Game.Models
{
    [Serializable]
    public class SerializableBehaviorData : IBehaviorData
    {
        [Required][SerializeField] private ExternalBehavior _behaviorTree = null!;
        public ExternalBehavior BehaviorTree => _behaviorTree;
    }
}