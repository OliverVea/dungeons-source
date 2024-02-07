#nullable enable

using System.Linq;
using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Managers;
using Runtime.Game.Extensions;
using UnityEngine;

namespace Runtime.Game.Controllers
{
    public class DeathController : IDeathController
    {
        private readonly ICharacterListManager _characterListManager;
        private readonly ITargetController _targetController;
        private readonly IPlayerTargetManager _playerTargetManager;
        private readonly IPlayerCharacterManager _playerCharacterManager;
        private readonly IThreatController _threatController;

        public DeathController(ICharacterListManager characterListManager,
            ITargetController targetController,
            IPlayerCharacterManager playerCharacterManager,
            IPlayerTargetManager playerTargetManager,
            IThreatController threatController)
        {
            _characterListManager = characterListManager;
            _targetController = targetController;
            _playerCharacterManager = playerCharacterManager;
            _playerTargetManager = playerTargetManager;
            _threatController = threatController;
        }

        public void Kill(Character character)
        {
            character.DeathService.Kill();
        }

        public void DeathCleanup(Character character)
        {
            if (character == _playerCharacterManager.PlayerCharacter)
            {
                _playerTargetManager.ClearPlayerTarget();
                _playerCharacterManager.ClearPlayerCharacter();
            }
            
            var allCharacters = _characterListManager.ListCharacters().ToArray();

            allCharacters.DropThreatTo(character, _threatController);
            
            allCharacters.ThatAreTargeting(character, _targetController)
                .SetTarget(null, _targetController);
            
            Object.Destroy(character.GameObject);
        }
    }
}