#nullable enable

using BehaviorDesigner.Runtime;
using Runtime.Abstractions;
using Runtime.Abstractions.Models;
using Runtime.Game.Components;
using Runtime.Game.Extensions;
using Runtime.Game.Services;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Runtime.DI.Installers
{
    public class CharacterInstaller : Installer<ICharacterData, CharacterInstaller>
    {
        private readonly ICharacterData _characterData;
        private readonly ISpawnPosition _spawnPosition;
        
        public CharacterInstaller(
            ICharacterData characterData,
            ISpawnPosition spawnPosition)
        {
            _characterData = characterData;
            _spawnPosition = spawnPosition;
        }
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Character>().AsSingle().OnInstantiated<Character>(OnCharacterInstantiated);
            
            Container.Bind<ICharacterData>().FromInstance(_characterData);
            Container.Bind<IBaseStats>().FromResolveGetter<ICharacterData>(x => x.BaseStats).AsTransient();
            Container.Bind<ISpellBook>().FromResolveGetter<ICharacterData>(x => x.SpellBook).AsTransient();
            Container.Bind<ISpawnPosition>().FromInstance(_spawnPosition);
            
            // Services
            Container.BindInterfacesTo<AnimationService>().AsSingle();
            Container.BindInterfacesTo<AutoAttackingService>().AsSingle();
            Container.BindInterfacesTo<ColorService>().AsSingle();
            Container.BindInterfacesTo<DeathService>().AsSingle();
            Container.BindInterfacesTo<HealthService>().AsSingle();
            Container.BindInterfacesTo<ManaService>().AsSingle();
            Container.BindInterfacesTo<ModelService>().AsSingle();
            Container.BindInterfacesTo<MovementService>().AsSingle();
            Container.BindInterfacesTo<NavMeshMovementService>().AsSingle();
            Container.BindInterfacesTo<OutlineService>().AsSingle();
            Container.BindInterfacesTo<SpawningService>().AsSingle();
            Container.BindInterfacesTo<TargetService>().AsSingle();
            Container.BindInterfacesTo<ThreatService>().AsSingle();
            Container.BindInterfacesTo<BehaviorService>().AsSingle();
            Container.BindInterfacesTo<EffectService>().AsSingle();
            Container.BindInterfacesTo<ConcentrationService>().AsSingle();
            Container.BindInterfacesTo<InventoryService>().AsSingle();
            Container.BindInterfacesTo<EquipmentService>().AsSingle();
            Container.BindInterfacesTo<EquipmentModelService>().AsSingle();
            
            
            // Components
            Container.Bind<ComponentComponent>().FromComponentOnRoot().AsSingle();

            Container.BindInterfacesTo<CharacterMouseComponent>().FromResolveGetter<ComponentComponent, CharacterMouseComponent>(x => x.CharacterMouseComponent).AsSingle();
            Container.Bind<GameObject>().FromResolveGetter<ComponentComponent>(x => x.GameObject).AsSingle();
            Container.Bind<Transform>().FromResolveGetter<ComponentComponent>(x => x.Transform).AsSingle();
            Container.Bind<BehaviorTree>().FromResolveGetter<ComponentComponent>(x => x.BehaviorTree).AsSingle();
            Container.Bind<Animator>().FromResolveGetter<ComponentComponent>(x => x.Animator).AsSingle();
            Container.Bind<Collider>().FromResolveGetter<ComponentComponent>(x => x.Collider).AsSingle();
            Container.Bind<Rigidbody>().FromResolveGetter<ComponentComponent>(x => x.Rigidbody).AsSingle();
            Container.Bind<NavMeshAgent>().FromResolveGetter<ComponentComponent>(x => x.NavMeshAgent).AsSingle();
            Container.Bind<SkinnedMeshRenderer>().FromResolveGetter<ComponentComponent>(x => x.SkinnedMeshRenderer).AsSingle();
            Container.Bind<Renderer>().FromResolveGetter<ComponentComponent>(x => x.SkinnedMeshRenderer).AsSingle();

            Container.Bind<IOutlineComponent>().FromResolveGetter<ComponentComponent>(x => x.OutlineComponent).AsSingle();
            Container.Bind<IHeadPositionComponent>().FromResolveGetter<ComponentComponent>(x => x.HeadPositionComponent).AsSingle();
            Container.Bind<IEquipmentModelComponent>().FromResolveGetter<ComponentComponent>(x => x.EquipmentModelComponent).AsSingle();
            
            // Literals
            Container.Bind<Faction>().FromInstance(_characterData.Faction).AsSingle();
        }

        private static void OnCharacterInstantiated(InjectContext injectContext, Character character)
        {
            character.BehaviorTree.QueueAllTasksForInject(injectContext.Container);
        }
    }
}