#nullable enable

using BehaviorDesigner.Runtime;
using Runtime.Abstractions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Game.Components
{
    public class ComponentComponent : MonoBehaviour
    {
        [Required][SerializeField] private GameObject _gameObject = null!;
        public GameObject GameObject => _gameObject;
        
        [Required][SerializeField] private Transform _transform = null!;
        public Transform Transform => _transform;
        
        [Required][SerializeField] private Animator _animator = null!;
        public Animator Animator => _animator;
        
        [Required][SerializeField] private Rigidbody _rigidbody = null!;
        public Rigidbody Rigidbody => _rigidbody;
        
        [Required][SerializeField] private Collider _collider = null!;
        public Collider Collider => _collider;
        
        [Required][SerializeField] private UnityEngine.AI.NavMeshAgent _navMeshAgent = null!;
        public UnityEngine.AI.NavMeshAgent NavMeshAgent => _navMeshAgent;
        
        [Required][SerializeField] private BehaviorTree _behaviorTree = null!;
        public BehaviorTree BehaviorTree => _behaviorTree;
        
        [Required][SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer = null!;
        public SkinnedMeshRenderer SkinnedMeshRenderer => _skinnedMeshRenderer;
        
        [Required][SerializeField] private OutlineComponent _outlineComponent = null!;
        public IOutlineComponent OutlineComponent => _outlineComponent;
        
        [Required][SerializeField] private CharacterMouseComponent _characterMouseComponent = null!;
        public CharacterMouseComponent CharacterMouseComponent => _characterMouseComponent;
        
        [Required][SerializeField] private HeadPositionComponent _headPositionComponent = null!;
        public HeadPositionComponent HeadPositionComponent => _headPositionComponent;
        
        [Required][SerializeField] private EquipmentModelComponent _equipmentModelComponent = null!;
        public IEquipmentModelComponent EquipmentModelComponent => _equipmentModelComponent;
    }
}