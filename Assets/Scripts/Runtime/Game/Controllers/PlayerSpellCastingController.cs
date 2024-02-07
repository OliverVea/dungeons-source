#nullable enable

using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Managers;
using Runtime.Abstractions.Spells;

namespace Runtime.Game.Controllers
{
    public class PlayerSpellCastingController : IPlayerSpellCastingController
    {
        private readonly ISpellCastingController _spellCastingController;
        private readonly IPlayerCharacterManager _playerCharacterManager;

        public PlayerSpellCastingController(ISpellCastingController spellCastingController, IPlayerCharacterManager playerCharacterManager)
        {
            _spellCastingController = spellCastingController;
            _playerCharacterManager = playerCharacterManager;
        }


        public void CastSpell(SpellId spellId)
        {
            if (_playerCharacterManager.PlayerCharacter is not { } playerCharacter) return;
            
            _spellCastingController.CastSpell(playerCharacter, spellId);
        }
    }
}