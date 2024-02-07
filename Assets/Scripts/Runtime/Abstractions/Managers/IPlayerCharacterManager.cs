#nullable enable

namespace Runtime.Abstractions.Managers
{
    public interface IPlayerCharacterManager
    {
        Character? PlayerCharacter { get; }
        void SetPlayerCharacter(Character character);
        void ClearPlayerCharacter();
    }
}