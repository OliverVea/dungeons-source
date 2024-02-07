#nullable enable

using Runtime.Abstractions.Models;
using UnityEngine;

namespace Runtime.Game.Models
{
    [CreateAssetMenu(menuName = "Character/CharacterComponentSettings")]
    public class ScriptableObjectCharacterComponentSettings : ScriptableObject, ICharacterComponentSettings
    {
        [SerializeField] private bool _rigidbodyIsKinematic;
        public bool RigidbodyIsKinematic => _rigidbodyIsKinematic;
        
        [SerializeField] private bool _behaviorTreeEnabled;
        public bool BehaviorTreeEnabled => _behaviorTreeEnabled;
        
        [SerializeField] private bool _navMeshAgentEnabled;
        public bool NavMeshAgentEnabled => _navMeshAgentEnabled;
    }
}