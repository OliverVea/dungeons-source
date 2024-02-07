#nullable enable

using Runtime.Abstractions.Models;

namespace Runtime.Abstractions.Controller
{
    public interface ICharacterSpawningController
    {
        Character SpawnCharacter(ISpawnPosition spawnPosition, ICharacterData characterData);
    }
}