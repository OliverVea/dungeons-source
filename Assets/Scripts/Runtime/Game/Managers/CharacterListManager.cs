#nullable enable

using System.Collections.Generic;
using Runtime.Abstractions;
using Runtime.Abstractions.Managers;

namespace Runtime.Game.Managers
{
    public class CharacterListManager : ICharacterListManager
    {
        private readonly HashSet<Character> _characterList = new();
        
        public void AddCharacter(Character character)
        {
            _characterList.Add(character);
        }

        public void RemoveCharacter(Character character)
        {
            _characterList.Remove(character);
        }

        public IEnumerable<Character> ListCharacters()
        {
            return _characterList;
        }

        public bool ContainsCharacter(Character target)
        {
            return _characterList.Contains(target);
        }
    }
}