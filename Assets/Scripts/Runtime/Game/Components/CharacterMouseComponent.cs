#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Managers;
using Zenject;

namespace Runtime.Game.Components
{
    public class CharacterMouseComponent : MouseComponentBase
    {
        [Inject] private Character _character = null!;
        [Inject] private IOutlineService _outlineService = null!;
        [Inject] private IPlayerCharacterManager _playerCharacterManager = null!;
        [Inject] private ICharacterListManager _characterListManager = null!;
        [Inject] private IPlayerTargetManager _playerTargetManager = null!;
        [Inject] private IAutoAttackingController _autoAttackingController = null!;

        public override void Enter()
        {
            _outlineService.SetHover(true);
        }

        public override void Exit()
        {
            if (!_characterListManager.ContainsCharacter(_character)) return;
            _outlineService.SetHover(false);
        }

        public override void LeftClick()
        {
            if (_playerCharacterManager.PlayerCharacter is not { } playerCharacter) return;
            
            _playerTargetManager.SetPlayerTarget(_character);
            _autoAttackingController.SetAutoAttacking(playerCharacter, false);
        }

        public override void RightClick()
        {
            if (_playerCharacterManager.PlayerCharacter is not { } playerCharacter) return;
            
            _playerTargetManager.SetPlayerTarget(_character);
            _autoAttackingController.SetAutoAttacking(playerCharacter, true);
        }

        public override void MiddleClick()
        {
        }
    }
}