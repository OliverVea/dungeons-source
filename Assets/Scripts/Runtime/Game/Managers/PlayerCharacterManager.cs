#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Managers;

namespace Runtime.Game.Managers
{
    public class PlayerCharacterManager : IPlayerCharacterManager
    {
        public Character? PlayerCharacter { get; private set; }
        
        public void SetPlayerCharacter(Character character)
        {
            PlayerCharacter = character;
        }

        public void ClearPlayerCharacter()
        {
            PlayerCharacter = null;
        }
    }
}