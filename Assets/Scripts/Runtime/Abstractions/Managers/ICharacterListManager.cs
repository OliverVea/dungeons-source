#nullable enable

using System.Collections.Generic;

namespace Runtime.Abstractions.Managers
{
    public interface ICharacterListManager
    {
        public void AddCharacter(Character character);
        public void RemoveCharacter(Character character);
        public IEnumerable<Character> ListCharacters();
        bool ContainsCharacter(Character target);
    }
}