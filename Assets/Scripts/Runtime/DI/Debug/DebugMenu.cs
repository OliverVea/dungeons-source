#nullable enable

using System.Collections.Generic;
using System.Linq;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Models;
using Runtime.Game.Models;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Runtime.DI.Debug
{
    public class DebugMenu : MonoBehaviour, IInitializable
    {
        [SerializeField] private ScriptableObjectCharacterData _characterData = null!;

        private IPlayerCharacterController _playerCharacterController = null!;
        private ICharacterSpawningController _characterSpawningController = null!;
        private IList<ISpawnPosition> _spawnPositions = null!;

        [Inject]
        public void Construct(
            IPlayerCharacterController playerCharacterController,
            ICharacterSpawningController characterSpawningController,
            IList<ISpawnPosition> spawnPositions)
        {
            _playerCharacterController = playerCharacterController;
            _characterSpawningController = characterSpawningController;
            _spawnPositions = spawnPositions;
        }


        public void Initialize()
        {
            _characterData = Resources.Load<ScriptableObjectCharacterData>("ScriptableObjects/CharacterData/PlayerCharacter");
            SpawnPlayer();
        }

        [Button]
        public void SpawnPlayer()
        {
            var spawnPosition = _spawnPositions.First();
            var character = _characterSpawningController.SpawnCharacter(spawnPosition, _characterData);
            _playerCharacterController.SetPlayerCharacter(character);
        }
    }
}