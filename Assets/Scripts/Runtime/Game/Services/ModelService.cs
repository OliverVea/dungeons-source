#nullable enable

using Runtime.Abstractions.Models;
using UnityEngine;
using Zenject;

namespace Runtime.Game.Services
{
    public class ModelService : IInitializable
    {
        private readonly SkinnedMeshRenderer _renderer;
        private readonly ICharacterData _characterData;
        
        public ModelService(ICharacterData characterData,
            SkinnedMeshRenderer renderer)
        {
            _renderer = renderer;
            _characterData = characterData;
        }
        
        public void Initialize()
        {
            _renderer.sharedMesh = _characterData.ModelData.CharacterModel;
        }
    }
}