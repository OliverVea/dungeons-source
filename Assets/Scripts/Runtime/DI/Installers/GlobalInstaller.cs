#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Models;
using Runtime.DI.Debug;
using Runtime.DI.Factories;
using Runtime.Game;
using Runtime.Game.Components;
using Runtime.Game.Controllers;
using Runtime.Game.Handlers;
using Runtime.Game.Helpers;
using Runtime.Game.Input;
using Runtime.Game.Managers;
using Runtime.Game.Models;
using Runtime.Game.Services;
using Runtime.Game.Spells.Fireball;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Runtime.DI.Installers
{
    [CreateAssetMenu(fileName = "GlobalInstaller", menuName = "Installers/Global")]
    public class GlobalInstaller : ScriptableObjectInstaller<GlobalInstaller>
    {
        [Required][SerializeField] private GameObject _baseCharacter = null!;
        
        public override void InstallBindings()
        {
            Container.Bind<ILogger>().FromInstance(UnityEngine.Debug.unityLogger).AsSingle();
            Container.Bind<InputWrapper>().AsSingle();
            Container.BindInterfacesTo<Timer>().AsTransient();
            
            
            // Input Handlers
            Container.BindInterfacesAndSelfTo<JumpHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<MouseButtonsHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<MouseHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<MovementHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<PanHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<ZoomHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<AbilityHandler>().AsSingle();
            
            
            // Managers
            Container.BindInterfacesTo<CharacterListManager>().AsSingle();
            Container.BindInterfacesTo<MouseComponentManager>().AsSingle();
            Container.BindInterfacesTo<MouseOverManager>().AsSingle();
            Container.BindInterfacesTo<PartyManager>().AsSingle();
            Container.BindInterfacesTo<PlayerCharacterManager>().AsSingle();
            Container.BindInterfacesTo<PlayerTargetManager>().AsSingle();

            Container.BindInterfacesTo<CoroutineManager>().FromNewComponentOnNewGameObject().AsSingle();
            
            
            // Factories
            Container.BindInterfacesTo<SpellFactory>().AsTransient();
            Container.BindInterfacesTo<ScriptableObjectFactory>().AsTransient();
            

            // Controllers
            Container.BindInterfacesTo<AnimationController>().AsTransient();
            Container.BindInterfacesTo<AutoAttackingController>().AsTransient();
            Container.BindInterfacesTo<CameraController>().AsTransient();
            Container.BindInterfacesTo<CharacterSpawningController>().AsTransient();
            Container.BindInterfacesTo<DeathController>().AsTransient();
            Container.BindInterfacesTo<HealthController>().AsTransient();
            Container.BindInterfacesTo<ManaController>().AsTransient();
            Container.BindInterfacesTo<MouseController>().AsTransient();
            Container.BindInterfacesTo<PlayerCharacterController>().AsTransient();
            Container.BindInterfacesTo<TargetController>().AsTransient();
            Container.BindInterfacesTo<ThreatController>().AsTransient();
            Container.BindInterfacesTo<TransformController>().AsTransient();
            Container.BindInterfacesTo<MovementController>().AsTransient();
            Container.BindInterfacesTo<NavMeshMovementController>().AsTransient();
            Container.BindInterfacesTo<InputMovementController>().AsTransient();
            Container.BindInterfacesTo<EffectController>().AsTransient();
            Container.BindInterfacesTo<ConcentrationController>().AsTransient();
            Container.BindInterfacesTo<SpellCastingController>().AsTransient();
            Container.BindInterfacesTo<PlayerSpellCastingController>().AsTransient();
            Container.BindInterfacesTo<SpellBookController>().AsTransient();
            Container.BindInterfacesTo<StatsController>().AsTransient();
            Container.BindInterfacesTo<InventoryController>().AsTransient();
            Container.BindInterfacesTo<EquipmentController>().AsTransient();
            Container.BindInterfacesTo<EquipmentModelController>().AsTransient();
            
            
            // Helpers
            Container.BindInterfacesTo<CameraOffsetHelper>().AsTransient();
            Container.BindInterfacesTo<CharacterComponentManagementHelper>().AsTransient();
            Container.BindInterfacesTo<FactionHelper>().AsTransient();
            Container.BindInterfacesTo<LayerHelper>().AsTransient();
            Container.BindInterfacesTo<RangeHelper>().AsTransient();
            Container.BindInterfacesTo<RaycastHelper>().AsTransient();
            Container.BindInterfacesTo<LineOfSightHelper>().AsTransient();
            Container.BindInterfacesTo<TimeHelper>().AsTransient();
            
            
            // Services
            Container.BindInterfacesTo<CameraService>().AsSingle();
            
            
            // Hierarchy - Components
            Container.Bind<ISpawnPosition>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesTo<UnityEventMouseComponent>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesTo<CharacterSpawnerComponent>().FromComponentsInHierarchy().AsSingle();
            Container.BindInterfacesTo<ConcentrationComponent>().FromComponentsInHierarchy().AsSingle();
            
            
            // Hierarchy - Other
            Container.Bind<Camera>().FromComponentInHierarchy().AsSingle();
            
            
            // Factories
            Container.BindFactory<ISpawnPosition, ICharacterData, Character, Character.Factory>()
                .FromSubContainerResolve().ByNewPrefabInstaller<CharacterInstaller>(_baseCharacter);

            
            // Spells
            Container.Bind<Fireball>().FromNew().AsTransient();
            

            Container.BindInterfacesTo<DebugMenu>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}