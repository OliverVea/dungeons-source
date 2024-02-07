#nullable enable

using Runtime.Abstractions;
using Runtime.Abstractions.Models;
using Zenject;

namespace Runtime.Game.Services
{
    public class BehaviorService : IBehaviorService, IInitializable
    {
        private readonly ICharacterData _characterData;
        private readonly Character _character;

        public BehaviorService(ICharacterData characterData,
            Character character)
        {
            _characterData = characterData;
            _character = character;
        }

        public void Initialize()
        {
            _character.BehaviorTree.ExternalBehavior = _characterData.BehaviorData.BehaviorTree;
        }
    }
}