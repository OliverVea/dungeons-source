#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Helpers;
using Runtime.Abstractions.Managers;

namespace Runtime.Game.Controllers
{
    public class PlayerCharacterController : IPlayerCharacterController
    {
        private readonly IPlayerCharacterManager _playerCharacterManager;
        private readonly ICharacterComponentManagementHelper _characterComponentManagementHelper;
        
        public PlayerCharacterController(IPlayerCharacterManager playerCharacterManager,
            ICharacterComponentManagementHelper characterComponentManagementHelper)
        {
            _playerCharacterManager = playerCharacterManager;
            _characterComponentManagementHelper = characterComponentManagementHelper;
        }

        /// <summary>
        /// Should be used to switch to a new player character.
        /// </summary>
        /// <param name="character"></param>
        public void SetPlayerCharacter(Character character)
        {
            if (_playerCharacterManager.PlayerCharacter is { } oldPlayerCharacter )
                _characterComponentManagementHelper.SetPlayerComponentSettings(oldPlayerCharacter, false);
            
            _playerCharacterManager.SetPlayerCharacter(character);
            
            _characterComponentManagementHelper.SetPlayerComponentSettings(character, true);
        }
    }
}