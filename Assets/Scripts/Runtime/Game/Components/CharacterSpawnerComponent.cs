#nullable enable

using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Helpers;
using Runtime.Game.Models;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Runtime.Game.Components
{
    public class CharacterSpawnerComponent : MonoBehaviour, IInitializable
    {
        [Inject] private ICharacterSpawningController _characterSpawningController = null!;
        [Inject] private ICharacterComponentManagementHelper _characterComponentManagementHelper = null!;
        
        [Required][SerializeField] private SpawnPositionComponent _spawnPosition = null!;
        [Required][SerializeField] private ScriptableObjectCharacterData _characterData = null!;
        
        
        public void Initialize()
        {
            if (!gameObject.activeInHierarchy) return;
            
            var character = _characterSpawningController.SpawnCharacter(_spawnPosition, _characterData);

            var isPlayer = false;
            _characterComponentManagementHelper.SetPlayerComponentSettings(character, isPlayer);
        }
    }
}