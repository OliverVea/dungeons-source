#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Managers;

namespace Runtime.Game.Managers
{
    public class PlayerTargetManager : IPlayerTargetManager
    {
        private readonly IPlayerCharacterManager _playerCharacterManager;
        private readonly ITargetController _targetController;

        public PlayerTargetManager(
            IPlayerCharacterManager playerCharacterManager,
            ITargetController targetController)
        {
            _playerCharacterManager = playerCharacterManager;
            _targetController = targetController;
        }

        public Character? PlayerTarget => GetPlayerTarget();

        private Character? GetPlayerTarget()
        {
            if (_playerCharacterManager.PlayerCharacter is not { } playerCharacter) return null;
                
            return _targetController.GetTarget(playerCharacter);
        }
        
        public void ClearPlayerTarget() => SetPlayerTarget(null);
        public void SetPlayerTarget(Character? newTarget)
        {
            if (_playerCharacterManager.PlayerCharacter is not { } playerCharacter) return;
            
            SetPlayerTarget(playerCharacter, newTarget);
        }

        private void SetPlayerTarget(Character playerCharacter, Character? newTarget)
        {
            var oldTarget = PlayerTarget;
            
            _targetController.SetTarget(playerCharacter, newTarget);
            
            oldTarget?.OutlineService.SetSelected(false);
            newTarget?.OutlineService.SetSelected(true);
        }
    }
}