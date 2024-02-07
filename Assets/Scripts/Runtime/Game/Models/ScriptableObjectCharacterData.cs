#nullable enable

using Runtime.Abstractions.Models;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Game.Models
{
    [CreateAssetMenu(menuName = "Character/CharacterData")]
    public class ScriptableObjectCharacterData : ScriptableObject, ICharacterData
    {
        [Required][SerializeField] private string _name = null!;
        public string Name => _name;

        [Required][SerializeField] private Faction _faction;
        public Faction Faction => _faction;

        [Required][SerializeField] private SerializableBaseStats _baseStats = null!;
        public IBaseStats BaseStats => _baseStats;

        [Required][SerializeField] private SerializableSpellBook _spellBook = null!;
        public ISpellBook SpellBook => _spellBook;

        [Required][SerializeField] private ScriptableObjectModelData _modelData = null!;
        public IModelData ModelData => _modelData;

        [Required][SerializeField] private SerializableBehaviorData _behaviorData = null!;
        public IBehaviorData BehaviorData => _behaviorData;
    }
}