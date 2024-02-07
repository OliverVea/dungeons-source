#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Models;

namespace Runtime.Game.Controllers
{
    public class CharacterSpawningController : ICharacterSpawningController
    {
        private readonly Character.Factory _characterFactory;

        public CharacterSpawningController(Character.Factory characterFactory)
        {
            _characterFactory = characterFactory;
        }

        public Character SpawnCharacter(ISpawnPosition spawnPosition, ICharacterData characterData)
        {
            return _characterFactory.Create(spawnPosition, characterData);
        }
    }
}