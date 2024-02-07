#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Controller;
using Runtime.Abstractions.Models;
using Zenject;

namespace Runtime.Game.Services
{
    public class SpawningService : IInitializable
    {
        private readonly Character _character;
        private readonly ITransformController _transformController;
        private readonly ISpawnPosition _spawnPosition;
        
        public SpawningService(ISpawnPosition spawnPosition, ITransformController transformController, Character character)
        {
            _spawnPosition = spawnPosition;
            _transformController = transformController;
            _character = character;
        }
        
        public void Initialize()
        {
            _transformController.SetPosition(_character, _spawnPosition.Position);
            _transformController.SetRotation(_character, _spawnPosition.Rotation);
            _character.Transform.gameObject.name =  _character.Name;
        }
    }
}