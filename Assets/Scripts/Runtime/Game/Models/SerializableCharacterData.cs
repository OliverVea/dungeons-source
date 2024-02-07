using System;
using Runtime.Abstractions.Models;
using UnityEngine;

namespace Runtime.Game.Models
{
    [Serializable]
    public class SerializableCharacterData : ICharacterData
    {
        public SerializableCharacterData(
            string name,
            Faction faction,
            SerializableBaseStats baseStats)
        {
            _name = name;
            _faction = faction;
            _baseStats = baseStats;
        }
        
        [SerializeField] private string _name;
        public string Name => _name;

        [SerializeField] private Faction _faction;
        public Faction Faction => _faction;

        [SerializeField] private SerializableBaseStats _baseStats;
        public IBaseStats BaseStats => _baseStats;

        [SerializeField] private SerializableSpellBook _spellBook;
        public ISpellBook SpellBook => _spellBook;

        [SerializeField] private ScriptableObjectModelData _modelData;
        public IModelData ModelData => _modelData;

        [SerializeField] private SerializableBehaviorData _behaviorData;
        public IBehaviorData BehaviorData => _behaviorData;
    }
}