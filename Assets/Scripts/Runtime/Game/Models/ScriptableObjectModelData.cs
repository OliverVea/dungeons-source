using Runtime.Abstractions.Models;
using UnityEngine;

namespace Runtime.Game.Models
{
    [CreateAssetMenu(menuName = "Character/ModelData")]
    public class ScriptableObjectModelData : ScriptableObject, IModelData
    {
        [SerializeField] private Mesh _characterModel;
        public Mesh CharacterModel => _characterModel;
    }
}