#nullable enable

using System;
using BehaviorDesigner.Runtime;
using Runtime.Abstractions.Managers;
using Runtime.Abstractions.Models;
using UnityEngine;
using Zenject;

namespace Runtime.Abstractions
{
    public class Character : IInitializable, IDisposable
    {
        [Inject] private ICharacterListManager _characterListManager = null!;
        public void Initialize() => _characterListManager.AddCharacter(this);
        public void Dispose() => _characterListManager.RemoveCharacter(this);

        [Inject] private readonly ICharacterData _characterData = null!;
        [Inject] private readonly IHeadPositionComponent _headPositionComponent = null!;
        
        [Inject] public readonly Faction Faction;
        [Inject] public readonly Transform Transform = null!;
        [Inject] public readonly GameObject GameObject = null!;
        [Inject] public readonly Rigidbody Rigidbody = null!;
        [Inject] public readonly Collider Collider = null!;
        [Inject] public readonly Animator Animator = null!;
        [Inject] public readonly Renderer Renderer = null!;
        [Inject] public readonly BehaviorTree BehaviorTree = null!;
        [Inject] public readonly IBaseStats BaseStats = null!;
        [Inject] public readonly ISpellBook SpellBook = null!;
        [Inject] public readonly IMovementService MovementService = null!;
        [Inject] public readonly IHealthService HealthService = null!;
        [Inject] public readonly IManaService ManaService = null!;
        [Inject] public readonly IInputMovementService InputMovementService = null!;
        [Inject] public readonly IAnimationService AnimationService = null!;
        [Inject] public readonly IDeathService DeathService = null!;
        [Inject] public readonly ITargetService TargetService = null!;
        [Inject] public readonly IOutlineService OutlineService = null!;
        [Inject] public readonly IAutoAttackingService AutoAttackingService = null!;
        [Inject] public readonly IThreatService ThreatService = null!;
        [Inject] public readonly INavMeshMovementService NavMeshMovementService = null!;
        [Inject] public readonly IEffectService EffectService = null!;
        [Inject] public readonly IColorService ColorService = null!;
        [Inject] public readonly IConcentrationService ConcentrationService = null!;
        [Inject] public readonly IInventoryService InventoryService = null!;
        [Inject] public readonly IEquipmentService EquipmentService = null!;
        [Inject] public readonly IEquipmentModelService EquipmentModelService = null!;
        
        public string Name => _characterData.Name;
        public Vector3 Head => _headPositionComponent.Position;
        public Vector3 Feet => Transform.position;

        public class Factory : PlaceholderFactory<ISpawnPosition, ICharacterData, Character>
        {
            
        }
    }
}